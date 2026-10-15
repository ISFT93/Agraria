USE Agraria
GO

-- ==========================================
-- 1. SP: Eliminar Artículo
-- ==========================================
IF OBJECT_ID('dbo.sp_delete_articulo', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_delete_articulo];
GO
CREATE PROCEDURE [dbo].[sp_delete_articulo]
    @id_articulo BIGINT
AS
BEGIN
    DELETE FROM articulos 
    WHERE id_articulo = @id_articulo;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. SP: Eliminar Vegetal
IF OBJECT_ID('dbo.sp_delete_vegetal', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_delete_vegetal];
GO
CREATE PROCEDURE [dbo].[sp_delete_vegetal]
    @id_vegetal BIGINT
AS
BEGIN
    DELETE FROM vegetal 
    WHERE id_vegetal = @id_vegetal;
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('dbo.sp_insert_articulo', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_insert_articulo];
GO
CREATE PROCEDURE [dbo].[sp_insert_articulo]
    @id_articulo BIGINT,
    @nombre VARCHAR(150),
    @id_marca INT,
    @stock_minimo FLOAT,
    @id_categoria INT
AS
BEGIN
    INSERT INTO articulos (id_articulo, nombre, id_marca, stock_minimo, id_categoria)
    VALUES (@id_articulo, @nombre, @id_marca, @stock_minimo, @id_categoria);
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==========================================
-- 2. STORED PROCEDURES: STOCK
-- ==========================================

-- 1. SP: Insertar Stock
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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==========================================
-- STORED PROCEDURES: VEGETAL
-- ==========================================

-- 1. SP: Insertar Vegetal
IF OBJECT_ID('dbo.sp_insert_vegetal', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_insert_vegetal];
GO
CREATE PROCEDURE [dbo].[sp_insert_vegetal]
    @id_vegetal BIGINT,
    @nombre_comun VARCHAR(100),
    @nombre_cientifico VARCHAR(150),
    @variedad_hibrido VARCHAR(100),
    @id_tipo_cultivo INT,
    @id_ciclo_vida INT,
    @periodosiembra VARCHAR(100),
    @id_metodo_siembra INT,
    @id_estado_fenologico INT,
    @requerimiento_hidrico VARCHAR(20)
AS
BEGIN
    INSERT INTO vegetal (
        id_vegetal, 
        nombre_comun, 
        nombre_cientifico, 
        variedad_hibrido, 
        id_tipo_cultivo, 
        id_ciclo_vida, 
        periodosiembra, 
        id_metodo_siembra, 
        id_estado_fenologico, 
        requerimiento_hidrico
    )
    VALUES (
        @id_vegetal, 
        @nombre_comun, 
        @nombre_cientifico, 
        @variedad_hibrido, 
        @id_tipo_cultivo, 
        @id_ciclo_vida, 
        @periodosiembra, 
        @id_metodo_siembra, 
        @id_estado_fenologico, 
        @requerimiento_hidrico
    );
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('dbo.sp_insertanimal', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_insertanimal];
GO
CREATE PROCEDURE [dbo].[sp_insertanimal]
    @id_animal bigint,
    @nombre_comun varchar(100),
    @nombre_cientifico varchar(150) = null,
    @id_tipo int,
    @id_rubro int,
    @id_subrubro int,
    @stock_minimo float
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO animal (
        id_animal,
        nombre_comun,
        nombre_cientifico,
        id_tipo,
        id_rubro,
        id_subrubro,
        stock_minimo
    )
    VALUES (
        @id_animal,
        @nombre_comun,
        @nombre_cientifico,
        @id_tipo,
        @id_rubro,
        @id_subrubro,
        @stock_minimo
    );
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 5. SP: Obtener último ID elemento
IF OBJECT_ID('dbo.sp_obtener_ultimo_id_elemento', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_obtener_ultimo_id_elemento];
GO
CREATE PROCEDURE [dbo].[sp_obtener_ultimo_id_elemento]
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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 4. Stored Procedure: Seleccionar Artículos (con marca y categoría)
IF OBJECT_ID('dbo.sp_select_articulos', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_select_articulos];
GO
CREATE PROCEDURE [dbo].[sp_select_articulos]
AS
BEGIN
    SELECT 
        a.id_articulo,
        a.nombre AS nombre_articulo,
        m.nombre AS marca,
        c.nombre AS categoria
    FROM articulos a
    LEFT JOIN marca m ON a.id_marca = m.id_marca
    LEFT JOIN categoria c ON a.id_categoria = c.id_categoria;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 5. SP: Obtener Combo Dinámico
