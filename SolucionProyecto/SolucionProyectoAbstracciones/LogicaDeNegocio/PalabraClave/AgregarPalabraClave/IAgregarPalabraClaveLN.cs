using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.PalabraClave.AgregarPalabraClave
{
    public interface IAgregarPalabraClaveLN
    {
        Task<int> Agregar(PalabraClaveDto PalabraPorAgregar);
    }
}
