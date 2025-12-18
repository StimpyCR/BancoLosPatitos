using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.ModelosParaUI.Analisis
{
    public class PersonaAnalizadaDto
    {
        public int IdPersona { get; set; }
        public int TipoIdentificacion { get; set; }

        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        public string EstadoDeRiesgo { get; set; }

        public DateTime FechaUltimoAnalisis { get; set; }
    }
}