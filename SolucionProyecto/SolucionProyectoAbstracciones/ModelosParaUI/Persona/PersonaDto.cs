using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.ModelosParaUI.Persona
{
    public class PersonaDto
    {
        public int Id { get; set; }

        [Required]
        [Range(100000000, 999999999, ErrorMessage = "La cédula debe tener exactamente 9 dígitos")]
        public int Identificacion { get; set; }

        [Required]
        [Display(Name = "Tipo de Identificación")]
        public int TipoIdentificacion { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Estado de Riesgo")]
        public int estadoDeRiesgo { get; set; }

        [Display(Name = "Fecha de registro")]
        public DateTime fechaDeRegistro { get; set; }
        [Display(Name = "Fecha de modificacion")]
        public DateTime? fechaDeModificacion { get; set; }

        public bool estado { get; set; }
    }
}
