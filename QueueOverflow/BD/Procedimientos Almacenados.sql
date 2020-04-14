-- =============================================
-- Autor:			Eduardo Flores
-- Fecha:			19/11/2014
-- Descripción:		Procedimientos Almacenados
-- Versión:			1.0.0
-- =============================================

USE QueueOverflowBD
GO

PRINT 'CREACION DE  PROCEDIMIENTOS'
PRINT '----------------------------------------------------------------------------------------------'
PRINT 'PROCEDIMIENTOS DE INSERCION'

PRINT 'CREACION DE PROCEDIMIENTO SP_INSERTUSER'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_InsertUser]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_InsertUser]
END
GO

CREATE PROCEDURE [SP_InsertUser]
@idUsuario						int OUTPUT,
@txtNombreUsuario				varchar(100),
@txtCorreo						varchar(100),
@txtPassword					varchar(100),
@txtNombreReal					varchar(100)
AS
BEGIN
INSERT INTO [tblUsuarios](txtNombreUsuario,txtCorreo,txtPassword,txtNombreReal) 
values (@txtNombreUsuario,@txtCorreo,CONVERT(varbinary(100),@txtPassword),@txtNombreReal)
SET @idUsuario = SCOPE_IDENTITY() 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_INSERTUSER'

PRINT 'CREACION DE PROCEDIMIENTO SP_INSERTQUESTION'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_InsertQuestion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_InsertQuestion]
END
GO

CREATE PROCEDURE [SP_InsertQuestion]
@idPregunta						int OUTPUT,
@txtTitulo						varchar(100),
@txtContenido					text,
@dateFechaCreacion				datetime,
@dateFechaModificacion			datetime,
@intEstado						int,
@idUsuario						int
AS
BEGIN
INSERT INTO [tblPreguntas](txtTitulo,txtContenido,dateFechaCreacion,dateFechaModificacion,intEstado,idUsuario) 
values (@txtTitulo,@txtContenido,@dateFechaCreacion,@dateFechaModificacion,@intEstado,@idUsuario)
SET @idPregunta = SCOPE_IDENTITY() 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_INSERTQUESTION'

PRINT 'CREACION DE PROCEDIMIENTO SP_INSERTCATEGORY'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_InsertCategory]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_InsertCategory]
END
GO

CREATE PROCEDURE [SP_InsertCategory]
@idCategoria					int OUTPUT,
@txtNombreCategoria				varchar(100)
AS
BEGIN
INSERT INTO [tblCategorias](txtNombreCategoria) 
values (@txtNombreCategoria)
SET @idCategoria = SCOPE_IDENTITY() 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_INSERTCATEGORY'

PRINT 'CREACION DE PROCEDIMIENTO SP_INSERTQUESTIONCATEGORY'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_InsertQuestionCategory') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_InsertQuestionCategory]
END
GO

CREATE PROCEDURE [SP_InsertQuestionCategory]
@idRegistro						int OUTPUT,
@idPregunta						int,
@idCategoria					int
AS
BEGIN
INSERT INTO [tblPreguntaCategorias](idPregunta,idCategoria) 
values (@idPregunta,@idCategoria)
SET @idRegistro = SCOPE_IDENTITY() 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_INSERTQUESTIONCATEGORY'

PRINT 'CREACION DE PROCEDIMIENTO SP_INSERTANSWER'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_InsertAnswer]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_InsertAnswer]
END
GO

CREATE PROCEDURE [SP_InsertAnswer]
@idRespuesta					int OUTPUT,
@txtContenido					text,
@intEstado						int,
@dateFechaCreacion				datetime,
@dateFechaModificacion			datetime,
@idPregunta						int,
@idUsuario						int
AS
BEGIN
INSERT INTO [tblRespuestas](txtContenido,intEstado,dateFechaCreacion,dateFechaModificacion,idPregunta,idUsuario) 
values (@txtContenido,@intEstado,@dateFechaCreacion,@dateFechaModificacion,@idPregunta,@idUsuario)
SET @idRespuesta = SCOPE_IDENTITY() 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_INSERTANSWER'

PRINT 'CREACION DE PROCEDIMIENTO SP_INSERTCOMENT'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_InserComent]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_InserComent]
END
GO

CREATE PROCEDURE [SP_InserComent]
@idComentario					int OUTPUT,
@txtContenido					text,
@dateFechaCreacion				datetime,
@idRegistro						int,
@flagTipoComentario				int,
@idUsuario						int
AS
BEGIN
INSERT INTO [tblComentarios](txtContenido,dateFechaCreacion,idRegistro,flagTipoComentario,idUsuario) 
values (@txtContenido,@dateFechaCreacion,@idRegistro,@flagTipoComentario,@idUsuario)
SET @idComentario = SCOPE_IDENTITY() 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_INSERTCOMENT'

