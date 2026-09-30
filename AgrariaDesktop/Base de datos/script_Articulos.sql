USE [Agraria]
GO

-- ==========================================================
-- 1. CREACIÓN DE LA TABLA (Sin IDENTITY, con stock_minimo como float)
-- ==========================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('dbo.articulos', 'U') IS NOT NULL
    DROP TABLE dbo.articulos;
GO

CREATE TABLE [dbo].[articulos](
	[id_articulo] [bigint] NOT NULL,
	[nombre] [varchar](150) NULL,
	[id_marca] [int] NULL,
	[stock_minimo] [float] NULL,
	[id_categoria] [int] NULL,
	PRIMARY KEY CLUSTERED ([id_articulo] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- ==========================================================
-- 2. RELACIONES / FOREIGN KEYS (ALTER TABLE)
-- ==========================================================
ALTER TABLE [dbo].[articulos] WITH CHECK ADD CONSTRAINT [fk_articulos_categoria] FOREIGN KEY([id_categoria]) REFERENCES [dbo].[categoria] ([id_categoria])
GO
ALTER TABLE [dbo].[articulos] CHECK CONSTRAINT [fk_articulos_categoria]
GO
ALTER TABLE [dbo].[articulos] WITH CHECK ADD CONSTRAINT [fk_articulos_marca] FOREIGN KEY([id_marca]) REFERENCES [dbo].[marca] ([id_marca])
GO
ALTER TABLE [dbo].[articulos] CHECK CONSTRAINT [fk_articulos_marca]
GO

-- ==========================================================
-- 3. PROCEDIMIENTOS ALMACENADOS
-- ==========================================================

-- A. Insertar Artículo
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[sp_insert_articulo]
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

-- B. Modificar Artículo
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[sp_update_articulo]
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

-- C. Eliminar Artículo
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[sp_delete_articulo]
    @id_articulo BIGINT
AS
BEGIN
    DELETE FROM articulos 
    WHERE id_articulo = @id_articulo;
END
GO