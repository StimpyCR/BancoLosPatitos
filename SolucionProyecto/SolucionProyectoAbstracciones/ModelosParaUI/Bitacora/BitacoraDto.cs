using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.ModelosParaUI.Bitacora
{
    public class BitacoraDto
    {
        public int idEvento { get; set; }
        [Display(Name = "Tabla de Evento")]
        [Required]
        [MaxLength(20)]
        public string tablaDeEvento { get; set; }

        [Display(Name = "Tipo de Evento")]
        [Required]
        [MaxLength(20)]
        public string tipoDeEvento { get; set; }

        [Display(Name = "Fecha del Evento")]
        public DateTime fechaDeEvento { get; set; }

        [Display(Name = "Descripción del Evento")]
        [Required]
        public string descripcionDeEvento { get; set; }

        [Display(Name = "Stack Trace")]
        public string stackTrace { get; set; }

        [Display(Name = "Datos Anteriores")]
        public string datosAnteriores { get; set; }

        [Display(Name = "Datos Posteriores")]
        public string datosPosteriores { get; set; }
    }
}