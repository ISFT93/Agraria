/* =====================================================================
   AgrariaNueva2 - SCRIPT ÚNICO DE CREACIÓN
   ---------------------------------------------------------------------
   Reemplaza a: 1_AgrarianNueva.sql, 2_AgrarianNueva_Relleno_...sql,
                05-update-CiclosModelos.sql y 06_fix_ciclos_modelo.sql
   (01_ a 04_ son de la base vieja "Agraria" y NO se usan acá).

   - Crea la base si no existe.
   - Se puede ejecutar más de una vez: las tablas se crean solo si faltan,
     los SP se borran y se vuelven a crear (DROP + CREATE) y los datos
     se insertan solo si no están.
   - No usa CREATE OR ALTER, así que funciona con cualquier nivel de
     compatibilidad de la base.

   Orden: 1) Base  2) Tablas  3) Stored procedures  4) Datos iniciales
   ===================================================================== */

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/* =====================================================================
   1) BASE DE DATOS
   ===================================================================== */
IF DB_ID(N'AgrariaNueva2') IS NULL
BEGIN
    EXEC(N'CREATE DATABASE [AgrariaNueva2]');
END
GO

USE [AgrariaNueva2];
GO

/* =====================================================================
   2) TABLAS  (en orden de dependencias)
   ===================================================================== */

-- ---------- CATÁLOGOS GENÉRICOS ----------
IF OBJECT_ID(N'dbo.catalogos_tipo', N'U') IS NULL
CREATE TABLE dbo.catalogos_tipo (
    Id_catalogo BIGINT       NOT NULL CONSTRAINT PK_catalogos_tipo PRIMARY KEY,
    Nombre      VARCHAR(100) NOT NULL,
    Activo      BIT          NOT NULL CONSTRAINT DF_catalogos_tipo_Activo DEFAULT (1)
);
GO

IF OBJECT_ID(N'dbo.catalogo_tipo_items', N'U') IS NULL
CREATE TABLE dbo.catalogo_tipo_items (
    Id_catalogo_item INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_catalogo_tipo_items PRIMARY KEY,
    Id_catalog       BIGINT       NOT NULL,
    Nombre           VARCHAR(150) NOT NULL,
    Activo           BIT          NOT NULL CONSTRAINT DF_catalogo_tipo_items_Activo DEFAULT (1),
    CONSTRAINT FK_catalogo_items_catalogo FOREIGN KEY (Id_catalog) REFERENCES dbo.catalogos_tipo (Id_catalogo)
);
GO

-- ---------- UBICACIÓN ----------
IF OBJECT_ID(N'dbo.Partidos', N'U') IS NULL
CREATE TABLE dbo.Partidos (
    IdPartido     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Partido PRIMARY KEY,
    NombrePartido VARCHAR(100) NULL
);
GO

IF OBJECT_ID(N'dbo.Localidades', N'U') IS NULL
CREATE TABLE dbo.Localidades (
    IdLocalidad     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Localidad PRIMARY KEY,
    NombreLocalidad VARCHAR(100) NULL,
    CodigoPostal    INT NULL,
    IdPartido       INT NULL,
    CONSTRAINT FK_Localidades_Partidos FOREIGN KEY (IdPartido) REFERENCES dbo.Partidos (IdPartido)
);
GO

-- ---------- USUARIOS ----------
IF OBJECT_ID(N'dbo.usuarios', N'U') IS NULL
CREATE TABLE dbo.usuarios (
    Id                  INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_AbmUsuario PRIMARY KEY,
    Nombre              VARCHAR(100) NULL,
    Apellido            VARCHAR(100) NULL,
    Documento           INT          NULL,
    Telefono            VARCHAR(20)  NULL,
    Direccion           VARCHAR(200) NULL,
    IdLocalidad         INT          NULL,
    IdPartido           INT          NULL,
    Email               VARCHAR(150) NULL,
    NombreUsuario       VARCHAR(100) NULL,
    Contraseña          VARCHAR(100) NULL,
    IdPreguntaSeguridad INT          NULL,   -- ítem del catálogo 13
    RespuestaSeguridad  VARCHAR(200) NULL,
    Estado              BIT          NULL CONSTRAINT DF_usuarios_Estado DEFAULT (1),
    CONSTRAINT FK_usuarios_Localidades FOREIGN KEY (IdLocalidad) REFERENCES dbo.Localidades (IdLocalidad),
    CONSTRAINT FK_usuarios_Partidos    FOREIGN KEY (IdPartido)   REFERENCES dbo.Partidos (IdPartido)
);
GO

IF OBJECT_ID(N'dbo.PermisosUsuario', N'U') IS NULL
CREATE TABLE dbo.PermisosUsuario (
    IdPermiso              INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PermisosUsuario PRIMARY KEY,
    IdUsuario              INT NULL,
    PuedeEntornoFormativo  BIT NULL CONSTRAINT DF_Perm_EntornoFormativo  DEFAULT (0),
    PuedeAltaUsuario       BIT NULL CONSTRAINT DF_Perm_AltaUsuario       DEFAULT (0),
    PuedeVenta             BIT NULL CONSTRAINT DF_Perm_Venta             DEFAULT (0),
    PuedeInventario        BIT NULL CONSTRAINT DF_Perm_Inventario        DEFAULT (0),
    PuedeIndustria         BIT NULL CONSTRAINT DF_Perm_Industria         DEFAULT (0),
    PuedeProduccionAnimal  BIT NULL CONSTRAINT DF_Perm_ProduccionAnimal  DEFAULT (0),
    PuedeProduccionVegetal BIT NULL CONSTRAINT DF_Perm_ProduccionVegetal DEFAULT (0),
    PuedeAdministracion    BIT NULL CONSTRAINT DF_Perm_Administracion    DEFAULT (0),
    PuedePañol             BIT NULL CONSTRAINT DF_Perm_Panol             DEFAULT (1),
    CONSTRAINT FK_PermisosUsuario_usuarios FOREIGN KEY (IdUsuario) REFERENCES dbo.usuarios (Id)
);
GO

-- ---------- AUXILIARES DE ELEMENTOS ----------
IF OBJECT_ID(N'dbo.marcas', N'U') IS NULL
CREATE TABLE dbo.marcas (
    id_marca INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_marcas PRIMARY KEY,
    nombre   VARCHAR(100) NULL
);
GO

IF OBJECT_ID(N'dbo.rubros', N'U') IS NULL
CREATE TABLE dbo.rubros (
    id_rubro INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_rubros PRIMARY KEY,
    id_tipo  INT          NOT NULL,   -- ítem del catálogo 1 (Tipo Animal)
    nombre   VARCHAR(100) NOT NULL
);
GO

IF OBJECT_ID(N'dbo.subrubros', N'U') IS NULL
CREATE TABLE dbo.subrubros (
    id_subrubro INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_subrubros PRIMARY KEY,
    id_rubro    INT          NOT NULL,
    nombre      VARCHAR(150) NOT NULL,
    CONSTRAINT fk_rubro FOREIGN KEY (id_rubro) REFERENCES dbo.rubros (id_rubro)
);
GO

IF OBJECT_ID(N'dbo.proveedores', N'U') IS NULL
CREATE TABLE dbo.proveedores (
    id_proveedor BIGINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_proveedores PRIMARY KEY,
    nombre       VARCHAR(150) NULL,
    cuil         VARCHAR(20)  NULL,
    telefono     VARCHAR(30)  NULL,
    direccion    VARCHAR(100) NULL,
    mail         VARCHAR(100) NULL
);
GO

