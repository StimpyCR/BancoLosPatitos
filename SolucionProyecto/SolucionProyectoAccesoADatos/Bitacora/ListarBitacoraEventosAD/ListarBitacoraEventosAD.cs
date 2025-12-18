using SolucionProyectoAbstracciones.AccesoADatos.Bitacora.ListarBitacoraEventos;
using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Bitacora.ListarBitacoraEventosAD
{
    public class ListarBitacoraEventosAD : IListarBitacoraEventosAD

    {
        private Contexto _elContexto;

        public ListarBitacoraEventosAD()
        {
            _elContexto = new Contexto();
        }

        public List<BitacoraDto> Obtener()
        {
            List<BitacoraDto> lista = (from b in _elContexto.Bitacora
                                       select new BitacoraDto
                                       {
                                           idEvento = b.idEvento,
                                           tablaDeEvento = b.tablaDeEvento,
                                           tipoDeEvento = b.tipoDeEvento,
                                           fechaDeEvento = b.fechaDeEvento,
                                           descripcionDeEvento = b.descripcionDeEvento,
                                           stackTrace = b.stackTrace,
                                           datosAnteriores = b.datosAnteriores,
                                           datosPosteriores = b.datosPosteriores
                                       }).ToList();

            return lista;
        }
    }
}