using QueueOverflow.BLL;
using QueueOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueueOverflow.Controllers
{
    public class CategoriaController : Controller
    {
        //
        // GET: /Categoria/
        public ActionResult Index()
        {
            List<Categoria> listaCategorias = CategoriaBLL.getAllCategories();
            return View(listaCategorias);
        }
        [HttpPost]
        public ActionResult GetQuestionsByIDCategory(int idCat)
        {
            List<PreguntaCategoria> listaPregCategoria = PreguntaCategoriaBLL.getQuestionQuestionsByIDCategory(idCat);
            List<Pregunta> listaPreguntas = new List<Pregunta>();
            foreach (var item in listaPregCategoria)
            {
                listaPreguntas.Add(PreguntaBLL.getQuestionByID(item.idPregunta));
            }
            return Json(listaPreguntas);
        }
    }
}