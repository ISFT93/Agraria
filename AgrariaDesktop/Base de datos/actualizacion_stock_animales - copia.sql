USE Agraria
GO

-- ==========================================
-- 1. CREACIÓN DE LA TABLA ACCESORIA datosAnimales
-- ==========================================
IF OBJECT_ID('dbo.datosAnimales', 'U') IS NOT NULL 
    DROP TABLE dbo.datosAnimales;
GO

CREATE TABLE [dbo].[datosAnimales](
    [id_datos_animal] [bigint] IDENTITY(1,1) NOT NULL,
    [id_stock] [bigint] NOT NULL,
    [nro_animal] [varchar](50) NULL,
    [estado_salud] [varchar](50) NULL,
    [es_productor] [bit] NULL,
    CONSTRAINT [PK_datosAnimales] PRIMARY KEY CLUSTERED ([id_datos_animal] ASC),
    CONSTRAINT [FK_datosAnimales_stock] FOREIGN KEY ([id_stock]) 
        REFERENCES [dbo].[stock] ([id_stock]) 
        ON DELETE CASCADE
);
GO

-- ==========================================
-- 2. SP: INSERTAR STOCK (Adaptado)
-- ==========================================
IF OBJECT_ID('dbo.sp_insert_stock', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_insert_stock];
GO
CREATE PROCEDURE [dbo].[sp_insert_stock]
    @id_elemento BIGINT,
    @tipo_elemento VARCHAR(50),
    @Nombre VARCHAR(50),
    @ciclo VARCHAR(50),
    @fecha_alta DATE,
    @fecha_baja DATE,
    @cantidad DECIMAL(10,2),
    @nro_animal VARCHAR(50) = NULL,
    @estado_salud VARCHAR(50) = NULL,
    @es_productor BIT = NULL,
    @precio MONEY,
    @id_proveedor BIGINT,
    @activo BIT,
    @vendible BIT,
    @motivo_movimiento VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Insertamos en la tabla principal stock (sin los campos de animales)
    INSERT INTO stock (
        id_elemento, tipo_elemento, Nombre, ciclo, fecha_alta, fecha_baja, 
        cantidad, precio, id_proveedor, activo, vendible, motivo_movimiento
    )
    VALUES (
        @id_elemento, @tipo_elemento, @Nombre, @ciclo, @fecha_alta, @fecha_baja, 
        @cantidad, @precio, @id_proveedor, @activo, @vendible, @motivo_movimiento
    );

    -- Obtenemos el id_stock generado
    DECLARE @id_stock_generado BIGINT = SCOPE_IDENTITY();

    -- 2. Si es un animal o tiene datos asociados, los guardamos en datosAnimales
    IF @tipo_elemento = 'Animal' OR @nro_animal IS NOT NULL OR @estado_salud IS NOT NULL
    BEGIN
        INSERT INTO datosAnimales (id_stock, nro_animal, estado_salud, es_productor)
        VALUES (@id_stock_generado, @nro_animal, @estado_salud, @es_productor);
    END
END;
GO

-- ==========================================
-- 3. SP: SELECCIONAR STOCK (Con JOIN)
-- ==========================================
IF OBJECT_ID('dbo.sp_select_stock', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_select_stock];
GO
CREATE PROCEDURE [dbo].[sp_select_stock]
    @tipo_elemento VARCHAR(50) = '',
    @nro_animal VARCHAR(50) = ''
AS
BEGIN
    SELECT 
        s.id_stock,
        s.id_elemento,
        s.tipo_elemento,
        s.Nombre,
        s.ciclo,
        s.fecha_alta,
        s.fecha_baja,
        s.cantidad,
        da.nro_animal,
        da.estado_salud,
        da.es_productor,
        s.precio,
        p.Nombre AS NombreProveedor,
        s.id_proveedor,
        s.activo,
        s.vendible,
        s.motivo_movimiento
    FROM stock s
    LEFT JOIN proveedores p ON s.id_proveedor = p.id_proveedor
    LEFT JOIN datosAnimales da ON s.id_stock = da.id_stock
    WHERE (@tipo_elemento = '' OR s.tipo_elemento = @tipo_elemento)
      AND (@nro_animal = '' OR da.nro_animal LIKE '%' + @nro_animal + '%');
END;
GO

-- ==========================================
-- 4. SP: ACTUALIZAR STOCK (Adaptado)
-- ==========================================
IF OBJECT_ID('dbo.sp_update_stock', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_update_stock];
GO
CREATE PROCEDURE [dbo].[sp_update_stock]
    @id_stock BIGINT,
    @id_elemento BIGINT,
    @tipo_elemento VARCHAR(50),
    @Nombre VARCHAR(50),
    @ciclo VARCHAR(50),
    @fecha_alta DATE,
    @fecha_baja DATE,
    @cantidad DECIMAL(10,2),
    @nro_animal VARCHAR(50) = NULL,
    @estado_salud VARCHAR(50) = NULL,
    @es_productor BIT = NULL,
    @precio MONEY,
    @id_proveedor BIGINT,
    @activo BIT,
    @vendible BIT,
    @motivo_movimiento VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Actualizamos la tabla principal stock
    UPDATE stock 
    SET id_elemento = @id_elemento,
        tipo_elemento = @tipo_elemento,
        Nombre = @Nombre,
        ciclo = @ciclo,
        fecha_alta = @fecha_alta,
        fecha_baja = @fecha_baja,
        cantidad = @cantidad,
        precio = @precio,
        id_proveedor = @id_proveedor,
        activo = @activo,
        vendible = @vendible,
        motivo_movimiento = @motivo_movimiento
    WHERE id_stock = @id_stock;

    -- 2. Gestionamos los datos en la tabla accesoria datosAnimales
    IF EXISTS (SELECT 1 FROM datosAnimales WHERE id_stock = @id_stock)
    BEGIN
        UPDATE datosAnimales
        SET nro_animal = @nro_animal,
            estado_salud = @estado_salud,
            es_productor = @es_productor
        WHERE id_stock = @id_stock;
    END
    ELSE IF @tipo_elemento = 'Animal' OR @nro_animal IS NOT NULL OR @estado_salud IS NOT NULL
    BEGIN
        INSERT INTO datosAnimales (id_stock, nro_animal, estado_salud, es_productor)
        VALUES (@id_stock, @nro_animal, @estado_salud, @es_productor);
    END
END;
GO
