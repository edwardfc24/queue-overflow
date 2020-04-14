using QueueOverflow.DAL;
using QueueOverflow.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;

namespace QueueOverflow.BLL
{
    public class PreguntaBLL
    {
        public static Pregunta rowToDto(PreguntaDS.PreguntasRow row)
        {
            Pregunta objPregunta = new Pregunta();
            objPregunta.idPregunta = row.idPregunta;
            objPregunta.txtTitulo = row.txtTitulo;
            objPregunta.txtContenido = row.txtContenido;
            objPregunta.dateFechaCreacion = row.dateFechaCreacion;
            objPregunta.dateFechaModificacion = row.dateFechaModificacion;
            objPregunta.intEstado = row.intEstado;
            objPregunta.idUsuario = row.idUsuario;
            return objPregunta;
        }
        public static List<Pregunta> getAllQuestions()
        {
            List<Pregunta> listaPreguntas = new List<Pregunta>();
            QueueOverflow.DAL.PreguntaDSTableAdapters.PreguntasTableAdapter objDataSet = new QueueOverflow.DAL.PreguntaDSTableAdapters.PreguntasTableAdapter();
            PreguntaDS.PreguntasDataTable dtPreguntas = objDataSet.GetAllQuestions();

            foreach (PreguntaDS.PreguntasRow row in dtPreguntas)
            {
                Pregunta objPregunta = rowToDto(row);
                listaPreguntas.Add(objPregunta);
            }
            return listaPreguntas;
        }
        public static Pregunta getQuestionByID(int idQuestion)
        {
            Pregunta objPregunta = new Pregunta();
            QueueOverflow.DAL.PreguntaDSTableAdapters.PreguntasTableAdapter objDataSet = new QueueOverflow.DAL.PreguntaDSTableAdapters.PreguntasTableAdapter();
            PreguntaDS.PreguntasDataTable dtPreguntas = objDataSet.GetQuestionByID(idQuestion);
            if (dtPreguntas.Count > 0)
            {
                objPregunta = rowToDto(dtPreguntas[0]);
                return objPregunta;
            }
            return null;
        }
        public static List<Pregunta> getQuestionsByIDUser(int idUser)
        {
            List<Pregunta> listaPreguntas = new List<Pregunta>();
            QueueOverflow.DAL.PreguntaDSTableAdapters.PreguntasTableAdapter objDataSet = new QueueOverflow.DAL.PreguntaDSTableAdapters.PreguntasTableAdapter();
            PreguntaDS.PreguntasDataTable dtPreguntas = objDataSet.GetQuestionByIDUser(idUser);
            foreach (PreguntaDS.PreguntasRow row in dtPreguntas)
            {
                Pregunta objPregunta = rowToDto(row);
                listaPreguntas.Add(objPregunta);
            }
            return listaPreguntas;
        }
        public static int insertQuestion(Pregunta question)
        {
            QueueOverflow.DAL.PreguntaDSTableAdapters.PreguntasTableAdapter objDataSet = new QueueOverflow.DAL.PreguntaDSTableAdapters.PreguntasTableAdapter();
            int? id = 0;
            objDataSet.InsertQuestion(ref id, question.txtTitulo, question.txtContenido, question.dateFechaCreacion, question.dateFechaModificacion, question.intEstado, question.idUsuario);
            return (int)id;
        }
        public static void updateQuestion(Pregunta question)
        {
            QueueOverflow.DAL.PreguntaDSTableAdapters.PreguntasTableAdapter objDataSet = new QueueOverflow.DAL.PreguntaDSTableAdapters.PreguntasTableAdapter();
            objDataSet.UpdateQuestion(question.idPregunta, question.txtTitulo, question.txtContenido, question.dateFechaCreacion, question.dateFechaModificacion, question.intEstado, question.idUsuario);
        }
        public static void deleteQuestion(int idQuestion)
        {
            QueueOverflow.DAL.PreguntaDSTableAdapters.PreguntasTableAdapter objDataSet = new QueueOverflow.DAL.PreguntaDSTableAdapters.PreguntasTableAdapter();
            objDataSet.DeleteQuestion(idQuestion);
        }
    }
}