using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.PalabraClave.EditarPalabraClave
{
    public interface IEditarPalabraClaveLN
    {
        int Editar(PalabraClaveDto palabraPorEditar);
    }
}
