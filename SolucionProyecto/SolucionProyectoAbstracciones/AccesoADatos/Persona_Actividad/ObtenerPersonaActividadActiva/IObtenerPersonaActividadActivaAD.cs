using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.Persona_Actividad.ObtenerPersonaActividadActiva
{
    public interface IObtenerPersonaActividadActivaAD
    {
        List<PersonaActividadDto> ObtenerDisponibles(int idUsuario);
    }
}