IF OBJECT_ID('dbo.sp_select_combo', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_select_combo];
GO
CREATE PROCEDURE [dbo].[sp_select_combo]
    @tabla NVARCHAR(100)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'SELECT * FROM ' + QUOTENAME(@tabla);
    EXEC sp_executesql @sql;
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 6. SP: Seleccionar Proveedores
IF OBJECT_ID('dbo.sp_select_proveedores', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_select_proveedores];
GO
CREATE PROCEDURE [dbo].[sp_select_proveedores]
AS
BEGIN
    SELECT id_proveedor, nombre FROM proveedores ORDER BY nombre ASC;
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 6. SP: Obtener Requerimiento Hídrico Fijo
IF OBJECT_ID('dbo.sp_select_requerimiento_hidrico', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_select_requerimiento_hidrico];
GO
CREATE PROCEDURE [dbo].[sp_select_requerimiento_hidrico]
AS
BEGIN
    SELECT 'Alto' AS nombre UNION SELECT 'Medio' UNION SELECT 'Bajo';
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
    LEFT JOIN proveedores p 
        ON s.id_proveedor = p.id_proveedor
    WHERE (@tipo_elemento = '' OR s.tipo_elemento = @tipo_elemento)
      AND (@nro_animal = '' OR s.nro_animal LIKE '%' + @nro_animal + '%');
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 4. SP: Seleccionar Stock por ID
IF OBJECT_ID('dbo.sp_select_stock_por_id', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_select_stock_por_id];
GO
CREATE PROCEDURE [dbo].[sp_select_stock_por_id]
    @id BIGINT
AS
BEGIN
    SELECT * FROM stock WHERE id_stock = @id;
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('dbo.sp_select_ultimo_id_animal', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_select_ultimo_id_animal];
GO
CREATE PROCEDURE [dbo].[sp_select_ultimo_id_animal]
    @min bigint,
    @max bigint
AS
BEGIN
    SET NOCOUNT ON;

    SELECT isnull(max(id_animal), 0)
    FROM animal
    WHERE id_animal >= @min AND id_animal <= @max;
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 7. SP: Obtener Último ID por Usuario
IF OBJECT_ID('dbo.sp_select_ultimo_id_vegetal', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_select_ultimo_id_vegetal];
GO
CREATE PROCEDURE [dbo].[sp_select_ultimo_id_vegetal]
    @min BIGINT,
    @max BIGINT
AS
BEGIN
    SELECT ISNULL(MAX(id_vegetal), 0) FROM vegetal WHERE id_vegetal >= @min AND id_vegetal < @max;
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. SP: Seleccionar Vegetal (Grilla)
IF OBJECT_ID('dbo.sp_select_vegetal', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_select_vegetal];
GO
CREATE PROCEDURE [dbo].[sp_select_vegetal]
    @filtro VARCHAR(100) = ''
AS
BEGIN
    SELECT 
        v.id_vegetal,
        v.nombre_comun,
        v.nombre_cientifico,
        v.variedad_hibrido,
        v.periodosiembra,
        v.requerimiento_hidrico,
        tc.nombre AS tipo_cultivo,
        cv.nombre AS ciclo_vida,
        ms.nombre AS metodo_siembra,
        ef.nombre AS estado_fenologico
    FROM vegetal v
    LEFT JOIN tipo_cultivo tc ON v.id_tipo_cultivo = tc.id_tipo_cultivo
    LEFT JOIN ciclo_vida cv ON v.id_ciclo_vida = cv.id_ciclo_vida
    LEFT JOIN metodo_siembra ms ON v.id_metodo_siembra = ms.id_metodo_siembra
    LEFT JOIN estado_fenologico ef ON v.id_estado_fenologico = ef.id_estado_fenologico
    WHERE (@filtro = '' OR v.nombre_comun LIKE '%' + @filtro + '%' OR v.variedad_hibrido LIKE '%' + @filtro + '%');
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 4. SP: Obtener Vegetal Por ID
IF OBJECT_ID('dbo.sp_select_vegetal_por_id', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_select_vegetal_por_id];
GO
CREATE PROCEDURE [dbo].[sp_select_vegetal_por_id]
    @id BIGINT
