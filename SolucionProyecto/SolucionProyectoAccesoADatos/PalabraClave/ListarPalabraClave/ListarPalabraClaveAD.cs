using SolucionProyectoAbstracciones.AccesoADatos.PalabraClave.ListarPalabraClave;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.PalabraClave.ListarPalabraClave
{
    public class ListarPalabraClaveAD : IListarPalabraClaveAD
    {
        private Contexto _elContexto;
        public ListarPalabraClaveAD()
        {
            _elContexto = new Contexto();
        }

        public List<PalabraClaveDto> Obtener()
        {
            List<PalabraClaveDto> laListaDePalabrasClave = (from pc in _elContexto.PalabraClave
                                                                     select new PalabraClaveDto
                                                                     {
                                                                         IdPalabra = pc.IdPalabra,
                                                                         Palabra = pc.Palabra,
                                                                         Orden = pc.Orden,
                                                                         FechaDeRegistro = pc.FechaDeRegistro,
                                                                         FechaDeModificacion = pc.FechaDeModificacion,
                                                                         Estado = pc.Estado
                                                                     }).ToList();
            return laListaDePalabrasClave;
        }
    }
}
