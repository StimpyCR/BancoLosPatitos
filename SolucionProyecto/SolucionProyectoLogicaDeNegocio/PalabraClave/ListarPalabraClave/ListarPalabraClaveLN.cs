using SolucionProyectoAbstracciones.AccesoADatos.PalabraClave.ListarPalabraClave;
using SolucionProyectoAbstracciones.LogicaDeNegocio.PalabraClave.ListarPalabraClave;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using SolucionProyectoAccesoADatos.PalabraClave.ListarPalabraClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.PalabraClave.ListarPalabraClave
{
    public class ListarPalabraClaveLN : IListarPalabraClaveLN
    {
        readonly IListarPalabraClaveAD _listarPalabraClaveAD;
        public ListarPalabraClaveLN()
        {
            _listarPalabraClaveAD = new ListarPalabraClaveAD();
        }
        public List<PalabraClaveDto> Obtener()
        {
            List<PalabraClaveDto> laListaDePalabrasClave = _listarPalabraClaveAD.Obtener();
            return laListaDePalabrasClave;
        }
    }
}
