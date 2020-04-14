using QueueOverflow.DAL;
using QueueOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueOverflow.BLL
{
    public class PreguntaCategoriaBLL
    {
        public static PreguntaCategoria rowToDto(PreguntaCategoriaDS.PreguntaCategoriasRow row)
        {
            PreguntaCategoria objPreguntaCategoria = new PreguntaCategoria();
            objPreguntaCategoria.idRegistro = row.idRegistro;
            objPreguntaCategoria.idPregunta = row.idPregunta;
            objPreguntaCategoria.idCategoria = row.idCategoria;
            return objPreguntaCategoria;
        }
        public static List<PreguntaCategoria> getAllQuestionCategories()
        {
            List<PreguntaCategoria> listaPreguntaCategorias = new List<PreguntaCategoria>();
            QueueOverflow.DAL.PreguntaCategoriaDSTableAdapters.PreguntaCategoriasTableAdapter objDataSet = new QueueOverflow.DAL.PreguntaCategoriaDSTableAdapters.PreguntaCategoriasTableAdapter();
            PreguntaCategoriaDS.PreguntaCategoriasDataTable dtPreguntaCategorias = objDataSet.GetAllQuestionsCategories();

            foreach (PreguntaCategoriaDS.PreguntaCategoriasRow row in dtPreguntaCategorias)
            {
                PreguntaCategoria objPreguntaCategoria = rowToDto(row);
                listaPreguntaCategorias.Add(objPreguntaCategoria);
            }
            return listaPreguntaCategorias;
        }
        public static List<PreguntaCategoria> getQuestionCategoriesByIDQuestion(int question)
        {
            List<PreguntaCategoria> listaPreguntaCategorias = new List<PreguntaCategoria>();
            QueueOverflow.DAL.PreguntaCategoriaDSTableAdapters.PreguntaCategoriasTableAdapter objDataSet = new QueueOverflow.DAL.PreguntaCategoriaDSTableAdapters.PreguntaCategoriasTableAdapter();
            PreguntaCategoriaDS.PreguntaCategoriasDataTable dtPreguntaCategorias = objDataSet.GetCategoriesByIDQuestion(question);
            foreach (PreguntaCategoriaDS.PreguntaCategoriasRow row in dtPreguntaCategorias)
            {
                PreguntaCategoria objPreguntaCategoria = rowToDto(row);
                listaPreguntaCategorias.Add(objPreguntaCategoria);
            }
            return listaPreguntaCategorias;
        }
        public static List<PreguntaCategoria> getQuestionQuestionsByIDCategory(int cat)
        {
            List<PreguntaCategoria> listaPreguntaCategorias = new List<PreguntaCategoria>();
            QueueOverflow.DAL.PreguntaCategoriaDSTableAdapters.PreguntaCategoriasTableAdapter objDataSet = new QueueOverflow.DAL.PreguntaCategoriaDSTableAdapters.PreguntaCategoriasTableAdapter();
            PreguntaCategoriaDS.PreguntaCategoriasDataTable dtPreguntaCategorias = objDataSet.GetQuestionsByIDCategory(cat);
            foreach (PreguntaCategoriaDS.PreguntaCategoriasRow row in dtPreguntaCategorias)
            {
                PreguntaCategoria objPreguntaCategoria = rowToDto(row);
                listaPreguntaCategorias.Add(objPreguntaCategoria);
            }
            return listaPreguntaCategorias;
        }
        public static int insertQuestionCategory(PreguntaCategoria pregCat)
        {
            QueueOverflow.DAL.PreguntaCategoriaDSTableAdapters.PreguntaCategoriasTableAdapter objDataSet = new QueueOverflow.DAL.PreguntaCategoriaDSTableAdapters.PreguntaCategoriasTableAdapter();
            int? id = 0;
            objDataSet.InsertQuestionCategory(ref id, pregCat.idPregunta, pregCat.idCategoria);
            return (int)id;
        }
        public static void updateQuestionCategory(PreguntaCategoria pregCat)
        {
            QueueOverflow.DAL.PreguntaCategoriaDSTableAdapters.PreguntaCategoriasTableAdapter objDataSet = new QueueOverflow.DAL.PreguntaCategoriaDSTableAdapters.PreguntaCategoriasTableAdapter();
            objDataSet.UpdateQuestionCategory(pregCat.idRegistro, pregCat.idPregunta, pregCat.idCategoria);
        }
        public static void deleteQuestionCategory(int idQuestionCategory)
        {
            QueueOverflow.DAL.PreguntaCategoriaDSTableAdapters.PreguntaCategoriasTableAdapter objDataSet = new QueueOverflow.DAL.PreguntaCategoriaDSTableAdapters.PreguntaCategoriasTableAdapter();
            objDataSet.DeleteQuestionCategory(idQuestionCategory);
        }
    }
}