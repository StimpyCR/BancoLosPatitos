using SolucionProyectoAbstracciones.AccesoADatos.Bitacora.ListarBitacoraEventos;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Bitacora.ListarBitacoraEventos;
using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using SolucionProyectoAccesoADatos.Bitacora.ListarBitacoraEventosAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Bitacora.ListarBitacoraEventos
{
    public class ListarBitacoraEventosLN: IListarBitacoraEventosLN
    {
        private readonly IListarBitacoraEventosAD _ListarBitacoraEventosAD;

        public ListarBitacoraEventosLN()
        {
            _ListarBitacoraEventosAD = new ListarBitacoraEventosAD();
        }

        public List<BitacoraDto> Obtener()
        {
            // Obtener la lista sin procesar desde el AD
            List<BitacoraDto> lista = _ListarBitacoraEventosAD.Obtener();

            List<BitacoraDto> listaOrdenada =
                lista.OrderByDescending(x => x.fechaDeEvento).ToList();

            return listaOrdenada;
        }
    }
}