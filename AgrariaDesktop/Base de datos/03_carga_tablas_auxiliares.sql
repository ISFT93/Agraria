--- Carga de Tablas ---
use Agraria
go

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
/* =====================================================
   INSERCIÓN DE LOCALIDADES - SAN VICENTE
   ===================================================== */
-- IdPartido = 2 (San Vicente)

IF NOT EXISTS (SELECT 1 FROM PreguntaSeguridad)
BEGIN

INSERT INTO PreguntaSeguridad (TextoPregunta)
VALUES 
('¿Nombre de tu primer Mascota?'),
('¿Cual es tu libro favorito?'),
('¿Nombre de tu mejor amigo de la infancia?'),
('¿Ciudad donde naciste?'),
('¿Nombre de tu escuela primaria?');
END;
GO

IF NOT EXISTS (SELECT 1 FROM tipo_cultivo)
BEGIN
    INSERT INTO tipo_cultivo (nombre) VALUES ('Hortícola'), ('Extensivo'), ('Frutícola'), ('Forrajero'), ('Pastura');
END;
GO

IF NOT EXISTS (SELECT 1 FROM ciclo_vida)
BEGIN
    INSERT INTO ciclo_vida (nombre) VALUES ('Anual'), ('Bianual'), ('Perenne');
END;
GO

IF NOT EXISTS (SELECT 1 FROM metodo_siembra)
BEGIN
    INSERT INTO metodo_siembra (nombre) VALUES ('Siembra directa'), ('Almácigo y trasplante'), ('Hidroponía');
END;
GO

IF NOT EXISTS (SELECT 1 FROM estado_fenologico)
BEGIN
    INSERT INTO estado_fenologico (nombre) VALUES ('Germinación'), ('Vegetativo'), ('Floración'), ('Fructificación'), ('Cosecha');
END;
GO

IF NOT EXISTS (SELECT 1 FROM categoria)
BEGIN
    INSERT INTO categoria (nombre) VALUES ('engorde'), ('pañol'), ('insumos'), ('otros');
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

insert into tipo_animal (nombre) values ('Mamífero'), ('Ave'), ('Insecto'), ('Pez');
go
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


---------------------------------Otras tablas restantes ---------------------------------------------------

INSERT INTO TipoEntorno (Nombre)
VALUES ('Animal'), ('Vegetal'), ('Industria'), ('Compras') , ('Pañol');
GO

INSERT INTO TipoMedida (Nombre)
VALUES ('Kilo'), ('Unidad'), ('Litro');
GO


INSERT INTO Productos (idProducto,Nombre, Descripcion,PrecioUnitario)
VALUES
(1,'Pollo al escabeche', 'Se cocina el pollo en agua con sal, luego se fríe y se marina con vinagre, laurel, ajo, pimienta y zanahoria.', 4000),
(2,'Empanadas de pollo', 'Pollo desmenuzado con cebolla y morrón. Se rellena la masa y se hornea.', 3000),
(3,'Pollo parrillero', 'Pollo condimentado con salmuera o adobo y cocinado a la parrilla.', 2000),
(4,'Miel', 'Preparación de miel con frascos de 1kg o ½ kg según el producto.', 2400);
GO

INSERT INTO Box (Nombre)
VALUES ('Box1'), ('Box2'), ('Box3');
GO


INSERT INTO Alimento (Nombre, Cantidad, IdTipoMedida, Precio, FechaIngreso, IdTipoEntorno, IdProveedor, Estado)
VALUES 
('Maíz molido', 1000, 2, 350.00, GETDATE(), 2, 1, 1),
('Balanceado Engorde', 800, 2, 420.00, GETDATE(), 2, 1, 1),
('Soja Pelletizada', 600, 2, 480.00, GETDATE(), 2, 1, 1),
('Avena', 500, 2, 300.00, GETDATE(), 2, 1, 1);
GO


INSERT INTO BoxCarne (Nombre)
VALUES 
('Box 1'),
('Box 2'),
('Box 3');
GO


INSERT INTO Box (Nombre)
VALUES ('Box1'), ('Box2'), ('Box3');
GO

INSERT INTO TipoAnimal (Nombre)
VALUES ('Melliceros');
GO



