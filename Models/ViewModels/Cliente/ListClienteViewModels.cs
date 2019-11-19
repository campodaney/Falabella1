using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Falabella.Models.ViewModels.Cliente
{
    public class ListClienteViewModels
    {
        public int idCliente { get; set; }
        public int idUsuario { get; set; }        
        public int idTipoDocumento { get; set; }        
        public string nombre { get; set; }        
        public string documento { get; set; }       
        public DateTime fechaNacimiento { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}