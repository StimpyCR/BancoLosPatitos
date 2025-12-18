using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerPersona
{
    public interface IObtenerPersonaAD
    {
         List<PersonaDto> ObtenerDisponibles(int idPersona);
    }
}