PRINT 'CREACION DE PROCEDIMIENTO SP_INSERTVOTE'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_InsertVote]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_InsertVote]
END
GO

CREATE PROCEDURE [SP_InsertVote]
@idVoto							int OUTPUT,
@intEstado						int,
@idRegistro						int,
@flagTipoVoto					int,
@idUsuario						int
AS
BEGIN
INSERT INTO [tblVotos](intEstado,idRegistro,flagTipoVoto,idUsuario) 
values (@intEstado,@idRegistro,@flagTipoVoto,@idUsuario)
SET @idVoto = SCOPE_IDENTITY() 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_INSERTVOTE'
PRINT 'FIN PROCEDIMIENTOS DE INSERCION'

PRINT 'PROCEDIMIENTOS DE UPDATE'
PRINT 'CREACION DE PROCEDIMIENTO SP_UPDATEUSER'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_UpdatetUser]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_UpdatetUser]
END
GO

CREATE PROCEDURE [SP_UpdatetUser]
@idUsuario						int,
@txtNombreUsuario				varchar(100),
@txtCorreo						varchar(100),
@txtPassword					varchar(100),
@txtNombreReal					varchar(100)
AS
BEGIN
UPDATE [tblUsuarios] 
SET txtNombreUsuario = @txtNombreUsuario,
	txtCorreo = @txtCorreo,
	txtPassword = CONVERT(varbinary(100),@txtPassword),
	txtNombreReal = @txtNombreReal
WHERE idUsuario = @idUsuario
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_UPDATEUSER'

PRINT 'CREACION DE PROCEDIMIENTO SP_UPDATEQUESTION'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_UpdateQuestion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_UpdateQuestion]
END
GO

CREATE PROCEDURE [SP_UpdateQuestion]
@idPregunta						int,
@txtTitulo						varchar(100),
@txtContenido					text,
@dateFechaCreacion				datetime,
@dateFechaModificacion			datetime,
@intEstado						int,
@idUsuario						int
AS
BEGIN
UPDATE [tblPreguntas]
SET txtTitulo = @txtTitulo,
	txtContenido = @txtContenido,
	dateFechaCreacion = @dateFechaCreacion,
	dateFechaModificacion = @dateFechaModificacion,
	intEstado = @intEstado,
	idUsuario = @idUsuario
WHERE idPregunta = @idPregunta 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_UPDATEQUESTION'

PRINT 'CREACION DE PROCEDIMIENTO SP_UPDATECATEGORY'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_UpdateCategory]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_UpdateCategory]
END
GO

CREATE PROCEDURE [SP_UpdateCategory]
@idCategoria					int,
@txtNombreCategoria				varchar(100)
AS
BEGIN
UPDATE [tblCategorias]
SET txtNombreCategoria = @txtNombreCategoria
WHERE idCategoria = @idCategoria 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_UPDATECATEGORY'

PRINT 'CREACION DE PROCEDIMIENTO SP_UPDATEQUESTIONCATEGORY'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_UpdateQuestionCategory') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_UpdateQuestionCategory]
END
GO

CREATE PROCEDURE [SP_UpdateQuestionCategory]
@idRegistro						int,
@idPregunta						int,
@idCategoria					int
AS
BEGIN
UPDATE [tblPreguntaCategorias]
SET idPregunta = @idPregunta,
	idCategoria = @idCategoria
WHERE idRegistro = @idRegistro 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_UPDATEQUESTIONCATEGORY'

PRINT 'CREACION DE PROCEDIMIENTO SP_UDPATEANSWER'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_UpdateAnswer]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_UpdateAnswer]
END
GO

CREATE PROCEDURE [SP_UpdateAnswer]
@idRespuesta					int,
@txtContenido					text,
@intEstado						int,
@dateFechaCreacion				datetime,
@dateFechaModificacion			datetime,
@idPregunta						int,
@idUsuario						int
AS
BEGIN
UPDATE [tblRespuestas]
SET txtContenido = @txtContenido,
	intEstado = @intEstado,
	dateFechaCreacion = @dateFechaCreacion,
	dateFechaModificacion = @dateFechaModificacion,
	idPregunta = @idPregunta,
	idUsuario = @idUsuario
WHERE idRespuesta = @idRespuesta 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_UDPATEANSWER'

PRINT 'CREACION DE PROCEDIMIENTO SP_UPDATECOMENT'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_UpdateComent]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_UpdateComent]
END
GO

