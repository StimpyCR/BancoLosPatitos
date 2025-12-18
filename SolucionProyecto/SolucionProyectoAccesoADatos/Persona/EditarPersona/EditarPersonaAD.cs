using SolucionProyectoAbstracciones.AccesoADatos.Persona.EditarUsuario;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Persona.EditarPersona
{
    public class EditarPersonaAD : IEditarPersonaAD
    {
        private readonly Contexto _contexto;

        public EditarPersonaAD()
        {
            _contexto = new Contexto();
        }

        public int Editar(PersonaDto personaEditada)
        {
            PersonaAD personaExistente = _contexto.persona
                .FirstOrDefault(p => p.IdPersona == personaEditada.Id);

            if (personaExistente == null)
            {
                throw new Exception("La persona especificada no existe en el sistema.");
            }

            personaExistente.Nombre = personaEditada.Nombre;
            personaExistente.primerApellido = personaEditada.PrimerApellido;
            personaExistente.segundoApellido = personaEditada.SegundoApellido;
            personaExistente.telefono = personaEditada.Telefono;
            personaExistente.correo = personaEditada.Correo;
            personaExistente.direccion = personaEditada.Direccion;
            personaExistente.estado = personaEditada.estado;

            personaExistente.fechaDeModificacion = DateTime.Now;

            int filasAfectadas = _contexto.SaveChanges();

            return filasAfectadas;
        }
    }
}
