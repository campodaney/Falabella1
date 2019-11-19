using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Falabella.Models.ViewModels.Venta
{
    public class ListVentaViewModels
    {
        public int idVenta { get; set; }
        public int idCompaniaProducto { get; set; }
        public int idCliente { get; set; }        
        public int idCompania { get; set; }
        public int idProducto { get; set; }
        public int idUsuario { get; set; }
        public int cantidad { get; set; }
        public int valor { get; set; }
        public string observacion { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string cliente { get; set; }
        public string compania { get; set; }
        public string producto { get; set; }
    }
}

