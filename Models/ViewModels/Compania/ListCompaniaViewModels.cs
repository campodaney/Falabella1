using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Falabella.Models.ViewModels.Compania
{
    public class ListCompaniaViewModels
    {
        public int idCompania { get; set; }
        public string nombre { get; set; }
        public string personaContacto { get; set; }
        public string telefonoContacto { get; set; }
        public string nit { get; set; }
    }
}