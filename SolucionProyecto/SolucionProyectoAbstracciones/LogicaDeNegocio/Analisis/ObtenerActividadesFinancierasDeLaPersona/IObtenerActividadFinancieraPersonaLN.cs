using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerActividadesFinancierasDeLaPersona
{
    public interface IObtenerActividadFinancieraPersonaLN
    {
        List<ActividadFinancieraDto> ObtenerDisponibles(int idPersona);
    }
}
