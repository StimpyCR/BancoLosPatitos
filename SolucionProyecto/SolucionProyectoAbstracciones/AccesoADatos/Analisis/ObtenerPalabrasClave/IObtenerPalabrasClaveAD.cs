using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerPalabrasClave
{
    public interface IObtenerPalabrasClaveAD
    {
        List<PalabraClaveDto> ObtenerDisponibles();
    }
}
