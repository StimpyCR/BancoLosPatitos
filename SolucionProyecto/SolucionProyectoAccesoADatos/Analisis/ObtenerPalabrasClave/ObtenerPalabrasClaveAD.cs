using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerPalabrasClave;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Analisis.ObtenerPalabrasClave
{
    public class ObtenerPalabrasClaveAD: IObtenerPalabrasClaveAD
    {
        private Contexto _elContexto;
        public ObtenerPalabrasClaveAD()
        {
            _elContexto = new Contexto();
        }
        public List<PalabraClaveDto> ObtenerDisponibles()
        {
            List<PalabraClaveDto> laListaPalabras =
                (from p in _elContexto.PalabraClave
                 where p.Estado == true       
                 select new PalabraClaveDto
                 {
                     IdPalabra = p.IdPalabra,
                     Palabra = p.Palabra,
                     Orden = p.Orden,
                     FechaDeRegistro = p.FechaDeRegistro,
                     FechaDeModificacion = p.FechaDeModificacion,
                     Estado = p.Estado
                 }).ToList();

            return laListaPalabras;
        }
    }
}
