USE [Agraria]
GO

/****** Objeto: StoredProcedure [dbo].[sp_update_articulo] Fecha de script: 20/9/2026 18:22:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- 6. Stored Procedure: Modificar Artículo
CREATE   PROCEDURE [dbo].[sp_update_articulo]
    @id_articulo BIGINT,
    @nombre VARCHAR(150),
    @id_marca INT,
    @fecha_alta DATE,
    @id_categoria INT
AS
BEGIN
    UPDATE articulos
    SET nombre = @nombre,
        id_marca = @id_marca,
        fecha_alta = @fecha_alta,
        id_categoria = @id_categoria
    WHERE id_articulo = @id_articulo;
END
GO


