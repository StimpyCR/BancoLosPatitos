using SolucionProyectoAbstracciones.AccesoADatos.Persona.ObtenerPersonaPorId;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Persona.ObtenerPersonaPorId;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.Persona.ObtenerPersonaPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Persona.ObtenerPersonaPorId
{
    public class ObtenerPersonaPorIdLN: IObtenerPersonaPorIdLN
    {
        private readonly IObtenerPersonaPorIdAD _obtenerPersonaAD;
        public ObtenerPersonaPorIdLN()
        {
            _obtenerPersonaAD = new ObtenerPersonaPorIdAD();
        }

        public PersonaDto ObtenerPersona (int idPersona)
        {
            PersonaDto persona = _obtenerPersonaAD.ObtenerPersona(idPersona);
            if (persona == null)
            {
                throw new Exception("No se encontró la persona con el Id proporcionado.");
            }
            return persona;
        }
    }
}
