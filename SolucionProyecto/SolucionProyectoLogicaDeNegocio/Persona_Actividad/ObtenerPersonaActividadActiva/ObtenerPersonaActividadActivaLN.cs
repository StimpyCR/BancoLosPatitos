
using SolucionProyectoAbstracciones.AccesoADatos.Persona_Actividad.ObtenerPersonaActividadActiva;
using SolucionProyectoAbstracciones.LogicaDeNegocio.PersonaActividad.Persona_Actividad.ObtenerPersonaActividadActiva;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using SolucionProyectoAccesoADatos.Actividad_Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Persona_Actividad.ObtenerPersonaActividadActiva
{
    public class ObtenerPersonaActividadActivaLN : IObtenerPersonaActividadActivaLN
    {
        private readonly IObtenerPersonaActividadActivaAD _obtenerPersonaActividadActivaAD;

        public ObtenerPersonaActividadActivaLN()
        {
            _obtenerPersonaActividadActivaAD = new ObtenerActividadesPersonaActivasAD();
        }

        public List<PersonaActividadDto> ObtenerDisponibles(int IdUsuario)
        {
            List<PersonaActividadDto> laListaDePersonaActividad = _obtenerPersonaActividadActivaAD.ObtenerDisponibles(IdUsuario);
            return laListaDePersonaActividad;
        }
    }
}

