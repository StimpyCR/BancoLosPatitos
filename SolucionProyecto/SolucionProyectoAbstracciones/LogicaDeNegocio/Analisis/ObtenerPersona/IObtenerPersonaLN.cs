using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerPersona
{
    public interface IObtenerPersonaLN
    {
        List<PersonaDto> ObtenerDisponibles(int idPersona);
    }
}
