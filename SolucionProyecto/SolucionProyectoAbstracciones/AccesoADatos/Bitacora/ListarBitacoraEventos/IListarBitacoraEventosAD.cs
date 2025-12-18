using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.Bitacora.ListarBitacoraEventos
{
    public interface IListarBitacoraEventosAD
    {
        List<BitacoraDto> Obtener();
    }
}
