using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.ActividadFinanciera.EditarActividadFinanciera 
{ 

    public interface IEditarActividadFinancieraAD
    {
        int Editar(ActividadFinancieraDto actividadPorEditar);
    }
}
