using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerPalabrasClave;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerPalabrasClave;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using SolucionProyectoAccesoADatos.Analisis.ObtenerPalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Analisis.ObtenerPalabrasClave
{
    public class ObtenerPalabrasClaveLNAdapter : IObtenerPalabrasClaveLN
    {
        private readonly IObtenerPalabrasClaveAD _obtenerPalabrasClaveAD;

        public ObtenerPalabrasClaveLNAdapter()
        {
            _obtenerPalabrasClaveAD = new ObtenerPalabrasClaveAD();
        }

        public List<PalabraClaveDto> ObtenerDisponibles()
        {
            return _obtenerPalabrasClaveAD.ObtenerDisponibles();
        }
    }
}