-- ---------- ELEMENTOS (Animales / Vegetales / Artículos) ----------
IF OBJECT_ID(N'dbo.animales', N'U') IS NULL
CREATE TABLE dbo.animales (
    id_animal         BIGINT       NOT NULL CONSTRAINT PK_animales PRIMARY KEY,
    nombre_comun      VARCHAR(100) NULL,
    nombre_cientifico VARCHAR(150) NULL,
    id_tipo           INT          NULL,
    id_rubro          INT          NULL,
    id_subrubro       INT          NULL,
    stock_minimo      FLOAT        NULL,
    CONSTRAINT fk_anim_rubro    FOREIGN KEY (id_rubro)    REFERENCES dbo.rubros (id_rubro),
    CONSTRAINT fk_anim_subrubro FOREIGN KEY (id_subrubro) REFERENCES dbo.subrubros (id_subrubro)
);
GO

IF OBJECT_ID(N'dbo.vegetales', N'U') IS NULL
CREATE TABLE dbo.vegetales (
    id_vegetal            BIGINT      NOT NULL CONSTRAINT PK_vegetales PRIMARY KEY,
    nombre_comun          VARCHAR(40) NOT NULL,
    nombre_cientifico     VARCHAR(40) NULL,
    variedad_hibrido      VARCHAR(40) NULL,
    id_tipo_cultivo       INT         NULL,
    id_ciclo_vida         INT         NULL,
    periodosiembra        VARCHAR(10) NULL,
    id_metodo_siembra     INT         NULL,
    id_estado_fenologico  INT         NULL,
    requerimiento_hidrico VARCHAR(20) NULL,
    CONSTRAINT CK_vegetales_req_hidrico CHECK (requerimiento_hidrico IN ('Bajo', 'Medio', 'Alto'))
);
GO

IF OBJECT_ID(N'dbo.articulos', N'U') IS NULL
CREATE TABLE dbo.articulos (
    id_articulo  BIGINT       NOT NULL CONSTRAINT PK_articulos PRIMARY KEY,
    nombre       VARCHAR(150) NULL,
    id_marca     INT          NULL,
    stock_minimo FLOAT        NULL,
    id_categoria INT          NULL,   -- ítem del catálogo 3
    CONSTRAINT fk_articulos_marca FOREIGN KEY (id_marca) REFERENCES dbo.marcas (id_marca)
);
GO

-- ---------- STOCK ----------
IF OBJECT_ID(N'dbo.stock', N'U') IS NULL
CREATE TABLE dbo.stock (
    id_stock          BIGINT        NOT NULL CONSTRAINT PK_stock PRIMARY KEY,
    id_elemento       BIGINT        NOT NULL,
    tipo_elemento     VARCHAR(50)   NOT NULL,
    Nombre            VARCHAR(50)   NOT NULL,
    ciclo             VARCHAR(50)   NULL,
    fecha_alta        DATE          NOT NULL,
    fecha_baja        DATE          NULL,
    cantidad          DECIMAL(10,2) NULL CONSTRAINT DF_stock_cantidad     DEFAULT (0.00),
    nro_animal        VARCHAR(50)   NULL,
    estado_salud      VARCHAR(50)   NULL,
    es_productor      BIT           NULL CONSTRAINT DF_stock_es_productor DEFAULT (0),
    precio            MONEY         NULL,
    id_proveedor      BIGINT        NULL,
    activo            BIT           NULL CONSTRAINT DF_stock_activo       DEFAULT (1),
    vendible          BIT           NULL CONSTRAINT DF_stock_vendible     DEFAULT (0),
    motivo_movimiento VARCHAR(100)  NULL
);
GO

IF OBJECT_ID(N'dbo.datosAnimales', N'U') IS NULL
CREATE TABLE dbo.datosAnimales (
    id_detalle   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_datosAnimales PRIMARY KEY,
    id_stock     BIGINT      NOT NULL,
    nro_animal   VARCHAR(50) NULL,
    sexo         VARCHAR(20) NULL,
    es_productor BIT         NOT NULL,
    CONSTRAINT FK_stock_datosAnimales FOREIGN KEY (id_stock) REFERENCES dbo.stock (id_stock) ON DELETE CASCADE
);
GO

-- ---------- ENTORNOS FORMATIVOS ----------
IF OBJECT_ID(N'dbo.TipoEntornos', N'U') IS NULL
CREATE TABLE dbo.TipoEntornos (
    IdTipoEntorno INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_TipoEntorno PRIMARY KEY,
    Nombre        VARCHAR(100) NULL
);
GO

IF OBJECT_ID(N'dbo.Entornos', N'U') IS NULL
CREATE TABLE dbo.Entornos (
    IdEntorno     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Entorno PRIMARY KEY,
    Nombre        VARCHAR(150) NULL,
    IdTipoEntorno INT          NULL,
    Responsable   VARCHAR(150) NULL,
    Año           VARCHAR(10)  NULL,
    Division      VARCHAR(10)  NULL,
    Grupo         VARCHAR(50)  NULL,
    Fecha         DATETIME     NULL,
    Observaciones VARCHAR(MAX) NULL,
    CONSTRAINT FK_Entornos_TipoEntornos FOREIGN KEY (IdTipoEntorno) REFERENCES dbo.TipoEntornos (IdTipoEntorno)
);
GO

-- ---------- CICLOS MODELO ----------
IF OBJECT_ID(N'dbo.ciclos_modelo', N'U') IS NULL
CREATE TABLE dbo.ciclos_modelo (
    id_ciclo          BIGINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ciclos_productivos PRIMARY KEY,
    nombre            VARCHAR(150)  NOT NULL,
    descripcion       VARCHAR(2000) NULL,
    duracion_estimada DECIMAL(12,2) NULL,
    modo_inicio       INT           NULL,   -- catálogo 14
    activo            BIT           NOT NULL CONSTRAINT DF_ciclos_activo DEFAULT (1),
    fecha_creacion    DATETIME      NOT NULL CONSTRAINT DF_ciclos_fecha  DEFAULT (GETDATE()),
    creado_por        INT           NOT NULL,
    CONSTRAINT FK_ciclos_modo_inicio FOREIGN KEY (modo_inicio) REFERENCES dbo.catalogo_tipo_items (Id_catalogo_item)
);
GO

IF OBJECT_ID(N'dbo.actividades_ciclo_modelo', N'U') IS NULL
CREATE TABLE dbo.actividades_ciclo_modelo (
    id_actividad_modelo       BIGINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_actividades_modelo PRIMARY KEY,
    id_ciclo                  BIGINT         NOT NULL,
    nombre                    VARCHAR(150)   NOT NULL,
    descripcion               VARCHAR(2000)  NULL,
    orden                     INT            NOT NULL,
    tipo_actividad            INT            NULL,   -- catálogo 15
    duracion_estimada         DECIMAL(12,2)  NULL,
    demora                    BIT            NULL,
    requiere_aprobacion       BIT            NOT NULL CONSTRAINT DF_act_aprobacion DEFAULT (0),
    permite_ejecucion_parcial BIT            NOT NULL CONSTRAINT DF_act_parcial    DEFAULT (0),
    condicion_avance          NVARCHAR(1000) NULL,
    activa                    BIT            NOT NULL CONSTRAINT DF_act_activa     DEFAULT (1),
    CONSTRAINT FK_actividades_ciclo FOREIGN KEY (id_ciclo)       REFERENCES dbo.ciclos_modelo (id_ciclo),
    CONSTRAINT FK_actividades_tipo  FOREIGN KEY (tipo_actividad) REFERENCES dbo.catalogo_tipo_items (Id_catalogo_item)
);
GO

