using QueueOverflow.DAL;
using QueueOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueOverflow.BLL
{
    public class UsuarioBLL
    {
        public static Usuario rowToDto(UsuarioDS.UsuariosRow row)
        {
            Usuario objUsuario = new Usuario();
            objUsuario.idUsuario = row.idUsuario;
            objUsuario.txtNombreUsuario = row.txtNombreUsuario;
            objUsuario.txtCorreo = row.txtCorreo;
            objUsuario.txtPassword = Convert.ToString(row.txtPassword);
            objUsuario.txtNombreReal = row.txtNombreReal;
            return objUsuario;
        }
        public static List<Usuario> getAllUsers()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            QueueOverflow.DAL.UsuarioDSTableAdapters.UsuariosTableAdapter objDataSet = new QueueOverflow.DAL.UsuarioDSTableAdapters.UsuariosTableAdapter();
            UsuarioDS.UsuariosDataTable dtUsuarios = objDataSet.GetAllUsers();

            foreach (UsuarioDS.UsuariosRow row in dtUsuarios)
            {
                Usuario objUsuario = rowToDto(row);
                listaUsuarios.Add(objUsuario);
            }
            return listaUsuarios;
        }
        public static Usuario getUserByID(int idUser)
        {
            Usuario objUsuario = new Usuario();
            QueueOverflow.DAL.UsuarioDSTableAdapters.UsuariosTableAdapter objDataSet = new QueueOverflow.DAL.UsuarioDSTableAdapters.UsuariosTableAdapter();
            UsuarioDS.UsuariosDataTable dtUsuarios = objDataSet.GetUserByID(idUser);
            if (dtUsuarios.Count > 0)
            {
                objUsuario = rowToDto(dtUsuarios[0]);
                return objUsuario;
            }
            return null;
        }
        public static Usuario getUserByNickPass(string nick, string pass)
        {
            Usuario objUsuario = new Usuario();
            QueueOverflow.DAL.UsuarioDSTableAdapters.UsuariosTableAdapter objDataSet = new QueueOverflow.DAL.UsuarioDSTableAdapters.UsuariosTableAdapter();
            UsuarioDS.UsuariosDataTable dtUsuarios = objDataSet.GetUserByNickPass(nick, pass);
            if (dtUsuarios.Count > 0)
            {
                objUsuario = rowToDto(dtUsuarios[0]);
                return objUsuario;
            }
            return null;
        }
        public static int insertUser(Usuario user)
        {
            QueueOverflow.DAL.UsuarioDSTableAdapters.UsuariosTableAdapter objDataSet = new QueueOverflow.DAL.UsuarioDSTableAdapters.UsuariosTableAdapter();
            int? id = 0;
            objDataSet.InsertUser(ref id, user.txtNombreUsuario, user.txtCorreo, user.txtPassword, user.txtNombreReal);
            return (int)id;
        }
        public static void updateUser(Usuario user)
        {
            QueueOverflow.DAL.UsuarioDSTableAdapters.UsuariosTableAdapter objDataSet = new QueueOverflow.DAL.UsuarioDSTableAdapters.UsuariosTableAdapter();
            objDataSet.UpdateUser(user.idUsuario, user.txtNombreUsuario, user.txtCorreo, user.txtPassword, user.txtNombreReal);
        }
        public static void deleteUser(int idUser)
        {
            QueueOverflow.DAL.UsuarioDSTableAdapters.UsuariosTableAdapter objDataSet = new QueueOverflow.DAL.UsuarioDSTableAdapters.UsuariosTableAdapter();
            objDataSet.DeleteUser(idUser);
        }
    }
}