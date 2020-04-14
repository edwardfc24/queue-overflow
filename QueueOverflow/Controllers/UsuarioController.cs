using QueueOverflow.BLL;
using QueueOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueueOverflow.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index([Bind(Prefix = "Item1")]Usuario user1, [Bind(Prefix = "Item2")]Usuario user2)
        {
            if (user1.txtCorreo != null && user1.txtNombreReal != null)
            {
                int id = UsuarioBLL.insertUser(user1);
                Session["idUser"] = id;
                if (Session["idPregunta"] != null)
                {
                    return RedirectToAction("Details", "Pregunta", Convert.ToInt32(Session["idPregunta"]));
                }
                else
                    return RedirectToAction("Index", "Pregunta");
            }
            else
            {
                Usuario aux = UsuarioBLL.getUserByNickPass(user2.txtNombreUsuario, user2.txtPassword);
                if (aux != null)
                {
                    Session["idUser"] = aux.idUsuario;
                    if (Session["idPregunta"] != null)
                    {
                        return RedirectToAction("Details", "Pregunta", Session["idPregunta"]);
                    }
                    else
                        return RedirectToAction("Index", "Pregunta");
                }
                return RedirectToAction("Index", "Usuario");
            }
        }
        public ActionResult All()
        {
            List<Usuario> listaUsuarios = UsuarioBLL.getAllUsers();
            return View(listaUsuarios);
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        public ActionResult Single(int id)
        {
            ViewBag.listaPreguntas = PreguntaBLL.getQuestionsByIDUser(id);
            ViewBag.listaRespuestas = RespuestaBLL.getAnswersByIDUser(id);
            Usuario user = UsuarioBLL.getUserByID(id);
            return View(user);
        }
    }
}