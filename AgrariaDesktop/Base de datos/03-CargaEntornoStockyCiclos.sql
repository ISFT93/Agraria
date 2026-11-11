/* =====================================================================
   AgrariaNueva2 - DATOS DE EJEMPLO: Entornos, Stock y Ciclos Modelo
   ---------------------------------------------------------------------
   Ejecutar en este orden:
     1) AgrariaNueva2_COMPLETO.sql
     2) AgrariaNueva2_DATOS_Animales_Vegetales_Articulos.sql
     3) ESTE script

   - Todo queda a nombre del usuario ADMIN.
   - Catálogos y elementos se buscan por NOMBRE, no por ID fijo.
   - Se puede ejecutar más de una vez: no duplica registros.
   ===================================================================== */

USE [AgrariaNueva2];
GO

SET NOCOUNT ON;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE NombreUsuario = 'ADMIN')
    RAISERROR('No existe el usuario ADMIN. Ejecute primero AgrariaNueva2_COMPLETO.sql', 16, 1);
GO

/* =====================================================================
   0) Artículos de PRODUCCIÓN que usan los ciclos como salida
      (huevos, leche, miel). Se numeran igual que la app.
   ===================================================================== */
DECLARE @IdUsuario BIGINT = (SELECT Id FROM dbo.usuarios WHERE NombreUsuario = 'ADMIN');
DECLARE @Base      BIGINT = @IdUsuario * 100000 + 20000;
DECLARE @Cantidad  BIGINT = (SELECT COUNT(*) FROM dbo.articulos
                             WHERE id_articulo >= @IdUsuario * 100000 AND id_articulo < (@IdUsuario + 1) * 100000);

;WITH datos AS (
    SELECT * FROM (VALUES
        (N'Huevos (maple x30)',   N'Propia', N'otros', 10, 1),
        (N'Leche cruda (litro)',  N'Propia', N'otros', 50, 2),
        (N'Miel (kg)',            N'Propia', N'otros', 5,  3)
    ) AS v (Nombre, Marca, Categoria, StockMin, Orden)
),
nuevos AS (
    SELECT d.*, ROW_NUMBER() OVER (ORDER BY d.Orden) AS nro
    FROM datos d
    WHERE NOT EXISTS (SELECT 1 FROM dbo.articulos a WHERE a.nombre = d.Nombre)
)
INSERT INTO dbo.articulos (id_articulo, nombre, id_marca, stock_minimo, id_categoria)
SELECT @Base + @Cantidad + n.nro - 1, n.Nombre, m.id_marca, n.StockMin, c.Id_catalogo_item
FROM nuevos n
LEFT JOIN dbo.marcas m              ON m.nombre = n.Marca
LEFT JOIN dbo.catalogo_tipo_items c ON c.Id_catalog = 3 AND c.Nombre = n.Categoria;
GO

/* =====================================================================
   1) ENTORNOS FORMATIVOS
   Tipo de entorno: Animal / Vegetal / Industria / Compras / Pañol
   ===================================================================== */
