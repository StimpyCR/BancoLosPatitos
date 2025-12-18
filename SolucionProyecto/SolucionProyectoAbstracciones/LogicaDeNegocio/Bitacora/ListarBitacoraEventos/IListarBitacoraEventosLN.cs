using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Bitacora.ListarBitacoraEventos
{
    public interface IListarBitacoraEventosLN
    {
        List<BitacoraDto> Obtener();
    }
}
