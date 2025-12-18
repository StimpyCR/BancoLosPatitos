using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerArchivos;
using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerPersona;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerArchivos;
using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using SolucionProyectoAccesoADatos.Analisis.ObtenerArchivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Analisis.ObtenerArchivos
{
    public class ObtenerArchivosLN : IObtenerArchivosLN
    {
     
        private readonly IObtenerArchivosAD _obtenerArchivosAD;

        
        public ObtenerArchivosLN()
        {
            _obtenerArchivosAD = new ObtenerArchivosAD();
        }
        public List<ArchivosDeAnalisisDto> ObtenerDisponibles(int idPersona)
        {
           
            List<ArchivosDeAnalisisDto> laListaDeArchivos = _obtenerArchivosAD.ObtenerDisponibles(idPersona);
            return laListaDeArchivos;
        }
    }
}