INSERT INTO dbo.Entornos (Nombre, IdTipoEntorno, Responsable, Año, Division, Grupo, Fecha, Observaciones)
SELECT v.Nombre, t.IdTipoEntorno, v.Responsable, v.Anio, v.Division, v.Grupo, v.Fecha, v.Obs
FROM (VALUES
    -- Nombre,                    Tipo,         Responsable,  Año, División, Grupo, Fecha,        Observaciones
    (N'Box 1 Gallinas',           N'Animal',    N'Soria',     '3', '4', 'A', '2026-03-09', N'Gallinas ponedoras en buen estado. Postura normal.'),
    (N'Box 2 Gallinas',           N'Animal',    N'Soria',     '3', '4', 'B', '2026-03-09', N'Hay cuatro gallinas en mal estado.'),
    (N'Tambo - Sala de ordeñe',   N'Animal',    N'Fernández', '4', '1', 'A', '2026-03-16', N'Ordeñe mañana y tarde. Controlar limpieza de pezoneras.'),
    (N'Corral de cerdos',         N'Animal',    N'Gómez',     '2', '3', 'A', '2026-03-23', N'Lechones recién destetados. Reforzar el bebedero.'),
    (N'Apiario',                  N'Animal',    N'Martínez',  '5', '2', 'B', '2026-04-06', N'Cinco colmenas activas. Revisar alzas antes de la floración.'),
    (N'Huerta - Sector 1',        N'Vegetal',   N'López',     '1', '2', 'A', '2026-03-10', N'Almácigos de lechuga y tomate.'),
    (N'Huerta - Invernadero',     N'Vegetal',   N'López',     '2', '1', 'B', '2026-03-17', N'Sistema hidropónico funcionando. Medir pH semanalmente.'),
    (N'Lote 4 - Maíz',            N'Vegetal',   N'Pereyra',   '6', '1', 'A', '2026-09-15', N'Siembra directa. Esperar lluvias para fertilizar.'),
    (N'Monte frutal',             N'Vegetal',   N'Acosta',    '4', '2', 'A', '2026-07-20', N'Poda de durazneros pendiente.'),
    (N'Sala de elaboración',      N'Industria', N'Ruiz',      '5', '1', 'A', '2026-04-14', N'Elaboración de dulce de leche y quesos.'),
    (N'Sala de extracción de miel', N'Industria', N'Martínez', '5', '2', 'A', '2026-11-03', N'Cosecha prevista para diciembre.'),
    (N'Compras del mes',          N'Compras',   N'Díaz',      '6', '2', 'A', '2026-05-04', N'Pedido de alimento balanceado y fertilizantes.'),
    (N'Pañol central',            N'Pañol',     N'Romero',    '3', '3', 'A', '2026-03-02', N'Inventario de herramientas al inicio del ciclo lectivo.')
) AS v (Nombre, Tipo, Responsable, Anio, Division, Grupo, Fecha, Obs)
INNER JOIN dbo.TipoEntornos t ON t.Nombre = v.Tipo
WHERE NOT EXISTS (SELECT 1 FROM dbo.Entornos e WHERE e.Nombre = v.Nombre);

PRINT CONCAT('Entornos insertados: ', @@ROWCOUNT);
GO

/* =====================================================================
   2) STOCK
   - id_stock con la lógica de la app: [IdUsuario] 4 xxxxxx (ADMIN -> 1400001...)
   - ciclo = suma de estaciones: Verano 2, Otoño 4, Invierno 8, Primavera 16
     (todo el año = 30)
   - Para animales, cantidad = cantidad de animales detallados en datosAnimales
   ===================================================================== */
DECLARE @IdUsuario BIGINT = (SELECT Id FROM dbo.usuarios WHERE NombreUsuario = 'ADMIN');
DECLARE @Base      BIGINT = CONVERT(BIGINT, CONCAT(@IdUsuario, '4000000'));
DECLARE @Ultimo    BIGINT = (SELECT ISNULL(MAX(id_stock), @Base) FROM dbo.stock
                             WHERE id_stock >= @Base AND id_stock <= @Base + 999999);

DECLARE @Stock TABLE (
    Orden INT, Tipo VARCHAR(50), Elemento NVARCHAR(150), Variedad NVARCHAR(40),
    Ciclo VARCHAR(50), FechaAlta DATE, Cantidad DECIMAL(10,2), Precio MONEY,
    Proveedor NVARCHAR(150), Vendible BIT
);

