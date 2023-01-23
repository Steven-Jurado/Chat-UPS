-- DROP SCHEMA dbo;

CREATE DATABASE chatups;

CREATE SCHEMA dbo;
-- chatups.dbo.Mensajes definition

-- Drop table

-- DROP TABLE chatups.dbo.Mensajes;

CREATE TABLE chatups.dbo.Mensajes (
	IdMensaje uniqueidentifier NOT NULL,
	ContenidoMensaje nvarchar(MAX) COLLATE Modern_Spanish_CI_AS NOT NULL,
	FechaCreacion datetime2 NOT NULL,
	CONSTRAINT PK_Mensajes PRIMARY KEY (IdMensaje)
);


-- chatups.dbo.Usuario definition

-- Drop table

-- DROP TABLE chatups.dbo.Usuario;

CREATE TABLE chatups.dbo.Usuario (
	IdUsuario int IDENTITY(1,1) NOT NULL,
	Usuario nvarchar(30) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Clave nvarchar(8) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Activo bit NOT NULL,
	CONSTRAINT PK_Usuario PRIMARY KEY (IdUsuario)
);


-- chatups.dbo.[__EFMigrationsHistory] definition

-- Drop table

-- DROP TABLE chatups.dbo.[__EFMigrationsHistory];

CREATE TABLE chatups.dbo.[__EFMigrationsHistory] (
	MigrationId nvarchar(150) COLLATE Modern_Spanish_CI_AS NOT NULL,
	ProductVersion nvarchar(32) COLLATE Modern_Spanish_CI_AS NOT NULL,
	CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
);


-- chatups.dbo.UsuarioChat definition

-- Drop table

-- DROP TABLE chatups.dbo.UsuarioChat;

CREATE TABLE chatups.dbo.UsuarioChat (
	IdUsuarioChat uniqueidentifier NOT NULL,
	Nombre nvarchar(MAX) COLLATE Modern_Spanish_CI_AS NOT NULL,
	IdentificadorGrupo uniqueidentifier NOT NULL,
	IdUsuario int NOT NULL,
	CONSTRAINT PK_UsuarioChat PRIMARY KEY (IdUsuarioChat),
	CONSTRAINT FK_UsuarioChat_Usuario_IdUsuario FOREIGN KEY (IdUsuario) REFERENCES chatups.dbo.Usuario(IdUsuario) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_UsuarioChat_IdUsuario ON dbo.UsuarioChat (  IdUsuario ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
