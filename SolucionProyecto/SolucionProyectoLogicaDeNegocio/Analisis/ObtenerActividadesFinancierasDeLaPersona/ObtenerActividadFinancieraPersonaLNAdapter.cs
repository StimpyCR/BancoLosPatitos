using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerActividadesFinancierasDeLaPersona;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerActividadesFinancierasDeLaPersona;
using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using SolucionProyectoAccesoADatos.Analisis.ObtenerActividadesFinancierasDeLaPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Analisis.ObtenerActividadesFinancierasDeLaPersona
{
    public class ObtenerActividadFinancieraPersonaLNAdapter : IObtenerActividadFinancieraPersonaLN
    {
        private readonly IObtenerActividadFinancieraPersonaAD _obtenerActividadFinancieraPersonaAD;

        public ObtenerActividadFinancieraPersonaLNAdapter()
        {
            _obtenerActividadFinancieraPersonaAD = new ObtenerActividadFinancieraPersonaAD();
        }

        public List<ActividadFinancieraDto> ObtenerDisponibles(int idPersona)
        {
            return _obtenerActividadFinancieraPersonaAD.ObtenerDisponibles(idPersona);
        }
    }
}