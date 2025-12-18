using SolucionProyectoAbstracciones.AccesoADatos.ActividadFinanciera.ListaActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;

using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.ActividadFinanciera.ListaActividadFinanciera
{
    public class ObtenerListaActividadFinancieraAD: IObtenerListaActividadFinancieraAD
    {
        private readonly Contexto _elContexto;

        public ObtenerListaActividadFinancieraAD()
        {
            _elContexto = new Contexto();
        }

        public List<ActividadFinancieraDto> Obtener()
        {
            List<ActividadFinancieraDto> listaDeActividadFinanciera =
               _elContexto.ActividadFinanciera
               .ToList()  
               .Select(actividadAD => new ActividadFinancieraDto
               {
                   IdActividadFinanciera = actividadAD.IdActividadFinanciera,
                     NombreActividadFinanciera = actividadAD.NombreActividadFinanciera,
                     DescripcionActividadFinanciera = actividadAD.DescripcionActividadFinanciera,
                     NivelDeRiesgo = actividadAD.NivelDeRiesgo,
                     FechaDeRegistro = actividadAD.FechaDeRegistro,
                     FechaDeModificacion = actividadAD.FechaDeModificacion,
                     Estado = actividadAD.Estado
                 }).ToList();

            return listaDeActividadFinanciera;
        }
    }
}