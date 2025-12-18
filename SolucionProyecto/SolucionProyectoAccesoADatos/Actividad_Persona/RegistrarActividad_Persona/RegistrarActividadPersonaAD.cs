using SolucionProyectoAbstracciones.AccesoADatos.Persona_Actividad.RegistrarActividadPersona;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Actividad_Persona.RegistrarActividad_Persona
{
    public class RegistrarActividadPersonaAD: IRegistrarActividadPersonaAD
    {
        private Contexto _elContexto;
        public RegistrarActividadPersonaAD()
        {
            _elContexto = new Contexto();
        }
        public async Task <int> RegistrarActividad (PersonaActividadDto laActividadPersonaParaGuardar, int id_Usuario, int id_ActividadFinanciera)
        {
            int cantidadDeFilasAfectadas = 0;

            laActividadPersonaParaGuardar.IdPersona = id_Usuario;
            laActividadPersonaParaGuardar.IdActividadFinanciera = id_ActividadFinanciera;

            bool yaActiva = await _elContexto.PersonaActividad
                            .AnyAsync(a => a.IdPersona == id_Usuario &&
                                      a.IdActividadFinanciera == id_ActividadFinanciera &&
                                      a.Estado == true);

            if (yaActiva)
            {
                PersonaActividadDto dtoActivo = await (from actividad in _elContexto.PersonaActividad
                                                       join fin in _elContexto.ActividadFinanciera
                                                       on actividad.IdActividadFinanciera equals fin.IdActividadFinanciera
                                                       where actividad.IdPersona == id_Usuario
                                                       && actividad.IdActividadFinanciera == id_ActividadFinanciera
                                                       && actividad.Estado == true
                                                       select new PersonaActividadDto
                                                       {
                                                            IdActividadPersona = actividad.IdActividadPersona,
                                                            IdActividadFinanciera = actividad.IdActividadFinanciera,
                                                            IdPersona = actividad.IdPersona,
                                                            NombreActividadFinanciera = fin.NombreActividadFinanciera,
                                                            NivelDeRiesgo = fin.NivelDeRiesgo,
                                                            NombreRiesgo = fin.NivelDeRiesgo == 1 ? "Bajo" :
                                                                           fin.NivelDeRiesgo == 2 ? "Medio" :
                                                                           fin.NivelDeRiesgo == 3 ? "Alto" : "Desconocido",
                                                            FechaDeRegistro = actividad.FechaDeRegistro,
                                                            FechaDeModificacion = actividad.FechaDeModificacion,
                                                            Estado = actividad.Estado
                                                       }).FirstOrDefaultAsync();
                if (dtoActivo != null)
                {
                    laActividadPersonaParaGuardar.IdActividadPersona = dtoActivo.IdActividadPersona;
                    laActividadPersonaParaGuardar.NombreActividadFinanciera = dtoActivo.NombreActividadFinanciera;
                    laActividadPersonaParaGuardar.NivelDeRiesgo = dtoActivo.NivelDeRiesgo;
                    laActividadPersonaParaGuardar.NombreRiesgo = dtoActivo.NombreRiesgo;
                    laActividadPersonaParaGuardar.FechaDeRegistro = dtoActivo.FechaDeRegistro;
                    laActividadPersonaParaGuardar.FechaDeModificacion = dtoActivo.FechaDeModificacion;
                    laActividadPersonaParaGuardar.Estado = dtoActivo.Estado;
                }
                return 0;
            }

            PersonaActividadAD inactiva = await _elContexto.PersonaActividad
                                        .FirstOrDefaultAsync(a => a.IdPersona == id_Usuario &&
                                                                    a.IdActividadFinanciera == id_ActividadFinanciera &&
                                                                    a.Estado == false);

            if (inactiva != null)
            {
                inactiva.Estado = true;
                inactiva.FechaDeModificacion = DateTime.Now;
                _elContexto.Entry(inactiva).State = EntityState.Modified;

                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();

                PersonaActividadDto dtoReactivado = await (
                                                            from actividad in _elContexto.PersonaActividad
                                                            join fin in _elContexto.ActividadFinanciera
                                                            on actividad.IdActividadFinanciera equals fin.IdActividadFinanciera
                                                            where actividad.IdPersona == id_Usuario
                                                            && actividad.IdActividadFinanciera == id_ActividadFinanciera
                                                            && actividad.Estado == true
                                                            select new PersonaActividadDto
                                                            {
                                                                IdActividadPersona = actividad.IdActividadPersona,
                                                                IdActividadFinanciera = actividad.IdActividadFinanciera,
                                                                IdPersona = actividad.IdPersona,
                                                                NombreActividadFinanciera = fin.NombreActividadFinanciera,
                                                                NivelDeRiesgo = fin.NivelDeRiesgo,
                                                                NombreRiesgo = fin.NivelDeRiesgo == 1 ? "Bajo" :
                                                                               fin.NivelDeRiesgo == 2 ? "Medio" :
                                                                               fin.NivelDeRiesgo == 3 ? "Alto" : "Desconocido",
                                                                FechaDeRegistro = actividad.FechaDeRegistro,
                                                                FechaDeModificacion = actividad.FechaDeModificacion,
                                                                Estado = actividad.Estado
                                                            }).FirstOrDefaultAsync();

                if (dtoReactivado != null)
                {
                    laActividadPersonaParaGuardar.IdActividadPersona = dtoReactivado.IdActividadPersona;
                    laActividadPersonaParaGuardar.NombreActividadFinanciera = dtoReactivado.NombreActividadFinanciera;
                    laActividadPersonaParaGuardar.NivelDeRiesgo = dtoReactivado.NivelDeRiesgo;
                    laActividadPersonaParaGuardar.NombreRiesgo = dtoReactivado.NombreRiesgo;
                    laActividadPersonaParaGuardar.FechaDeRegistro = dtoReactivado.FechaDeRegistro;
                    laActividadPersonaParaGuardar.FechaDeModificacion = dtoReactivado.FechaDeModificacion;
                    laActividadPersonaParaGuardar.Estado = dtoReactivado.Estado;
                }

                return cantidadDeFilasAfectadas;
            }

            PersonaActividadAD nuevo = new PersonaActividadAD
            {
                IdPersona = id_Usuario,
                IdActividadFinanciera = id_ActividadFinanciera,
                FechaDeRegistro = DateTime.Now,
                FechaDeModificacion = null,
                Estado = true
            };

            _elContexto.PersonaActividad.Add(nuevo);
            cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();

            PersonaActividadDto dtoInsertado = await (
                                                    from actividad in _elContexto.PersonaActividad.AsNoTracking()
                                                    join fin in _elContexto.ActividadFinanciera.AsNoTracking()
                                                    on actividad.IdActividadFinanciera equals fin.IdActividadFinanciera
                                                    where actividad.IdPersona == id_Usuario
                                                    && actividad.IdActividadFinanciera == id_ActividadFinanciera
                                                    && actividad.Estado == true
                                                    select new PersonaActividadDto
                                                    {
                                                        IdActividadPersona = actividad.IdActividadPersona,
                                                        IdActividadFinanciera = actividad.IdActividadFinanciera,
                                                        IdPersona = actividad.IdPersona,
                                                        NombreActividadFinanciera = fin.NombreActividadFinanciera,
                                                        NivelDeRiesgo = fin.NivelDeRiesgo,
                                                        NombreRiesgo = fin.NivelDeRiesgo == 1 ? "Bajo" :
                                                                       fin.NivelDeRiesgo == 2 ? "Medio" :
                                                                       fin.NivelDeRiesgo == 3 ? "Alto" : "Desconocido",
                                                        FechaDeRegistro = actividad.FechaDeRegistro,
                                                        FechaDeModificacion = actividad.FechaDeModificacion,
                                                        Estado = actividad.Estado
                                                    }).FirstOrDefaultAsync();

            if (dtoInsertado != null)
            {
                laActividadPersonaParaGuardar.IdActividadPersona = dtoInsertado.IdActividadPersona;
                laActividadPersonaParaGuardar.NombreActividadFinanciera = dtoInsertado.NombreActividadFinanciera;
                laActividadPersonaParaGuardar.NivelDeRiesgo = dtoInsertado.NivelDeRiesgo;
                laActividadPersonaParaGuardar.NombreRiesgo = dtoInsertado.NombreRiesgo;
                laActividadPersonaParaGuardar.FechaDeRegistro = dtoInsertado.FechaDeRegistro;
                laActividadPersonaParaGuardar.FechaDeModificacion = dtoInsertado.FechaDeModificacion;
                laActividadPersonaParaGuardar.Estado = dtoInsertado.Estado;
            }
            return cantidadDeFilasAfectadas;
        }

        public List<PersonaActividadDto> ObtenerDisponiblesParaAgregar(int idUsuario)
        {
            List<int> idsActivas = (from p in _elContexto.PersonaActividad
                                    where p.IdPersona == idUsuario && p.Estado == true
                                    select p.IdActividadFinanciera).ToList();

            List<PersonaActividadDto> opciones = (
                from fin in _elContexto.ActividadFinanciera
                where !idsActivas.Contains(fin.IdActividadFinanciera)
                orderby fin.NombreActividadFinanciera
                select new PersonaActividadDto
                {
                    IdPersona = idUsuario,
                    IdActividadFinanciera = fin.IdActividadFinanciera,
                    NombreActividadFinanciera = fin.NombreActividadFinanciera,
                    NivelDeRiesgo = fin.NivelDeRiesgo,
                    NombreRiesgo = fin.NivelDeRiesgo == 1 ? "Bajo" :
                                   fin.NivelDeRiesgo == 2 ? "Medio" :
                                   fin.NivelDeRiesgo == 3 ? "Alto" : "Desconocido",
                    IdActividadPersona = 0,
                    FechaDeRegistro = default(System.DateTime),
                    FechaDeModificacion = null,
                    Estado = false
                }
            ).ToList();

            return opciones;
        }
    }
}
