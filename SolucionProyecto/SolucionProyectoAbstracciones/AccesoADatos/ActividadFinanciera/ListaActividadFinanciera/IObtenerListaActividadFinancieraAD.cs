using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.ActividadFinanciera.ListaActividadFinanciera
{
    public interface IObtenerListaActividadFinancieraAD
    {
        List<ActividadFinancieraDto> Obtener();
    }
}
