USE [Agraria]
GO

/****** Objeto: StoredProcedure [dbo].[sp_select_articulos] Fecha de script: 20/9/2026 18:22:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- 4. Stored Procedure: Seleccionar Artículos (con marca y categoría)
CREATE   PROCEDURE [dbo].[sp_select_articulos]
AS
BEGIN
    SELECT 
        a.id_articulo,
        a.nombre AS nombre_articulo,
        m.nombre AS marca,
        a.fecha_alta,
        c.nombre AS categoria
    FROM articulos a
    LEFT JOIN marca m ON a.id_marca = m.id_marca
    LEFT JOIN categoria c ON a.id_categoria = c.id_categoria;
END
GO