CREATE PROCEDURE [SP_UpdateComent]
@idComentario					int,
@txtContenido					text,
@dateFechaCreacion				datetime,
@idRegistro						int,
@flagTipoComentario				int,
@idUsuario						int
AS
BEGIN
UPDATE [tblComentarios]
SET txtContenido = @txtContenido,
	dateFechaCreacion = @dateFechaCreacion,
	idRegistro = @idRegistro,
	flagTipoComentario = @flagTipoComentario,
	idUsuario = @idUsuario 
WHERE idComentario = @idComentario 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_UPDATECOMENT'

PRINT 'CREACION DE PROCEDIMIENTO SP_UPDATEVOTE'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_UpdateVote]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_UpdateVote]
END
GO

CREATE PROCEDURE [SP_UpdateVote]
@idVoto							int OUTPUT,
@intEstado						int,
@idRegistro						int,
@flagTipoVoto					int,
@idUsuario						int
AS
BEGIN
UPDATE [tblVotos]
SET intEstado = @intEstado,
	idRegistro = @idRegistro,
	flagTipoVoto = @flagTipoVoto,
	idUsuario = @idUsuario
WHERE idVoto = @idVoto 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_UPDATEVOTE'
PRINT 'FIN PROCEDIMIENTOS DE UPDATE'

PRINT 'PROCEDIMIENTOS DE DELETE'
PRINT 'CREACION DE PROCEDIMIENTO SP_DELETEUSER'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_DeleteUser]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_DeleteUser]
END
GO

CREATE PROCEDURE [SP_DeleteUser]
@idUsuario						int
AS
BEGIN
DELETE FROM [tblUsuarios] 
WHERE idUsuario = @idUsuario
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_DELETEUSER'

PRINT 'CREACION DE PROCEDIMIENTO SP_DELETEQUESTION'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_DeleteQuestion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_DeleteQuestion]
END
GO

CREATE PROCEDURE [SP_DeleteQuestion]
@idPregunta						int
AS
BEGIN
DELETE FROM [tblPreguntas]
WHERE idPregunta = @idPregunta 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_DELETEQUESTION'

PRINT 'CREACION DE PROCEDIMIENTO SP_DELETECATEGORY'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_DeleteCategory]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_DeleteCategory]
END
GO

CREATE PROCEDURE [SP_DeleteCategory]
@idCategoria					int
AS
BEGIN
DELETE FROM [tblCategorias]
WHERE idCategoria = @idCategoria 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_DELETECATEGORY'

PRINT 'CREACION DE PROCEDIMIENTO SP_DELETEQUESTIONCATEGORY'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_DeleteQuestionCategory') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_DeleteQuestionCategory]
END
GO

CREATE PROCEDURE [SP_DeleteQuestionCategory]
@idRegistro						int
AS
BEGIN
DELETE FROM [tblPreguntaCategorias]
WHERE idRegistro = @idRegistro 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_DELETEQUESTIONCATEGORY'

PRINT 'CREACION DE PROCEDIMIENTO SP_DELETEANSWER'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_DeleteAnswer]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_DeleteAnswer]
END
GO

CREATE PROCEDURE [SP_DeleteAnswer]
@idRespuesta					int
AS
BEGIN
DELETE FROM [tblRespuestas]
WHERE idRespuesta = @idRespuesta 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_DELETEANSWER'

PRINT 'CREACION DE PROCEDIMIENTO SP_DELETECOMENT'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_DeleteComent]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_DeleteComent]
END
GO

CREATE PROCEDURE [SP_DeleteComent]
@idComentario					int
AS
BEGIN
DELETE FROM [tblComentarios]
WHERE idComentario = @idComentario 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_DELETECOMENT'

PRINT 'CREACION DE PROCEDIMIENTO SP_DELETEVOTE'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_DeleteVote]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_DeleteVote]
END
GO

CREATE PROCEDURE [SP_DeleteVote]
@idVoto							int
AS
BEGIN
DELETE FROM [tblVotos]
WHERE idVoto = @idVoto 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_DELETEVOTE'
PRINT 'FIN PROCEDIMIENTOS DE DELETE'

PRINT 'PROCEDIMIENTOS DE SELECT'
PRINT 'CREACION DE PROCEDIMIENTO SP_GETALLUSERS'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetAllUsers]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetAllUsers]
END
GO

CREATE PROCEDURE [SP_GetAllUsers]
AS
BEGIN
SELECT * FROM [tblUsuarios] 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETALLUSERS'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETUSERBYID'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetUserByID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetUserByID]
END
GO

