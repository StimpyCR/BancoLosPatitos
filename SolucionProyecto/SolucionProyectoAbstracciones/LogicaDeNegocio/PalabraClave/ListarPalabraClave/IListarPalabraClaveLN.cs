using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.PalabraClave.ListarPalabraClave
{
    public interface IListarPalabraClaveLN
    {
        List<PalabraClaveDto> Obtener();
    }
}
