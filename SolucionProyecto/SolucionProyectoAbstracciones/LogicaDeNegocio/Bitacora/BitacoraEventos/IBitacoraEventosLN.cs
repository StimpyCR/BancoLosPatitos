using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Bitacora.BitacoraEventos
{
    public interface IBitacoraEventosLN
    {
        BitacoraDto RegistrarEvento(BitacoraDto evento);
    }
}