CREATE PROCEDURE [SP_GetUserByID]
@idUsuario						int
AS
BEGIN
SELECT * FROM [tblUsuarios] 
WHERE idUsuario = @idUsuario
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETUSERBYID'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETUSERBYMAILPASS'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetUserByMailPass]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetUserByMailPass]
END
GO

CREATE PROCEDURE [SP_GetUserByMailPass]
@txtCorreo						varchar(100),
@txtPassword					varchar(100)
AS
BEGIN
SELECT * FROM [tblUsuarios] 
WHERE txtCorreo = @txtCorreo
AND txtPassword = CONVERT(VARBINARY(100),@txtPassword)
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETUSERBYMAILPASS'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETUSERBYNICKPASS'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetUserByNickPass]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetUserByNickPass]
END
GO

CREATE PROCEDURE [SP_GetUserByNickPass]
@txtNombreUsuario					varchar(100),
@txtPassword					varchar(100)
AS
BEGIN
SELECT * FROM [tblUsuarios] 
WHERE txtNombreUsuario = @txtNombreUsuario
AND txtPassword = CONVERT(VARBINARY(100),@txtPassword)
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETUSERBYNICKPASS'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETALLQUESTIONS'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetAllQuestions]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetAllQuestions]
END
GO

CREATE PROCEDURE [SP_GetAllQuestions]
AS
BEGIN
SELECT * FROM [tblPreguntas]
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETALLQUESTIONS'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETQUESTIONSBYIDUSER'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetQuestionsByIDUser]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetQuestionsByIDUser]
END
GO

CREATE PROCEDURE [SP_GetQuestionsByIDUser]
@idUsuario						int
AS
BEGIN
SELECT *  FROM [tblPreguntas]
WHERE idUsuario = @idUsuario 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETQUESTIONSBYIDUSER'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETQUESTIONSBYID'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetQuestionsByID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetQuestionsByID]
END
GO

CREATE PROCEDURE [SP_GetQuestionsByID]
@idPregunta						int
AS
BEGIN
SELECT *  FROM [tblPreguntas]
WHERE idPregunta = @idPregunta 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETQUESTIONSBYID'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETALLCATEGORIES'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetAllCategories]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetAllCategories]
END
GO

CREATE PROCEDURE [SP_GetAllCategories]
AS
BEGIN
SELECT * FROM [tblCategorias]
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETALLCATEGORIES'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETCATEGORIESBYID'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetCategoriesByID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetCategoriesByID]
END
GO

CREATE PROCEDURE [SP_GetCategoriesByID]
@idCategoria					int
AS
BEGIN
SELECT * FROM [tblCategorias]
WHERE idCategoria = @idCategoria 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETCATEGORIESBYID'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETCATEGORIESBYNAME'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetCategoriesByName]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetCategoriesByID]
END
GO

CREATE PROCEDURE [dbo].[SP_GetCategoriesByName]
@txtNombreCategoria					varchar(100)
AS
BEGIN
SELECT * FROM [tblCategorias]
WHERE txtNombreCategoria = @txtNombreCategoria 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETCATEGORIESBYNAME'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETCATEGORIESBYIDQUESTION'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetCategoriesByIDQuestion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetCategoriesByIDQuestion]
END
GO

CREATE PROCEDURE [SP_GetCategoriesByIDQuestion]
@idPregunta					int
AS
BEGIN
SELECT * FROM [tblPreguntaCategorias]
WHERE idPregunta = @idPregunta 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETCATEGORIESBYIDQUESTION'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETALLQUESTIONCATEGORY'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetAllQuestionCategory') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetAllQuestionCategory]
END
GO

CREATE PROCEDURE [SP_GetAllQuestionCategory]
AS
BEGIN
SELECT * FROM [tblPreguntaCategorias]
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETALLQUESTIONCATEGORY'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETQUESTIONSBYIDCATEGORY'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetQuestionsByIDCategory]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetQuestionsByIDCategory]
END
GO

CREATE PROCEDURE [SP_GetQuestionsByIDCategory]
@idCategoria					int
AS
BEGIN
SELECT * FROM [tblPreguntaCategorias]
WHERE idCategoria = @idCategoria 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETQUESTIONSBYIDCATEGORY'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETALLANSWERS'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetAllAnswers]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetAllAnswers]
END
GO

CREATE PROCEDURE [SP_GetAllAnswers]
AS
BEGIN
SELECT * FROM [tblRespuestas]
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETALLANSWERS'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETANSWERBYID'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetAnswerByID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetAnswerByID]
END
GO

