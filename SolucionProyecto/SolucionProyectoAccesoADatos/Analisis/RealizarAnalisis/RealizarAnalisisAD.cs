using SolucionProyectoAbstracciones.AccesoADatos.Analisis.RealizarAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.Analisis;
using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Analisis.RealizarAnalisis
{
    public class RealizarAnalisisAD : IRealizarAnalisisAD
    {
        private readonly Contexto _contexto;

        public RealizarAnalisisAD()
        {
            _contexto = new Contexto();
        }

        public void RegistrarAnalisis(AnalisisDto analisisDto)
        {
            var analisisAD = new AnalisisAD
            {
                IdPersona = analisisDto.IdPersona,
                CantidadArchivos = analisisDto.CantidadArchivos,
                CantidadPalabrasClave = analisisDto.CantidadPalabrasClave,
                NivelDeRiesgo = analisisDto.NivelDeRiesgo,
                Comentario = analisisDto.Comentario,
                FechaDeAnalisis = DateTime.Now
            };

            _contexto.Analisis.Add(analisisAD);
            _contexto.SaveChanges();

            analisisDto.IdAnalisis = analisisAD.IdAnalisis;
            analisisDto.FechaDeAnalisis = analisisAD.FechaDeAnalisis;
        }
    }
}
