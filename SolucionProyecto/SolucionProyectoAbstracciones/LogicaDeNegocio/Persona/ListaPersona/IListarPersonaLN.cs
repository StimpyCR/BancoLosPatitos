using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Persona.ListaPersona
{
    public interface IListarPersonaLN
    {
        List<PersonaDto> Obtener();
    }
}
