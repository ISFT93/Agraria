USE [Agraria];
GO

-- ==========================================
-- 1. MIGRACIÓN Y RECREACIÓN DE LA TABLA STOCK
-- ==========================================

-- Paso 0: Limpiar la tabla temporal si quedó creada de un intento anterior
IF OBJECT_ID(N'[dbo].[stock_temp]', N'U') IS NOT NULL
    DROP TABLE [dbo].[stock_temp];
GO

-- Paso 1: Crear la tabla temporal sin IDENTITY y con sus valores por defecto
CREATE TABLE [dbo].[stock_temp](
	[id_stock] [bigint] NOT NULL,
	[id_elemento] [bigint] NOT NULL,
	[tipo_elemento] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[ciclo] [varchar](50) NULL,
	[fecha_alta] [date] NOT NULL,
	[fecha_baja] [date] NULL,
	[cantidad] [decimal](10, 2) NULL DEFAULT ((0.00)),
	[nro_animal] [varchar](50) NULL,
	[estado_salud] [varchar](50) NULL,
	[es_productor] [bit] NULL DEFAULT ((0)),
	[precio] [money] NULL,
	[id_proveedor] [bigint] NULL,
	[activo] [bit] NULL DEFAULT ((1)),
	[vendible] [bit] NULL DEFAULT ((0)),
	[motivo_movimiento] [varchar](100) NULL,
    PRIMARY KEY CLUSTERED ([id_stock] ASC)
);
GO

-- Paso 2: Copiar los datos de la tabla original a la temporal
IF OBJECT_ID(N'[dbo].[stock]', N'U') IS NOT NULL
BEGIN
    INSERT INTO [dbo].[stock_temp] (
        [id_stock], [id_elemento], [tipo_elemento], [Nombre], [ciclo], 
        [fecha_alta], [fecha_baja], [cantidad], [nro_animal], [estado_salud], 
        [es_productor], [precio], [id_proveedor], [activo], [vendible], [motivo_movimiento]
    )
    SELECT 
        [id_stock], [id_elemento], [tipo_elemento], [Nombre], [ciclo], 
        [fecha_alta], [fecha_baja], [cantidad], [nro_animal], [estado_salud], 
        [es_productor], [precio], [id_proveedor], [activo], [vendible], [motivo_movimiento]
    FROM [dbo].[stock];

    -- Paso 3: Eliminar las Claves Foráneas que apuntan a 'stock'
    DECLARE @sql NVARCHAR(MAX) = N'';
    SELECT @sql += N'ALTER TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id)) 
        + '.' + QUOTENAME(OBJECT_NAME(parent_object_id)) + 
        ' DROP CONSTRAINT ' + QUOTENAME(name) + ';' + CHAR(13)
    FROM sys.foreign_keys
    WHERE referenced_object_id = OBJECT_ID('[dbo].[stock]');
    EXEC sp_executesql @sql;

    -- Paso 4: Borrar la tabla original de stock
    DROP TABLE [dbo].[stock];
END
GO

-- Paso 5: Renombrar la tabla temporal al nombre definitivo
IF OBJECT_ID(N'[dbo].[stock_temp]', N'U') IS NOT NULL
BEGIN
    EXEC sp_rename 'dbo.stock_temp', 'stock';
END
GO


-- ==========================================
-- 2. TABLA ACCESORIA: DATOS ANIMALES
-- ==========================================

-- Crear tabla si no existe, o alterar si falta la columna 'sexo'
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='datosAnimales' and xtype='U')
BEGIN
    CREATE TABLE datosAnimales (
        id_detalle INT IDENTITY(1,1) PRIMARY KEY,
        id_stock BIGINT NOT NULL,
        nro_animal VARCHAR(50) NULL,
        sexo VARCHAR(20) NULL,
        es_productor BIT NOT NULL,
        CONSTRAINT FK_stock_datosAnimales FOREIGN KEY (id_stock) REFERENCES stock(id_stock) ON DELETE CASCADE
    );
END
ELSE
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('datosAnimales') AND name = 'sexo')
    BEGIN
        ALTER TABLE datosAnimales ADD sexo VARCHAR(20) NULL;
    END
END
GO


-- ==========================================
-- 3. STORED PROCEDURES: CABECERA DEL STOCK
-- ==========================================

