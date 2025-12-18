using SolucionProyectoAbstracciones.AccesoADatos.Persona.AgregarUsuario;
using SolucionProyectoAbstracciones.General.GestionDeFechas;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Persona.AgregarPersona;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Persona.AgregarPersona;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgregarPersonaAD = SolucionProyectoAccesoADatos.Persona.AgregarPersona.AgregarPersonaAD;
using IAgregarPersonaAD = SolucionProyectoAbstracciones.AccesoADatos.Persona.AgregarUsuario.IAgregarPersonaAD;

namespace SolucionProyectoLogicaDeNegocio.Persona.AgregarPersona
{
    public class AgregarPersonaLN : IAgregarPersonaLN
    {
        private readonly IAgregarPersonaAD _agregarPersonaAD;

        public AgregarPersonaLN()
        {
            _agregarPersonaAD = new AgregarPersonaAD();
        }

        public async Task<int> Agregar(PersonaDto laPersona)
        {
            if (laPersona == null)
                throw new ArgumentNullException(nameof(laPersona), "La persona no puede ser nula.");

            if (laPersona.Identificacion <= 0)
                throw new ArgumentException("La identificación debe ser un número positivo.");

            if (string.IsNullOrWhiteSpace(laPersona.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(laPersona.Telefono))
                throw new ArgumentException("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(laPersona.Correo))
                throw new ArgumentException("El correo electrónico es obligatorio.");

            int idGenerado = await _agregarPersonaAD.Agregar(laPersona);

            return idGenerado;
        }
    }
}