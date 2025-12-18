using SolucionProyectoAbstracciones.AccesoADatos.Persona.ListaPersona;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Persona.ListaPersona
{
    public class ListarPersonaAD : IListarPersonaAD
    {
        private Contexto _elContexto;

        public ListarPersonaAD()
        {
            _elContexto = new Contexto();
        }
        public List<PersonaDto> Obtener()
        { 
            List <PersonaDto> laListaDePersonas = (from p in _elContexto.persona
                                                  select new PersonaDto
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
                                                        estado = p.estado

                                                  }).ToList();
            return laListaDePersonas;
        }
    }
}
