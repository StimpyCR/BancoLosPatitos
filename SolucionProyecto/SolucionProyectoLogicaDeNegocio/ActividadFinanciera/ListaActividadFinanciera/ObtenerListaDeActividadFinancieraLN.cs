using SolucionProyectoAbstracciones.LogicaDeNegocio.ActividadFinanciera.ListaActividadFinanciera;
using SolucionProyectoAbstracciones.AccesoADatos.ActividadFinanciera.ListaActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using SolucionProyectoAccesoADatos.ActividadFinanciera.ListaActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.ActividadFinanciera.ListaActividadFinanciera
{
    public class ObtenerListaDeActividadFinancieraLN: IObtenerListaDeActividadFinancieraLN
    {
        private readonly IObtenerListaActividadFinancieraAD _obtenerListaDeActividadFinancieraAD;

        public ObtenerListaDeActividadFinancieraLN()
        {
            _obtenerListaDeActividadFinancieraAD = new ObtenerListaActividadFinancieraAD();
        }
        public List<ActividadFinancieraDto> Obtener()
        {
            List<ActividadFinancieraDto> laListaDeActividadFinanciera = _obtenerListaDeActividadFinancieraAD.Obtener();
            return laListaDeActividadFinanciera;
        }
    }
}
