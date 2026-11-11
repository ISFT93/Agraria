/* =====================================================================
   AgrariaNueva2 - DATOS DE EJEMPLO: Animales, Vegetales y Artículos
   ---------------------------------------------------------------------
   Ejecutar DESPUÉS de AgrariaNueva2_COMPLETO.sql (necesita los catálogos,
   rubros, subrubros, marcas y el usuario ADMIN).

   - Los IDs se generan con la MISMA lógica que la aplicación, a nombre del
     usuario ADMIN, así después la app sigue numerando sin chocar:
         Vegetales : [IdUsuario] 1 xxxx   (ej. ADMIN=1 -> 110001, 110002...)
         Artículos : [IdUsuario] 2 xxxx   (ej. ADMIN=1 -> 120000, 120001...)
         Animales  : [IdUsuario] 3 xxxx   (ej. ADMIN=1 -> 130001, 130002...)
   - Los catálogos se buscan por NOMBRE, no por ID fijo.
   - Se puede ejecutar más de una vez: no duplica registros.
   ===================================================================== */

USE [AgrariaNueva2];
GO

SET NOCOUNT ON;
GO

/* =====================================================================
   0) Subrubros que faltaban para tener todos los rubros cubiertos
   ===================================================================== */
INSERT INTO dbo.subrubros (id_rubro, nombre)
SELECT r.id_rubro, v.Subrubro
FROM (VALUES
    (N'Aberdeen Angus', N'Bovinos'),
    (N'Corriedale',     N'Ovino'),
    (N'Parrillero',     N'Avícola')
) AS v (Subrubro, Rubro)
INNER JOIN dbo.rubros r ON r.nombre = v.Rubro
WHERE NOT EXISTS (SELECT 1 FROM dbo.subrubros s WHERE s.nombre = v.Subrubro);
GO

/* =====================================================================
   1) ANIMALES
   ===================================================================== */
DECLARE @IdUsuario BIGINT = (SELECT Id FROM dbo.usuarios WHERE NombreUsuario = 'ADMIN');
IF @IdUsuario IS NULL
BEGIN
    RAISERROR('No existe el usuario ADMIN. Ejecute primero AgrariaNueva2_COMPLETO.sql', 16, 1);
    RETURN;
END;

DECLARE @Base   BIGINT = @IdUsuario * 100000 + 30000;   -- rango de animales
DECLARE @Ultimo BIGINT = (SELECT ISNULL(MAX(id_animal), @Base) FROM dbo.animales
                          WHERE id_animal >= @Base AND id_animal <= @Base + 9999);

;WITH datos AS (
    SELECT * FROM (VALUES
        -- nombre_comun,          nombre_cientifico,              tipo (cat. 1), rubro,      subrubro,            stock_min, orden
        (N'Vaca Hereford',        N'Bos taurus',                  N'Mamífero',   N'Bovinos',  N'Hereford',          5,   1),
        (N'Toro Hereford',        N'Bos taurus',                  N'Mamífero',   N'Bovinos',  N'Hereford',          1,   2),
        (N'Vaca Holando',         N'Bos taurus',                  N'Mamífero',   N'Bovinos',  N'Holando argentina', 5,   3),
        (N'Ternero Holando',      N'Bos taurus',                  N'Mamífero',   N'Bovinos',  N'Holando argentina', 2,   4),
        (N'Novillo Angus',        N'Bos taurus',                  N'Mamífero',   N'Bovinos',  N'Aberdeen Angus',    3,   5),
        (N'Cerda Landrace',       N'Sus scrofa domesticus',       N'Mamífero',   N'Porcinos', N'Landrace',          3,   6),
        (N'Lechón Landrace',      N'Sus scrofa domesticus',       N'Mamífero',   N'Porcinos', N'Landrace',          6,   7),
        (N'Oveja Corriedale',     N'Ovis aries',                  N'Mamífero',   N'Ovino',    N'Corriedale',        4,   8),
        (N'Cordero Corriedale',   N'Ovis aries',                  N'Mamífero',   N'Ovino',    N'Corriedale',        2,   9),
        (N'Gallina Ponedora',     N'Gallus gallus domesticus',    N'Ave',        N'Avícola',  N'Ponedora',          20, 10),
        (N'Gallina Bataraza',     N'Gallus gallus domesticus',    N'Ave',        N'Avícola',  N'Bataraza',          10, 11),
        (N'Pollo Parrillero',     N'Gallus gallus domesticus',    N'Ave',        N'Avícola',  N'Parrillero',        30, 12),
        (N'Colmena Abeja Africana', N'Apis mellifera scutellata', N'Insecto',    N'Apícola',  N'Africana',          2,  13)
    ) AS v (Nombre, Cientifico, Tipo, Rubro, Subrubro, StockMin, Orden)
),
nuevos AS (
    SELECT d.*, ROW_NUMBER() OVER (ORDER BY d.Orden) AS nro
    FROM datos d
    WHERE NOT EXISTS (SELECT 1 FROM dbo.animales a WHERE a.nombre_comun = d.Nombre)
)
INSERT INTO dbo.animales (id_animal, nombre_comun, nombre_cientifico, id_tipo, id_rubro, id_subrubro, stock_minimo)
SELECT
    @Ultimo + n.nro,
    n.Nombre,
    n.Cientifico,
    t.Id_catalogo_item,
    r.id_rubro,
    s.id_subrubro,
    n.StockMin
