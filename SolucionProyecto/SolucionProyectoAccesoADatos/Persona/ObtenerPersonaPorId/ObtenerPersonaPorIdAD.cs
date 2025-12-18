using SolucionProyectoAbstracciones.AccesoADatos.Persona.ObtenerPersonaPorId;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Persona.ObtenerPersonaPorId
{
    public class ObtenerPersonaPorIdAD: IObtenerPersonaPorIdAD
    {
        private readonly Contexto _contexto;

        public ObtenerPersonaPorIdAD()
        {
            _contexto = new Contexto();
        }

        public PersonaDto ObtenerPersona (int idPersona)
        {
            PersonaDto persona = _contexto.persona
                .Where(p => p.IdPersona == idPersona)
                .Select(p => new PersonaDto
                {
                    Id = p.IdPersona,
                    Identificacion = p.identificacion,
                    TipoIdentificacion = p.tipoIdentificacion,
                    Nombre = p.Nombre,
                    PrimerApellido = p.primerApellido,
                    SegundoApellido = p.segundoApellido,
                    Telefono = p.telefono,
                    Correo = p.correo,
                    Direccion = p.direccion,
                    estadoDeRiesgo = p.estadoDeRiesgo,
                    fechaDeRegistro = p.fechaDeRegistro,
                    fechaDeModificacion = p.fechaDeModificacion,
                    estado = p.estado,
                })
                .FirstOrDefault();
            return persona;
        }
    }
}
