using QueueOverflow.DAL;
using QueueOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueOverflow.BLL
{
    public class ComentarioBLL
    {
        public static Comentario rowToDto(ComentarioDS.ComentariosRow row)
        {
            Comentario objComentario = new Comentario();
            objComentario.idComentario = row.idComentario;
            objComentario.txtContenido = row.txtContenido;
            objComentario.dateFechaCreacion = row.dateFechaCreacion;
            objComentario.idRegistro = row.idRegistro;
            objComentario.flagTipoComentario = row.flagTipoComentario;
            objComentario.idUsuario = row.idUsuario;
            return objComentario;
        }
        public static List<Comentario> getAllComents()
        {
            List<Comentario> listaComentarios = new List<Comentario>();
            QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter objDataSet = new QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter();
            ComentarioDS.ComentariosDataTable dtComentarios = objDataSet.GetAllComents();

            foreach (ComentarioDS.ComentariosRow row in dtComentarios)
            {
                Comentario objComentario = rowToDto(row);
                listaComentarios.Add(objComentario);
            }
            return listaComentarios;
        }
        public static Comentario getComentByID(int idComent)
        {
            Comentario objComentario = new Comentario();
            QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter objDataSet = new QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter();
            ComentarioDS.ComentariosDataTable dtComentarios = objDataSet.GetComentyID(idComent);
            if (dtComentarios.Count > 0)
            {
                objComentario = rowToDto(dtComentarios[0]);
                return objComentario;
            }
            return null;
        }
        public static List<Comentario> getComentByIDUser(int idUser)
        {
            List<Comentario> listaComentarios = new List<Comentario>();
            QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter objDataSet = new QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter();
            ComentarioDS.ComentariosDataTable dtComentarios = objDataSet.GetComentByIDUser(idUser);
            foreach (ComentarioDS.ComentariosRow row in dtComentarios)
            {
                Comentario objComentario = rowToDto(row);
                listaComentarios.Add(objComentario);
            }
            return listaComentarios;
        }
        public static List<Comentario> getComentByIDRegisterTypeRegister(int register, int type)
        {
            List<Comentario> listaComentarios = new List<Comentario>();
            QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter objDataSet = new QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter();
            ComentarioDS.ComentariosDataTable dtComentarios = objDataSet.GetComentByIDRegisterTypeRegister(register, type);
            foreach (ComentarioDS.ComentariosRow row in dtComentarios)
            {
                Comentario objComentario = rowToDto(row);
                listaComentarios.Add(objComentario);
            }
            return listaComentarios;
        }
        public static int insertComent(Comentario coment)
        {
            QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter objDataSet = new QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter();
            int? id = 0;
            objDataSet.InsertComent(ref id, coment.txtContenido, coment.dateFechaCreacion, coment.idRegistro, coment.flagTipoComentario, coment.idUsuario);
            return (int)id;
        }
        public static void updateComent(Comentario coment)
        {
            QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter objDataSet = new QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter();
            objDataSet.UpdateComent(coment.idComentario, coment.txtContenido, coment.dateFechaCreacion, coment.idRegistro, coment.flagTipoComentario, coment.idUsuario);
        }
        public static void deleteComent(int idComent)
        {
            QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter objDataSet = new QueueOverflow.DAL.ComentarioDSTableAdapters.ComentariosTableAdapter();
            objDataSet.DeleteComent(idComent);
        }
    }
}