FROM nuevos n
LEFT JOIN dbo.catalogo_tipo_items t ON t.Id_catalog = 1 AND t.Nombre = n.Tipo
LEFT JOIN dbo.rubros r              ON r.nombre = n.Rubro
LEFT JOIN dbo.subrubros s           ON s.nombre = n.Subrubro AND s.id_rubro = r.id_rubro;

PRINT CONCAT('Animales insertados: ', @@ROWCOUNT);
GO

/* =====================================================================
   2) VEGETALES
   periodosiembra admite hasta 10 caracteres (ej. 'Mar-May')
   requerimiento_hidrico solo admite 'Alto', 'Medio' o 'Bajo'
   ===================================================================== */
DECLARE @IdUsuario BIGINT = (SELECT Id FROM dbo.usuarios WHERE NombreUsuario = 'ADMIN');
DECLARE @Base   BIGINT = @IdUsuario * 100000 + 10000;   -- rango de vegetales
DECLARE @Ultimo BIGINT = (SELECT ISNULL(MAX(id_vegetal), @Base) FROM dbo.vegetales
                          WHERE id_vegetal >= @Base AND id_vegetal < @Base + 10000);

;WITH datos AS (
    SELECT * FROM (VALUES
        -- nombre_comun, nombre_cientifico,            variedad,          tipo cultivo (2), ciclo vida (9), período,  método siembra (7),        estado fenológico (4), req. hídrico, orden
        (N'Lechuga',     N'Lactuca sativa',            N'Mantecosa',      N'Hortícola',  N'Anual',   'Mar-May', N'Almácigo y trasplante', N'Germinación',    'Alto',   1),
        (N'Lechuga',     N'Lactuca sativa',            N'Grand Rapids',   N'Hortícola',  N'Anual',   'Todo año', N'Hidroponía',           N'Vegetativo',     'Alto',   2),
        (N'Tomate',      N'Solanum lycopersicum',      N'Platense',       N'Hortícola',  N'Anual',   'Ago-Oct', N'Almácigo y trasplante', N'Vegetativo',     'Alto',   3),
        (N'Zapallo',     N'Cucurbita moschata',        N'Anco',           N'Hortícola',  N'Anual',   'Oct-Dic', N'Siembra directa',       N'Vegetativo',     'Medio',  4),
        (N'Acelga',      N'Beta vulgaris var. cicla',  N'Penca blanca',   N'Hortícola',  N'Bianual', 'Feb-Abr', N'Siembra directa',       N'Germinación',    'Medio',  5),
        (N'Zanahoria',   N'Daucus carota',             N'Chantenay',      N'Hortícola',  N'Bianual', 'Feb-Mar', N'Siembra directa',       N'Germinación',    'Medio',  6),
        (N'Cebolla',     N'Allium cepa',               N'Valcatorce',     N'Hortícola',  N'Bianual', 'Mar-Abr', N'Almácigo y trasplante', N'Vegetativo',     'Medio',  7),
        (N'Papa',        N'Solanum tuberosum',         N'Spunta',         N'Hortícola',  N'Anual',   'Ago-Sep', N'Siembra directa',       N'Floración',      'Medio',  8),
        (N'Maíz',        N'Zea mays',                  N'Híbrido',        N'Extensivo',  N'Anual',   'Sep-Dic', N'Siembra directa',       N'Vegetativo',     'Medio',  9),
        (N'Soja',        N'Glycine max',               N'Grupo IV',       N'Extensivo',  N'Anual',   'Oct-Dic', N'Siembra directa',       N'Floración',      'Medio', 10),
        (N'Trigo',       N'Triticum aestivum',         N'Pan',            N'Extensivo',  N'Anual',   'May-Jul', N'Siembra directa',       N'Germinación',    'Bajo',  11),
        (N'Alfalfa',     N'Medicago sativa',           N'Grupo 9',        N'Forrajero',  N'Perenne', 'Mar-May', N'Siembra directa',       N'Vegetativo',     'Medio', 12),
        (N'Avena',       N'Avena sativa',              N'Forrajera',      N'Forrajero',  N'Anual',   'Feb-Abr', N'Siembra directa',       N'Vegetativo',     'Bajo',  13),
        (N'Raigrás',     N'Lolium multiflorum',        N'Anual',          N'Pastura',    N'Anual',   'Mar-Abr', N'Siembra directa',       N'Vegetativo',     'Medio', 14),
        (N'Durazno',     N'Prunus persica',            N'Flordaking',     N'Frutícola',  N'Perenne', 'Jun-Ago', N'Almácigo y trasplante', N'Floración',      'Medio', 15),
        (N'Naranja',     N'Citrus sinensis',           N'Valencia',       N'Frutícola',  N'Perenne', 'Ago-Sep', N'Almácigo y trasplante', N'Fructificación', 'Medio', 16),
        (N'Frutilla',    N'Fragaria x ananassa',       N'Camarosa',       N'Frutícola',  N'Perenne', 'Mar-Abr', N'Almácigo y trasplante', N'Floración',      'Alto',  17)
    ) AS v (Nombre, Cientifico, Variedad, TipoCultivo, CicloVida, Periodo, Metodo, Estado, Hidrico, Orden)
),
nuevos AS (
    SELECT d.*, ROW_NUMBER() OVER (ORDER BY d.Orden) AS nro
    FROM datos d
    WHERE NOT EXISTS (SELECT 1 FROM dbo.vegetales x
                      WHERE x.nombre_comun = d.Nombre AND ISNULL(x.variedad_hibrido, '') = d.Variedad)
)
INSERT INTO dbo.vegetales (id_vegetal, nombre_comun, nombre_cientifico, variedad_hibrido, id_tipo_cultivo,
                           id_ciclo_vida, periodosiembra, id_metodo_siembra, id_estado_fenologico, requerimiento_hidrico)
