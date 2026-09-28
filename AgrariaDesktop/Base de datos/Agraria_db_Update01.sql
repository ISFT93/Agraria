/* Realizado por Isaias */

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipo_cultivo]') AND type in (N'U'))
BEGIN
    CREATE TABLE tipo_cultivo (
        id_tipo_cultivo INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100) -- ('Hortícola', 'Extensivo', 'Frutícola', 'Forrajero')
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ciclo_vida]') AND type in (N'U'))
BEGIN
    CREATE TABLE ciclo_vida (
        id_ciclo_vida INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(50) -- ('Anual', 'Bianual', 'Perenne')
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[metodo_siembra]') AND type in (N'U'))
BEGIN
    CREATE TABLE metodo_siembra (
        id_metodo_siembra INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100) -- ('Siembra directa', 'Almácigo y trasplante', 'Hidroponía')
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[estado_fenologico]') AND type in (N'U'))
BEGIN
    CREATE TABLE estado_fenologico (
        id_estado_fenologico INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100) -- ('Germinación', 'Vegetativo', 'Floración', 'Fructificación', 'Cosecha')
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipo_animal]') AND type in (N'U'))
BEGIN
    CREATE TABLE tipo_animal (
        id_tipo_animal INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100) -- Ej: Mamífero, Ave, Insecto
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rubro]') AND type in (N'U'))
BEGIN
    CREATE TABLE rubro (
        id_rubro INT IDENTITY(1,1) PRIMARY KEY,
        id_tipo INT NOT NULL,
        nombre VARCHAR(100) NOT NULL, -- Ej: Vaca, Gallina, Cerdo, Abeja
        CONSTRAINT fk_tipo_animal FOREIGN KEY (id_tipo) REFERENCES tipo_animal(id_tipo_animal)
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subrubro]') AND type in (N'U'))
BEGIN
    CREATE TABLE subrubro (
        id_subrubro INT IDENTITY(1,1) PRIMARY KEY,
        id_rubro INT NOT NULL,
        nombre VARCHAR(150) NOT NULL, -- Ej: Hereford, Holando Argentino, Batarasa, etc.
        CONSTRAINT fk_rubro FOREIGN KEY (id_rubro) REFERENCES rubro(id_rubro)
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vegetal]') AND type in (N'U'))
BEGIN
    CREATE TABLE vegetal (
        id_vegetal BIGINT PRIMARY KEY,   
        nombre_comun VARCHAR(40) NOT NULL,
        nombre_cientifico VARCHAR(40),
        variedad_hibrido VARCHAR(40),
        id_tipo_cultivo INT,
        id_ciclo_vida INT,
        periodosiembra VARCHAR(10),
        id_metodo_siembra INT,
        id_estado_fenologico INT,
        requerimiento_hidrico VARCHAR(20) CHECK (requerimiento_hidrico IN ('Alto', 'Medio', 'Bajo')),
        CONSTRAINT fk_veg_cultivo FOREIGN KEY (id_tipo_cultivo) REFERENCES tipo_cultivo(id_tipo_cultivo),
        CONSTRAINT fk_veg_ciclo FOREIGN KEY (id_ciclo_vida) REFERENCES ciclo_vida(id_ciclo_vida),
        CONSTRAINT fk_veg_metodo FOREIGN KEY (id_metodo_siembra) REFERENCES metodo_siembra(id_metodo_siembra),
        CONSTRAINT fk_veg_fenologico FOREIGN KEY (id_estado_fenologico) REFERENCES estado_fenologico(id_estado_fenologico) 
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[animal]') AND type in (N'U'))
BEGIN
    CREATE TABLE animal (
        id_animal BIGINT PRIMARY KEY,
        nombre_comun VARCHAR(100),
        nombre_cientifico VARCHAR(150),
        id_tipo INT,
        id_rubro INT,
        id_subrubro INT,
        fecha_nacimiento DATE,
        sexo VARCHAR(20) CHECK (sexo IN ('Macho', 'Hembra')),
        CONSTRAINT fk_anim_tipo FOREIGN KEY (id_tipo) REFERENCES tipo_animal(id_tipo_animal),
        CONSTRAINT fk_anim_rubro FOREIGN KEY (id_rubro) REFERENCES rubro(id_rubro),
        CONSTRAINT fk_anim_subrubro FOREIGN KEY (id_subrubro) REFERENCES subrubro(id_subrubro)
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proveedores]') AND type in (N'U'))
BEGIN
    CREATE TABLE proveedores (
        id_proveedores BIGINT PRIMARY KEY,
        nombre VARCHAR(150),
        cuil VARCHAR(20),
        telefono VARCHAR(30),
        direccion VARCHAR(100),
        mail VARCHAR(100)
    );
END;
GO

/* Realizado por Noelia */
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[marca]') AND type in (N'U'))
BEGIN
    CREATE TABLE marca (
        id_marca INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100)
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categoria]') AND type in (N'U'))
BEGIN
    CREATE TABLE categoria (
        id_categoria INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100) --- (engorde/pañol/insumos/otros)
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulos]') AND type in (N'U'))
BEGIN
    CREATE TABLE articulos (
        id_articulo BIGINT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(150),
        id_marca INT,
        fecha_alta DATE,
        id_categoria INT, 
        CONSTRAINT fk_articulos_marca FOREIGN KEY (id_marca) REFERENCES marca(id_marca),
        CONSTRAINT fk_articulos_categoria FOREIGN KEY (id_categoria) REFERENCES categoria(id_categoria)
    );
END;
GO

--- Carga de Tablas ---

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