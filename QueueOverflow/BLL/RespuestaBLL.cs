using QueueOverflow.DAL;
using QueueOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueOverflow.BLL
{
    public class RespuestaBLL
    {
        public static Respuesta rowToDto(RespuestaDS.RespuestasRow row)
        {
            Respuesta objRespuesta = new Respuesta();
            objRespuesta.idRespuesta = row.idRespuesta;
            objRespuesta.txtContenido = row.txtContenido;
            objRespuesta.intEstado = row.intEstado;
            objRespuesta.dateFechaCreacion = row.dateFechaCreacion;
            objRespuesta.dateFechaModificacion = row.dateFechaModificacion;
            objRespuesta.idPregunta = row.idPregunta;
            objRespuesta.idUsuario = row.idUsuario;
            return objRespuesta;
        }
        public static List<Respuesta> getAllAnswers()
        {
            List<Respuesta> listaRespuestas = new List<Respuesta>();
            QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter objDataSet = new QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter();
            RespuestaDS.RespuestasDataTable dtRespuestas = objDataSet.GetAllAnswers();

            foreach (RespuestaDS.RespuestasRow row in dtRespuestas)
            {
                Respuesta objRespuesta = rowToDto(row);
                listaRespuestas.Add(objRespuesta);
            }
            return listaRespuestas;
        }
        public static Respuesta getAnswerByID(int idAnswer)
        {
            Respuesta objRespuesta = new Respuesta();
            QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter objDataSet = new QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter();
            RespuestaDS.RespuestasDataTable dtRespuestas = objDataSet.GetAnswerByID(idAnswer);
            if (dtRespuestas.Count > 0)
            {
                objRespuesta = rowToDto(dtRespuestas[0]);
                return objRespuesta;
            }
            return null;
        }
        public static List<Respuesta> getAnswersByIDUser(int idUser)
        {
            List<Respuesta> listaRespuestas = new List<Respuesta>();
            QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter objDataSet = new QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter();
            RespuestaDS.RespuestasDataTable dtRespuestas = objDataSet.GetAnswerByIDUser(idUser);
            foreach (RespuestaDS.RespuestasRow row in dtRespuestas)
            {
                Respuesta objRespuesta = rowToDto(row);
                listaRespuestas.Add(objRespuesta);
            }
            return listaRespuestas;
        }
        public static List<Respuesta> getAnswersByIDQuestion(int idQuestion)
        {
            List<Respuesta> listaRespuestas = new List<Respuesta>();
            QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter objDataSet = new QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter();
            RespuestaDS.RespuestasDataTable dtRespuestas = objDataSet.GetAnswerByIDQuestion(idQuestion);
            foreach (RespuestaDS.RespuestasRow row in dtRespuestas)
            {
                Respuesta objRespuesta = rowToDto(row);
                listaRespuestas.Add(objRespuesta);
            }
            return listaRespuestas;
        }
        public static int insertAnswer(Respuesta question)
        {
            QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter objDataSet = new QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter();
            int? id = 0;
            objDataSet.InsertAnswer(ref id, question.txtContenido, question.intEstado, question.dateFechaCreacion, question.dateFechaModificacion, question.idPregunta, question.idUsuario);
            return (int)id;
        }
        public static void updateAnswer(Respuesta question)
        {
            QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter objDataSet = new QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter();
            objDataSet.UpdateAnswer(question.idRespuesta, question.txtContenido, question.intEstado, question.dateFechaCreacion, question.dateFechaModificacion, question.idPregunta, question.idUsuario);
        }
        public static void deleteAnswer(int idAnswer)
        {
            QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter objDataSet = new QueueOverflow.DAL.RespuestaDSTableAdapters.RespuestasTableAdapter();
            objDataSet.DeleteAnswer(idAnswer);
        }
    }
}