SELECT
    @Ultimo + n.nro,
    n.Nombre,
    n.Cientifico,
    n.Variedad,
    tc.Id_catalogo_item,
    cv.Id_catalogo_item,
    n.Periodo,
    ms.Id_catalogo_item,
    ef.Id_catalogo_item,
    n.Hidrico
FROM nuevos n
LEFT JOIN dbo.catalogo_tipo_items tc ON tc.Id_catalog = 2 AND tc.Nombre = n.TipoCultivo
LEFT JOIN dbo.catalogo_tipo_items cv ON cv.Id_catalog = 9 AND cv.Nombre = n.CicloVida
LEFT JOIN dbo.catalogo_tipo_items ms ON ms.Id_catalog = 7 AND ms.Nombre = n.Metodo
LEFT JOIN dbo.catalogo_tipo_items ef ON ef.Id_catalog = 4 AND ef.Nombre = n.Estado;

PRINT CONCAT('Vegetales insertados: ', @@ROWCOUNT);
GO

/* =====================================================================
   3) ARTÍCULOS
   La app calcula el próximo ID como: base + 20000 + CANTIDAD de artículos
   del usuario. Por eso se numeran seguidos desde esa cantidad.
   ===================================================================== */
DECLARE @IdUsuario BIGINT = (SELECT Id FROM dbo.usuarios WHERE NombreUsuario = 'ADMIN');
DECLARE @Base      BIGINT = @IdUsuario * 100000 + 20000;   -- rango de artículos
DECLARE @Cantidad  BIGINT = (SELECT COUNT(*) FROM dbo.articulos
                             WHERE id_articulo >= @IdUsuario * 100000 AND id_articulo < (@IdUsuario + 1) * 100000);

