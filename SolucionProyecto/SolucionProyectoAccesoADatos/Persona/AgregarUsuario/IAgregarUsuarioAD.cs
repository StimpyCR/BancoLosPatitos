using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.Persona.AgregarUsuario
{
    public interface IAgregarUsuarioAD
    {
        Task<int> Agregar(UsuarioDto elUsuarioParaGuardar);
    }
}
