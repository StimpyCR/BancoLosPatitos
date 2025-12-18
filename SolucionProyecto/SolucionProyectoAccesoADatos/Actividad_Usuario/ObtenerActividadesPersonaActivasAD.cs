using SolucionProyectoAbstracciones.AccesoADatos.Persona_Actividad.ObtenerPersonaActividadActiva;
using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Actividad_Persona
{
    public class ObtenerActividadesPersonaActivasAD: IObtenerPersonaActividadActivaAD
    {
        private Contexto _elContexto;
        public ObtenerActividadesPersonaActivasAD()
        {
            _elContexto = new Contexto();
        }
        public List<PersonaActividadDto> ObtenerDisponibles(int idUsuario)
        {
            List<PersonaActividadDto> laListaDeActividadesPersonaDisp = (from actividad in _elContexto.PersonaActividad
                                                                         join fin in _elContexto.ActividadFinanciera
                                                                         on actividad.IdActividadFinanciera equals fin.IdActividadFinanciera
                                                                         where actividad.Estado == true && actividad.IdPersona == idUsuario
                                                                         select new PersonaActividadDto
                                                                              {
                                                                                    IdActividadPersona = actividad.IdActividad,
                                                                                    IdActividadFinanciera = actividad.IdActividadFinanciera,
                                                                                    IdPersona = actividad.IdUsuario,
                                                                                    FechaDeRegistro = actividad.FechaDeRegistro,
                                                                                    FechaDeModificacion = actividad.FechaDeModificacion,
                                                                                    Estado = actividad.Estado
                                                                              }).ToList();          
            return laListaDeActividadesPersonaDisp;
        }
    }
}