;WITH datos AS (
    SELECT * FROM (VALUES
        -- nombre,                                       marca,       categoría (cat. 3), stock_min, orden
        -- ---- ENGORDE (alimentación animal) ----
        (N'Alimento balanceado bovino (bolsa 40 kg)',    N'Molinos',  N'engorde',  10,  1),
        (N'Alimento balanceado porcino (bolsa 40 kg)',   N'Molinos',  N'engorde',  8,   2),
        (N'Alimento para ponedoras (bolsa 25 kg)',       N'Molinos',  N'engorde',  8,   3),
        (N'Alimento iniciador pollitos (bolsa 25 kg)',   N'Molinos',  N'engorde',  4,   4),
        (N'Maíz partido (bolsa 25 kg)',                  N'Propia',   N'engorde',  10,  5),
        (N'Rollo de alfalfa',                            N'Propia',   N'engorde',  5,   6),
        (N'Sal mineral bovinos (bolsa 25 kg)',           N'Otro',     N'engorde',  3,   7),
        -- ---- INSUMOS ----
        (N'Semilla de lechuga (sobre 10 g)',             N'Otro',     N'insumos',  10,  8),
        (N'Semilla de tomate (sobre 5 g)',               N'Otro',     N'insumos',  10,  9),
        (N'Sustrato para almácigos (bolsa 50 l)',        N'Otro',     N'insumos',  4,  10),
        (N'Fertilizante urea (bolsa 50 kg)',             N'Otro',     N'insumos',  3,  11),
        (N'Fosfato diamónico (bolsa 50 kg)',             N'Otro',     N'insumos',  3,  12),
        (N'Vacuna antiaftosa (frasco)',                  N'Otro',     N'insumos',  2,  13),
        (N'Antiparasitario ivermectina 1% (frasco)',     N'Otro',     N'insumos',  2,  14),
        (N'Cera estampada para panales (kg)',            N'Otro',     N'insumos',  2,  15),
        -- ---- PAÑOL (herramientas) ----
        (N'Pala de punta',                               N'Otro',     N'pañol',    4,  16),
        (N'Azada',                                       N'Otro',     N'pañol',    4,  17),
        (N'Rastrillo',                                   N'Otro',     N'pañol',    4,  18),
        (N'Carretilla',                                  N'Otro',     N'pañol',    2,  19),
        (N'Tijera de podar',                             N'Otro',     N'pañol',    3,  20),
        (N'Manguera 25 m',                               N'Otro',     N'pañol',    2,  21),
        (N'Mochila pulverizadora 20 l',                  N'Otro',     N'pañol',    1,  22),
        (N'Ahumador apícola',                            N'Otro',     N'pañol',    1,  23),
        (N'Guantes de trabajo (par)',                    N'Otro',     N'pañol',    10, 24),
        (N'Balde 10 l',                                  N'Otro',     N'pañol',    5,  25),
        -- ---- OTROS ----
        (N'Bolsas de arpillera',                         N'Otro',     N'otros',    20, 26),
        (N'Hilo para enfardar (rollo)',                  N'Otro',     N'otros',    2,  27),
        (N'Cajón cosechero',                             N'Propia',   N'otros',    10, 28)
    ) AS v (Nombre, Marca, Categoria, StockMin, Orden)
),
nuevos AS (
    SELECT d.*, ROW_NUMBER() OVER (ORDER BY d.Orden) AS nro
    FROM datos d
    WHERE NOT EXISTS (SELECT 1 FROM dbo.articulos a WHERE a.nombre = d.Nombre)
)
INSERT INTO dbo.articulos (id_articulo, nombre, id_marca, stock_minimo, id_categoria)
SELECT
    @Base + @Cantidad + n.nro - 1,
    n.Nombre,
    m.id_marca,
    n.StockMin,
    c.Id_catalogo_item
FROM nuevos n
LEFT JOIN dbo.marcas m              ON m.nombre = n.Marca
LEFT JOIN dbo.catalogo_tipo_items c ON c.Id_catalog = 3 AND c.Nombre = n.Categoria;

PRINT CONCAT('Artículos insertados: ', @@ROWCOUNT);
GO

/* =====================================================================
   4) VERIFICACIÓN
   ===================================================================== */
SELECT 'Animales'  AS Tabla, COUNT(*) AS Registros FROM dbo.animales
UNION ALL
SELECT 'Vegetales',          COUNT(*)              FROM dbo.vegetales
UNION ALL
SELECT 'Artículos',          COUNT(*)              FROM dbo.articulos;

-- Si alguna de estas consultas devuelve filas, un catálogo no coincidió por nombre
SELECT 'Animal sin tipo/rubro/subrubro' AS Problema, id_animal AS Id, nombre_comun AS Nombre
FROM dbo.animales WHERE id_tipo IS NULL OR id_rubro IS NULL OR id_subrubro IS NULL
UNION ALL
SELECT 'Vegetal sin catálogo', id_vegetal, nombre_comun
FROM dbo.vegetales WHERE id_tipo_cultivo IS NULL OR id_ciclo_vida IS NULL OR id_metodo_siembra IS NULL OR id_estado_fenologico IS NULL
UNION ALL
SELECT 'Artículo sin marca/categoría', id_articulo, nombre
FROM dbo.articulos WHERE id_marca IS NULL OR id_categoria IS NULL;
GO