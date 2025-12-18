using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ListarAnalisis;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ListarAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.Analisis;
using SolucionProyectoAccesoADatos.Analisis.ListarAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Analisis.ListarAnalisis
{
    public class ListarAnalisisPorPersonaIdLN: IListarAnalisisPorPersonaIdLN
    {
        private readonly IListarAnalisisPorPersonaIdAD _accesoADatos;

        public ListarAnalisisPorPersonaIdLN()
        {
            _accesoADatos = new ListarAnalisisPorPersonaIdAD();
        }

        public List<AnalisisDto> Ejecutar(int idPersona)
        {
            return _accesoADatos.Obtener(idPersona);
        }
    }
}