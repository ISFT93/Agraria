USE AGRARIA100
GO
--ciclos modelos preparados prevamientente para usar el template en el momento de ejecutar uno de ellos, 
--va a permitir que cierto nivel de usuarios pueda preparar esquemas tradicionales que luego deben seguirse
   CREATE TABLE dbo.ciclos_modelo (
        id_ciclo bigint IDENTITY(1,1) NOT NULL CONSTRAINT PK_ciclos_productivos PRIMARY KEY,
        nombre varchar(150) NOT NULL, 
        descripcion varchar(2000) NULL,
        duracion_estimada decimal(12,2) NULL, --cantidad en dias de cuanto dura el ciclo
        modo_inicio int,                      --para futuro poder iniciar ciclos automaticos
        activo bit NOT NULL ,                 --vigente o no para usarlo como modelo
        fecha_creacion datetime NOT NULL ,
        creado_por int NOT NULL
    );     
GO
--actividades que conforman el  modelo y pueden ser divididas, 
    CREATE TABLE dbo.actividades_ciclo_modelo (
        id_actividad_modelo bigint IDENTITY(1,1) NOT NULL CONSTRAINT PK_actividades_modelo PRIMARY KEY,
        id_ciclo bigint NOT NULL,
        nombre varchar(150) NOT NULL,
        descripcion varchar(2000) NULL,
        orden int NOT NULL,     --orden del paso a paso de las actividades
        tipo_actividad int,     --secuencial, paralela
        duracion_estimada decimal(12,2) NULL, 
        demora bit ,   --es para el caso de poder avanzar con las siguientes tareas
        requiere_aprobacion bit NOT NULL ,  --condiciona su ejecucion
        permite_ejecucion_parcial bit NOT NULL , --alguna tarea que pueda quedar incompleta
        condicion_avance nvarchar(1000) NULL,   --detalles tecnicos
        activa bit NOT NULL ,
        
    );
	
	

GO




--Insumos y productos previstos por actividad.
--salidas que pueden producirse de la actividad como producto final
    CREATE TABLE dbo.actividad_elementos (
        id_actividad_elemento bigint IDENTITY(1,1) NOT NULL CONSTRAINT PK_actividad_elementos PRIMARY KEY,
        id_actividad_modelo bigint NOT NULL,
        id_elemento bigint NOT NULL,
        tipo_elemento int not null, -- ANIMAL, VEGETAL, ARTICULO
        tipo_movimiento int NOT NULL, -- SALIDA / ENTRADA
        cantidad_prevista decimal(18,4) NOT NULL,
        id_unidad int NOT NULL,
        obligatorio bit NOT NULL , --es un elemento imprescindible
        vendible_destino bit NULL,  --si es de salida, si va para la venta
        permite_sustitucion bit ,    --si es de entrada y puede sustituirse por otro
        observaciones varchar(1000) NULL  

    );