-- 1. Agregar la columna 'sexo' a la tabla datosAnimales si es que no existe
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('datosAnimales') AND name = 'sexo')
BEGIN
    ALTER TABLE datosAnimales ADD sexo VARCHAR(20) NULL;
END
GO

-- 2. Recrear el procedimiento almacenado sp_insert_detalle_animal limpiamente
CREATE OR ALTER PROCEDURE sp_insert_detalle_animal
    @id_stock BIGINT,
    @nro_animal VARCHAR(50),
    @sexo VARCHAR(20),
    @es_productor BIT
AS
BEGIN
    INSERT INTO datosAnimales (id_stock, nro_animal, sexo, es_productor)
    VALUES (@id_stock, @nro_animal, @sexo, @es_productor);
END
GO