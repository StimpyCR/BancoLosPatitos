using SolucionProyectoAbstracciones.AccesoADatos.Persona.ListaPersona;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Persona.ListaPersona;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.Persona.ListaPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Persona.ListaPersona
{
    public class ListarPersonaLN : IListarPersonaLN
    {
        private readonly IListarPersonaAD _listarPersonaAD;
        public ListarPersonaLN()
        {
            _listarPersonaAD = new ListarPersonaAD();
        }

        public List<PersonaDto> Obtener()
        {
            List<PersonaDto> laListaDePersonas = _listarPersonaAD.Obtener();
            return laListaDePersonas;
        }
    }
}
