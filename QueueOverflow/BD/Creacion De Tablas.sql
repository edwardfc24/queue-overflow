-- =================================================
-- Autor:			Eduardo Flores
-- Fecha:			19/11/2014
-- Descripción:		QueueOverflow
-- Versión:			1.0.0
-- =================================================

PRINT 'INICIANDO CREACION DE LA BASE DE DATOS'

USE master;
GO

IF EXISTS(SELECT name FROM sys.databases WHERE name = 'QueueOverflowBD')
	DROP DATABASE QueueOverflowBD
GO

IF NOT EXISTS(SELECT name FROM sys.databases WHERE name = 'QueueOverflowBD')
	CREATE DATABASE QueueOverflowBD;
GO

USE QueueOverflowBD
GO

PRINT 'FIN CREACION BASE DE DATOS'
GO

PRINT 'INICIANDO CREACION DE TABLAS'

PRINT 'INICIANDO CREACION DE TBLUSUARIOS'
IF EXISTS(SELECT name FROM QueueOverflowBD.sysobjects WHERE name = N'tblUsuarios' AND xtype='U')
	DROP TABLE [tblUsuarios]
	GO
CREATE TABLE [tblUsuarios]
(
	idUsuario						int IDENTITY(1,1) NOT NULL,
	txtNombreUsuario				varchar(100),
	txtCorreo						varchar(100),
	txtPassword						varbinary(100),
	txtNombreReal					varchar(100)
	CONSTRAINT pk_tblUsuarios PRIMARY KEY (idUsuario)
) 
GO
PRINT 'FIN CREACION DE TBLUSUARIOS'

PRINT 'INICIANDO CREACION DE TBLPREGUNTAS'
IF EXISTS(SELECT name FROM QueueOverflowBD.sysobjects WHERE name = N'tblPreguntas' AND xtype='U')
	DROP TABLE [tblPreguntas]
	GO
CREATE TABLE [tblPreguntas]
(
	idPregunta						int IDENTITY(1,1) NOT NULL,
	txtTitulo						varchar(100),
	txtContenido					text,
	dateFechaCreacion				datetime,
	dateFechaModificacion			datetime,
	intEstado						int,
	idUsuario						int
	CONSTRAINT pk_tblPreguntas PRIMARY KEY (idPregunta)
) 
GO
PRINT 'FIN CREACION DE TBLPREGUNTAS'

PRINT 'INICIANDO CREACION DE TBLCATEGORIAS'
IF EXISTS(SELECT name FROM QueueOverflowBD.sysobjects WHERE name = N'tblCategorias' AND xtype='U')
	DROP TABLE [tblCategorias]
	GO
CREATE TABLE [tblCategorias]
(
	idCategoria						int IDENTITY(1,1) NOT NULL,
	txtNombreCategoria				varchar(100)
	CONSTRAINT pk_tblCategorias PRIMARY KEY (idCategoria)
) 
GO
PRINT 'FIN CREACION DE TBLCATEGORIAS'

PRINT 'INICIANDO CREACION DE TBLPREGUNTACATEGORIAS'
IF EXISTS(SELECT name FROM QueueOverflowBD.sysobjects WHERE name = N'tblPreguntaCategorias' AND xtype='U')
	DROP TABLE [tblPreguntaCategorias]
	GO
CREATE TABLE [tblPreguntaCategorias]
(
	idRegistro						int IDENTITY(1,1) NOT NULL,
	idPregunta						int,
	idCategoria						int
	CONSTRAINT pk_tblPreguntaCategorias PRIMARY KEY (idRegistro)
) 
GO
PRINT 'FIN CREACION DE TBLPREGUNTACATEGORIAS'

PRINT 'INICIANDO CREACION DE TBLRESPUESTAS'
IF EXISTS(SELECT name FROM QueueOverflowBD.sysobjects WHERE name = N'tblRespuestas' AND xtype='U')
	DROP TABLE [tblRespuestas]
	GO
CREATE TABLE [tblRespuestas]
(
	idRespuesta						int IDENTITY(1,1) NOT NULL,
	txtContenido					text,
	intEstado						int,
	dateFechaCreacion				datetime,
	dateFechaModificacion			datetime,
	idPregunta						int,
	idUsuario						int
	CONSTRAINT pk_tblRespuestas PRIMARY KEY (idRespuesta)
) 
GO
PRINT 'FIN CREACION DE TBLRESPUESTAS'

PRINT 'INICIANDO CREACION DE TBLCOMENTARIOS'
IF EXISTS(SELECT name FROM QueueOverflowBD.sysobjects WHERE name = N'tblComentarios' AND xtype='U')
	DROP TABLE [tblComentarios]
	GO
CREATE TABLE [tblComentarios]
(
	idComentario					int IDENTITY(1,1) NOT NULL,
	txtContenido					text,
	dateFechaCreacion				datetime,
	idRegistro						int,
	flagTipoComentario				int,
	idUsuario						int
	CONSTRAINT pk_tblComentarios PRIMARY KEY (idComentario)
) 
GO
PRINT 'FIN CREACION DE TBLCOMENTARIOS'

PRINT 'INICIANDO CREACION DE TBLVOTOS'
IF EXISTS(SELECT name FROM QueueOverflowBD.sysobjects WHERE name = N'tblVotos' AND xtype='U')
	DROP TABLE [tblVotos]
	GO
CREATE TABLE [tblVotos]
(
	idVoto							int IDENTITY(1,1) NOT NULL,
	intEstado						int,
	idRegistro						int,
	flagTipoVoto					int,
	idUsuario						int
	CONSTRAINT pk_tblVotos PRIMARY KEY (idVoto)
) 
GO
PRINT 'FIN CREACION DE TBLVOTOS'

USE QueueOverflowBD
GO