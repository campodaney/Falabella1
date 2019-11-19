using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Falabella.Models.ViewModels.Cliente
{
    public class ClienteViewModels
    {
        public int idCliente { get; set; }
        [Required]
        public int idUsuario { get; set; }
        [Required]
        [Display(Name = "TipoDocumento")]
        public int idTipoDocumento { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Documento")]
        public string documento { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaNacimiento { get; set; }
        [Required]
        public DateTime fechaRegistro { get; set; }
    }
}