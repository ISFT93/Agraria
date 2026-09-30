ALTER PROCEDURE [dbo].[sp_insert_articulo]
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