INSERT INTO @Stock VALUES
-- ---- Artículos ----
( 1, 'Articulo', N'Alimento balanceado bovino (bolsa 40 kg)',  NULL, '30', '2026-03-02', 25, 18500, N'Agroinsumos Pampeanos S.A.',      0),
( 2, 'Articulo', N'Alimento balanceado porcino (bolsa 40 kg)', NULL, '30', '2026-03-02', 15, 19800, N'Agroinsumos Pampeanos S.A.',      0),
( 3, 'Articulo', N'Alimento para ponedoras (bolsa 25 kg)',     NULL, '30', '2026-03-02', 20, 14200, N'Agroinsumos Pampeanos S.A.',      0),
( 4, 'Articulo', N'Rollo de alfalfa',                          NULL, '12', '2026-04-10', 12, 45000, N'Semillas y Forrajes Del Sur SRL', 0),
( 5, 'Articulo', N'Semilla de lechuga (sobre 10 g)',           NULL, '20', '2026-02-20', 30,  2500, N'Semillas y Forrajes Del Sur SRL', 0),
( 6, 'Articulo', N'Fertilizante urea (bolsa 50 kg)',           NULL, '18', '2026-08-05',  8, 52000, N'Agroinsumos Pampeanos S.A.',      0),
( 7, 'Articulo', N'Vacuna antiaftosa (frasco)',                NULL, '30', '2026-03-15', 10,  9800, N'Veterinaria El Estribo',          0),
( 8, 'Articulo', N'Pala de punta',                             NULL, '30', '2026-03-02',  6, 21000, N'Agroinsumos Pampeanos S.A.',      0),
( 9, 'Articulo', N'Azada',                                     NULL, '30', '2026-03-02',  8, 15500, N'Agroinsumos Pampeanos S.A.',      0),
(10, 'Articulo', N'Carretilla',                                NULL, '30', '2026-03-02',  3, 85000, N'Agroinsumos Pampeanos S.A.',      0),
(11, 'Articulo', N'Guantes de trabajo (par)',                  NULL, '30', '2026-03-02', 20,  4500, N'Agroinsumos Pampeanos S.A.',      0),
(12, 'Articulo', N'Huevos (maple x30)',                        NULL, '30', '2026-10-20', 15,  6000, NULL,                               1),
(13, 'Articulo', N'Leche cruda (litro)',                       NULL, '30', '2026-10-20', 120,   900, NULL,                              1),
(14, 'Articulo', N'Miel (kg)',                                 NULL, '18', '2026-01-15', 25,  8500, NULL,                               1),
-- ---- Vegetales ----
(15, 'Vegetal',  N'Lechuga',  N'Mantecosa', '20', '2026-05-12', 200,  700, NULL, 1),
(16, 'Vegetal',  N'Tomate',   N'Platense',  '18', '2026-01-20', 150, 1500, NULL, 1),
(17, 'Vegetal',  N'Zapallo',  N'Anco',      '6',  '2026-03-25',  80, 1200, NULL, 1),
(18, 'Vegetal',  N'Maíz',     N'Híbrido',   '6',  '2026-04-15', 2000, 250, NULL, 1),
(19, 'Vegetal',  N'Alfalfa',  N'Grupo 9',   '30', '2026-02-10',   50, NULL, N'Semillas y Forrajes Del Sur SRL', 0),
-- ---- Animales (la cantidad se recalcula con el detalle) ----
(20, 'Animal',   N'Vaca Holando',     NULL, '30', '2026-03-01',  4, NULL, NULL, 0),
(21, 'Animal',   N'Toro Hereford',    NULL, '30', '2026-03-01',  1, NULL, NULL, 0),
(22, 'Animal',   N'Cerda Landrace',   NULL, '30', '2026-03-20',  3, NULL, NULL, 0),
(23, 'Animal',   N'Gallina Ponedora', NULL, '30', '2026-03-09', 10, NULL, NULL, 0);

;WITH resuelto AS (
    SELECT s.*,
           CASE s.Tipo
               WHEN 'Articulo' THEN (SELECT TOP 1 id_articulo FROM dbo.articulos WHERE nombre = s.Elemento ORDER BY id_articulo)
               WHEN 'Vegetal'  THEN (SELECT TOP 1 id_vegetal  FROM dbo.vegetales WHERE nombre_comun = s.Elemento
                                         AND (s.Variedad IS NULL OR variedad_hibrido = s.Variedad) ORDER BY id_vegetal)
               WHEN 'Animal'   THEN (SELECT TOP 1 id_animal   FROM dbo.animales  WHERE nombre_comun = s.Elemento ORDER BY id_animal)
           END AS IdElemento
    FROM @Stock s
),
nuevos AS (
    SELECT r.*, ROW_NUMBER() OVER (ORDER BY r.Orden) AS nro
    FROM resuelto r
    WHERE r.IdElemento IS NOT NULL
      AND NOT EXISTS (SELECT 1 FROM dbo.stock x WHERE x.tipo_elemento = r.Tipo AND x.id_elemento = r.IdElemento)
)
INSERT INTO dbo.stock (id_stock, id_elemento, tipo_elemento, Nombre, ciclo, fecha_alta, fecha_baja,
                       cantidad, precio, id_proveedor, activo, vendible, motivo_movimiento)
SELECT @Ultimo + n.nro,
       n.IdElemento,
       n.Tipo,
       LEFT(n.Elemento + ISNULL(' ' + n.Variedad, ''), 50),
       n.Ciclo,
       n.FechaAlta,
       NULL,
       n.Cantidad,
       n.Precio,
       p.id_proveedor,
       1,
       n.Vendible,
       'Carga inicial'
