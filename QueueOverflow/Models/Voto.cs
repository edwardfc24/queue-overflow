using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueOverflow.Models
{
    public class Voto
    {
        public int idVoto { get; set; }
        public int intEstado { get; set; }
        public int idRegistro { get; set; }
        public int flagTipoVoto { get; set; }
        public int idUsuario { get; set; }
    }
}