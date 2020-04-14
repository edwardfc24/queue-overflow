using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QueueOverflow.Models
{
    public class Pregunta
    {
        [Display(Name = "ID")]
        public int idPregunta { get; set; }
        [Display(Name = "Título de Pregunta")]
        [MinLength(4, ErrorMessage = "El título debe tener mínimo 4 carcteres")]
        public string txtTitulo { get; set; }
        [Display(Name = "Contenido")]
        [MinLength(4, ErrorMessage = "El contenido debe tener mínimo 4 carcteres")]
        public string txtContenido { get; set; }
        public DateTime dateFechaCreacion { get; set; }
        public DateTime dateFechaModificacion { get; set; }
        public int intEstado { get; set; }
        public int idUsuario { get; set; }
    }
}