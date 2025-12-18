using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerActividadesFinancierasDeLaPersona
{
    public interface IObtenerActividadFinancieraPersonaAD
    {
        List<ActividadFinancieraDto> ObtenerDisponibles(int idPersona);
    }
}
