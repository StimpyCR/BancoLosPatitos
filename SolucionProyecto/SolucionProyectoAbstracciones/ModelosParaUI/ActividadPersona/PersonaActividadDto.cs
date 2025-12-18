using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad
{
    public class PersonaActividadDto
    {
        [Display(Name = "Id de la actividad persona")]
        public int IdActividadPersona { get; set; }
        [Display(Name = "Id de la actividad financiera")]
        public int IdActividadFinanciera { get; set; }
        public int IdPersona { get; set; }
        [Display(Name = "Nombre de la actividad financiera")]
        public string NombreActividadFinanciera { get; set; }
        [Display(Name = "Nivel de riesgo")]
        public int NivelDeRiesgo { get; set; }
        [Display(Name = "Nombre del riesgo")]
        public string NombreRiesgo { get; set; }
        [Display(Name = "Fecha de registro")]
        public DateTime FechaDeRegistro { get; set; }
        [Display(Name = "Fecha de modificacion")]
        public DateTime? FechaDeModificacion { get; set; }
        public bool Estado { get; set; }                   
    }
}
