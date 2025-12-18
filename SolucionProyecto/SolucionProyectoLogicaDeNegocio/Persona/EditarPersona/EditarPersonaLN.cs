
using SolucionProyectoAbstracciones.AccesoADatos.Persona.AgregarUsuario;
using SolucionProyectoAbstracciones.AccesoADatos.Persona.EditarPersona;
using SolucionProyectoAbstracciones.AccesoADatos.Persona.EditarUsuario;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Persona.EditarPersona;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.Persona.AgregarPersona;
using SolucionProyectoAccesoADatos.Persona.EditarPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEditarPersonaAD = SolucionProyectoAbstracciones.AccesoADatos.Persona.EditarUsuario.IEditarPersonaAD;

namespace SolucionProyectoLogicaDeNegocio.Persona.EditarPersona
{
    public class EditarPersonaLN : IEditarPersonaLN
    {
        private readonly IEditarPersonaAD _EditarPersonaAD;

        public EditarPersonaLN()
        {
            _EditarPersonaAD = new EditarPersonaAD(); 
        }

        public int Editar(PersonaDto laPersonaParaEditar)
        {
            if (laPersonaParaEditar == null)
                throw new ArgumentNullException(nameof(laPersonaParaEditar), "La persona no puede ser nula.");

            if (string.IsNullOrWhiteSpace(laPersonaParaEditar.Nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(laPersonaParaEditar.Correo))
                throw new ArgumentException("El correo electrónico es obligatorio.");

            if (string.IsNullOrWhiteSpace(laPersonaParaEditar.Telefono))
                throw new ArgumentException("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(laPersonaParaEditar.Direccion))
                throw new ArgumentException("La dirección es obligatoria.");

            int resultado = _EditarPersonaAD.Editar(laPersonaParaEditar);

            if (resultado <= 0)
            {
                throw new Exception("No se pudo actualizar la información de la persona.");
            }

            return resultado;
        }
    }
}