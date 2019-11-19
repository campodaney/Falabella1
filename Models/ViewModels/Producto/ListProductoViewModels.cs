using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Falabella.Models.ViewModels.Producto
{
    public class ListProductoViewModels
    {
        public int idProducto { get; set; }
        public int idUsuario{ get; set; }
        public string nombre { get; set; }
        public Boolean estado { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}