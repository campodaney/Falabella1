using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Falabella.Models.ViewModels.CompaniaProducto
{
    public class CompaniaProductoViewModels
    {
        public int idCompaniaProducto { get; set; }
        [Required]
        [Display(Name = "Compañia")]
        public int idCompania { get; set; }
        [Required]
        [Display(Name = "Productos")]
        public int idProducto { get; set; }
        [Required]
        public int idUsuario { get; set; }
        [Required]
        public Boolean estado { get; set; }
        [Required]
        public DateTime fechaRegistro { get; set; }
    }
}