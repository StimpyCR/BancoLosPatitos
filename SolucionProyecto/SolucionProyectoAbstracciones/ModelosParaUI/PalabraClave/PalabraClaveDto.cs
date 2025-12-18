using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave
{
    public class PalabraClaveDto
    {
        [Key]
        public int IdPalabra { get; set; }
        public string Palabra { get; set; }
        public int Orden { get; set; }
        [Display(Name = "Fecha de registro")]
        public DateTime FechaDeRegistro { get; set; }
        [Display(Name = "Fecha de modificacion")]
        public DateTime? FechaDeModificacion { get; set; }
        public bool Estado { get; set; }
    }
}
