using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerPersona;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerPersona;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.Analisis.ObtenerPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Analisis.ObtenerPersona
{
    public class ObtenerPersonaLN : IObtenerPersonaLN
    {
        private readonly IObtenerPersonaAD _obtenerPersonaAD;

              public ObtenerPersonaLN()
        {
            _obtenerPersonaAD = new ObtenerPersonaAD();
        }
        public List<PersonaDto> ObtenerDisponibles(int idPersona)
        {
            List<PersonaDto> laListaDePersonas = _obtenerPersonaAD.ObtenerDisponibles(idPersona);
            return laListaDePersonas;
        }
    }
}
