using SolucionProyectoAbstracciones.LogicaDeNegocio.Bitacora.BitacoraEventos;
using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Bitacora.BitacoraEventos
{
    public class BitacoraEventosLN : IBitacoraEventosLN
    {
        private readonly IBitacoraEventosAD _bitacoraEventosAD;

        public BitacoraEventosLN()
        {
            _bitacoraEventosAD = new BitacoraEventosAD();
        }

        public BitacoraDto RegistrarEvento(BitacoraDto evento)
        {
            return _bitacoraEventosAD.Registrar(evento);
        }
    }
}