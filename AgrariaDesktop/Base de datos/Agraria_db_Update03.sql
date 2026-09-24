USE Agraria;
GO

DELETE FROM PermisosUsuario;
DELETE FROM AbmUsuario;

DBCC CHECKIDENT ('PermisosUsuario', RESEED, 0);
DBCC CHECKIDENT ('AbmUsuario', RESEED, 0);
GO

-- ==========================================
-- INSERCIÓN DE USUARIOS (ADMIN + 4 USUARIOS)
-- ==========================================

-- 1. ADMIN
INSERT INTO AbmUsuario (Nombre, Apellido, Documento, Telefono, Direccion, IdLocalidad, IdPartido, Email, NombreUsuario, Contraseña, IdPreguntaSeguridad, RespuestaSeguridad, Estado)
VALUES ('Administrador', 'General', 00000000, '0000000000', 'Sistema', 1, 1, 'admin@agraria.com', 'ADMIN', '1234', 1, 'Default', 1);

-- 2. Usuariouno
INSERT INTO AbmUsuario (Nombre, Apellido, Documento, Telefono, Direccion, IdLocalidad, IdPartido, Email, NombreUsuario, Contraseña, IdPreguntaSeguridad, RespuestaSeguridad, Estado)
VALUES ('Usuario', 'dos', 11111111, '1111111111', 'Direccion 1', 1, 1, 'usuariodos@agraria.com', 'usudos', '1234', 1, 'Default', 1);

-- 3. Usuariodos
INSERT INTO AbmUsuario (Nombre, Apellido, Documento, Telefono, Direccion, IdLocalidad, IdPartido, Email, NombreUsuario, Contraseña, IdPreguntaSeguridad, RespuestaSeguridad, Estado)
VALUES ('Usuario', 'tres', 22222222, '2222222222', 'Direccion 2', 1, 1, 'usuariotres@agraria.com', 'ustres', '1234', 1, 'Default', 1);

-- 4. Usuariotres
INSERT INTO AbmUsuario (Nombre, Apellido, Documento, Telefono, Direccion, IdLocalidad, IdPartido, Email, NombreUsuario, Contraseña, IdPreguntaSeguridad, RespuestaSeguridad, Estado)
VALUES ('Usuario', 'cuatro', 33333333, '3333333333', 'Direccion 3', 1, 1, 'usuariocuatro@agraria.com', 'uscuatro', '1234', 1, 'Default', 1);

-- 5. Usuariocuatro
INSERT INTO AbmUsuario (Nombre, Apellido, Documento, Telefono, Direccion, IdLocalidad, IdPartido, Email, NombreUsuario, Contraseña, IdPreguntaSeguridad, RespuestaSeguridad, Estado)
VALUES ('Usuario', 'cinco', 44444444, '4444444444', 'Direccion 4', 1, 1, 'usuariocinco@agraria.com', 'uscinco', '1234', 1, 'Default', 1);


-- ==========================================
-- INSERCIÓN DE PERMISOS PARA LOS USUARIOS
-- ==========================================

-- Permisos completos para el Administrador (Id 1)
INSERT INTO PermisosUsuario (IdUsuario, PuedeEntornoFormativo, PuedeAltaUsuario, PuedeVenta, PuedeInventario, PuedeIndustria, PuedeProduccionAnimal, PuedeProduccionVegetal, PuedeAdministracion)
VALUES (1, 1, 1, 1, 1, 1, 1, 1, 1);

-- Permisos estándar para los 4 usuarios (Ids 2, 3, 4 y 5)
INSERT INTO PermisosUsuario (IdUsuario, PuedeEntornoFormativo, PuedeAltaUsuario, PuedeVenta, PuedeInventario, PuedeIndustria, PuedeProduccionAnimal, PuedeProduccionVegetal, PuedeAdministracion)
VALUES 
(2, 1, 0, 1, 1, 0, 1, 1, 0),
(3, 1, 0, 1, 1, 0, 1, 1, 0),
(4, 1, 0, 1, 1, 0, 1, 1, 0),
(5, 1, 0, 1, 1, 0, 1, 1, 0);