IF OBJECT_ID(N'dbo.actividad_elementos', N'U') IS NULL
CREATE TABLE dbo.actividad_elementos (
    id_actividad_elemento BIGINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_actividad_elementos PRIMARY KEY,
    id_actividad_modelo   BIGINT        NOT NULL,
    id_elemento           BIGINT        NOT NULL,
    tipo_elemento         INT           NOT NULL,   -- catálogo 11
    tipo_movimiento       INT           NOT NULL,   -- catálogo 16 (Entrada / Salida)
    cantidad_prevista     DECIMAL(18,4) NOT NULL,
    id_unidad             INT           NOT NULL,   -- catálogo 17
    obligatorio           BIT           NOT NULL CONSTRAINT DF_elem_obligatorio DEFAULT (1),
    vendible_destino      BIT           NULL,
    permite_sustitucion   BIT           NULL,
    observaciones         VARCHAR(1000) NULL,
    orden                 INT           NULL,
    CONSTRAINT FK_elementos_actividad  FOREIGN KEY (id_actividad_modelo) REFERENCES dbo.actividades_ciclo_modelo (id_actividad_modelo),
    CONSTRAINT FK_elementos_tipo       FOREIGN KEY (tipo_elemento)       REFERENCES dbo.catalogo_tipo_items (Id_catalogo_item),
    CONSTRAINT FK_elementos_movimiento FOREIGN KEY (tipo_movimiento)     REFERENCES dbo.catalogo_tipo_items (Id_catalogo_item),
    CONSTRAINT FK_elementos_unidad     FOREIGN KEY (id_unidad)           REFERENCES dbo.catalogo_tipo_items (Id_catalogo_item)
);
GO

-- Por si la tabla ya existía de antes sin la columna "orden"
IF COL_LENGTH(N'dbo.actividad_elementos', N'orden') IS NULL
    ALTER TABLE dbo.actividad_elementos ADD orden INT NULL;
GO

/* =====================================================================
   3) STORED PROCEDURES
   ===================================================================== */

