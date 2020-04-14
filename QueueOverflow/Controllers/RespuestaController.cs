using QueueOverflow.BLL;
using QueueOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueueOverflow.Controllers
{
    public class RespuestaController : Controller
    {
        //
        // GET: /Respuesta/
        public ActionResult Edit(int id)
        {
            Respuesta respuesta = RespuestaBLL.getAnswerByID(id);
            return View(respuesta);
        }
        [HttpPost]
        public ActionResult Edit(Respuesta respuesta)
        {
            respuesta.dateFechaCreacion = DateTime.Now;
            RespuestaBLL.updateAnswer(respuesta);
            return RedirectToAction("Single/" + respuesta.idUsuario, "Usuario");
        }
        public ActionResult Delete(int id)
        {
            Respuesta resp = RespuestaBLL.getAnswerByID(id);
            if (resp.intEstado == 1)
            {
                Pregunta preg = PreguntaBLL.getQuestionByID(resp.idPregunta);
                preg.intEstado = 0;
                PreguntaBLL.updateQuestion(preg);
            }
            RespuestaBLL.deleteAnswer(id);
            return RedirectToAction("Index", "Pregunta");
        }
    }
}