FROM nuevos n
LEFT JOIN dbo.proveedores p ON p.nombre = n.Proveedor;

PRINT CONCAT('Registros de stock insertados: ', @@ROWCOUNT);

-- ---------- Detalle de animales (datosAnimales) ----------
-- Prefijo de la caravana / número de animal por especie
DECLARE @Detalle TABLE (Elemento NVARCHAR(150), Prefijo VARCHAR(5), Cantidad INT, Sexo VARCHAR(20), Productor BIT);
INSERT INTO @Detalle VALUES
    (N'Vaca Holando',     'HOL', 4,  'Hembra', 1),
    (N'Toro Hereford',    'HER', 1,  'Macho',  1),
    (N'Cerda Landrace',   'LAN', 3,  'Hembra', 1),
    (N'Gallina Ponedora', 'GAL', 10, 'Hembra', 1);

;WITH numeros AS (
    SELECT TOP (50) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS n FROM sys.all_objects
)
INSERT INTO dbo.datosAnimales (id_stock, nro_animal, sexo, es_productor)
SELECT s.id_stock,
       CONCAT(d.Prefijo, '-', RIGHT('000' + CAST(nu.n AS VARCHAR(3)), 3)),
       d.Sexo,
       d.Productor
FROM @Detalle d
INNER JOIN dbo.animales a ON a.nombre_comun = d.Elemento
INNER JOIN dbo.stock s    ON s.tipo_elemento = 'Animal' AND s.id_elemento = a.id_animal
INNER JOIN numeros nu     ON nu.n <= d.Cantidad
WHERE NOT EXISTS (SELECT 1 FROM dbo.datosAnimales x WHERE x.id_stock = s.id_stock);

-- La cantidad del stock de animales = animales detallados
UPDATE s
SET cantidad = (SELECT COUNT(*) FROM dbo.datosAnimales x WHERE x.id_stock = s.id_stock)
FROM dbo.stock s
WHERE s.tipo_elemento = 'Animal'
  AND EXISTS (SELECT 1 FROM dbo.datosAnimales x WHERE x.id_stock = s.id_stock);
GO

/* =====================================================================
   3) CICLOS MODELO  +  ACTIVIDADES  +  ELEMENTOS
   Criterio de movimiento:
     Entrada = lo que la actividad USA o CONSUME (insumos, animales, herramientas)
     Salida  = lo que la actividad PRODUCE (cosecha, leche, huevos, miel)
   Vendible solo se marca en elementos de Salida.
   ===================================================================== */
DECLARE @IdUsuario INT = (SELECT Id FROM dbo.usuarios WHERE NombreUsuario = 'ADMIN');

-- ---------- 3.1 Cabeceras ----------
DECLARE @Ciclos TABLE (Ciclo NVARCHAR(150), Descripcion NVARCHAR(2000), Duracion INT, ModoInicio NVARCHAR(50), Fecha DATE);
INSERT INTO @Ciclos VALUES
(N'Cultivo de Lechuga',            N'Desde el almácigo hasta la cosecha de lechuga mantecosa en la huerta.',             75, N'Manual',         '2026-03-02'),
(N'Producción de Huevos',          N'Manejo diario de gallinas ponedoras y recolección de huevos.',                       365, N'Automático',     '2026-03-09'),
(N'Tambo - Ordeñe Holando',        N'Alimentación, sanidad y ordeñe del rodeo Holando. Ciclo mensual.',                  30, N'Semicontrolado', '2026-03-16'),
(N'Engorde de Cerdos Landrace',    N'Recepción de lechones destetados hasta la venta de capones terminados.',            150, N'Manual',         '2026-03-23'),
(N'Cosecha de Miel',               N'Revisión de colmenas, colocación de alzas y extracción de miel.',                   120, N'Manual',         '2026-08-03'),
(N'Siembra de Maíz - Lote 4',      N'Cultivo extensivo de maíz en siembra directa.',                                     150, N'Manual',         '2026-09-15');

INSERT INTO dbo.ciclos_modelo (nombre, descripcion, duracion_estimada, modo_inicio, activo, fecha_creacion, creado_por)
SELECT c.Ciclo, c.Descripcion, c.Duracion, mi.Id_catalogo_item, 1, c.Fecha, @IdUsuario
FROM @Ciclos c
LEFT JOIN dbo.catalogo_tipo_items mi ON mi.Id_catalog = 14 AND mi.Nombre = c.ModoInicio
WHERE NOT EXISTS (SELECT 1 FROM dbo.ciclos_modelo x WHERE x.nombre = c.Ciclo);

