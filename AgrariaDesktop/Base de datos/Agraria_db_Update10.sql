-- ==========================================
-- 1. TABLA STOCK: CREACIÓN O ALTERACIÓN SEGURA
-- ==========================================

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[stock]') AND type in (N'U'))
BEGIN
    CREATE TABLE stock (
        id_stock BIGINT IDENTITY(1,1) PRIMARY KEY,
        id_elemento BIGINT NOT NULL,
        tipo_elemento VARCHAR(50) NOT NULL,
        Nombre VARCHAR(50) NOT NULL,
        ciclo VARCHAR(50) NULL,     
        fecha_alta DATE NOT NULL,
        fecha_baja DATE NULL,
        cantidad DECIMAL(10,2) DEFAULT 0.00,
        nro_animal VARCHAR(50) NULL,
        estado_salud VARCHAR(50) NULL,
        es_productor BIT DEFAULT 0,
        precio MONEY NULL, 
        id_proveedor BIGINT NULL,
        activo BIT DEFAULT 1, 
        vendible BIT DEFAULT 0,
        motivo_movimiento VARCHAR(100) NULL,
        CONSTRAINT fk_stock_proveedor FOREIGN KEY (id_proveedor) REFERENCES proveedoress(id_proveedores)
    );
END
ELSE
BEGIN
    -- Si la tabla ya existe y no tiene la columna 'Nombre', se la agrega
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[stock]') AND name = 'Nombre')
    BEGIN
        ALTER TABLE stock ADD Nombre VARCHAR(50) NOT NULL DEFAULT 'Sin Nombre';
    END
END;
GO

-- ==========================================
-- 2. STORED PROCEDURES: STOCK
-- ==========================================

-- 1. SP: Insertar Stock
CREATE OR ALTER PROCEDURE sp_insert_stock
    @id_elemento BIGINT,
    @tipo_elemento VARCHAR(50),
    @Nombre VARCHAR(50),
    @ciclo VARCHAR(50),
    @fecha_alta DATE,
    @fecha_baja DATE,
    @cantidad DECIMAL(10,2),
    @nro_animal VARCHAR(50),
    @estado_salud VARCHAR(50),
    @es_productor BIT,
    @precio MONEY,
    @id_proveedor BIGINT,
    @activo BIT,
    @vendible BIT,
    @motivo_movimiento VARCHAR(100)
AS
BEGIN
    INSERT INTO stock (
        id_elemento, tipo_elemento, Nombre, ciclo, fecha_alta, fecha_baja, 
        cantidad, nro_animal, estado_salud, es_productor, precio, 
        id_proveedor, activo, vendible, motivo_movimiento
    )
    VALUES (
        @id_elemento, @tipo_elemento, @Nombre, @ciclo, @fecha_alta, @fecha_baja, 
        @cantidad, @nro_animal, @estado_salud, @es_productor, @precio, 
        @id_proveedor, @activo, @vendible, @motivo_movimiento
    );
END;
GO

-- 2. SP: Actualizar Stock
CREATE OR ALTER PROCEDURE sp_update_stock
    @id_stock BIGINT,
    @id_elemento BIGINT,
    @tipo_elemento VARCHAR(50),
    @Nombre VARCHAR(50),
    @ciclo VARCHAR(50),
    @fecha_alta DATE,
    @fecha_baja DATE,
    @cantidad DECIMAL(10,2),
    @nro_animal VARCHAR(50),
    @estado_salud VARCHAR(50),
    @es_productor BIT,
    @precio MONEY,
    @id_proveedor BIGINT,
    @activo BIT,
    @vendible BIT,
    @motivo_movimiento VARCHAR(100)
AS
BEGIN
    UPDATE stock 
    SET id_elemento = @id_elemento,
        tipo_elemento = @tipo_elemento,
        Nombre = @Nombre,
        ciclo = @ciclo,
        fecha_alta = @fecha_alta,
        fecha_baja = @fecha_baja,
        cantidad = @cantidad,
        nro_animal = @nro_animal,
        estado_salud = @estado_salud,
        es_productor = @es_productor,
        precio = @precio,
        id_proveedor = @id_proveedor,
        activo = @activo,
        vendible = @vendible,
        motivo_movimiento = @motivo_movimiento
    WHERE id_stock = @id_stock;
END;
GO

