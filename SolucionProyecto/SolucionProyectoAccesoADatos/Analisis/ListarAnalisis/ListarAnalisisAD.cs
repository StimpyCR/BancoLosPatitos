using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ListarAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.Analisis;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Analisis.ListarAnalisis
{
    public class ListarAnalisisAD : IListarAnalisisAD
    {
        private readonly Contexto _contexto;

        public ListarAnalisisAD()
        {
            _contexto = new Contexto();
        }

        public List<AnalisisDto> Obtener()
        {
            List<AnalisisDto> listaAnalisis =
                (from a in _contexto.Analisis
                 select new AnalisisDto
                 {
                     IdAnalisis = a.IdAnalisis,
                     IdPersona = a.IdPersona,
                     CantidadArchivos = a.CantidadArchivos,
                     CantidadPalabrasClave = a.CantidadPalabrasClave,
                     NivelDeRiesgo = a.NivelDeRiesgo,
                     Comentario = a.Comentario,
                     FechaDeAnalisis = a.FechaDeAnalisis
                 }).ToList();

            return listaAnalisis;
        }
    }
}