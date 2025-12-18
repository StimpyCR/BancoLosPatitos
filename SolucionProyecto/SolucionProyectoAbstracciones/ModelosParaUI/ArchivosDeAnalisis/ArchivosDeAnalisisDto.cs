using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis
{
    public class ArchivosDeAnalisisDto
    {
        [Key]
        [Display(Name = "Id")]
        public int IdArchivo { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Texto (resumen)")]
        public string textoResumen { get; set; }

        [Required]
        [Display(Name = "Fuente")]
        public string fuente { get; set; }

        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime fechaDeRegistro { get; set; }
    }
}