using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ListarAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.Analisis;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Analisis.ListarAnalisis
{
    public class ListarPersonasAnalizadasAD : IListarPersonasAnalizadasAD
    {
        private readonly Contexto _contexto;

        public ListarPersonasAnalizadasAD()
        {
            _contexto = new Contexto();
        }

        public List<PersonaAnalizadaDto> Obtener()
        {
            var lista = (from p in _contexto.persona
                         join a in _contexto.Analisis
                             on p.IdPersona equals a.IdPersona
                         group a by new
                         {
                             p.IdPersona,
                             p.tipoIdentificacion,
                             p.Nombre,
                             p.primerApellido,
                             p.segundoApellido,
                             p.estadoDeRiesgo
                         } into g
                         select new PersonaAnalizadaDto
                         {
                             IdPersona = g.Key.IdPersona,
                             TipoIdentificacion = g.Key.tipoIdentificacion,
                             Nombre = g.Key.Nombre,
                             PrimerApellido = g.Key.primerApellido,
                             SegundoApellido = g.Key.segundoApellido,

                              EstadoDeRiesgo =
    g.Max(x => x.NivelDeRiesgo) == 0 ? "Sin análisis" :
    g.Max(x => x.NivelDeRiesgo) == 1 ? "Bajo" :
    g.Max(x => x.NivelDeRiesgo) == 2 ? "Medio" :
    g.Max(x => x.NivelDeRiesgo) == 3 ? "Alto" :
    "Crítico",


                             FechaUltimoAnalisis = g.Max(x => x.FechaDeAnalisis)
                         })
                         .ToList();

            return lista;
        }
    }
}
