using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Falabella.Models.ViewModels.Venta
{
    public class VentaViewModels
    {
        public int idVenta { get; set; }
        public int idCompaniaProducto { get; set; }
        [Required]
        [Display(Name = "Cliente")]
        public int idCliente { get; set; }
        [Required]
        [Display(Name = "Producto")]
        public int idProducto { get; set; }
        public int idCompania { get; set; }
        public int idUsuario { get; set; }
        public int cantidad { get; set; }
        public int valor { get; set; }
        public string observacion { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}