CREATE PROCEDURE [SP_GetAnswerByID]
@idRespuesta					int
AS
BEGIN
SELECT * FROM [tblRespuestas]
WHERE idRespuesta = @idRespuesta 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETANSWERBYID'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETANSWERBYIDQUESTION'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetAnswerByIDQuestion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetAnswerByIDQuestion]
END
GO

CREATE PROCEDURE [SP_GetAnswerByIDQuestion]
@idPregunta					int
AS
BEGIN
SELECT * FROM [tblRespuestas]
WHERE idPregunta = @idPregunta 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETANSWERBYIDQUESTION'


PRINT 'CREACION DE PROCEDIMIENTO SP_GETANSWERBYIDUSER'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetAnswerByIDUser]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetAnswerByIDUser]
END
GO

CREATE PROCEDURE [SP_GetAnswerByIDUser]
@idUsuario					int
AS
BEGIN
SELECT * FROM [tblRespuestas]
WHERE idUsuario = @idUsuario 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETANSWERBYIDUSER'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETANSWERBYIDUSERIDQUESTION'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetAnswerByIDUserIDQuestion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetAnswerByIDUserIDQuestion]
END
GO

CREATE PROCEDURE [SP_GetAnswerByIDUserIDQuestion]
@idUsuario					int,
@idPregunta					int
AS
BEGIN
SELECT * FROM [tblRespuestas]
WHERE idUsuario = @idUsuario
AND idPregunta = @idPregunta 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETANSWERBYIDUSERIDQUESTION'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETALLCOMENTS'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetAllComents]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetAllComents]
END
GO

CREATE PROCEDURE [SP_GetAllComents]
AS
BEGIN
SELECT * FROM [tblComentarios]
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETALLCOMENTS'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETCOMENTBYID'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetComentByID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetComentByID]
END
GO

CREATE PROCEDURE [SP_GetComentByID]
@idComentario					int
AS
BEGIN
SELECT * FROM [tblComentarios]
WHERE idComentario = @idComentario 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETCOMENTBYID'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETCOMENTBYIDREGISTERTYPEREGISTER'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetComentByIDRegisterTypeRegister') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetComentByIDRegisterTypeRegister]
END
GO

CREATE PROCEDURE [SP_GetComentByIDRegisterTypeRegister]
@idRegistro					int,
@flagTipoComentario			int
AS
BEGIN
SELECT * FROM [tblComentarios]
WHERE idRegistro = @idRegistro 
AND flagTipoComentario = @flagTipoComentario
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETCOMENTBYIDREGISTERTYPEREGISTER'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETCOMENTBYIDUSER'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetComentByIDUser') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetComentByIDUser]
END
GO

CREATE PROCEDURE [SP_GetComentByIDUser]
@idUsuario					int
AS
BEGIN
SELECT * FROM [tblComentarios]
WHERE idUsuario = @idUsuario 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETCOMENTBYIDUSER'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETALLVOTES'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetAllVotes]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetAllVotes]
END
GO

CREATE PROCEDURE [SP_GetAllVotes]
AS
BEGIN
SELECT * FROM [tblVotos]
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETALLVOTES'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETVOTEBYID'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetVoteByID]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetVoteByID]
END
GO

CREATE PROCEDURE [SP_GetVoteByID]
@idVoto							int
AS
BEGIN
SELECT * FROM [tblVotos]
WHERE idVoto = @idVoto 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETVOTEBYID'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETVOTEBYIDUSER'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetVoteByIDUser]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetVoteByIDUser]
END
GO

CREATE PROCEDURE [SP_GetVoteByIDUser]
@idUsuario							int
AS
BEGIN
SELECT * FROM [tblVotos]
WHERE idUsuario = @idUsuario 
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETVOTEBYIDUSER'

PRINT 'CREACION DE PROCEDIMIENTO SP_GETVOTEBYIDREGISTERTYPEREGISTER'

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[SP_GetVoteByIDRegisterTypeRegister]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [SP_GetVoteByIDRegisterTypeRegister]
END
GO

CREATE PROCEDURE [SP_GetVoteByIDRegisterTypeRegister]
@idRegistro						int,
@flagTipoVoto					int
AS
BEGIN
SELECT * FROM [tblVotos]
WHERE idRegistro = @idRegistro
AND flagTipoVoto = @flagTipoVoto
END
GO
PRINT 'FIN CREACION DE PROCEDIMIENTO SP_GETVOTEBYIDREGISTERTYPEREGISTER'

PRINT 'FIN PROCEDIMIENTOS DE SELECT'

PRINT 'END PROCEDURES'

