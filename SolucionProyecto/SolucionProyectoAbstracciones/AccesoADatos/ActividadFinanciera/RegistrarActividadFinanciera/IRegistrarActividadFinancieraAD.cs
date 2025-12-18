using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.ActividadFinanciera.RegistrarActividadFinanciera
{
    public interface IRegistrarActividadFinancieraAD
    {
        Task<int> RegistrarActividadFinanciera(ActividadFinancieraDto nuevaActividad);
       
    }
}
