using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.Persona.EditarUsuario
{
    public interface IEditarPersonaAD
    {
        int Editar(PersonaDto usuarioParaEditar);
    }
}
