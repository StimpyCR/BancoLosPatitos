using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Persona_Actividad.ObtenerPersonaActividadActiva
{
    public interface IObtenerPersonaActividadActivaLN
    {
        List<PersonaActividadDto> ObtenerDisponibles(int IdUsuario);
    }
}
