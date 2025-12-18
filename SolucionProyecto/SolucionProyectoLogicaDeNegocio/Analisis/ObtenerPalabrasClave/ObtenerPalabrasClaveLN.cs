using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerPalabrasClave;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Analisis.ObtenerPalabrasClave
{
    public class ObtenerPalabrasClaveLN: IObtenerPalabrasClaveLN
    {
        private readonly IObtenerPalabrasClaveLN _obtenerPalabrasClaveLN;

        public ObtenerPalabrasClaveLN(IObtenerPalabrasClaveLN obtenerPalabrasClaveLN)
        {
            _obtenerPalabrasClaveLN = obtenerPalabrasClaveLN;
        }

        public List<PalabraClaveDto> ObtenerDisponibles()
        {
            return _obtenerPalabrasClaveLN.ObtenerDisponibles();
        }
    }
}
