using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Falabella.Models.ViewModels.Producto
{
    public class ProductoViewModels
    {
        public int idProducto { get; set; }
        public int idUsuario { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        public Boolean estado { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}