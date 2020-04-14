using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueOverflow.Models
{
    public class Comentario
    {
        public int idComentario { get; set; }
        public string txtContenido { get; set; }
        public DateTime dateFechaCreacion { get; set; }
        public int idRegistro { get; set; }
        public int flagTipoComentario { get; set; }
        public int idUsuario { get; set; }
    }
}