using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera
{
    public class ActividadFinancieraDto
    {
        [Key]
        [Display(Name = "Id actividad financiera")]
        public int IdActividadFinanciera { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres.")]
        [Display(Name = "Nombre de la actividad financiera")]
        public string NombreActividadFinanciera { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(150, ErrorMessage = "Máximo 150 caracteres.")]
        [Display(Name = "Descripcion de la actividad financiera")]
        public string DescripcionActividadFinanciera { get; set; }

        [Range(1, 3, ErrorMessage = "Seleccione un nivel de riesgo válido (Bajo=1, Medio=2, Alto=3).")]
        [Display(Name = "Nivel de riesgo")]
        public int NivelDeRiesgo { get; set; }
        [Display(Name = "Fecha de registro")]

        public DateTime FechaDeRegistro { get; set; }
        [Display(Name = "Fecha de modificacion")]
        public DateTime? FechaDeModificacion { get; set; }
        public bool Estado { get; set; }
    }
}