PRINT CONCAT('Ciclos insertados: ', @@ROWCOUNT);

-- ---------- 3.2 Actividades ----------
DECLARE @Actividades TABLE (
    Ciclo NVARCHAR(150), Orden INT, Nombre NVARCHAR(150), Descripcion NVARCHAR(2000), Tipo NVARCHAR(50),
    Duracion INT, Demora BIT, Aprobacion BIT, Parcial BIT, Condicion NVARCHAR(1000)
);
INSERT INTO @Actividades VALUES
-- Ciclo,                       Ord, Nombre,                       Descripción,                                         Tipo,           Días, Dem, Apr, Parc, Condición de avance
(N'Cultivo de Lechuga',           1, N'Siembra en almácigo',       N'Sembrar en bandejas con sustrato.',                N'Secuencial',     5, 0, 0, 0, N'Almácigos sembrados y regados.'),
(N'Cultivo de Lechuga',           2, N'Trasplante',                N'Pasar plantines a los canteros.',                   N'Secuencial',     2, 0, 1, 0, N'Plantines con 4 hojas verdaderas.'),
(N'Cultivo de Lechuga',           3, N'Riego y mantenimiento',     N'Riego, desmalezado y fertilización.',               N'Paralela',      60, 1, 0, 1, N'Plantas sin malezas y con buen color.'),
(N'Cultivo de Lechuga',           4, N'Cosecha',                   N'Corte y acondicionamiento en cajones.',             N'Secuencial',     3, 0, 1, 1, N'Cabezas formadas.'),

(N'Producción de Huevos',         1, N'Recepción de aves',         N'Ingreso de gallinas al box.',                       N'Secuencial',     1, 0, 0, 0, N'Aves alojadas y con agua.'),
(N'Producción de Huevos',         2, N'Alimentación diaria',       N'Suministro de alimento y agua.',                    N'Paralela',     365, 0, 0, 1, NULL),
(N'Producción de Huevos',         3, N'Recolección de huevos',     N'Recolección y clasificación diaria.',               N'Paralela',     365, 0, 0, 1, NULL),

(N'Tambo - Ordeñe Holando',       1, N'Alimentación del rodeo',    N'Balanceado en sala y rollo en comedero.',           N'Paralela',      30, 0, 0, 1, NULL),
(N'Tambo - Ordeñe Holando',       2, N'Control sanitario',         N'Vacunación según calendario sanitario.',            N'Condicionada',   1, 1, 1, 0, N'Solo si corresponde por calendario.'),
(N'Tambo - Ordeñe Holando',       3, N'Ordeñe',                    N'Ordeñe mañana y tarde.',                            N'Paralela',      30, 0, 0, 1, N'Equipo de ordeñe limpio.'),

(N'Engorde de Cerdos Landrace',   1, N'Recepción de lechones',     N'Ingreso de lechones destetados al corral.',         N'Secuencial',     1, 0, 0, 0, N'Lechones pesados e identificados.'),
(N'Engorde de Cerdos Landrace',   2, N'Alimentación',              N'Balanceado y maíz según peso.',                     N'Paralela',     140, 0, 0, 1, NULL),
(N'Engorde de Cerdos Landrace',   3, N'Desparasitación',           N'Aplicación de antiparasitario.',                    N'Condicionada',   1, 1, 1, 0, N'Al ingreso y a los 60 días.'),
(N'Engorde de Cerdos Landrace',   4, N'Venta de capones',          N'Venta de animales terminados.',                     N'Secuencial',     2, 0, 1, 1, N'Peso mayor a 100 kg.'),

(N'Cosecha de Miel',              1, N'Revisión de colmenas',      N'Control de reina, cría y reservas.',                N'Secuencial',     2, 0, 0, 0, N'Colmenas fuertes y sanas.'),
(N'Cosecha de Miel',              2, N'Colocación de alzas',       N'Agregar alzas con cera estampada.',                 N'Secuencial',     1, 0, 0, 0, NULL),
(N'Cosecha de Miel',              3, N'Cosecha y extracción',      N'Retiro de alzas y extracción en sala.',             N'Secuencial',     3, 0, 1, 1, N'Marcos operculados al 80%.'),

