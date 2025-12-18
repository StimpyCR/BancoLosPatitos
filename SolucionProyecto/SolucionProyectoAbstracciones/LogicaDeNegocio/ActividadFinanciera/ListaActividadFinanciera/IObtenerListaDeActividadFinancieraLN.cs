using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.ActividadFinanciera.ListaActividadFinanciera
{
    public interface IObtenerListaDeActividadFinancieraLN
    {
        List<ActividadFinancieraDto> Obtener();
    }
}
