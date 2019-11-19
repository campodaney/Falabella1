using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Falabella.Models.ViewModels.TipoDocumento
{
    public class TipoDocumentoViewModels
    {
        public int idTipoDocumento { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}