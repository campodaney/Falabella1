using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Falabella.Models.ViewModels.CompaniaProducto
{
    public class ListCompaniaProductoViewModels
    {
        public int idCompaniaProducto { get; set; }
        public int idCompania { get; set; }
        public int idProducto { get; set; }
        public int idUsuario { get; set; }
        public Boolean estado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string compania { get; set; }
        public string producto { get; set; }
        public string nombre { get; set; }
    }
}