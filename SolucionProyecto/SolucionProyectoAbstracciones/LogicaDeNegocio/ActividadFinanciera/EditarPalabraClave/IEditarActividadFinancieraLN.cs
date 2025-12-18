using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.ActividadFinanciera.EditarActividadFinanciera
{

    public interface IEditarActividadFinancieraLN
    {
        int Editar(ActividadFinancieraDto actividadPorEditar);
    }
}