-- =========================== GENERALES ===============================
IF OBJECT_ID(N'dbo.sp_select_combo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_combo;
GO
CREATE PROCEDURE dbo.sp_select_combo
    @tabla NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @sql NVARCHAR(MAX) = N'SELECT * FROM ' + QUOTENAME(@tabla);
    EXEC sp_executesql @sql;
END;
GO

IF OBJECT_ID(N'dbo.sp_select_items_catalogo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_items_catalogo;
GO
CREATE PROCEDURE dbo.sp_select_items_catalogo
    @id_catalogo INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id_catalogo_item, Nombre
    FROM dbo.catalogo_tipo_items
    WHERE Id_catalog = @id_catalogo
      AND Activo = 1;
END;
GO

IF OBJECT_ID(N'dbo.sp_select_proveedores', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_proveedores;
GO
CREATE PROCEDURE dbo.sp_select_proveedores
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_proveedor, nombre FROM dbo.proveedores ORDER BY nombre ASC;
END;
GO

IF OBJECT_ID(N'dbo.sp_select_requerimiento_hidrico', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_requerimiento_hidrico;
GO
CREATE PROCEDURE dbo.sp_select_requerimiento_hidrico
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 'Alto' AS nombre UNION SELECT 'Medio' UNION SELECT 'Bajo';
END;
GO

-- Último ID usado de un elemento (mira el catálogo y el stock)
IF OBJECT_ID(N'dbo.sp_obtener_ultimo_id_elemento', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_obtener_ultimo_id_elemento;
GO
CREATE PROCEDURE dbo.sp_obtener_ultimo_id_elemento
    @tipo_elemento VARCHAR(50),
    @min BIGINT,
    @max BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ultimoId_Cat   BIGINT = 0;
    DECLARE @ultimoId_Stock BIGINT = 0;

    -- Antes apuntaba a las tablas viejas "vegetal" y "animal"
    IF @tipo_elemento = 'Vegetal'
        SELECT @ultimoId_Cat = ISNULL(MAX(id_vegetal), 0)  FROM dbo.vegetales WHERE id_vegetal  >= @min AND id_vegetal  < @max;
    ELSE IF @tipo_elemento = 'Animal'
        SELECT @ultimoId_Cat = ISNULL(MAX(id_animal), 0)   FROM dbo.animales  WHERE id_animal   >= @min AND id_animal   < @max;
    ELSE IF @tipo_elemento = 'Articulo'
        SELECT @ultimoId_Cat = ISNULL(MAX(id_articulo), 0) FROM dbo.articulos WHERE id_articulo >= @min AND id_articulo < @max;

    SELECT @ultimoId_Stock = ISNULL(MAX(id_elemento), 0)
    FROM dbo.stock
    WHERE tipo_elemento = @tipo_elemento
      AND id_elemento >= @min
      AND id_elemento <  @max;

    IF @ultimoId_Stock > @ultimoId_Cat
        SELECT @ultimoId_Stock;
    ELSE
        SELECT @ultimoId_Cat;
END;
GO

-- =========================== ARTÍCULOS ===============================
IF OBJECT_ID(N'dbo.sp_select_articulos', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_articulos;
GO
CREATE PROCEDURE dbo.sp_select_articulos
AS
BEGIN
    SET NOCOUNT ON;
    -- Antes usaba las tablas viejas "marca" y "categoria"
    SELECT
        a.id_articulo,
        a.nombre AS nombre_articulo,
        m.nombre AS marca,
        c.Nombre AS categoria
    FROM dbo.articulos a
    LEFT JOIN dbo.marcas m              ON a.id_marca     = m.id_marca
    LEFT JOIN dbo.catalogo_tipo_items c ON a.id_categoria = c.Id_catalogo_item;
END;
GO

IF OBJECT_ID(N'dbo.sp_insert_articulo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_insert_articulo;
GO
CREATE PROCEDURE dbo.sp_insert_articulo
    @id_articulo  BIGINT,
    @nombre       VARCHAR(150),
    @id_marca     INT,
    @stock_minimo FLOAT,
    @id_categoria INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.articulos (id_articulo, nombre, id_marca, stock_minimo, id_categoria)
    VALUES (@id_articulo, @nombre, @id_marca, @stock_minimo, @id_categoria);
END;
GO

IF OBJECT_ID(N'dbo.sp_update_articulo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_update_articulo;
GO
CREATE PROCEDURE dbo.sp_update_articulo
    @id_articulo  BIGINT,
    @nombre       VARCHAR(150),
    @id_marca     INT,
    @stock_minimo FLOAT,
    @id_categoria INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.articulos
    SET nombre       = @nombre,
        id_marca     = @id_marca,
        stock_minimo = @stock_minimo,
        id_categoria = @id_categoria
    WHERE id_articulo = @id_articulo;
END;
GO

IF OBJECT_ID(N'dbo.sp_delete_articulo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_delete_articulo;
GO
CREATE PROCEDURE dbo.sp_delete_articulo
    @id_articulo BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.articulos WHERE id_articulo = @id_articulo;
END;
GO

-- =========================== ANIMALES ================================
IF OBJECT_ID(N'dbo.sp_selectanimales', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_selectanimales;
GO
CREATE PROCEDURE dbo.sp_selectanimales
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        a.id_animal         AS idanimal,
        a.nombre_comun      AS nombrecomun,
        a.nombre_cientifico AS nombrecientifico,
        a.id_tipo           AS idtipo,
        a.id_rubro          AS idrubro,
        a.id_subrubro       AS idsubrubro,
        t.Nombre            AS tipo_animal,
        r.nombre            AS rubro,
        sr.nombre           AS subrubro,
        a.stock_minimo      AS stockminimo
    FROM dbo.animales a
    LEFT JOIN dbo.catalogo_tipo_items t ON a.id_tipo     = t.Id_catalogo_item
    LEFT JOIN dbo.rubros r              ON a.id_rubro    = r.id_rubro
    LEFT JOIN dbo.subrubros sr          ON a.id_subrubro = sr.id_subrubro;
END;
GO

IF OBJECT_ID(N'dbo.sp_insertanimales', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_insertanimales;
GO
CREATE PROCEDURE dbo.sp_insertanimales
    @id_animal         BIGINT,
    @nombre_comun      VARCHAR(100),
    @nombre_cientifico VARCHAR(150) = NULL,
    @id_tipo           INT,
    @id_rubro          INT,
    @id_subrubro       INT,
    @stock_minimo      FLOAT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.animales (id_animal, nombre_comun, nombre_cientifico, id_tipo, id_rubro, id_subrubro, stock_minimo)
    VALUES (@id_animal, @nombre_comun, @nombre_cientifico, @id_tipo, @id_rubro, @id_subrubro, @stock_minimo);
END;
GO

-- El código llama "sp_updateanimales" (antes existía "sp_updateanimal" sobre la tabla vieja "animal")
IF OBJECT_ID(N'dbo.sp_updateanimales', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_updateanimales;
GO
CREATE PROCEDURE dbo.sp_updateanimales
    @id_animal         BIGINT,
    @nombre_comun      VARCHAR(100),
    @nombre_cientifico VARCHAR(150) = NULL,
    @id_tipo           INT,
    @id_rubro          INT,
    @id_subrubro       INT,
    @stock_minimo      FLOAT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.animales
    SET nombre_comun      = @nombre_comun,
        nombre_cientifico = @nombre_cientifico,
        id_tipo           = @id_tipo,
        id_rubro          = @id_rubro,
        id_subrubro       = @id_subrubro,
        stock_minimo      = @stock_minimo
    WHERE id_animal = @id_animal;
END;
GO

IF OBJECT_ID(N'dbo.sp_select_ultimo_id_animal', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_ultimo_id_animal;
GO
CREATE PROCEDURE dbo.sp_select_ultimo_id_animal
    @min BIGINT,
    @max BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(MAX(id_animal), 0)
    FROM dbo.animales
    WHERE id_animal >= @min AND id_animal <= @max;
END;
GO

-- =========================== VEGETALES ===============================
IF OBJECT_ID(N'dbo.sp_select_vegetales', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_vegetales;
GO
CREATE PROCEDURE dbo.sp_select_vegetales
    @filtro VARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        v.id_vegetal,
        v.nombre_comun,
        v.nombre_cientifico,
        v.variedad_hibrido,
        v.periodosiembra,
        v.requerimiento_hidrico,
        tc.Nombre AS tipo_cultivo,
        cv.Nombre AS ciclo_vida,
        ms.Nombre AS metodo_siembra,
        ef.Nombre AS estado_fenologico
    FROM dbo.vegetales v
    LEFT JOIN dbo.catalogo_tipo_items tc ON v.id_tipo_cultivo      = tc.Id_catalogo_item
    LEFT JOIN dbo.catalogo_tipo_items cv ON v.id_ciclo_vida        = cv.Id_catalogo_item
    LEFT JOIN dbo.catalogo_tipo_items ms ON v.id_metodo_siembra    = ms.Id_catalogo_item
    LEFT JOIN dbo.catalogo_tipo_items ef ON v.id_estado_fenologico = ef.Id_catalogo_item
    WHERE (@filtro = '' OR v.nombre_comun LIKE '%' + @filtro + '%' OR v.variedad_hibrido LIKE '%' + @filtro + '%');
END;
GO

-- El código llama "sp_select_vegetales_por_id" con @Id_vegetal
IF OBJECT_ID(N'dbo.sp_select_vegetales_por_id', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_vegetales_por_id;
GO
CREATE PROCEDURE dbo.sp_select_vegetales_por_id
    @id_vegetal BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.vegetales WHERE id_vegetal = @id_vegetal;
END;
GO

-- Antes insertaba en la tabla vieja "vegetal"
IF OBJECT_ID(N'dbo.sp_insert_vegetales', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_insert_vegetales;
GO
CREATE PROCEDURE dbo.sp_insert_vegetales
    @id_vegetal            BIGINT,
    @nombre_comun          VARCHAR(100),
    @nombre_cientifico     VARCHAR(150),
    @variedad_hibrido      VARCHAR(100),
    @id_tipo_cultivo       INT,
    @id_ciclo_vida         INT,
    @periodosiembra        VARCHAR(100),
    @id_metodo_siembra     INT,
    @id_estado_fenologico  INT,
    @requerimiento_hidrico VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.vegetales (
        id_vegetal, nombre_comun, nombre_cientifico, variedad_hibrido, id_tipo_cultivo,
        id_ciclo_vida, periodosiembra, id_metodo_siembra, id_estado_fenologico, requerimiento_hidrico
    )
    VALUES (
        @id_vegetal, @nombre_comun, @nombre_cientifico, @variedad_hibrido, @id_tipo_cultivo,
        @id_ciclo_vida, @periodosiembra, @id_metodo_siembra, @id_estado_fenologico, @requerimiento_hidrico
    );
END;
GO

-- El código llama "sp_update_vegetales" (antes existía "sp_update_vegetal" sobre la tabla vieja)
IF OBJECT_ID(N'dbo.sp_update_vegetales', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_update_vegetales;
GO
CREATE PROCEDURE dbo.sp_update_vegetales
    @id_vegetal            BIGINT,
    @nombre_comun          VARCHAR(100),
    @nombre_cientifico     VARCHAR(150),
    @variedad_hibrido      VARCHAR(100),
    @id_tipo_cultivo       INT,
    @id_ciclo_vida         INT,
    @periodosiembra        VARCHAR(100),
    @id_metodo_siembra     INT,
    @id_estado_fenologico  INT,
    @requerimiento_hidrico VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.vegetales
    SET nombre_comun          = @nombre_comun,
        nombre_cientifico     = @nombre_cientifico,
        variedad_hibrido      = @variedad_hibrido,
        id_tipo_cultivo       = @id_tipo_cultivo,
        id_ciclo_vida         = @id_ciclo_vida,
        periodosiembra        = @periodosiembra,
        id_metodo_siembra     = @id_metodo_siembra,
        id_estado_fenologico  = @id_estado_fenologico,
        requerimiento_hidrico = @requerimiento_hidrico
    WHERE id_vegetal = @id_vegetal;
END;
GO

IF OBJECT_ID(N'dbo.sp_select_ultimo_id_vegetal', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_ultimo_id_vegetal;
GO
CREATE PROCEDURE dbo.sp_select_ultimo_id_vegetal
    @min BIGINT,
    @max BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(MAX(id_vegetal), 0) FROM dbo.vegetales WHERE id_vegetal >= @min AND id_vegetal < @max;
END;
GO

-- =========================== STOCK ===================================
IF OBJECT_ID(N'dbo.sp_select_stock', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_stock;
GO
CREATE PROCEDURE dbo.sp_select_stock
    @tipo_elemento VARCHAR(50) = NULL,
    @Nombre        VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        s.id_stock, s.id_elemento, s.tipo_elemento, s.Nombre, s.ciclo,
        s.fecha_alta, s.fecha_baja, s.cantidad, s.precio, s.id_proveedor,
        p.nombre AS proveedor_nombre, s.activo, s.vendible
    FROM dbo.stock s
    LEFT JOIN dbo.proveedores p ON s.id_proveedor = p.id_proveedor
    WHERE (@tipo_elemento IS NULL OR @tipo_elemento = '' OR s.tipo_elemento = @tipo_elemento)
      AND (@Nombre IS NULL OR @Nombre = '' OR s.Nombre LIKE '%' + @Nombre + '%');
END;
GO

IF OBJECT_ID(N'dbo.sp_select_stock_por_id', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_stock_por_id;
GO
CREATE PROCEDURE dbo.sp_select_stock_por_id
    @id BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.stock WHERE id_stock = @id;
END;
GO

IF OBJECT_ID(N'dbo.sp_insert_stock', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_insert_stock;
GO
CREATE PROCEDURE dbo.sp_insert_stock
    @id_stock          BIGINT,
    @id_elemento       BIGINT,
    @tipo_elemento     VARCHAR(50),
    @Nombre            VARCHAR(50),
    @ciclo             VARCHAR(50),
    @fecha_alta        DATETIME,
    @fecha_baja        DATETIME      = NULL,
    @cantidad          DECIMAL(18,2),
    @precio            DECIMAL(18,2) = NULL,
    @id_proveedor      BIGINT        = NULL,
    @activo            BIT,
    @vendible          BIT,
    @motivo_movimiento VARCHAR(255)  = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.stock (
        id_stock, id_elemento, tipo_elemento, Nombre, ciclo,
        fecha_alta, fecha_baja, cantidad, precio, id_proveedor, activo, vendible, motivo_movimiento
    )
    VALUES (
        @id_stock, @id_elemento, @tipo_elemento, @Nombre, @ciclo,
        @fecha_alta, @fecha_baja, @cantidad, @precio, @id_proveedor, @activo, @vendible, @motivo_movimiento
    );
END;
GO

IF OBJECT_ID(N'dbo.sp_update_stock', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_update_stock;
GO
CREATE PROCEDURE dbo.sp_update_stock
    @id_stock      BIGINT,
    @id_elemento   BIGINT,
    @tipo_elemento VARCHAR(50),
    @Nombre        VARCHAR(50),
    @ciclo         VARCHAR(50),
    @fecha_alta    DATETIME,
    @fecha_baja    DATETIME      = NULL,
    @cantidad      DECIMAL(18,2),
    @precio        DECIMAL(18,2) = NULL,
    @id_proveedor  BIGINT        = NULL,
    @activo        BIT,
    @vendible      BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.stock SET
        id_elemento   = @id_elemento,
        tipo_elemento = @tipo_elemento,
        Nombre        = @Nombre,
        ciclo         = @ciclo,
        fecha_alta    = @fecha_alta,
        fecha_baja    = @fecha_baja,
        cantidad      = @cantidad,
        precio        = @precio,
        id_proveedor  = @id_proveedor,
        activo        = @activo,
        vendible      = @vendible
    WHERE id_stock = @id_stock;
END;
GO

-- El código llama "sp_insert_detalle_animales" (antes se llamaba "sp_insert_detalle_animal")
IF OBJECT_ID(N'dbo.sp_insert_detalle_animales', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_insert_detalle_animales;
GO
CREATE PROCEDURE dbo.sp_insert_detalle_animales
    @id_stock     BIGINT,
    @nro_animal   VARCHAR(50),
    @sexo         VARCHAR(20),
    @es_productor BIT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.datosAnimales (id_stock, nro_animal, sexo, es_productor)
    VALUES (@id_stock, @nro_animal, @sexo, @es_productor);
END;
GO

-- El código llama "sp_update_detalle_animales" (antes se llamaba "sp_update_detalle_animal")
IF OBJECT_ID(N'dbo.sp_update_detalle_animales', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_update_detalle_animales;
GO
CREATE PROCEDURE dbo.sp_update_detalle_animales
    @id_stock     BIGINT,
    @nro_animal   VARCHAR(50),
    @sexo         VARCHAR(20),
    @es_productor BIT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.datosAnimales WHERE id_stock = @id_stock AND nro_animal = @nro_animal)
        UPDATE dbo.datosAnimales
        SET sexo = @sexo, es_productor = @es_productor
        WHERE id_stock = @id_stock AND nro_animal = @nro_animal;
    ELSE
        INSERT INTO dbo.datosAnimales (id_stock, nro_animal, sexo, es_productor)
        VALUES (@id_stock, @nro_animal, @sexo, @es_productor);
END;
GO

IF OBJECT_ID(N'dbo.sp_obtener_detalle_animales_por_stock', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_obtener_detalle_animales_por_stock;
GO
CREATE PROCEDURE dbo.sp_obtener_detalle_animales_por_stock
    @id_stock BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_detalle, id_stock, nro_animal, sexo, es_productor
    FROM dbo.datosAnimales
    WHERE id_stock = @id_stock;
END;
GO

-- =========================== CICLOS MODELO ===========================
IF OBJECT_ID(N'dbo.sp_select_ciclo_modelo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_ciclo_modelo;
GO
CREATE PROCEDURE dbo.sp_select_ciclo_modelo
    @filtro VARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        c.id_ciclo,
        c.nombre,
        c.descripcion,
        c.duracion_estimada,
        c.modo_inicio,
        mi.Nombre       AS modo_inicio_nombre,
        c.activo,
        c.fecha_creacion,
        c.creado_por,
        u.NombreUsuario AS creado_por_nombre
    FROM dbo.ciclos_modelo c
    LEFT JOIN dbo.catalogo_tipo_items mi ON mi.Id_catalogo_item = c.modo_inicio
    LEFT JOIN dbo.usuarios u             ON u.Id = c.creado_por
    WHERE @filtro = ''
       OR c.nombre      LIKE '%' + @filtro + '%'
       OR c.descripcion LIKE '%' + @filtro + '%'
    ORDER BY c.id_ciclo DESC;
END;
GO

IF OBJECT_ID(N'dbo.sp_get_ciclo_por_id', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_get_ciclo_por_id;
GO
CREATE PROCEDURE dbo.sp_get_ciclo_por_id
    @id_ciclo BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        c.*,
        mi.Nombre       AS modo_inicio_nombre,
        u.NombreUsuario AS creado_por_nombre
    FROM dbo.ciclos_modelo c
    LEFT JOIN dbo.catalogo_tipo_items mi ON mi.Id_catalogo_item = c.modo_inicio
    LEFT JOIN dbo.usuarios u             ON u.Id = c.creado_por
    WHERE c.id_ciclo = @id_ciclo;
END;
GO

IF OBJECT_ID(N'dbo.sp_insert_ciclo_modelo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_insert_ciclo_modelo;
GO
CREATE PROCEDURE dbo.sp_insert_ciclo_modelo
    @nombre            VARCHAR(150),
    @descripcion       VARCHAR(2000),
    @duracion_estimada DECIMAL(12,2),
    @modo_inicio       INT,
    @activo            BIT,
    @fecha_creacion    DATETIME,
    @creado_por        INT,
    @id_ciclo_generado BIGINT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.ciclos_modelo (nombre, descripcion, duracion_estimada, modo_inicio, activo, fecha_creacion, creado_por)
    VALUES (@nombre, @descripcion, @duracion_estimada, @modo_inicio, @activo, @fecha_creacion, @creado_por);

    SET @id_ciclo_generado = SCOPE_IDENTITY();
END;
GO

IF OBJECT_ID(N'dbo.sp_update_ciclo_modelo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_update_ciclo_modelo;
GO
CREATE PROCEDURE dbo.sp_update_ciclo_modelo
    @id_ciclo          BIGINT,
    @nombre            VARCHAR(150),
    @descripcion       VARCHAR(2000),
    @duracion_estimada DECIMAL(12,2),
    @modo_inicio       INT,
    @activo            BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.ciclos_modelo
    SET nombre            = @nombre,
        descripcion       = @descripcion,
        duracion_estimada = @duracion_estimada,
        modo_inicio       = @modo_inicio,
        activo            = @activo
    WHERE id_ciclo = @id_ciclo;
END;
GO

IF OBJECT_ID(N'dbo.sp_get_actividades_por_ciclo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_get_actividades_por_ciclo;
GO
CREATE PROCEDURE dbo.sp_get_actividades_por_ciclo
    @id_ciclo BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        a.*,
        ta.Nombre AS tipo_actividad_nombre
    FROM dbo.actividades_ciclo_modelo a
    LEFT JOIN dbo.catalogo_tipo_items ta ON ta.Id_catalogo_item = a.tipo_actividad
    WHERE a.id_ciclo = @id_ciclo
    ORDER BY a.orden ASC;
END;
GO

IF OBJECT_ID(N'dbo.sp_insert_actividad_ciclo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_insert_actividad_ciclo;
GO
CREATE PROCEDURE dbo.sp_insert_actividad_ciclo
    @id_ciclo                  BIGINT,
    @nombre                    VARCHAR(150),
    @descripcion               VARCHAR(2000),
    @orden                     INT,
    @tipo_actividad            INT,
    @duracion_estimada         DECIMAL(12,2),
    @demora                    BIT,
    @requiere_aprobacion       BIT,
    @permite_ejecucion_parcial BIT,
    @condicion_avance          NVARCHAR(1000),
    @activa                    BIT,
    @id_actividad_generada     BIGINT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.actividades_ciclo_modelo (
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

IF OBJECT_ID(N'dbo.sp_update_actividad_ciclo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_update_actividad_ciclo;
GO
CREATE PROCEDURE dbo.sp_update_actividad_ciclo
    @id_actividad_modelo       BIGINT,
    @nombre                    VARCHAR(150),
    @descripcion               VARCHAR(2000),
    @orden                     INT,
    @tipo_actividad            INT,
    @duracion_estimada         DECIMAL(12,2),
    @demora                    BIT,
    @requiere_aprobacion       BIT,
    @permite_ejecucion_parcial BIT,
    @condicion_avance          NVARCHAR(1000),
    @activa                    BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.actividades_ciclo_modelo
    SET nombre                    = @nombre,
        descripcion               = @descripcion,
        orden                     = @orden,
        tipo_actividad            = @tipo_actividad,
        duracion_estimada         = @duracion_estimada,
        demora                    = @demora,
        requiere_aprobacion       = @requiere_aprobacion,
        permite_ejecucion_parcial = @permite_ejecucion_parcial,
        condicion_avance          = @condicion_avance,
        activa                    = @activa
    WHERE id_actividad_modelo = @id_actividad_modelo;
END;
GO

-- Al modificar un ciclo se borran sus actividades/elementos y se reinsertan
IF OBJECT_ID(N'dbo.sp_delete_actividades_por_ciclo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_delete_actividades_por_ciclo;
GO
CREATE PROCEDURE dbo.sp_delete_actividades_por_ciclo
    @id_ciclo BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE e
    FROM dbo.actividad_elementos e
    INNER JOIN dbo.actividades_ciclo_modelo a ON a.id_actividad_modelo = e.id_actividad_modelo
    WHERE a.id_ciclo = @id_ciclo;

    DELETE FROM dbo.actividades_ciclo_modelo WHERE id_ciclo = @id_ciclo;
END;
GO

IF OBJECT_ID(N'dbo.sp_select_elementos_por_tipo', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_select_elementos_por_tipo;
GO
CREATE PROCEDURE dbo.sp_select_elementos_por_tipo
    @tipo VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF @tipo = 'Animal'
        SELECT id_animal   AS id_elemento, nombre_comun AS nombre FROM dbo.animales  ORDER BY nombre_comun;
    ELSE IF @tipo = 'Vegetal'
        SELECT id_vegetal  AS id_elemento, nombre_comun AS nombre FROM dbo.vegetales ORDER BY nombre_comun;
    ELSE IF @tipo IN ('Articulo', 'Artículo')
        SELECT id_articulo AS id_elemento, nombre       AS nombre FROM dbo.articulos ORDER BY nombre;
    ELSE
        SELECT CAST(NULL AS BIGINT) AS id_elemento, CAST(NULL AS VARCHAR(150)) AS nombre WHERE 1 = 0;
END;
GO

IF OBJECT_ID(N'dbo.sp_get_elementos_por_actividad', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_get_elementos_por_actividad;
GO
CREATE PROCEDURE dbo.sp_get_elementos_por_actividad
    @id_actividad_modelo BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        e.*,
        te.Nombre AS tipo_elemento_nombre,
        tm.Nombre AS tipo_movimiento_nombre,
        un.Nombre AS unidad_nombre,
        CASE te.Nombre
            WHEN 'Animal'   THEN an.nombre_comun
            WHEN 'Vegetal'  THEN ve.nombre_comun
            WHEN 'Articulo' THEN ar.nombre
            WHEN 'Artículo' THEN ar.nombre
        END AS nombre_elemento
    FROM dbo.actividad_elementos e
    LEFT JOIN dbo.catalogo_tipo_items te ON te.Id_catalogo_item = e.tipo_elemento
    LEFT JOIN dbo.catalogo_tipo_items tm ON tm.Id_catalogo_item = e.tipo_movimiento
    LEFT JOIN dbo.catalogo_tipo_items un ON un.Id_catalogo_item = e.id_unidad
    LEFT JOIN dbo.animales  an ON an.id_animal   = e.id_elemento
    LEFT JOIN dbo.vegetales ve ON ve.id_vegetal  = e.id_elemento
    LEFT JOIN dbo.articulos ar ON ar.id_articulo = e.id_elemento
    WHERE e.id_actividad_modelo = @id_actividad_modelo
    ORDER BY ISNULL(e.orden, 2147483647), e.id_actividad_elemento;
END;
GO

IF OBJECT_ID(N'dbo.sp_insert_actividad_elemento', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_insert_actividad_elemento;
GO
CREATE PROCEDURE dbo.sp_insert_actividad_elemento
    @id_actividad_modelo BIGINT,
    @id_elemento         BIGINT,
    @tipo_elemento       INT,
    @tipo_movimiento     INT,
    @cantidad_prevista   DECIMAL(18,4),
    @id_unidad           INT,
    @obligatorio         BIT,
    @vendible_destino    BIT,
    @permite_sustitucion BIT,
    @observaciones       VARCHAR(1000) = NULL,
    @orden               INT           = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.actividad_elementos (
        id_actividad_modelo, id_elemento, tipo_elemento, tipo_movimiento, cantidad_prevista,
        id_unidad, obligatorio, vendible_destino, permite_sustitucion, observaciones, orden
    )
    VALUES (
        @id_actividad_modelo, @id_elemento, @tipo_elemento, @tipo_movimiento, @cantidad_prevista,
        @id_unidad, @obligatorio, @vendible_destino, @permite_sustitucion, @observaciones, @orden
    );
END;
GO

/* =====================================================================
   4) DATOS INICIALES  (solo se insertan si no existen)
   ===================================================================== */

-- ---------- 4.1 Cabeceras de catálogos (IDs fijos: el código los usa) ----------
INSERT INTO dbo.catalogos_tipo (Id_catalogo, Nombre, Activo)
SELECT v.Id, v.Nombre, 1
FROM (VALUES
    (1,  N'Tipo Animal'),
    (2,  N'Tipo de Cultivo'),
    (3,  N'Artículos / Categoría'),
    (4,  N'Estado Fenológico'),
    (5,  N'Rubro Animal'),
    (6,  N'Subrubro'),
    (7,  N'Método de Siembra'),
    (8,  N'Requerimiento Hídrico'),
    (9,  N'Ciclo de Vida'),
    (10, N'Marca Artículo'),
    (11, N'Tipo Elemento'),
    (12, N'Proveedor Stock'),
    (13, N'Pregunta de Seguridad'),
    (14, N'Modo inicio'),
    (15, N'Tipo Actividad'),
    (16, N'Tipo Movimiento'),
    (17, N'Tipo Unidad'),
    (18, N'Tipo Entornos')
) AS v (Id, Nombre)
WHERE NOT EXISTS (SELECT 1 FROM dbo.catalogos_tipo c WHERE c.Id_catalogo = v.Id);
GO

-- ---------- 4.2 Ítems de catálogos ----------
-- Se respeta el mismo orden del script original para que los Id_catalogo_item
-- queden iguales en una base nueva.
INSERT INTO dbo.catalogo_tipo_items (Id_catalog, Nombre, Activo)
SELECT v.Cat, v.Nombre, 1
FROM (VALUES
    -- 1: Tipo Animal
    (1,  N'Mamífero',          1), (1,  N'Ave',              2), (1,  N'Insecto',          3), (1,  N'Pez',            4),
    -- 5: Rubro Animal
    (5,  N'Bovino',            5), (5,  N'Apicola',          6), (5,  N'Porcino',          7), (5,  N'Ovino',          8), (5, N'Avícola', 9),
    -- 6: Subrubro / Raza
    (6,  N'Hereford',         10), (6,  N'Holando argentina',11), (6,  N'Bataraza',        12), (6,  N'Ponedora',      13),
    (6,  N'Africana',         14), (6,  N'Landrace',         15),
    -- 2: Tipo de Cultivo
    (2,  N'Hortícola',        16), (2,  N'Extensivo',        17), (2,  N'Frutícola',       18), (2,  N'Forrajero',     19), (2, N'Pastura', 20),
    -- 7: Método de Siembra
    (7,  N'Siembra directa',  21), (7,  N'Almácigo y trasplante', 22), (7, N'Hidroponía',  23),
    -- 4: Estado Fenológico
    (4,  N'Germinación',      24), (4,  N'Vegetativo',       25), (4,  N'Floración',       26), (4,  N'Fructificación',27), (4, N'Cosecha', 28),
    -- 8: Requerimiento Hídrico
    (8,  N'Alto',             29), (8,  N'Medio',            30), (8,  N'Bajo',            31),
    -- 9: Ciclo de Vida
    (9,  N'Anual',            32), (9,  N'Bianual',          33), (9,  N'Perenne',         34),
    -- 3: Categoría de Artículo
    (3,  N'engorde',          35), (3,  N'pañol',            36), (3,  N'insumos',         37), (3,  N'otros',         38),
    -- 10: Marca
    (10, N'Genérica',         39),
    -- 12: Proveedor
    (12, N'Proveedor General',40),
    -- 11: Tipo Elemento (el SP sp_select_elementos_por_tipo depende de estos nombres)
    (11, N'Articulo',         41), (11, N'Vegetal',          42), (11, N'Animal',          43),
    -- 13: Preguntas de seguridad
    (13, N'¿Cuál es el nombre de tu primera mascota?',   44),
    (13, N'¿En qué ciudad naciste?',                     45),
    (13, N'¿Cuál es el apellido de soltera de tu madre?',46),
    (13, N'¿Cuál era el nombre de tu primera escuela?',  47),
    -- 14: Modo Inicio
    (14, N'Manual',           48), (14, N'Automático',       49), (14, N'Semicontrolado',  50),
    -- 15: Tipo Actividad
    (15, N'Secuencial',       51), (15, N'Paralela',         52), (15, N'Condicionada',    53),
    -- 16: Tipo Movimiento (el formulario de ciclos busca "Entrada" y "Salida" por nombre)
    (16, N'Entrada',          54), (16, N'Salida',           55),
    -- 17: Tipo Unidad
    (17, N'Kilogramos (kg)',  56), (17, N'Gramos (g)',       57), (17, N'Litros (l)',      58),
    (17, N'Unidades (u)',     59), (17, N'Hectáreas (ha)',   60), (17, N'Atados / Bultos', 61),
    -- 18: Tipo Entornos
    (18, N'Animal',           62), (18, N'Vegetal',          63), (18, N'Industria',       64),
    (18, N'Compras',          65), (18, N'Pañol',            66)
) AS v (Cat, Nombre, Orden)
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.catalogo_tipo_items i
    WHERE i.Id_catalog = v.Cat AND i.Nombre = v.Nombre
)
ORDER BY v.Orden;
GO

-- ---------- 4.3 Partidos y Localidades ----------
INSERT INTO dbo.Partidos (NombrePartido)
SELECT v.Nombre
FROM (VALUES (N'Almirante Brown', 1), (N'San Vicente', 2)) AS v (Nombre, Orden)
WHERE NOT EXISTS (SELECT 1 FROM dbo.Partidos p WHERE p.NombrePartido = v.Nombre)
ORDER BY v.Orden;
GO

INSERT INTO dbo.Localidades (NombreLocalidad, CodigoPostal, IdPartido)
SELECT v.Localidad, v.CP, p.IdPartido
FROM (VALUES
    (N'Adrogué',                     1846, N'Almirante Brown',  1),
    (N'Burzaco',                     1852, N'Almirante Brown',  2),
    (N'Claypole',                    1849, N'Almirante Brown',  3),
    (N'Glew',                        1856, N'Almirante Brown',  4),
    (N'Longchamps',                  1854, N'Almirante Brown',  5),
    (N'Malvinas Argentinas (Brown)', 1847, N'Almirante Brown',  6),
    (N'Ministro Rivadavia',          1854, N'Almirante Brown',  7),
    (N'San José',                    1846, N'Almirante Brown',  8),
    (N'Soledad',                     1853, N'Almirante Brown',  9),
    (N'Rafael Calzada',              1847, N'Almirante Brown', 10),
    (N'San Vicente',                 1865, N'San Vicente',     11),
    (N'Alejandro Korn',              1864, N'San Vicente',     12),
    (N'Domselaar',                   1984, N'San Vicente',     13),
    (N'Villa Coll',                  1865, N'San Vicente',     14),
    (N'Laguna del Ojo',              1865, N'San Vicente',     15),
    (N'Estancia El Pino',            1865, N'San Vicente',     16),
    (N'Paraje La Laurita',           1865, N'San Vicente',     17),
    (N'Campo de Mayo Chico',         1865, N'San Vicente',     18)
) AS v (Localidad, CP, Partido, Orden)
INNER JOIN dbo.Partidos p ON p.NombrePartido = v.Partido
WHERE NOT EXISTS (SELECT 1 FROM dbo.Localidades l WHERE l.NombreLocalidad = v.Localidad)
ORDER BY v.Orden;
GO

-- ---------- 4.4 Usuarios y permisos ----------
-- (El script viejo insertaba en "AbmUsuario", que no existe en esta base)
DECLARE @IdLocalidad INT = (SELECT TOP 1 IdLocalidad FROM dbo.Localidades WHERE NombreLocalidad = N'Adrogué');
DECLARE @IdPartido   INT = (SELECT TOP 1 IdPartido   FROM dbo.Partidos    WHERE NombrePartido   = N'Almirante Brown');
DECLARE @IdPregunta  INT = (SELECT MIN(Id_catalogo_item) FROM dbo.catalogo_tipo_items WHERE Id_catalog = 13);

INSERT INTO dbo.usuarios (Nombre, Apellido, Documento, Telefono, Direccion, IdLocalidad, IdPartido, Email,
                          NombreUsuario, Contraseña, IdPreguntaSeguridad, RespuestaSeguridad, Estado)
SELECT v.Nombre, v.Apellido, v.Documento, v.Telefono, v.Direccion, @IdLocalidad, @IdPartido, v.Email,
       v.Usuario, '1234', @IdPregunta, 'Default', 1
FROM (VALUES
    ('Administrador', 'General', 0,        '0000000000', 'Sistema',     'admin@agraria.com',         'ADMIN',    1),
    ('Usuario',       'dos',     11111111, '1111111111', 'Direccion 1', 'usuariodos@agraria.com',    'usudos',   2),
    ('Usuario',       'tres',    22222222, '2222222222', 'Direccion 2', 'usuariotres@agraria.com',   'ustres',   3),
    ('Usuario',       'cuatro',  33333333, '3333333333', 'Direccion 3', 'usuariocuatro@agraria.com', 'uscuatro', 4),
    ('Usuario',       'cinco',   44444444, '4444444444', 'Direccion 4', 'usuariocinco@agraria.com',  'uscinco',  5)
) AS v (Nombre, Apellido, Documento, Telefono, Direccion, Email, Usuario, Orden)
WHERE NOT EXISTS (SELECT 1 FROM dbo.usuarios u WHERE u.NombreUsuario = v.Usuario)
ORDER BY v.Orden;

INSERT INTO dbo.PermisosUsuario (IdUsuario, PuedeEntornoFormativo, PuedeAltaUsuario, PuedeVenta, PuedeInventario,
                                 PuedeIndustria, PuedeProduccionAnimal, PuedeProduccionVegetal, PuedeAdministracion, PuedePañol)
SELECT u.Id,
       1,
       CASE WHEN u.NombreUsuario = 'ADMIN' THEN 1 ELSE 0 END,
       1,
       1,
       CASE WHEN u.NombreUsuario = 'ADMIN' THEN 1 ELSE 0 END,
       1,
       1,
       CASE WHEN u.NombreUsuario = 'ADMIN' THEN 1 ELSE 0 END,
       1
FROM dbo.usuarios u
WHERE u.NombreUsuario IN ('ADMIN', 'usudos', 'ustres', 'uscuatro', 'uscinco')
  AND NOT EXISTS (SELECT 1 FROM dbo.PermisosUsuario p WHERE p.IdUsuario = u.Id);
GO

-- ---------- 4.5 Rubros y subrubros ----------
-- id_tipo = ítem del catálogo 1 (Mamífero / Ave / Insecto), buscado por nombre
INSERT INTO dbo.rubros (id_tipo, nombre)
SELECT t.Id_catalogo_item, v.Rubro
FROM (VALUES
    (N'Bovinos',  N'Mamífero', 1),
    (N'Porcinos', N'Mamífero', 2),
    (N'Ovino',    N'Mamífero', 3),
    (N'Avícola',  N'Ave',      4),
    (N'Apícola',  N'Insecto',  5)
) AS v (Rubro, Tipo, Orden)
INNER JOIN dbo.catalogo_tipo_items t ON t.Id_catalog = 1 AND t.Nombre = v.Tipo
WHERE NOT EXISTS (SELECT 1 FROM dbo.rubros r WHERE r.nombre = v.Rubro)
ORDER BY v.Orden;
GO

INSERT INTO dbo.subrubros (id_rubro, nombre)
SELECT r.id_rubro, v.Subrubro
FROM (VALUES
    (N'Hereford',          N'Bovinos',  1),
    (N'Holando argentina', N'Bovinos',  2),
    (N'Bataraza',          N'Avícola',  3),
    (N'Ponedora',          N'Avícola',  4),
    (N'Africana',          N'Apícola',  5),
    (N'Landrace',          N'Porcinos', 6)
) AS v (Subrubro, Rubro, Orden)
INNER JOIN dbo.rubros r ON r.nombre = v.Rubro
WHERE NOT EXISTS (SELECT 1 FROM dbo.subrubros s WHERE s.nombre = v.Subrubro)
ORDER BY v.Orden;
GO

-- ---------- 4.6 Marcas ----------
INSERT INTO dbo.marcas (nombre)
SELECT v.Nombre
FROM (VALUES (N'Propia', 1), (N'Otro', 2), (N'Molinos', 3)) AS v (Nombre, Orden)
WHERE NOT EXISTS (SELECT 1 FROM dbo.marcas m WHERE m.nombre = v.Nombre)
ORDER BY v.Orden;
GO

-- ---------- 4.7 Proveedores ----------
INSERT INTO dbo.proveedores (nombre, cuil, telefono, direccion, mail)
SELECT v.Nombre, v.Cuil, v.Tel, v.Dir, v.Mail
FROM (VALUES
    (N'Agroinsumos Pampeanos S.A.',      '30-12345678-9', '011-5555-1010', N'Ruta 5 Km 100, Mercedes, BA',          'ventas@agropampeanos.com.ar',  1),
    (N'Semillas y Forrajes Del Sur SRL', '30-87654321-1', '0223-456-7890', N'Av. Circunvalación 1200, Tandil, BA',  'contacto@semillasdelsur.com.ar',2),
    (N'Veterinaria El Estribo',          '27-11223344-5', '0221-333-4444', N'Calle 44 Nro 1500, La Plata, BA',      'info@vet-elestribo.com.ar',    3)
) AS v (Nombre, Cuil, Tel, Dir, Mail, Orden)
WHERE NOT EXISTS (SELECT 1 FROM dbo.proveedores p WHERE p.nombre = v.Nombre)
ORDER BY v.Orden;
GO

-- ---------- 4.8 Tipos de entorno (tabla TipoEntornos) ----------
INSERT INTO dbo.TipoEntornos (Nombre)
SELECT v.Nombre
FROM (VALUES (N'Animal', 1), (N'Vegetal', 2), (N'Industria', 3), (N'Compras', 4), (N'Pañol', 5)) AS v (Nombre, Orden)
WHERE NOT EXISTS (SELECT 1 FROM dbo.TipoEntornos t WHERE t.Nombre = v.Nombre)
ORDER BY v.Orden;
GO

/* =====================================================================
   5) VERIFICACIÓN RÁPIDA
   ===================================================================== */
SELECT 'Tablas'            AS Objeto, COUNT(*) AS Cantidad FROM sys.tables
UNION ALL
SELECT 'Stored procedures',           COUNT(*)             FROM sys.procedures
UNION ALL
SELECT 'Ítems de catálogo',           COUNT(*)             FROM dbo.catalogo_tipo_items
UNION ALL
SELECT 'Usuarios',                    COUNT(*)             FROM dbo.usuarios;
GO

PRINT 'AgrariaNueva2 creada / actualizada correctamente.';
GO