(N'Siembra de Maíz - Lote 4',     1, N'Fertilización de base',     N'Aplicación de fosfato diamónico.',                  N'Secuencial',     2, 1, 0, 0, NULL),
(N'Siembra de Maíz - Lote 4',     2, N'Siembra',                   N'Siembra directa con sembradora.',                   N'Secuencial',     3, 1, 1, 0, N'Humedad suficiente en el suelo.'),
(N'Siembra de Maíz - Lote 4',     3, N'Refertilización',           N'Aplicación de urea en V6.',                         N'Condicionada',   2, 1, 0, 0, N'Cultivo en estado V6.'),
(N'Siembra de Maíz - Lote 4',     4, N'Cosecha',                   N'Cosecha con contratista.',                          N'Secuencial',     5, 1, 1, 1, N'Grano con humedad menor a 16%.');

INSERT INTO dbo.actividades_ciclo_modelo (id_ciclo, nombre, descripcion, orden, tipo_actividad, duracion_estimada,
                                          demora, requiere_aprobacion, permite_ejecucion_parcial, condicion_avance, activa)
SELECT c.id_ciclo, a.Nombre, a.Descripcion, a.Orden, ta.Id_catalogo_item, a.Duracion,
       a.Demora, a.Aprobacion, a.Parcial, a.Condicion, 1
FROM @Actividades a
INNER JOIN dbo.ciclos_modelo c        ON c.nombre = a.Ciclo
LEFT JOIN  dbo.catalogo_tipo_items ta ON ta.Id_catalog = 15 AND ta.Nombre = a.Tipo
WHERE NOT EXISTS (SELECT 1 FROM dbo.actividades_ciclo_modelo x WHERE x.id_ciclo = c.id_ciclo AND x.orden = a.Orden);

PRINT CONCAT('Actividades insertadas: ', @@ROWCOUNT);

-- ---------- 3.3 Elementos de cada actividad ----------
DECLARE @Elementos TABLE (
    Ciclo NVARCHAR(150), OrdenAct INT, Orden INT, Tipo NVARCHAR(20), Elemento NVARCHAR(150), Variedad NVARCHAR(40),
    Movimiento NVARCHAR(20), Cantidad DECIMAL(18,4), Unidad NVARCHAR(50),
    Obligatorio BIT, Sustitucion BIT, Vendible BIT, Obs NVARCHAR(1000)
);
INSERT INTO @Elementos VALUES
-- Ciclo,                     Act, Ord, Tipo,       Elemento,                                    Variedad,     Mov.,       Cant., Unidad,              Obl, Sus, Vend, Observaciones
(N'Cultivo de Lechuga',          1, 1, N'Articulo', N'Semilla de lechuga (sobre 10 g)',           NULL,         N'Entrada',     2, N'Unidades (u)',        1, 0, 0, N''),
(N'Cultivo de Lechuga',          1, 2, N'Articulo', N'Sustrato para almácigos (bolsa 50 l)',      NULL,         N'Entrada',     1, N'Unidades (u)',        1, 1, 0, N''),
(N'Cultivo de Lechuga',          2, 1, N'Articulo', N'Azada',                                     NULL,         N'Entrada',     2, N'Unidades (u)',        0, 1, 0, N'Se devuelve al pañol.'),
(N'Cultivo de Lechuga',          3, 1, N'Articulo', N'Manguera 25 m',                             NULL,         N'Entrada',     1, N'Unidades (u)',        1, 0, 0, N'Se devuelve al pañol.'),
(N'Cultivo de Lechuga',          3, 2, N'Articulo', N'Fertilizante urea (bolsa 50 kg)',           NULL,         N'Entrada',     5, N'Kilogramos (kg)',     0, 1, 0, N''),
(N'Cultivo de Lechuga',          4, 1, N'Articulo', N'Cajón cosechero',                           NULL,         N'Entrada',    10, N'Unidades (u)',        1, 0, 0, N''),
(N'Cultivo de Lechuga',          4, 2, N'Vegetal',  N'Lechuga',                                   N'Mantecosa', N'Salida',    200, N'Unidades (u)',        1, 0, 1, N'Venta en feria escolar.'),

