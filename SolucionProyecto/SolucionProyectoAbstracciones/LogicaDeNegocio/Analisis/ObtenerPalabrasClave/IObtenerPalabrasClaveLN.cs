using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerPalabrasClave
{
    public interface IObtenerPalabrasClaveLN
    {
        List<PalabraClaveDto> ObtenerDisponibles();
    }
}
