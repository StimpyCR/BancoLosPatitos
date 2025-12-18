using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Persona.EditarUsuario
{
    public interface IEditarUsuarioLN
    {
        int Editar(PersonaDto personaParaEditar);
    }
}
