using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.PalabraClave.ListarPalabraClave
{
    public interface IListarPalabraClaveAD
    {
        List<PalabraClaveDto> Obtener();
    }
}