(N'Producción de Huevos',        1, 1, N'Animal',   N'Gallina Ponedora',                          NULL,         N'Entrada',    50, N'Unidades (u)',        1, 0, 0, N''),
(N'Producción de Huevos',        2, 1, N'Articulo', N'Alimento para ponedoras (bolsa 25 kg)',     NULL,         N'Entrada',    30, N'Atados / Bultos',     1, 1, 0, N'Aprox. 120 g por gallina por día.'),
(N'Producción de Huevos',        3, 1, N'Articulo', N'Huevos (maple x30)',                        NULL,         N'Salida',    500, N'Unidades (u)',        1, 0, 1, N''),

(N'Tambo - Ordeñe Holando',      1, 1, N'Articulo', N'Alimento balanceado bovino (bolsa 40 kg)',  NULL,         N'Entrada',    20, N'Atados / Bultos',     1, 1, 0, N''),
(N'Tambo - Ordeñe Holando',      1, 2, N'Articulo', N'Rollo de alfalfa',                          NULL,         N'Entrada',     5, N'Unidades (u)',        1, 1, 0, N''),
(N'Tambo - Ordeñe Holando',      2, 1, N'Articulo', N'Vacuna antiaftosa (frasco)',                NULL,         N'Entrada',     1, N'Unidades (u)',        1, 0, 0, N''),
(N'Tambo - Ordeñe Holando',      3, 1, N'Animal',   N'Vaca Holando',                              NULL,         N'Entrada',    10, N'Unidades (u)',        1, 0, 0, N'Vacas en ordeñe.'),
(N'Tambo - Ordeñe Holando',      3, 2, N'Articulo', N'Leche cruda (litro)',                       NULL,         N'Salida',   3000, N'Litros (l)',          1, 0, 1, N''),

(N'Engorde de Cerdos Landrace',  1, 1, N'Animal',   N'Lechón Landrace',                           NULL,         N'Entrada',    10, N'Unidades (u)',        1, 0, 0, N''),
(N'Engorde de Cerdos Landrace',  2, 1, N'Articulo', N'Alimento balanceado porcino (bolsa 40 kg)', NULL,         N'Entrada',    40, N'Atados / Bultos',     1, 1, 0, N''),
(N'Engorde de Cerdos Landrace',  2, 2, N'Articulo', N'Maíz partido (bolsa 25 kg)',                NULL,         N'Entrada',    20, N'Atados / Bultos',     0, 1, 0, N''),
(N'Engorde de Cerdos Landrace',  3, 1, N'Articulo', N'Antiparasitario ivermectina 1% (frasco)',   NULL,         N'Entrada',     1, N'Unidades (u)',        1, 0, 0, N''),
(N'Engorde de Cerdos Landrace',  4, 1, N'Animal',   N'Lechón Landrace',                           NULL,         N'Salida',     10, N'Unidades (u)',        1, 0, 1, N'Capones terminados.'),

(N'Cosecha de Miel',             1, 1, N'Animal',   N'Colmena Abeja Africana',                    NULL,         N'Entrada',     5, N'Unidades (u)',        1, 0, 0, N''),
(N'Cosecha de Miel',             1, 2, N'Articulo', N'Ahumador apícola',                          NULL,         N'Entrada',     1, N'Unidades (u)',        1, 0, 0, N'Se devuelve al pañol.'),
(N'Cosecha de Miel',             2, 1, N'Articulo', N'Cera estampada para panales (kg)',          NULL,         N'Entrada',     3, N'Kilogramos (kg)',     1, 0, 0, N''),
(N'Cosecha de Miel',             3, 1, N'Articulo', N'Miel (kg)',                                 NULL,         N'Salida',     60, N'Kilogramos (kg)',     1, 0, 1, N''),

(N'Siembra de Maíz - Lote 4',    1, 1, N'Articulo', N'Fosfato diamónico (bolsa 50 kg)',           NULL,         N'Entrada',   400, N'Kilogramos (kg)',     1, 1, 0, N'100 kg/ha en 4 ha.'),
(N'Siembra de Maíz - Lote 4',    2, 1, N'Vegetal',  N'Maíz',                                      N'Híbrido',   N'Entrada',     4, N'Hectáreas (ha)',      1, 0, 0, N'Superficie sembrada.'),
(N'Siembra de Maíz - Lote 4',    3, 1, N'Articulo', N'Fertilizante urea (bolsa 50 kg)',           NULL,         N'Entrada',   600, N'Kilogramos (kg)',     0, 1, 0, N'150 kg/ha.'),
(N'Siembra de Maíz - Lote 4',    4, 1, N'Vegetal',  N'Maíz',                                      N'Híbrido',   N'Salida',  32000, N'Kilogramos (kg)',     1, 0, 1, N'Rinde estimado 8000 kg/ha.');

