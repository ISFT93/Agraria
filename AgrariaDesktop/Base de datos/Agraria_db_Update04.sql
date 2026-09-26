USE [Agraria]
GO

/****** Objeto: StoredProcedure [dbo].[sp_insert_articulo] Fecha de script: 20/9/2026 18:21:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- 3. Actualizamos el procedimiento almacenado por las dudas
CREATE   PROCEDURE [dbo].[sp_insert_articulo]
    @id_articulo BIGINT,
    @nombre VARCHAR(150),
    @id_marca INT,
    @fecha_alta DATE,
    @id_categoria INT
AS
BEGIN
    INSERT INTO articulos (id_articulo, nombre, id_marca, fecha_alta, id_categoria)
    VALUES (@id_articulo, @nombre, @id_marca, @fecha_alta, @id_categoria);
END
GO