AS
BEGIN
    SELECT * FROM vegetal WHERE id_vegetal = @id;
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('dbo.sp_selectanimal', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_selectanimal];
GO
CREATE PROCEDURE [dbo].[sp_selectanimal]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        a.id_animal as idanimal,
        a.nombre_comun as nombrecomun,
        a.nombre_cientifico as nombrecientifico,
        a.id_tipo as idtipo,
        a.id_rubro as idrubro,
        a.id_subrubro as idsubrubro,
        t.nombre as tipo_animal,
        r.nombre as rubro,
        sr.nombre as subrubro,
        a.stock_minimo as stockminimo
    FROM animal a
    LEFT JOIN tipo_animal t ON a.id_tipo = t.id_tipo_animal
    LEFT JOIN rubro r ON a.id_rubro = r.id_rubro
    LEFT JOIN subrubro sr ON a.id_subrubro = sr.id_subrubro;
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('dbo.sp_update_articulo', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_update_articulo];
GO
CREATE PROCEDURE [dbo].[sp_update_articulo]
    @id_articulo BIGINT,
    @nombre VARCHAR(150),
    @id_marca INT,
    @stock_minimo FLOAT,
    @id_categoria INT
AS
BEGIN
    UPDATE articulos
    SET nombre = @nombre,
        id_marca = @id_marca,
        stock_minimo = @stock_minimo,
        id_categoria = @id_categoria
    WHERE id_articulo = @id_articulo;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 2. SP: Actualizar Stock
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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 2. SP: Actualizar Vegetal
IF OBJECT_ID('dbo.sp_update_vegetal', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_update_vegetal];
GO
CREATE PROCEDURE [dbo].[sp_update_vegetal]
    @id_vegetal BIGINT,
    @nombre_comun VARCHAR(100),
    @nombre_cientifico VARCHAR(150),
    @variedad_hibrido VARCHAR(100),
    @id_tipo_cultivo INT,
    @id_ciclo_vida INT,
    @periodosiembra VARCHAR(100),
    @id_metodo_siembra INT,
    @id_estado_fenologico INT,
    @requerimiento_hidrico VARCHAR(20)
AS
BEGIN
    UPDATE vegetal 
    SET nombre_comun = @nombre_comun,
        nombre_cientifico = @nombre_cientifico,
        variedad_hibrido = @variedad_hibrido,
        id_tipo_cultivo = @id_tipo_cultivo,
        id_ciclo_vida = @id_ciclo_vida,
        periodosiembra = @periodosiembra,
        id_metodo_siembra = @id_metodo_siembra,
        id_estado_fenologico = @id_estado_fenologico,
        requerimiento_hidrico = @requerimiento_hidrico
    WHERE id_vegetal = @id_vegetal;
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('dbo.sp_updateanimal', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_updateanimal];
GO
CREATE PROCEDURE [dbo].[sp_updateanimal]
    @id_animal bigint,
    @nombre_comun varchar(100),
    @nombre_cientifico varchar(150) = null,
    @id_tipo int,
    @id_rubro int,
    @id_subrubro int,
    @stock_minimo float
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE animal
    SET nombre_comun = @nombre_comun,
        nombre_cientifico = @nombre_cientifico,
        id_tipo = @id_tipo,
        id_rubro = @id_rubro,
        id_subrubro = @id_subrubro,
        stock_minimo = @stock_minimo
    WHERE id_animal = @id_animal;
END;
GO