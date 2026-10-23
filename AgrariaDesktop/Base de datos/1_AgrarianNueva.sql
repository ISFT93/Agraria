USE [AgrariaNueva2]
GO
/****** Object:  Table [dbo].[animales]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[animales](
	[id_animal] [bigint] NOT NULL,
	[nombre_comun] [varchar](100) NULL,
	[nombre_cientifico] [varchar](150) NULL,
	[id_tipo] [int] NULL,
	[id_rubro] [int] NULL,
	[id_subrubro] [int] NULL,
	[stock_minimo] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_animal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[articulos]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulos](
	[id_articulo] [bigint] NOT NULL,
	[nombre] [varchar](150) NULL,
	[id_marca] [int] NULL,
	[stock_minimo] [float] NULL,
	[id_categoria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catalogo_tipo_items]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catalogo_tipo_items](
	[Id_catalogo_item] [int] IDENTITY(1,1) NOT NULL,
	[Id_catalog] [bigint] NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_catalogo_item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catalogos_tipo]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catalogos_tipo](
	[Id_catalogo] [bigint] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_catalogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[datosAnimales]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[datosAnimales](
	[id_detalle] [int] IDENTITY(1,1) NOT NULL,
	[id_stock] [bigint] NOT NULL,
	[nro_animal] [varchar](50) NULL,
	[sexo] [varchar](20) NULL,
	[es_productor] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entornos]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entornos](
	[IdEntorno] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
	[IdTipoEntorno] [int] NULL,
	[Responsable] [varchar](150) NULL,
	[Año] [varchar](10) NULL,
	[Division] [varchar](10) NULL,
	[Grupo] [varchar](50) NULL,
	[Fecha] [datetime] NULL,
	[Observaciones] [varchar](max) NULL,
 CONSTRAINT [PK_Entorno] PRIMARY KEY CLUSTERED 
(
	[IdEntorno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[IdLocalidad] [int] IDENTITY(1,1) NOT NULL,
	[NombreLocalidad] [varchar](100) NULL,
	[CodigoPostal] [int] NULL,
	[IdPartido] [int] NULL,
 CONSTRAINT [PK_Localidad] PRIMARY KEY CLUSTERED 
(
	[IdLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marcas]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marcas](
	[id_marca] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partidos]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partidos](
	[IdPartido] [int] IDENTITY(1,1) NOT NULL,
	[NombrePartido] [varchar](100) NULL,
 CONSTRAINT [PK_Partido] PRIMARY KEY CLUSTERED 
(
	[IdPartido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermisosUsuario]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisosUsuario](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[PuedeEntornoFormativo] [bit] NULL,
	[PuedeAltaUsuario] [bit] NULL,
	[PuedeVenta] [bit] NULL,
	[PuedeInventario] [bit] NULL,
	[PuedeIndustria] [bit] NULL,
	[PuedeProduccionAnimal] [bit] NULL,
	[PuedeProduccionVegetal] [bit] NULL,
	[PuedeAdministracion] [bit] NULL,
	[PuedePañol] [bit] NULL,
 CONSTRAINT [PK_PermisosUsuario] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedores]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedores](
	[id_proveedor] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NULL,
	[cuil] [varchar](20) NULL,
	[telefono] [varchar](30) NULL,
	[direccion] [varchar](100) NULL,
	[mail] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rubros]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rubros](
	[id_rubro] [int] IDENTITY(1,1) NOT NULL,
	[id_tipo] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_rubro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stock]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stock](
	[id_stock] [bigint] NOT NULL,
	[id_elemento] [bigint] NOT NULL,
	[tipo_elemento] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[ciclo] [varchar](50) NULL,
	[fecha_alta] [date] NOT NULL,
	[fecha_baja] [date] NULL,
	[cantidad] [decimal](10, 2) NULL,
	[nro_animal] [varchar](50) NULL,
	[estado_salud] [varchar](50) NULL,
	[es_productor] [bit] NULL,
	[precio] [money] NULL,
	[id_proveedor] [bigint] NULL,
	[activo] [bit] NULL,
	[vendible] [bit] NULL,
	[motivo_movimiento] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_stock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subrubros]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subrubros](
	[id_subrubro] [int] IDENTITY(1,1) NOT NULL,
	[id_rubro] [int] NOT NULL,
	[nombre] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_subrubro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEntornos]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEntornos](
	[IdTipoEntorno] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK_TipoEntorno] PRIMARY KEY CLUSTERED 
(
	[IdTipoEntorno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](100) NULL,
	[Documento] [int] NULL,
	[Telefono] [varchar](20) NULL,
	[Direccion] [varchar](200) NULL,
	[IdLocalidad] [int] NULL,
	[IdPartido] [int] NULL,
	[Email] [varchar](150) NULL,
	[NombreUsuario] [varchar](100) NULL,
	[Contraseña] [varchar](100) NULL,
	[IdPreguntaSeguridad] [int] NULL,
	[RespuestaSeguridad] [varchar](200) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_AbmUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vegetales]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vegetales](
	[id_vegetal] [bigint] NOT NULL,
	[nombre_comun] [varchar](40) NOT NULL,
	[nombre_cientifico] [varchar](40) NULL,
	[variedad_hibrido] [varchar](40) NULL,
	[id_tipo_cultivo] [int] NULL,
	[id_ciclo_vida] [int] NULL,
	[periodosiembra] [varchar](10) NULL,
	[id_metodo_siembra] [int] NULL,
	[id_estado_fenologico] [int] NULL,
	[requerimiento_hidrico] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_vegetal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[catalogo_tipo_items] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[catalogos_tipo] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[PermisosUsuario] ADD  DEFAULT ((0)) FOR [PuedeEntornoFormativo]
GO
ALTER TABLE [dbo].[PermisosUsuario] ADD  DEFAULT ((0)) FOR [PuedeAltaUsuario]
GO
ALTER TABLE [dbo].[PermisosUsuario] ADD  DEFAULT ((0)) FOR [PuedeVenta]
GO
ALTER TABLE [dbo].[PermisosUsuario] ADD  DEFAULT ((0)) FOR [PuedeInventario]
GO
ALTER TABLE [dbo].[PermisosUsuario] ADD  DEFAULT ((0)) FOR [PuedeIndustria]
GO
ALTER TABLE [dbo].[PermisosUsuario] ADD  DEFAULT ((0)) FOR [PuedeProduccionAnimal]
GO
ALTER TABLE [dbo].[PermisosUsuario] ADD  DEFAULT ((0)) FOR [PuedeProduccionVegetal]
GO
ALTER TABLE [dbo].[PermisosUsuario] ADD  DEFAULT ((0)) FOR [PuedeAdministracion]
GO
ALTER TABLE [dbo].[PermisosUsuario] ADD  DEFAULT ((1)) FOR [PuedePañol]
GO
ALTER TABLE [dbo].[stock] ADD  DEFAULT ((0.00)) FOR [cantidad]
GO
ALTER TABLE [dbo].[stock] ADD  DEFAULT ((0)) FOR [es_productor]
GO
ALTER TABLE [dbo].[stock] ADD  DEFAULT ((1)) FOR [activo]
GO
ALTER TABLE [dbo].[stock] ADD  DEFAULT ((0)) FOR [vendible]
GO
ALTER TABLE [dbo].[usuarios] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[animales]  WITH CHECK ADD  CONSTRAINT [fk_anim_rubro] FOREIGN KEY([id_rubro])
REFERENCES [dbo].[rubros] ([id_rubro])
GO
ALTER TABLE [dbo].[animales] CHECK CONSTRAINT [fk_anim_rubro]
GO
ALTER TABLE [dbo].[animales]  WITH CHECK ADD  CONSTRAINT [fk_anim_subrubro] FOREIGN KEY([id_subrubro])
REFERENCES [dbo].[subrubros] ([id_subrubro])
GO
ALTER TABLE [dbo].[animales] CHECK CONSTRAINT [fk_anim_subrubro]
GO
ALTER TABLE [dbo].[articulos]  WITH CHECK ADD  CONSTRAINT [fk_articulos_marca] FOREIGN KEY([id_marca])
REFERENCES [dbo].[marcas] ([id_marca])
GO
ALTER TABLE [dbo].[articulos] CHECK CONSTRAINT [fk_articulos_marca]
GO
ALTER TABLE [dbo].[catalogo_tipo_items]  WITH CHECK ADD FOREIGN KEY([Id_catalog])
REFERENCES [dbo].[catalogos_tipo] ([Id_catalogo])
GO
ALTER TABLE [dbo].[datosAnimales]  WITH CHECK ADD  CONSTRAINT [FK_stock_datosAnimales] FOREIGN KEY([id_stock])
REFERENCES [dbo].[stock] ([id_stock])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[datosAnimales] CHECK CONSTRAINT [FK_stock_datosAnimales]
GO
ALTER TABLE [dbo].[Entornos]  WITH CHECK ADD FOREIGN KEY([IdTipoEntorno])
REFERENCES [dbo].[TipoEntornos] ([IdTipoEntorno])
GO
ALTER TABLE [dbo].[Localidades]  WITH NOCHECK ADD FOREIGN KEY([IdPartido])
REFERENCES [dbo].[Partidos] ([IdPartido])
GO
ALTER TABLE [dbo].[PermisosUsuario]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[usuarios] ([Id])
GO
ALTER TABLE [dbo].[subrubros]  WITH CHECK ADD  CONSTRAINT [fk_rubro] FOREIGN KEY([id_rubro])
REFERENCES [dbo].[rubros] ([id_rubro])
GO
ALTER TABLE [dbo].[subrubros] CHECK CONSTRAINT [fk_rubro]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD FOREIGN KEY([IdPartido])
REFERENCES [dbo].[Partidos] ([IdPartido])
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD FOREIGN KEY([IdPartido])
REFERENCES [dbo].[Partidos] ([IdPartido])
GO
ALTER TABLE [dbo].[vegetales]  WITH CHECK ADD CHECK  (([requerimiento_hidrico]='Bajo' OR [requerimiento_hidrico]='Medio' OR [requerimiento_hidrico]='Alto'))
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_articulo]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_delete_articulo]
    @id_articulo BIGINT
AS
BEGIN
    DELETE FROM articulos 
    WHERE id_articulo = @id_articulo;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_articulo]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_insert_detalle_animal]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_insert_detalle_animal]
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
/****** Object:  StoredProcedure [dbo].[sp_insert_stock]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_insert_stock]
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
/****** Object:  StoredProcedure [dbo].[sp_insert_vegetales]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insert_vegetales]
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
/****** Object:  StoredProcedure [dbo].[sp_insertanimales]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertanimales]
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

    INSERT INTO animales (
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
/****** Object:  StoredProcedure [dbo].[sp_obtener_detalle_animales_por_stock]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_obtener_detalle_animales_por_stock]
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
/****** Object:  StoredProcedure [dbo].[sp_obtener_ultimo_id_elemento]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_select_articulos]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_select_combo]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_select_proveedores]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_select_proveedores]
AS
BEGIN
    SELECT id_proveedor, nombre FROM proveedores ORDER BY nombre ASC;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_select_requerimiento_hidrico]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_select_requerimiento_hidrico]
AS
BEGIN
    SELECT 'Alto' AS nombre UNION SELECT 'Medio' UNION SELECT 'Bajo';
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_select_stock]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_select_stock]
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
/****** Object:  StoredProcedure [dbo].[sp_select_stock_por_id]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_select_stock_por_id]
    @id BIGINT
AS
BEGIN
    SELECT * FROM stock WHERE id_stock = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_select_ultimo_id_animal]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_select_ultimo_id_animal]
    @min bigint,
    @max bigint
AS
BEGIN
    SET NOCOUNT ON;

    SELECT isnull(max(id_animal), 0)
    FROM animales
    WHERE id_animal >= @min AND id_animal <= @max;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_select_ultimo_id_vegetal]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_select_ultimo_id_vegetal]
    @min BIGINT,
    @max BIGINT
AS
BEGIN
    SELECT ISNULL(MAX(id_vegetal), 0) FROM vegetal WHERE id_vegetal >= @min AND id_vegetal < @max;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_select_vegetal_por_id]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_select_vegetal_por_id]
    @id BIGINT
AS
BEGIN
    SELECT * FROM vegetal WHERE id_vegetal = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_select_vegetales]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_select_vegetales]
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
    FROM vegetales v
    LEFT JOIN catalogo_tipo_items tc ON v.id_tipo_cultivo = tc.Id_catalogo_item
    LEFT JOIN catalogo_tipo_items cv ON v.id_ciclo_vida = cv.Id_catalogo_item
    LEFT JOIN catalogo_tipo_items ms ON v.id_metodo_siembra = ms.Id_catalogo_item
    LEFT JOIN catalogo_tipo_items ef ON v.id_estado_fenologico = ef.Id_catalogo_item
    WHERE (@filtro = '' OR v.nombre_comun LIKE '%' + @filtro + '%' OR v.variedad_hibrido LIKE '%' + @filtro + '%');
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_selectanimales]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_selectanimales]
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
    FROM animales a
    LEFT JOIN catalogo_tipo_items t ON a.id_tipo = t.Id_catalogo_item
    LEFT JOIN rubros r ON a.id_rubro = r.id_rubro
    LEFT JOIN subrubros sr ON a.id_subrubro = sr.id_subrubro;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_update_articulo]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_update_detalle_animal]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_update_detalle_animal]
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
/****** Object:  StoredProcedure [dbo].[sp_update_stock]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_update_stock]
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
/****** Object:  StoredProcedure [dbo].[sp_update_vegetal]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[sp_updateanimal]    Script Date: 23/10/2026 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
