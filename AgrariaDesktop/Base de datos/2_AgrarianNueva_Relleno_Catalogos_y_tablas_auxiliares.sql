USE AgrariaNueva2;
GO

-- Tabla Principal (Define cada tipo o 'familia' de catálogo con ID fijo forzado)
CREATE TABLE Catalogos_tipo (
    Id_catalogo BIGINT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- Tabla Secundaria (Contiene las opciones/ítems de cada catálogo - Ajustada a BIGINT)
CREATE TABLE Catalogo_tipo_items (
    Id_catalogo_item INT IDENTITY(1,1) PRIMARY KEY,
    Id_catalog BIGINT NOT NULL,
    Nombre VARCHAR(150) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (Id_catalog) REFERENCES Catalogos_tipo(Id_catalogo)
);
GO


-- 2. REGISTRO DE CABECERAS DE CATÁLOGOS (Catalogos_tipo - IDs Fijos)

INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (1, 'Tipo Animal', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (2, 'Tipo de Cultivo', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (3, 'Artículos / Categoría', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (4, 'Estado Fenológico', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (5, 'Rubro Animal', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (6, 'Subrubro', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (7, 'Método de Siembra', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (8, 'Requerimiento Hídrico', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (9, 'Ciclo de Vida', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (10, 'Marca Artículo', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (11, 'Tipo Elemento', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (12, 'Proveedor Stock', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (13, 'Pregunta de Seguridad', 1);
GO


---- Sub Tablas de Ciclo Modelo/Actividades Ciclo Modelo / Actividades Elementos      ---- Tipo_Elemento utiliza el ID 11
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (14, 'Modo inicio', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (15, 'Tipo Actividad', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (16, 'Tipo Movimiento', 1);
INSERT INTO Catalogos_tipo (Id_catalogo, Nombre, Activo) VALUES (17, 'Tipo Unidad', 1);
----

GO


-- 3. ÍTEMS DE CADA CATÁLOGO (Catalogo_tipo_items - Autoincremental)

-- --- MÓDULO ANIMALES ---
-- Tipo Animal (Id_catalog = 1)
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (1, 'Mamífero', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (1, 'Ave', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (1, 'Insecto', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (1, 'Pez', 1);

-- Rubro Animal (Id_catalog = 5)
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (5, 'Bovino', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (5, 'Apicola', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (5, 'Porcino', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (5, 'Ovino', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (5, 'Avícola', 1);

-- Subrubro y Raza Animal (Id_catalog = 6)
-- --- MÓDULO ANIMALES (Actualización de Subrubro y Raza - Id_catalog = 6) ---
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (6, 'Hereford', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (6, 'Holando argentina', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (6, 'Bataraza', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (6, 'Ponedora', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (6, 'Africana', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (6, 'Landrace', 1);


-- --- MÓDULO VEGETALES ---
-- Tipo de Cultivo (Id_catalog = 2)
-- --- MÓDULO VEGETALES (Actualización de Tipo de Cultivo - Id_catalog = 2) ---
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (2, 'Hortícola', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (2, 'Extensivo', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (2, 'Frutícola', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (2, 'Forrajero', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (2, 'Pastura', 1);

-- Método de Siembra (Id_catalog = 7)
-- --- MÓDULO VEGETALES (Actualización de Método de Siembra - Id_catalog = 7) ---
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (7, 'Siembra directa', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (7, 'Almácigo y trasplante', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (7, 'Hidroponía', 1);

-- Estado Fenológico (Id_catalog = 4)
-- --- MÓDULO VEGETALES (Actualización de Estado Fenológico - Id_catalog = 4) ---
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (4, 'Germinación', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (4, 'Vegetativo', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (4, 'Floración', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (4, 'Fructificación', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (4, 'Cosecha', 1);

-- Requerimiento Hídrico (Id_catalog = 8)
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (8, 'Alto', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (8, 'Medio', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (8, 'Bajo', 1);

-- Ciclo de Vida (Id_catalog = 9)
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (9, 'Anual', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (9, 'Bianual', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (9, 'Perenne', 1);


-- --- MÓDULO ARTÍCULOS ---
-- Categoría (Id_catalog = 3)
-- --- MÓDULO ARTÍCULOS (Actualización de Categoría - Id_catalog = 3) ---
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (3, 'engorde', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (3, 'pañol', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (3, 'insumos', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (3, 'otros', 1);

-- Marca (Id_catalog = 10)
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (10, 'Genérica', 1);


-- --- MÓDULO STOCK / PROVEEDORES ---
-- Proveedor (Id_catalog = 12)
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (12, 'Proveedor General', 1);

-- Ítems de Tipo Elemento (Id_catalog = 11)
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (11, 'Articulo', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (11, 'Vegetal', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (11, 'Animal', 1);

-- 2. Registrar los ítems (preguntas frecuentes) asociados al Id_catalog = 13
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (13, '¿Cuál es el nombre de tu primera mascota?', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (13, '¿En qué ciudad naciste?', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (13, '¿Cuál es el apellido de soltera de tu madre?', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (13, '¿Cuál era el nombre de tu primera escuela?', 1);
GO



-- 14: Modo Inicio
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (14, 'Manual', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (14, 'Automático', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (14, 'Semicontrolado', 1);
GO
-- 15: Tipo Actividad
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (15, 'Secuencial', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (15, 'Paralela', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (15, 'Condicionada', 1);
GO
-- 16: Tipo Movimiento
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (16, 'Entrada', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (16, 'Salida', 1);
GO
-- 17: Tipo Unidad
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (17, 'Kilogramos (kg)', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (17, 'Gramos (g)', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (17, 'Litros (l)', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (17, 'Unidades (u)', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (17, 'Hectáreas (ha)', 1);
INSERT INTO Catalogo_tipo_items (Id_catalog, Nombre, Activo) VALUES (17, 'Atados / Bultos', 1);
GO


IF NOT EXISTS (SELECT 1 FROM Partido)
BEGIN

INSERT INTO dbo.Partido (NombrePartido) VALUES ('Almirante Brown');
INSERT INTO dbo.Partido (NombrePartido) VALUES ('San Vicente');
END;
GO

/* =====================================================
   INSERCIÓN DE LOCALIDADES - ALMIRANTE BROWN
   ===================================================== */
-- IdPartido = 1 (Almirante Brown)
-- IdPartido = 2 (San Vicente)

IF NOT EXISTS (SELECT 1 FROM Localidad)
BEGIN
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Adrogué', 1846, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Burzaco', 1852, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Claypole', 1849, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Glew', 1856, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Longchamps', 1854, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Malvinas Argentinas (Brown)', 1847, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Ministro Rivadavia', 1854, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'San José', 1846, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Soledad', 1853, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Rafael Calzada', 1847, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'San Vicente', 1865, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Alejandro Korn', 1864, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Domselaar', 1984, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Villa Coll', 1865, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Laguna del Ojo', 1865, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Estancia El Pino', 1865, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Paraje La Laurita', 1865, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Campo de Mayo Chico', 1865, 2);
END;
GO


-- ==========================================
-- INSERCIÓN SEGURA DE USUARIOS Y PERMISOS
-- ==========================================

DECLARE @IdActual INT;

-- ==========================================
-- 1. ADMIN
-- ==========================================
IF NOT EXISTS (SELECT 1 FROM AbmUsuario WHERE NombreUsuario = 'ADMIN')
BEGIN
    INSERT INTO AbmUsuario (Nombre, Apellido, Documento, Telefono, Direccion, IdLocalidad, IdPartido, Email, NombreUsuario, Contraseña, IdPreguntaSeguridad, RespuestaSeguridad, Estado)
    VALUES ('Administrador', 'General', 00000000, '0000000000', 'Sistema', 1, 1, 'admin@agraria.com', 'ADMIN', '1234', 1, 'Default', 1);
END;

-- Asignar permisos buscando su ID real
SELECT @IdActual = Id FROM AbmUsuario WHERE NombreUsuario = 'ADMIN';
IF NOT EXISTS (SELECT 1 FROM PermisosUsuario WHERE IdUsuario = @IdActual)
BEGIN
    INSERT INTO PermisosUsuario (IdUsuario, PuedeEntornoFormativo, PuedeAltaUsuario, PuedeVenta, PuedeInventario, PuedeIndustria, PuedeProduccionAnimal, PuedeProduccionVegetal, PuedeAdministracion)
    VALUES (@IdActual, 1, 1, 1, 1, 1, 1, 1, 1);
END;

-- ==========================================
-- 2. USUARIO DOS (usudos)
-- ==========================================

IF NOT EXISTS (SELECT 1 FROM AbmUsuario WHERE NombreUsuario = 'usudos')
BEGIN
    INSERT INTO AbmUsuario (Nombre, Apellido, Documento, Telefono, Direccion, IdLocalidad, IdPartido, Email, NombreUsuario, Contraseña, IdPreguntaSeguridad, RespuestaSeguridad, Estado)
    VALUES ('Usuario', 'dos', 11111111, '1111111111', 'Direccion 1', 1, 1, 'usuariodos@agraria.com', 'usudos', '1234', 1, 'Default', 1);
END;

SELECT @IdActual = Id FROM AbmUsuario WHERE NombreUsuario = 'usudos';
IF NOT EXISTS (SELECT 1 FROM PermisosUsuario WHERE IdUsuario = @IdActual)
BEGIN
    INSERT INTO PermisosUsuario (IdUsuario, PuedeEntornoFormativo, PuedeAltaUsuario, PuedeVenta, PuedeInventario, PuedeIndustria, PuedeProduccionAnimal, PuedeProduccionVegetal, PuedeAdministracion)
    VALUES (@IdActual, 1, 0, 1, 1, 0, 1, 1, 0);
END;

-- ==========================================
-- 3. USUARIO TRES (ustres)
-- ==========================================
IF NOT EXISTS (SELECT 1 FROM AbmUsuario WHERE NombreUsuario = 'ustres')
BEGIN
    INSERT INTO AbmUsuario (Nombre, Apellido, Documento, Telefono, Direccion, IdLocalidad, IdPartido, Email, NombreUsuario, Contraseña, IdPreguntaSeguridad, RespuestaSeguridad, Estado)
    VALUES ('Usuario', 'tres', 22222222, '2222222222', 'Direccion 2', 1, 1, 'usuariotres@agraria.com', 'ustres', '1234', 1, 'Default', 1);
END;

SELECT @IdActual = Id FROM AbmUsuario WHERE NombreUsuario = 'ustres';
IF NOT EXISTS (SELECT 1 FROM PermisosUsuario WHERE IdUsuario = @IdActual)
BEGIN
    INSERT INTO PermisosUsuario (IdUsuario, PuedeEntornoFormativo, PuedeAltaUsuario, PuedeVenta, PuedeInventario, PuedeIndustria, PuedeProduccionAnimal, PuedeProduccionVegetal, PuedeAdministracion)
    VALUES (@IdActual, 1, 0, 1, 1, 0, 1, 1, 0);
END;

-- ==========================================
-- 4. USUARIO CUATRO (uscuatro)
-- ==========================================
IF NOT EXISTS (SELECT 1 FROM AbmUsuario WHERE NombreUsuario = 'uscuatro')
BEGIN
    INSERT INTO AbmUsuario (Nombre, Apellido, Documento, Telefono, Direccion, IdLocalidad, IdPartido, Email, NombreUsuario, Contraseña, IdPreguntaSeguridad, RespuestaSeguridad, Estado)
    VALUES ('Usuario', 'cuatro', 33333333, '3333333333', 'Direccion 3', 1, 1, 'usuariocuatro@agraria.com', 'uscuatro', '1234', 1, 'Default', 1);
END;

SELECT @IdActual = Id FROM AbmUsuario WHERE NombreUsuario = 'uscuatro';
IF NOT EXISTS (SELECT 1 FROM PermisosUsuario WHERE IdUsuario = @IdActual)
BEGIN
    INSERT INTO PermisosUsuario (IdUsuario, PuedeEntornoFormativo, PuedeAltaUsuario, PuedeVenta, PuedeInventario, PuedeIndustria, PuedeProduccionAnimal, PuedeProduccionVegetal, PuedeAdministracion)
    VALUES (@IdActual, 1, 0, 1, 1, 0, 1, 1, 0);
END;

-- ==========================================
-- 5. USUARIO CINCO (uscinco)
-- ==========================================
IF NOT EXISTS (SELECT 1 FROM AbmUsuario WHERE NombreUsuario = 'uscinco')
BEGIN
    INSERT INTO AbmUsuario (Nombre, Apellido, Documento, Telefono, Direccion, IdLocalidad, IdPartido, Email, NombreUsuario, Contraseña, IdPreguntaSeguridad, RespuestaSeguridad, Estado)
    VALUES ('Usuario', 'cinco', 44444444, '4444444444', 'Direccion 4', 1, 1, 'usuariocinco@agraria.com', 'uscinco', '1234', 1, 'Default', 1);
END;

SELECT @IdActual = Id FROM AbmUsuario WHERE NombreUsuario = 'uscinco';
IF NOT EXISTS (SELECT 1 FROM PermisosUsuario WHERE IdUsuario = @IdActual)
BEGIN
    INSERT INTO PermisosUsuario (IdUsuario, PuedeEntornoFormativo, PuedeAltaUsuario, PuedeVenta, PuedeInventario, PuedeIndustria, PuedeProduccionAnimal, PuedeProduccionVegetal, PuedeAdministracion)
    VALUES (@IdActual, 1, 0, 1, 1, 0, 1, 1, 0);
END;
GO

insert into rubro (id_tipo, nombre) values (1, 'Bovinos'), (1, 'Porcinos'), (1, 'Ovino '), (2, 'Avícola'), (3, 'Apícola');
go
insert into subrubro (id_rubro, nombre) values (1, 'Hereford'), (1, 'Holando argentina'), (4, 'Bataraza'), (4, 'Ponedora'), (5, 'Africana'), (2, 'Landrace');
go
-- Se inserta el proveedor 1 solo si no existe
IF NOT EXISTS (SELECT 1 FROM [dbo].[proveedores] WHERE id_proveedor = 1)
BEGIN
    INSERT INTO [dbo].[proveedores] ([nombre], [cuil], [telefono], [direccion], [mail])
    VALUES ( 'Agroinsumos Pampeanos S.A.', '30-12345678-9', '011-5555-1010', 'Ruta 5 Km 100, Mercedes, BA', 'ventas@agropampeanos.com.ar');
END;

-- Se inserta el proveedor 2 solo si no existe
IF NOT EXISTS (SELECT 1 FROM [dbo].[proveedores] WHERE id_proveedor = 2)
BEGIN
    INSERT INTO [dbo].[proveedores] ( [nombre], [cuil], [telefono], [direccion], [mail])
    VALUES ( 'Semillas y Forrajes Del Sur SRL', '30-87654321-1', '0223-456-7890', 'Av. Circunvalación 1200, Tandil, BA', 'contacto@semillasdelsur.com.ar');
END;

-- Se inserta el proveedor 3 solo si no existe
IF NOT EXISTS (SELECT 1 FROM [dbo].[proveedores] WHERE id_proveedor = 3)
BEGIN
    INSERT INTO [dbo].[proveedores] ( [nombre], [cuil], [telefono], [direccion], [mail])
    VALUES ( 'Veterinaria El Estribo', '27-11223344-5', '0221-333-4444', 'Calle 44 Nro 1500, La Plata, BA', 'info@vet-elestribo.com.ar');
END;
GO

insert into marca (nombre) values ('Propia'), ('Otro'), ('Molinos');
go

