USE [Agraria]
GO

/****** Objeto: Table [dbo].[AbmUsuario] Fecha de script: 20/9/2026 18:32:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AbmUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](100) NULL,
	[Documento] [int] NULL,
	[Telefono] [varchar](20) NULL,
	[Direccion] [varchar](200) NULL,
	[IdLocalidad] [int] NULL,
	[IdPartido] [int] NULL,
	[Email] [varchar](150) NULL,
	[NombreUsuario] [varchar](100) NULL,
	[Contraseña] [varchar](100) NULL,
	[IdPreguntaSeguridad] [int] NULL,
	[RespuestaSeguridad] [varchar](200) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_AbmUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AbmUsuario] ADD  DEFAULT ((1)) FOR [Estado]
GO

ALTER TABLE [dbo].[AbmUsuario]  WITH CHECK ADD FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidad] ([IdLocalidad])
GO

ALTER TABLE [dbo].[AbmUsuario]  WITH CHECK ADD FOREIGN KEY([IdPartido])
REFERENCES [dbo].[Partido] ([IdPartido])
GO

ALTER TABLE [dbo].[AbmUsuario]  WITH CHECK ADD FOREIGN KEY([IdPreguntaSeguridad])
REFERENCES [dbo].[PreguntaSeguridad] ([IdPregunta])
GO


