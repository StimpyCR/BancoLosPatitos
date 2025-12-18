using SolucionProyectoAbstracciones.AccesoADatos.Persona.AgregarUsuario;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Persona.AgregarPersona
{
        public class AgregarPersonaAD:  IAgregarPersonaAD
    {
        private readonly Contexto _elContexto;

    public AgregarPersonaAD()
    {
        _elContexto = new Contexto();
    }

    public async Task<int> Agregar(PersonaDto laPersonaParaGuardar)
    {
        bool existe = _elContexto.persona.Any(p => p.identificacion == laPersonaParaGuardar.Identificacion);

        if (existe)
        {
            throw new InvalidOperationException("Ya existe una persona registrada con esta identificación.");
        }

        PersonaAD laPersonaEntidad = ConvierteObjetoAEntidad(laPersonaParaGuardar);
        laPersonaEntidad.fechaDeRegistro = DateTime.Now;
        laPersonaEntidad.fechaDeModificacion = DateTime.Now;
        laPersonaEntidad.estado = true;

        _elContexto.persona.Add(laPersonaEntidad);
        await _elContexto.SaveChangesAsync();

        return laPersonaEntidad.IdPersona; 
    }

    private PersonaAD ConvierteObjetoAEntidad(PersonaDto dto)
    {
        return new PersonaAD
        {
            identificacion = dto.Identificacion,
            tipoIdentificacion = dto.TipoIdentificacion,
            Nombre = dto.Nombre,
            primerApellido = dto.PrimerApellido,
            segundoApellido = dto.SegundoApellido,
            telefono = dto.Telefono,
            correo = dto.Correo,
            direccion = dto.Direccion,
            estadoDeRiesgo = dto.estadoDeRiesgo,
            estado = dto.estado
        };
    }
}
}