CREATE OR ALTER PROCEDURE sp_insert_stock
    @id_stock BIGINT,
    @id_elemento BIGINT,
    @tipo_elemento VARCHAR(50),
    @Nombre VARCHAR(50),
    @ciclo VARCHAR(50),
    @fecha_alta DATETIME,
    @fecha_baja DATETIME = NULL,
    @cantidad DECIMAL(18,2),
    @precio DECIMAL(18,2) = NULL,
    @id_proveedor BIGINT = NULL,
    @activo BIT,
    @vendible BIT,
    @motivo_movimiento VARCHAR(255) = NULL
AS
BEGIN
    INSERT INTO stock (
        id_stock, id_elemento, tipo_elemento, Nombre, ciclo, 
        fecha_alta, fecha_baja, cantidad, precio, id_proveedor, activo, vendible, motivo_movimiento
    )
    VALUES (
        @id_stock, @id_elemento, @tipo_elemento, @Nombre, @ciclo, 
        @fecha_alta, @fecha_baja, @cantidad, @precio, @id_proveedor, @activo, @vendible, @motivo_movimiento
    );
END;
GO

CREATE OR ALTER PROCEDURE sp_update_stock
    @id_stock BIGINT,
    @id_elemento BIGINT,
    @tipo_elemento VARCHAR(50),
    @Nombre VARCHAR(50),
    @ciclo VARCHAR(50),
    @fecha_alta DATETIME,
    @fecha_baja DATETIME = NULL,
    @cantidad DECIMAL(18,2),
    @precio DECIMAL(18,2) = NULL,
    @id_proveedor BIGINT = NULL,
    @activo BIT,
    @vendible BIT
AS
BEGIN
    UPDATE stock SET
        id_elemento = @id_elemento,
        tipo_elemento = @tipo_elemento,
        Nombre = @Nombre,
        ciclo = @ciclo,
        fecha_alta = @fecha_alta,
        fecha_baja = @fecha_baja,
        cantidad = @cantidad,
        precio = @precio,
        id_proveedor = @id_proveedor,
        activo = @activo,
        vendible = @vendible
    WHERE id_stock = @id_stock;
END;
GO

CREATE OR ALTER PROCEDURE sp_select_stock
    @tipo_elemento VARCHAR(50) = NULL,
    @Nombre VARCHAR(50) = NULL
AS
BEGIN
    SELECT 
        s.id_stock, s.id_elemento, s.tipo_elemento, s.Nombre, s.ciclo,
        s.fecha_alta, s.fecha_baja, s.cantidad, s.precio, s.id_proveedor,
        p.nombre AS proveedor_nombre, s.activo, s.vendible
    FROM stock s
    LEFT JOIN proveedores p ON s.id_proveedor = p.id_proveedor
    WHERE (@tipo_elemento IS NULL OR @tipo_elemento = '' OR s.tipo_elemento = @tipo_elemento)
      AND (@Nombre IS NULL OR @Nombre = '' OR s.Nombre LIKE '%' + @Nombre + '%');
END;
GO


-- ==========================================
-- 4. STORED PROCEDURES: DETALLES ANIMALES
-- ==========================================

CREATE OR ALTER PROCEDURE sp_insert_detalle_animal
    @id_stock BIGINT,
    @nro_animal VARCHAR(50),
    @sexo VARCHAR(20),
    @es_productor BIT
AS
BEGIN
    INSERT INTO datosAnimales (id_stock, nro_animal, sexo, es_productor)
    VALUES (@id_stock, @nro_animal, @sexo, @es_productor);
END;
GO

CREATE OR ALTER PROCEDURE sp_update_detalle_animal
    @id_stock BIGINT,
    @nro_animal VARCHAR(50),
    @sexo VARCHAR(20),
    @es_productor BIT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM datosAnimales WHERE id_stock = @id_stock AND nro_animal = @nro_animal)
    BEGIN
        UPDATE datosAnimales
        SET sexo = @sexo,
            es_productor = @es_productor
        WHERE id_stock = @id_stock AND nro_animal = @nro_animal;
    END
    ELSE
    BEGIN
        INSERT INTO datosAnimales (id_stock, nro_animal, sexo, es_productor)
        VALUES (@id_stock, @nro_animal, @sexo, @es_productor);
    END
END;
GO

CREATE OR ALTER PROCEDURE sp_obtener_detalle_animales_por_stock
    @id_stock BIGINT
AS
BEGIN
    SELECT 
        id_detalle, 
        id_stock, 
        nro_animal, 
        sexo, 
        es_productor
    FROM datosAnimales
    WHERE id_stock = @id_stock;
END;
GO