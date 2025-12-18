using SolucionProyectoAbstracciones.AccesoADatos.ActividadFinanciera.RegistrarActividadFinanciera;
using SolucionProyectoAbstracciones.LogicaDeNegocio.ActividadFinanciera.RegistrarActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using SolucionProyectoAccesoADatos.ActividadFinanciera.RegistrarActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.ActividadFinanciera.RegistrarActividadFinanciera
{
    public class RegistrarActividadFinancieraLN: IRegistrarActividadFinancieraLN
    {
        private IRegistrarActividadFinancieraAD _registrarActividadFinancieraAD;

        public RegistrarActividadFinancieraLN()
        {
            _registrarActividadFinancieraAD = new RegistrarActividadFinancieraAD();
            
        }

        public async Task<int> RegistrarActividadFinanciera(ActividadFinancieraDto nuevaActividad)
        {

            int cantidadDeFilasAfectadas = await _registrarActividadFinancieraAD.RegistrarActividadFinanciera(nuevaActividad);

            return cantidadDeFilasAfectadas;
        }
    }
}
