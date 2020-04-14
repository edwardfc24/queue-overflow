using QueueOverflow.BLL;
using QueueOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueueOverflow.Controllers
{
    public class PreguntaController : Controller
    {
        //
        // GET: /Pregunta/
        public ActionResult Index()
        {
            List<Pregunta> listaPreguntas = PreguntaBLL.getAllQuestions();
            if (Session["idUser"] != null)
            {
                Usuario user = UsuarioBLL.getUserByID(Convert.ToInt32(Session["idUser"]));
                ViewBag.idUsuario = user.idUsuario;
                ViewBag.NombreUsuario = user.txtNombreUsuario;
            }
            return View(listaPreguntas);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Prefix = "Item1")]Pregunta question, [Bind(Prefix = "Item2")]Categoria cat)
        {
            if (Session["idUser"] != null)
            {
                Usuario user = UsuarioBLL.getUserByID(Convert.ToInt32(Session["idUser"]));
                ViewBag.idUsuario = user.idUsuario;
                ViewBag.NombreUsuario = user.txtNombreUsuario;
                question.dateFechaCreacion = DateTime.Now;
                question.dateFechaModificacion = DateTime.Now;
                question.intEstado = 0;
                question.idUsuario = user.idUsuario;
                string[] listaCategorias = cat.txtNombreCategoria.Split(',');
                int[] listaID = new int[listaCategorias.Length];
                for (int i = 0; i < listaCategorias.Length; i++)
                {
                    Categoria aux = CategoriaBLL.getCategoryByName(listaCategorias[i].ToUpper());
                    if (aux != null)
                        listaID[i] = aux.idCategoria;
                    else
                    {
                        aux = new Categoria();
                        aux.txtNombreCategoria = listaCategorias[i].ToUpper().Trim();
                        listaID[i] = CategoriaBLL.insertCategory(aux);
                    }
                }
                int idQuestion = PreguntaBLL.insertQuestion(question);
                for (int i = 0; i < listaID.Length; i++)
                {
                    PreguntaCategoria pregCat = new PreguntaCategoria();
                    pregCat.idPregunta = idQuestion;
                    pregCat.idCategoria = listaID[i];
                    PreguntaCategoriaBLL.insertQuestionCategory(pregCat);
                }
            }
            return RedirectToAction("Index", "Pregunta");
        }
        public ActionResult Details(int id)
        {
            if (Session["idUser"] != null)
            {
                Usuario user = UsuarioBLL.getUserByID(Convert.ToInt32(Session["idUser"]));
                ViewBag.idUsuario = user.idUsuario;
                ViewBag.NombreUsuario = user.txtNombreUsuario;
            }
            Pregunta question = PreguntaBLL.getQuestionByID(id);
            List<PreguntaCategoria> lista = PreguntaCategoriaBLL.getQuestionCategoriesByIDQuestion(id);
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Respuesta> listaRespuestas = RespuestaBLL.getAnswersByIDQuestion(id);
            List<Comentario> listaComentarios = new List<Comentario>();
            foreach (var pregCat in lista)
            {
                listaCategorias.Add(CategoriaBLL.getCategoryByID(pregCat.idCategoria));
            }
            foreach (var respuesta in listaRespuestas)
            {
                List<Comentario> aux = ComentarioBLL.getComentByIDRegisterTypeRegister(respuesta.idRespuesta, 1);
                foreach (var coment in aux)
                {
                    listaComentarios.Add(coment);
                }
            }
            ViewBag.listaCategorias = listaCategorias;
            ViewBag.listaRespuestas = listaRespuestas;
            ViewBag.listaComentPreguntas = ComentarioBLL.getComentByIDRegisterTypeRegister(id, 0);
            ViewBag.listaComentRespuestas = listaComentarios;
            return View(question);
        }
        [HttpPost]
        public ActionResult insertComentario(string comentario, int idPregunta)
        {
            int num = 0;
            if (Session["idUser"] != null)
            {
                Comentario auxComent = new Comentario();
                auxComent.txtContenido = @comentario;
                auxComent.dateFechaCreacion = DateTime.Now;
                auxComent.idRegistro = idPregunta;
                auxComent.flagTipoComentario = 0;
                auxComent.idUsuario = Convert.ToInt32(Session["idUser"]);
                num = ComentarioBLL.insertComent(auxComent);
                return Json(num);
            }
            Session["idPregunta"] = idPregunta;
            return Json(num);
        }
        [HttpPost]
        public ActionResult insertComentarioRespuesta(string comentario, int idRespuesta)
        {
            int num = 0;
            if (Session["idUser"] != null)
            {
                Comentario auxComent = new Comentario();
                auxComent.txtContenido = @comentario;
                auxComent.dateFechaCreacion = DateTime.Now;
                auxComent.idRegistro = idRespuesta;
                auxComent.flagTipoComentario = 1;
                auxComent.idUsuario = Convert.ToInt32(Session["idUser"]);
                num = ComentarioBLL.insertComent(auxComent);
                return Json(num);
            }
            return Json(num);
        }
        [HttpPost]
        public ActionResult insertRespuesta(string respuesta, int idPregunta)
        {
            int num = 0;
            if (Session["idUser"] != null)
            {
                List<Respuesta> list = RespuestaBLL.getAnswersByIDQuestion(idPregunta);
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        if (item.idUsuario == Convert.ToInt32(Session["idUser"]))
                        {
                            num = -1;
                            return Json(num);
                        }
                    }
                    Respuesta aux = new Respuesta();
                    aux.txtContenido = @respuesta;
                    aux.intEstado = 0;
                    aux.dateFechaCreacion = DateTime.Now;
                    aux.dateFechaModificacion = DateTime.Now;
                    aux.idPregunta = idPregunta;
                    aux.idUsuario = Convert.ToInt32(Session["idUser"]);
                    num = RespuestaBLL.insertAnswer(aux);
                    return Json(num);
                }
                else
                {
                    Respuesta aux = new Respuesta();
                    aux.txtContenido = @respuesta;
                    aux.intEstado = 0;
                    aux.dateFechaCreacion = DateTime.Now;
                    aux.dateFechaModificacion = DateTime.Now;
                    aux.idPregunta = idPregunta;
                    aux.idUsuario = Convert.ToInt32(Session["idUser"]);
                    num = RespuestaBLL.insertAnswer(aux);
                    return Json(num);
                }
            }
            return Json(num);
        }
        [HttpPost]
        public ActionResult insertVote(int estado, int registro, int tipo)
        {
            int num = 0;
            if (Session["idUser"] != null)
            {
                List<Voto> aux = VotoBLL.getVotesByIDRegisterTyperRegister(registro, tipo);
                if (aux.Count > 0)
                {
                    bool encontro = false;
                    foreach (Voto voto in aux)
                    {
                        if (voto.idUsuario == Convert.ToInt32(Session["idUser"]))
                        {
                            num = -1;
                            encontro = true;
                        }
                    }
                    if (!encontro)
                    {
                        Voto auxV = new Voto();
                        auxV.intEstado = estado;
                        auxV.idRegistro = registro;
                        auxV.flagTipoVoto = tipo;
                        auxV.idUsuario = Convert.ToInt32(Session["idUser"]);
                        num = VotoBLL.insertVote(auxV);
                        return Json(num);
                    }
                    else
                        return Json(num);
                }
                else
                {
                    Voto auxV = new Voto();
                    auxV.intEstado = estado;
                    auxV.idRegistro = registro;
                    auxV.flagTipoVoto = tipo;
                    auxV.idUsuario = Convert.ToInt32(Session["idUser"]);
                    num = VotoBLL.insertVote(auxV);
                    return Json(num);
                }
            }
            return Json(num);
        }
        [HttpPost]
        public ActionResult marcarRespuesta(int idRespuesta)
        {
            int num = 0;
            if (Session["idUser"] != null)
            {
                Respuesta auxRespuesta = RespuestaBLL.getAnswerByID(idRespuesta);
                Pregunta auxPregunta = PreguntaBLL.getQuestionByID(auxRespuesta.idPregunta);
                int idUserAux = Convert.ToInt32(Session["idUser"]);
                if (auxPregunta.intEstado != 1)
                {
                    if (auxPregunta.idUsuario == idUserAux)
                    {
                        if (auxRespuesta.intEstado != 1)
                        {
                            auxRespuesta.intEstado = 1;
                            RespuestaBLL.updateAnswer(auxRespuesta);
                            auxPregunta.intEstado = 1;
                            PreguntaBLL.updateQuestion(auxPregunta);
                            num = 1;
                            return Json(num);
                        }
                    }
                    else
                    {
                        num = 2;
                        return Json(num);
                    }
                }
                else
                {
                    num = -1;
                    return Json(num);
                }
            }
            return Json(num);
        }
        public ActionResult sumarVotos(int idRegistro, int tipo)
        {
            int num = 0;
            List<Voto> votos = VotoBLL.getVotesByIDRegisterTyperRegister(idRegistro, tipo);
            foreach (Voto voto in votos)
            {
                if (voto.intEstado == 1)
                    num++;
                else
                    num--;
            }
            return Json(num);
        }
        public ActionResult Edit(int id)
        {
            Pregunta pregunta = PreguntaBLL.getQuestionByID(id);
            if (Session["idUser"] != null)
            {
                int idU = Convert.ToInt32(Session["idUser"]);
                if (pregunta.idUsuario == idU)
                    return View(pregunta);
                else
                    return Details(id);
            }
            return Details(id);
        }
        [HttpPost]
        public ActionResult Edit(Pregunta pregunta)
        {
            pregunta.dateFechaModificacion = DateTime.Now;
            PreguntaBLL.updateQuestion(pregunta);
            return RedirectToAction("Index", "Pregunta");
        }
        public ActionResult Delete(int id)
        {
            PreguntaBLL.deleteQuestion(id);
            List<Respuesta> listaRespuesta = RespuestaBLL.getAllAnswers();
            foreach (Respuesta resp in listaRespuesta)
            {
                if (resp.idPregunta == id)
                    RespuestaBLL.deleteAnswer(resp.idRespuesta);
            }
            return RedirectToAction("Index", "Pregunta");
        }
    }
}