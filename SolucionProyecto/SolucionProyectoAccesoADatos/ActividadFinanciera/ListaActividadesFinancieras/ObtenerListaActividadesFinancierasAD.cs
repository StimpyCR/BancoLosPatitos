using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.ActividadFinanciera.ListaActividadesFinancieras
{
    public class ObtenerListaActividadesFinancierasAD
    {
        private Contexto _elContexto;
        public ObtenerListaActividadesFinancierasAD()
        {
            _elContexto = new Contexto();
        }
        public List<ActividadFinancieraDto> Obtener ()
        {
            List<ActividadFinancieraDto> laListaDeActividadesFinancieras = (from actividadFinanciera in _elContexto.ActividadFinanciera                                                                                                                              
                                                                            select new ActividadFinancieraDto
                                                                            {
                                                                            IdActividadFinanciera = actividadFinanciera.IdActividadFinanciera,
                                                                            NombreActividadFinanciera = actividadFinanciera.NombreActividadFinanciera,
                                                                            DescripcionActividadFinanciera = actividadFinanciera.DescripcionActividadFinanciera,
                                                                            NivelDeRiesgo = actividadFinanciera.NivelDeRiesgo,
                                                                            FechaDeRegistro = actividadFinanciera.FechaDeRegistro,
                                                                            FechaDeModificacion = actividadFinanciera.FechaDeModificacion,
                                                                            Estado = actividadFinanciera.Estado
                                                                            }).ToList();
            return laListaDeActividadesFinancieras;
        }
    }
}
