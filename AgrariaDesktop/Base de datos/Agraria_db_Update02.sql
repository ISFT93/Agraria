
-- ==========================================
-- STORED PROCEDURES: VEGETAL
-- ==========================================

-- 1. SP: Insertar Vegetal
CREATE PROCEDURE sp_insert_vegetal
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

-- 2. SP: Actualizar Vegetal
CREATE PROCEDURE sp_update_vegetal
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


--- sp Select

CREATE PROCEDURE sp_select_vegetal
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

-- SP para ObtenerPorId
CREATE PROCEDURE sp_select_vegetal_por_id
    @id BIGINT
AS
BEGIN
    SELECT * FROM vegetal WHERE id_vegetal = @id;
END;
GO

-- SP para ObtenerCombo (Usa SQL dinámico seguro para el nombre de la tabla)
CREATE PROCEDURE sp_select_combo
    @tabla NVARCHAR(100)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'SELECT * FROM ' + QUOTENAME(@tabla);
    EXEC sp_executesql @sql;
END;
GO

-- SP para ObtenerRequerimientoHidrico
CREATE PROCEDURE sp_select_requerimiento_hidrico
AS
BEGIN
    SELECT 'Alto' AS nombre UNION SELECT 'Medio' UNION SELECT 'Bajo';
END;
GO

-- SP para ObtenerUltimoIdPorUsuario
CREATE PROCEDURE sp_select_ultimo_id_vegetal
    @min BIGINT,
    @max BIGINT
AS
BEGIN
    SELECT ISNULL(MAX(id_vegetal), 0) FROM vegetal WHERE id_vegetal >= @min AND id_vegetal < @max;
END;
GO