/*Realizado por Isaias*/


CREATE TABLE tipo_cultivo (
    id_tipo_cultivo INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) -- ('Hortícola', 'Extensivo', 'Frutícola', 'Forrajero') ,
);
go

CREATE TABLE ciclo_vida (
    id_ciclo_vida INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50)   --('Anual', 'Bianual', 'Perenne') ,
);
go

CREATE TABLE metodo_siembra (
    id_metodo_siembra INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100)   --('Siembra directa', 'Almácigo y trasplante', 'Hidroponía') ,
);
go

CREATE TABLE estado_fenologico (
    id_estado_fenologico INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) -- ('Germinación', 'Vegetativo', 'Floración', 'Fructificación', 'Cosecha') ,
);
go

CREATE TABLE tipo_animal (
    id_tipo_animal INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100)  -- Ej: Mamífero, Ave, Insecto
);
go

CREATE TABLE rubro (
    id_rubro INT IDENTITY(1,1) PRIMARY KEY,
    id_tipo INT NOT NULL,
    nombre VARCHAR(100) NOT NULL, -- Ej: Vaca, Gallina, Cerdo, Abeja
    CONSTRAINT fk_tipo_animal FOREIGN KEY (id_tipo) REFERENCES tipo_animal(id_tipo_animal)
);

go
CREATE TABLE subrubro (
    id_subrubro INT IDENTITY(1,1) PRIMARY KEY,
    id_rubro INT NOT NULL,
    nombre VARCHAR(150) NOT NULL, -- Ej: Hereford, Holando Argentino, Batarasa, etc.
    CONSTRAINT fk_rubro FOREIGN KEY (id_rubro) REFERENCES rubro(id_rubro)
);

go
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
    requerimiento_hidrico VARCHAR(20) CHECK (requerimiento_hidrico IN ('Alto', 'Medio', 'Bajo'))
    CONSTRAINT fk_veg_cultivo FOREIGN KEY (id_tipo_cultivo) REFERENCES tipo_cultivo(id_tipo_cultivo),
    CONSTRAINT fk_veg_ciclo FOREIGN KEY (id_ciclo_vida) REFERENCES ciclo_vida(id_ciclo_vida),
    CONSTRAINT fk_veg_metodo FOREIGN KEY (id_metodo_siembra) REFERENCES metodo_siembra(id_metodo_siembra),
    CONSTRAINT fk_veg_fenologico FOREIGN KEY (id_estado_fenologico) REFERENCES estado_fenologico(id_estado_fenologico) 
);

go

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

go

CREATE TABLE proveedores (
    id_proveedores BIGINT PRIMARY KEY,
    nombre VARCHAR(150) ,
    cuil VARCHAR(20),
    telefono VARCHAR(30),
    direccion VARCHAR(100),
    mail VARCHAR(100),
);


/* Realizado por Noelia  */
go

CREATE TABLE marca (
    id_marca INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100)
);
go

CREATE TABLE categoria(
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100)   --- (engorde/pañol/insumos/otros)
);
go

CREATE TABLE articulos (
    id_articulo BIGINT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(150),
    id_marca INT ,
    fecha_alta DATE,
    id_categoria int, 
    
    
    CONSTRAINT fk_articulos_marca FOREIGN KEY (id_marca) REFERENCES marca(id_marca),
    CONSTRAINT fk_articulos_categoria FOREIGN KEY (id_categoria) REFERENCES categoria(id_categoria)
    
);


/*Realizado por Isaias*/
--A revisar ya que pueden faltarle cosas o sobrar
/*
CREATE TABLE stock (
    id_stock bigint PRIMARY KEY,   
    id_articulo BIGINT ,            -- Opcional: Para herramientas, insumos o elementos de pañol
    id_ciclo VARCHAR(50),               -- Ciclo productivo o campaña
    fecha_alta DATE,
    fecha_baja DATE null ,               -- Nullable para cuando el stock se da de baja
    nro_animal VARCHAR(50) null ,        -- Caravana o identificación específica del animal en stock
    estado_salud ENUM('Excelente','Bueno', 'Malo') ,      -- Excelente / bueno / malo
    es_productor VARCHAR(50),         -- Si genera leche, huevos, etc.
    precio MONEY,                       -- Precio
    id_proveedor BIGINT ,           -- 
    activo BIT DEFAULT 1,
    vendible BIT DEFAULT 0,
    cantidad DECIMAL(10,2) DEFAULT 0.00,
    CONSTRAINT fk_stock_vegetal FOREIGN KEY (id_vegetal) REFERENCES vegetal(id_vegetal),
    CONSTRAINT fk_stock_animal FOREIGN KEY (id_animal) REFERENCES animal(id_animal),
    CONSTRAINT fk_stock_articulo FOREIGN KEY (id_articulo) REFERENCES articulos(id_articulo),
    CONSTRAINT fk_stock_proveedor FOREIGN KEY (id_proveedor) REFERENCES proveedores(id_proveedores)
);
*/
go
---Carga de Tablas----


INSERT INTO tipo_cultivo (nombre) VALUES ('Hortícola'), ('Extensivo'), ('Frutícola'), ('Forrajero'), ('Pastura');
INSERT INTO ciclo_vida (nombre) VALUES ('Anual'), ('Bianual'), ('Perenne');
INSERT INTO metodo_siembra (nombre) VALUES ('Siembra directa'), ('Almácigo y trasplante'), ('Hidroponía');
INSERT INTO estado_fenologico (nombre) VALUES ('Germinación'), ('Vegetativo'), ('Floración'), ('Fructificación'), ('Cosecha');



