using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.ModelosParaUI.Analisis
{
     public class AnalisisDto
    {
            [Key]
            [Display(Name = "ID del Análisis")]
            public int IdAnalisis { get; set; }

            [Display(Name = "ID de Persona")]
            public int IdPersona { get; set; }

            [Display(Name = "Cantidad de Archivos")]
            public int CantidadArchivos { get; set; }

            [Display(Name = "Cantidad de Palabras Clave")]
            public int CantidadPalabrasClave { get; set; }

            [Display(Name = "Nivel de Riesgo")]
            public int NivelDeRiesgo { get; set; }

            [Display(Name = "Comentario")]
            public string Comentario { get; set; }

            [Display(Name = "Fecha del Análisis")]
            public DateTime FechaDeAnalisis { get; set; }
        }
    }