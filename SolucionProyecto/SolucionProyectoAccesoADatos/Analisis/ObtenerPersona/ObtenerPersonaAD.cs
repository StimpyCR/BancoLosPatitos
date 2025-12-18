using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerPersona;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Analisis.ObtenerPersona
{
    public class ObtenerPersonaAD: IObtenerPersonaAD
    {
        private Contexto _elContexto;
        public ObtenerPersonaAD()
        {
            _elContexto = new Contexto();
        }
        public List<PersonaDto> ObtenerDisponibles(int idPersona)
        {
            List<PersonaDto> laListaPersonas =
                (from p in _elContexto.persona
                 where p.estado == true
                 && p.IdPersona == idPersona
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

            return laListaPersonas;
        }
    }
}