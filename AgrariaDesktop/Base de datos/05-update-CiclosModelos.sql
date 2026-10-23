
use Agraria
go
-- ========================================================
-- 1. CICLOS MODELO (Plantillas Base)
-- ========================================================
CREATE TABLE dbo.ciclos_modelo (
    id_ciclo bigint IDENTITY(1,1) NOT NULL CONSTRAINT PK_ciclos_productivos PRIMARY KEY,
    nombre varchar(150) NOT NULL, 
    descripcion varchar(2000) NULL,
    duracion_estimada decimal(12,2) NULL, 
    modo_inicio int,                      -- Combobox (ID Catálogo Maestro: 14)
    activo bit NOT NULL DEFAULT 1,                 
    fecha_creacion datetime NOT NULL DEFAULT GETDATE(),
    creado_por int NOT NULL,
    
    -- Relación con el ítem seleccionado del catálogo
    CONSTRAINT FK_ciclos_modo_inicio FOREIGN KEY (modo_inicio) REFERENCES dbo.Catalogo_tipo_items(Id_catalogo_item)
);     
GO

-- ========================================================
-- 2. ACTIVIDADES DEL MODELO (Paso a paso)
-- ========================================================
CREATE TABLE dbo.actividades_ciclo_modelo (
    id_actividad_modelo bigint IDENTITY(1,1) NOT NULL CONSTRAINT PK_actividades_modelo PRIMARY KEY,
    id_ciclo bigint NOT NULL,
    nombre varchar(150) NOT NULL,
    descripcion varchar(2000) NULL,
    orden int NOT NULL,     
    tipo_actividad int,                   -- Combobox (ID Catálogo Maestro: 15)
    duracion_estimada decimal(12,2) NULL, 
    demora bit,   
    requiere_aprobacion bit NOT NULL DEFAULT 0,  
    permite_ejecucion_parcial bit NOT NULL DEFAULT 0, 
    condicion_avance nvarchar(1000) NULL,   
    activa bit NOT NULL DEFAULT 1,
    
    CONSTRAINT FK_actividades_ciclo FOREIGN KEY (id_ciclo) REFERENCES dbo.ciclos_modelo(id_ciclo),
    -- Relación con el ítem seleccionado del catálogo
    CONSTRAINT FK_actividades_tipo FOREIGN KEY (tipo_actividad) REFERENCES dbo.Catalogo_tipo_items(Id_catalogo_item)
);
GO

-- ========================================================
-- 3. ELEMENTOS DE LA ACTIVIDAD (Insumos y Productos)
-- ========================================================
CREATE TABLE dbo.actividad_elementos (
    id_actividad_elemento bigint IDENTITY(1,1) NOT NULL CONSTRAINT PK_actividad_elementos PRIMARY KEY,
    id_actividad_modelo bigint NOT NULL,
    id_elemento bigint NOT NULL,
    tipo_elemento int not null,           -- Combobox (ID Catálogo Maestro: 11 - Tipo Stock)
    tipo_movimiento int NOT NULL,         -- Combobox (ID Catálogo Maestro: 16 - Entrada/Salida)
    cantidad_prevista decimal(18,4) NOT NULL,
    id_unidad int NOT NULL,               -- Combobox (ID Catálogo Maestro: 17 - Unidades)
    obligatorio bit NOT NULL DEFAULT 1, 
    vendible_destino bit NULL,  
    permite_sustitucion bit,    
    observaciones varchar(1000) NULL,
    
    CONSTRAINT FK_elementos_actividad FOREIGN KEY (id_actividad_modelo) REFERENCES dbo.actividades_ciclo_modelo(id_actividad_modelo),
    -- Relaciones con los ítems seleccionados de los catálogos
    CONSTRAINT FK_elementos_tipo FOREIGN KEY (tipo_elemento) REFERENCES dbo.Catalogo_tipo_items(Id_catalo-go_item),
    CONSTRAINT FK_elementos_movimiento FOREIGN KEY (tipo_movimiento) REFERENCES dbo.Catalogo_tipo_items(Id_catalogo_item),
    CONSTRAINT FK_elementos_unidad FOREIGN KEY (id_unidad) REFERENCES dbo.Catalogo_tipo_items(Id_catalogo_item)
);   
GO



















   ---------------- STORE PROCEDURE CICLO MODELO

IF OBJECT_ID('dbo.sp_select_ciclo_modelo', 'P') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_select_ciclo_modelo];
GO

CREATE PROCEDURE [dbo].[sp_select_ciclo_modelo]
    @filtro VARCHAR(100) = ''
AS
BEGIN
    -- Evita el envío de mensajes de recuento de filas para mejorar el rendimiento
    SET NOCOUNT ON;

    SELECT 
        id_ciclo,
        nombre,
        descripcion,
        duracion_estimada,
        modo_inicio,
        activo,
        fecha_creacion,
        creado_por
    FROM 
        dbo.ciclos_modelo
    WHERE 
        (
            @filtro = '' 
            OR nombre LIKE '%' + @filtro + '%' 
            OR descripcion LIKE '%' + @filtro + '%'
        );
END;
GO









-- ========================================================
-- 1. STORED PROCEDURES: CICLO MODELO (Cabecera)
-- ========================================================
CREATE OR ALTER PROCEDURE sp_insert_ciclo_modelo
    @nombre VARCHAR(150),
    @descripcion VARCHAR(2000),
    @duracion_estimada DECIMAL(12,2),
    @modo_inicio INT,
    @activo BIT,
    @fecha_creacion DATETIME,
    @creado_por INT,
    @id_ciclo_generado BIGINT OUTPUT -- Parámetro de salida para capturar el ID generado