-- 3. SP: Seleccionar Stock
CREATE OR ALTER PROCEDURE sp_select_stock
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
        s.nro_animal,
        s.estado_salud,
        s.es_productor,
        s.precio,
        p.Nombre AS NombreProveedor,
        s.id_proveedor,
        s.activo,
        s.vendible,
        s.motivo_movimiento
    FROM stock s
    LEFT JOIN proveedoress p 
        ON s.id_proveedor = p.id_proveedores
    WHERE (@tipo_elemento = '' OR s.tipo_elemento = @tipo_elemento)
      AND (@nro_animal = '' OR s.nro_animal LIKE '%' + @nro_animal + '%');
END;
GO

-- 4. SP: Seleccionar Stock por ID
CREATE OR ALTER PROCEDURE sp_select_stock_por_id
    @id BIGINT
AS
BEGIN
    SELECT * FROM stock WHERE id_stock = @id;
END;
GO

-- 5. SP: Obtener último ID elemento
CREATE OR ALTER PROCEDURE sp_obtener_ultimo_id_elemento
    @tipo_elemento VARCHAR(50),
    @min BIGINT,
    @max BIGINT
AS
BEGIN
    DECLARE @ultimoId_Cat BIGINT = 0;
    DECLARE @ultimoId_Stock BIGINT = 0;

    -- Buscamos el último ID en la tabla específica (Catálogo)
    IF @tipo_elemento = 'Vegetal'
        SELECT @ultimoId_Cat = ISNULL(MAX(id_vegetal), 0) FROM vegetal WHERE id_vegetal >= @min AND id_vegetal < @max;
    ELSE IF @tipo_elemento = 'Animal'
        SELECT @ultimoId_Cat = ISNULL(MAX(id_animal), 0) FROM animal WHERE id_animal >= @min AND id_animal < @max;
    ELSE IF @tipo_elemento = 'Articulo'
        SELECT @ultimoId_Cat = ISNULL(MAX(id_articulo), 0) FROM articulos WHERE id_articulo >= @min AND id_articulo < @max;

    -- Buscamos el último ID guardado en la tabla de Stock
    SELECT @ultimoId_Stock = ISNULL(MAX(id_elemento), 0) 
    FROM stock 
    WHERE tipo_elemento = @tipo_elemento 
      AND id_elemento >= @min 
      AND id_elemento < @max;

    -- Comparamos ambos y devolvemos el mayor
    IF @ultimoId_Stock > @ultimoId_Cat
        SELECT @ultimoId_Stock;
    ELSE
        SELECT @ultimoId_Cat;
END;
GO

-- 6. SP: Seleccionar Proveedores
CREATE OR ALTER PROCEDURE sp_select_proveedores
AS
BEGIN
    SELECT id_proveedores, nombre FROM proveedoress ORDER BY nombre ASC;
END;
GO
---------------------------cargamos unos proveedores para probar el circuito.

-- Se inserta el proveedor 1 solo si no existe
IF NOT EXISTS (SELECT 1 FROM [dbo].[proveedoress] WHERE id_proveedores = 1)
BEGIN
    INSERT INTO [dbo].[proveedoress] ([id_proveedores], [nombre], [cuil], [telefono], [direccion], [mail])
    VALUES (1, 'Agroinsumos Pampeanos S.A.', '30-12345678-9', '011-5555-1010', 'Ruta 5 Km 100, Mercedes, BA', 'ventas@agropampeanos.com.ar');
END;

-- Se inserta el proveedor 2 solo si no existe
IF NOT EXISTS (SELECT 1 FROM [dbo].[proveedoress] WHERE id_proveedores = 2)
BEGIN
    INSERT INTO [dbo].[proveedoress] ([id_proveedores], [nombre], [cuil], [telefono], [direccion], [mail])
    VALUES (2, 'Semillas y Forrajes Del Sur SRL', '30-87654321-1', '0223-456-7890', 'Av. Circunvalación 1200, Tandil, BA', 'contacto@semillasdelsur.com.ar');
END;

-- Se inserta el proveedor 3 solo si no existe
IF NOT EXISTS (SELECT 1 FROM [dbo].[proveedoress] WHERE id_proveedores = 3)
BEGIN
    INSERT INTO [dbo].[proveedoress] ([id_proveedores], [nombre], [cuil], [telefono], [direccion], [mail])
    VALUES (3, 'Veterinaria El Estribo', '27-11223344-5', '0221-333-4444', 'Calle 44 Nro 1500, La Plata, BA', 'info@vet-elestribo.com.ar');
END;
GO