-- 1. Crear o verificar la tabla Accesoria (datosAnimales)
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
GO

-- 2. Procedimiento para insertar la Cabecera del Stock
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
        fecha_alta, fecha_baja, cantidad, precio, id_proveedor, activo, vendible
    )
    VALUES (
        @id_stock, @id_elemento, @tipo_elemento, @Nombre, @ciclo, 
        @fecha_alta, @fecha_baja, @cantidad, @precio, @id_proveedor, @activo, @vendible
    );
END
GO

-- 3. Procedimiento para actualizar la Cabecera del Stock
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
END
GO

-- 4. Procedimiento para insertar el detalle de cada animal en la tabla accesoria
CREATE OR ALTER PROCEDURE sp_insert_detalle_animal
    @id_stock BIGINT,
    @nro_animal VARCHAR(50),
    @sexo VARCHAR(20),
    @es_productor BIT
AS
BEGIN
    INSERT INTO datosAnimales (id_stock, nro_animal, sexo, es_productor)
    VALUES (@id_stock, @nro_animal, @sexo, @es_productor);
END
GO

-- 5. Procedimiento para seleccionar el stock (Grilla principal)
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
END
GO