AS
BEGIN
    INSERT INTO ciclos_modelo (nombre, descripcion, duracion_estimada, modo_inicio, activo, fecha_creacion, creado_por)
    VALUES (@nombre, @descripcion, @duracion_estimada, @modo_inicio, @activo, @fecha_creacion, @creado_por);
    
    -- Capturamos el ID autonumérico generado para pasarlo a la siguiente tabla
    SET @id_ciclo_generado = SCOPE_IDENTITY();
END;
GO

CREATE OR ALTER PROCEDURE sp_update_ciclo_modelo
    @id_ciclo BIGINT,
    @nombre VARCHAR(150),
    @descripcion VARCHAR(2000),
    @duracion_estimada DECIMAL(12,2),
    @modo_inicio INT,
    @activo BIT
AS
BEGIN
    UPDATE ciclos_modelo
    SET nombre = @nombre,
        descripcion = @descripcion,
        duracion_estimada = @duracion_estimada,
        modo_inicio = @modo_inicio,
        activo = @activo
    WHERE id_ciclo = @id_ciclo;
END;
GO

-- ========================================================
-- 2. STORED PROCEDURES: ACTIVIDADES DEL CICLO (Paso a paso)
-- ========================================================
CREATE OR ALTER PROCEDURE sp_insert_actividad_ciclo
    @id_ciclo BIGINT,
    @nombre VARCHAR(150),
    @descripcion VARCHAR(2000),
    @orden INT,
    @tipo_actividad INT,
    @duracion_estimada DECIMAL(12,2),
    @demora BIT,
    @requiere_aprobacion BIT,
    @permite_ejecucion_parcial BIT,
    @condicion_avance NVARCHAR(1000),
    @activa BIT,
    @id_actividad_generada BIGINT OUTPUT -- Parámetro de salida
AS
BEGIN
    INSERT INTO actividades_ciclo_modelo (
        id_ciclo, nombre, descripcion, orden, tipo_actividad, duracion_estimada, 
        demora, requiere_aprobacion, permite_ejecucion_parcial, condicion_avance, activa
    )
    VALUES (
        @id_ciclo, @nombre, @descripcion, @orden, @tipo_actividad, @duracion_estimada, 
        @demora, @requiere_aprobacion, @permite_ejecucion_parcial, @condicion_avance, @activa
    );

    SET @id_actividad_generada = SCOPE_IDENTITY();
END;
GO

CREATE OR ALTER PROCEDURE sp_update_actividad_ciclo
    @id_actividad_modelo BIGINT,
    @nombre VARCHAR(150),
    @descripcion VARCHAR(2000),
    @orden INT,
    @tipo_actividad INT,
    @duracion_estimada DECIMAL(12,2),
    @demora BIT,
    @requiere_aprobacion BIT,
    @permite_ejecucion_parcial BIT,
    @condicion_avance NVARCHAR(1000),
    @activa BIT
AS
BEGIN
    UPDATE actividades_ciclo_modelo
    SET nombre = @nombre,
        descripcion = @descripcion,
        orden = @orden,
        tipo_actividad = @tipo_actividad,
        duracion_estimada = @duracion_estimada,
        demora = @demora,
        requiere_aprobacion = @requiere_aprobacion,
        permite_ejecucion_parcial = @permite_ejecucion_parcial,
        condicion_avance = @condicion_avance,
        activa = @activa
    WHERE id_actividad_modelo = @id_actividad_modelo;
END;
GO

-- ========================================================
-- 3. STORED PROCEDURES: ELEMENTOS DE LA ACTIVIDAD (Insumos/Productos)
-- ========================================================
CREATE OR ALTER PROCEDURE sp_insert_actividad_elemento
    @id_actividad_modelo BIGINT,
    @id_elemento BIGINT,
    @tipo_elemento INT,
    @tipo_movimiento INT,
    @cantidad_prevista DECIMAL(18,4),
    @id_unidad INT,
    @obligatorio BIT,
    @vendible_destino BIT,
    @permite_sustitucion BIT,
    @observaciones VARCHAR(1000)
AS
BEGIN
    INSERT INTO actividad_elementos (
        id_actividad_modelo, id_elemento, tipo_elemento, tipo_movimiento, 
        cantidad_prevista, id_unidad, obligatorio, vendible_destino, permite_sustitucion, observaciones
    )
    VALUES (
        @id_actividad_modelo, @id_elemento, @tipo_elemento, @tipo_movimiento, 
        @cantidad_prevista, @id_unidad, @obligatorio, @vendible_destino, @permite_sustitucion, @observaciones
    );
END;
GO


CREATE OR ALTER PROCEDURE sp_select_items_catalogo
    @id_catalogo INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT Id_catalogo_item, Nombre 
    FROM Catalogo_tipo_items 
    WHERE Id_catalog = @id_catalogo 
      AND Activo = 1;
END;
GO



CREATE OR ALTER PROCEDURE sp_select_elementos_por_tipo
    @tipo VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF @tipo = 'Animal'
    BEGIN
        SELECT id_animal AS id_elemento, nombre_comun AS nombre 
        FROM animal 
        ORDER BY nombre_comun ASC;
    END
    ELSE IF @tipo = 'Vegetal'
    BEGIN
        SELECT id_vegetal AS id_elemento, nombre_comun AS nombre 
        FROM vegetal 
        ORDER BY nombre_comun ASC;
    END
    ELSE IF @tipo = 'Articulo'
    BEGIN
        SELECT id_articulo AS id_elemento, nombre AS nombre 
        FROM articulos 
        ORDER BY nombre ASC;
    END
END;
GO