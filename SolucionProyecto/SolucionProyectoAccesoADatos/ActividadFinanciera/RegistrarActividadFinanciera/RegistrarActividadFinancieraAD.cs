using SolucionProyectoAbstracciones.AccesoADatos.ActividadFinanciera.RegistrarActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.ActividadFinanciera.RegistrarActividadFinanciera
{
    public class RegistrarActividadFinancieraAD: IRegistrarActividadFinancieraAD
    {
        private Contexto _elcontexto;

        public RegistrarActividadFinancieraAD()
        {
            _elcontexto = new Contexto();
        }
        public async Task<int> RegistrarActividadFinanciera(ActividadFinancieraDto nuevaActividad)
        {
            int cantidadDeFilasAfectadas = 0;

          
            bool nombreExiste = await _elcontexto.ActividadFinanciera
                .AnyAsync(a => a.NombreActividadFinanciera.ToLower() == nuevaActividad.NombreActividadFinanciera.ToLower());

            if (nombreExiste)
            {
                return 0; 
            }

            
            ActividadFinancieraAD nuevaEntidad = new ActividadFinancieraAD
            {
               
                NombreActividadFinanciera = nuevaActividad.NombreActividadFinanciera,
                DescripcionActividadFinanciera = nuevaActividad.DescripcionActividadFinanciera,
                NivelDeRiesgo = nuevaActividad.NivelDeRiesgo,
                FechaDeRegistro = DateTime.Now,
                FechaDeModificacion = null,
                Estado = true
            };

            _elcontexto.ActividadFinanciera.Add(nuevaEntidad);
            cantidadDeFilasAfectadas = await _elcontexto.SaveChangesAsync();

            return cantidadDeFilasAfectadas;
        }
    }
}
