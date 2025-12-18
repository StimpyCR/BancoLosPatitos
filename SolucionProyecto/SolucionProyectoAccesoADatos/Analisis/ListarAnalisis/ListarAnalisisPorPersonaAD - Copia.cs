using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ListarAnalisis;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Analisis.ListarAnalisis
{
    public class ListarAnalisisPorPersonaAD : IListarAnalisisPorPersonaAD
    {
        private readonly Contexto db;


        public ListarAnalisisPorPersonaAD()
        {
            db = new Contexto();
        }

        public List<AnalisisAD> ListarAnalisisPorPersona(int idPersona)
        {
            try
            {
                var lista = db.Analisis
                              .Where(a => a.IdPersona == idPersona)
                              .OrderByDescending(a => a.FechaDeAnalisis)
                              .ToList();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los análisis por persona", ex);
            }
        }
    }
}
