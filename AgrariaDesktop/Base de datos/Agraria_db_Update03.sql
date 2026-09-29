USE Agraria;
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