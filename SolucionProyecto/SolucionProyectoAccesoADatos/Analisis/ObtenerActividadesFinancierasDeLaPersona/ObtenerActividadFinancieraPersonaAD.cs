using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerActividadesFinancierasDeLaPersona;
using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.Proyecciones;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Analisis.ObtenerActividadesFinancierasDeLaPersona
{
    public class ObtenerActividadFinancieraPersonaAD: IObtenerActividadFinancieraPersonaAD
    {
        private Contexto _elContexto;

        public ObtenerActividadFinancieraPersonaAD()
        {
            _elContexto = new Contexto();
        }

        public List<ActividadFinancieraDto> ObtenerDisponibles(int idPersona)
        {
            List<ActividadFinancieraProyeccion> query =
                (from pa in _elContexto.PersonaActividad
                 join af in _elContexto.ActividadFinanciera
                     on pa.IdActividadFinanciera equals af.IdActividadFinanciera
                 where pa.IdPersona == idPersona
                       && pa.Estado == true
                       && af.Estado == true
                 select new ActividadFinancieraProyeccion
                 {
                     IdActividadFinanciera = af.IdActividadFinanciera,
                     NombreActividadFinanciera = af.NombreActividadFinanciera,
                     DescripcionActividadFinanciera = af.DescripcionActividadFinanciera,
                     NivelDeRiesgo = af.NivelDeRiesgo,
                     FechaDeRegistro = af.FechaDeRegistro,
                     FechaDeModificacion = af.FechaDeModificacion,
                     Estado = af.Estado
                 }).ToList();

            List<ActividadFinancieraDto> laListaDeActividades = new List<ActividadFinancieraDto>();

            foreach (ActividadFinancieraProyeccion x in query)
            {
                ActividadFinancieraDto actividad = new ActividadFinancieraDto
                {
                    IdActividadFinanciera = x.IdActividadFinanciera,
                    NombreActividadFinanciera = x.NombreActividadFinanciera,
                    DescripcionActividadFinanciera = x.DescripcionActividadFinanciera,
                    NivelDeRiesgo = x.NivelDeRiesgo,
                    FechaDeRegistro = x.FechaDeRegistro,
                    FechaDeModificacion = x.FechaDeModificacion,
                    Estado = x.Estado
                };

                laListaDeActividades.Add(actividad);
            }

            return laListaDeActividades;
        }
    }
}
