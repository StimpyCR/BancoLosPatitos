using SolucionProyectoAbstracciones.AccesoADatos.ActividadFinanciera.EditarActividadFinanciera;
using SolucionProyectoAbstracciones.LogicaDeNegocio.ActividadFinanciera.EditarActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using SolucionProyectoAccesoADatos.ActividadFinanciera.EditarActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.ActividadFinanciera.EditarActividadFinanciera
{
    public class EditarActividadFinancieraLN: IEditarActividadFinancieraLN
    {
        private IEditarActividadFinancieraAD _editarActividadFinancieraAD;
        public EditarActividadFinancieraLN()
        {
            _editarActividadFinancieraAD = new EditarActividadFinancieraAD();
        }
        public int Editar(ActividadFinancieraDto actividadPorEditar)
        {
            int cantidadDeFilasAfectadas = _editarActividadFinancieraAD.Editar(actividadPorEditar);
            return cantidadDeFilasAfectadas;
        }
    }
}
