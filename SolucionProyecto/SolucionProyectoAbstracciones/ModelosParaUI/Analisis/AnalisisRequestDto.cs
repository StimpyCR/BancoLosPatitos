using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.ModelosParaUI.Analisis
{
    public class AnalisisRequestDto
    {
        public class RealizarAnalisisRequestDto
        {
            // identificador de la persona a analizar
            public int IdPersona { get; set; }
        }

        public class RealizarAnalisisResultDto
        {
            public int IdPersona { get; set; }
            public int CantidadArchivosAnalizados { get; set; }
            public int CantidadCoincidencias { get; set; } // suma palabra-archivo
            public int NivelDeRiesgo { get; set; } // 1..4
            public string Comentario { get; set; }
        }
    }
}