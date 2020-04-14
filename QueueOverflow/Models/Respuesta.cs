using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueOverflow.Models
{
    public class Respuesta
    {
        public int idRespuesta { get; set; }
        public string txtContenido { get; set; }
        public int intEstado { get; set; }
        public DateTime dateFechaCreacion { get; set; }
        public DateTime dateFechaModificacion { get; set; }
        public int idPregunta { get; set; }
        public int idUsuario { get; set; }
    }
}