INSERT INTO dbo.actividad_elementos (id_actividad_modelo, id_elemento, tipo_elemento, tipo_movimiento, cantidad_prevista,
                                     id_unidad, obligatorio, vendible_destino, permite_sustitucion, observaciones, orden)
SELECT act.id_actividad_modelo,
       el.IdElemento,
       te.Id_catalogo_item,
       tm.Id_catalogo_item,
       e.Cantidad,
       un.Id_catalogo_item,
       e.Obligatorio,
       CASE WHEN e.Movimiento = N'Salida' THEN e.Vendible ELSE 0 END,
       e.Sustitucion,
       NULLIF(e.Obs, N''),
       e.Orden
FROM @Elementos e
INNER JOIN dbo.ciclos_modelo c              ON c.nombre = e.Ciclo
INNER JOIN dbo.actividades_ciclo_modelo act ON act.id_ciclo = c.id_ciclo AND act.orden = e.OrdenAct
INNER JOIN dbo.catalogo_tipo_items te       ON te.Id_catalog = 11 AND te.Nombre = e.Tipo
INNER JOIN dbo.catalogo_tipo_items tm       ON tm.Id_catalog = 16 AND tm.Nombre = e.Movimiento
INNER JOIN dbo.catalogo_tipo_items un       ON un.Id_catalog = 17 AND un.Nombre = e.Unidad
CROSS APPLY (
    SELECT CASE e.Tipo
        WHEN N'Articulo' THEN (SELECT TOP 1 id_articulo FROM dbo.articulos WHERE nombre = e.Elemento ORDER BY id_articulo)
        WHEN N'Vegetal'  THEN (SELECT TOP 1 id_vegetal  FROM dbo.vegetales WHERE nombre_comun = e.Elemento
                                   AND (e.Variedad IS NULL OR variedad_hibrido = e.Variedad) ORDER BY id_vegetal)
        WHEN N'Animal'   THEN (SELECT TOP 1 id_animal   FROM dbo.animales  WHERE nombre_comun = e.Elemento ORDER BY id_animal)
    END AS IdElemento
) el
WHERE el.IdElemento IS NOT NULL
  AND NOT EXISTS (SELECT 1 FROM dbo.actividad_elementos x
                  WHERE x.id_actividad_modelo = act.id_actividad_modelo AND x.orden = e.Orden);

PRINT CONCAT('Elementos de actividades insertados: ', @@ROWCOUNT);
GO

/* =====================================================================
   4) VERIFICACIÓN
   ===================================================================== */
SELECT 'Entornos'                AS Tabla, COUNT(*) AS Registros FROM dbo.Entornos
UNION ALL SELECT 'Stock',                  COUNT(*) FROM dbo.stock
UNION ALL SELECT 'Detalle animales',       COUNT(*) FROM dbo.datosAnimales
UNION ALL SELECT 'Ciclos modelo',          COUNT(*) FROM dbo.ciclos_modelo
UNION ALL SELECT 'Actividades',            COUNT(*) FROM dbo.actividades_ciclo_modelo
UNION ALL SELECT 'Elementos de actividad', COUNT(*) FROM dbo.actividad_elementos;

-- Resumen por ciclo: cada ciclo debería tener actividades y cada actividad al menos un elemento
SELECT c.id_ciclo,
       c.nombre                               AS ciclo,
       COUNT(a.id_actividad_modelo)           AS actividades,
       ISNULL(SUM(a.elementos), 0)            AS elementos,
       SUM(CASE WHEN a.elementos = 0 THEN 1 ELSE 0 END) AS actividades_sin_elementos
FROM dbo.ciclos_modelo c
LEFT JOIN (
    SELECT act.id_ciclo, act.id_actividad_modelo,
           (SELECT COUNT(*) FROM dbo.actividad_elementos e WHERE e.id_actividad_modelo = act.id_actividad_modelo) AS elementos
    FROM dbo.actividades_ciclo_modelo act
) a ON a.id_ciclo = c.id_ciclo
GROUP BY c.id_ciclo, c.nombre
ORDER BY c.id_ciclo;
GO
