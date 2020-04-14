using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QueueOverflow.Models
{
    public class Usuario
    {
        [Display(Name="ID")]
        public int idUsuario { get; set; }
        [Display(Name="Nombre de Usuario")]
        [MinLength(4, ErrorMessage="El nombre de usuario debe tener mínimo 4 carcteres")]
        public string txtNombreUsuario { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name="E-mail")]
        public string txtCorreo { get; set; }
        [Display(Name="Contraseña")]
        [StringLength(16,MinimumLength=4,ErrorMessage="La contraseña debe tener mínimo 4 carácteres y máximo 16")]
        public string txtPassword { get; set; }
        [Display(Name="Nombre Completo")]
        [MinLength(4, ErrorMessage = "El nombre debe tener mínimo 4 carcteres")]
        public string txtNombreReal { get; set; }
    }
}