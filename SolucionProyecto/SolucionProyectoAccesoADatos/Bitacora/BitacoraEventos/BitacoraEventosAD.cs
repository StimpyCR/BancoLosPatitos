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
    public class BitacoraEventosAD : IBitacoraEventosAD
    {
        private readonly Contexto _elContexto;

        public BitacoraEventosAD()
        {
            _elContexto = new Contexto();
        }

        public BitacoraDto Registrar(BitacoraDto elEventoParaGuardar)
        {
            BitacoraAD entidad = ConvierteAD(elEventoParaGuardar);

            entidad.fechaDeEvento = DateTime.Now;

            _elContexto.Bitacora.Add(entidad);
            _elContexto.SaveChanges();   

            return ConvierteDTO(entidad);
        }

        private BitacoraAD ConvierteAD(BitacoraDto dto)
        {
            return new BitacoraAD
            {
                tablaDeEvento = dto.tablaDeEvento,
                tipoDeEvento = dto.tipoDeEvento,
                descripcionDeEvento = dto.descripcionDeEvento,
                datosAnteriores = dto.datosAnteriores,
                datosPosteriores = dto.datosPosteriores,
                stackTrace = dto.stackTrace
            };
        }

        private BitacoraDto ConvierteDTO(BitacoraAD entidad)
        {
            return new BitacoraDto
            {
                idEvento = entidad.idEvento,
                tablaDeEvento = entidad.tablaDeEvento,
                tipoDeEvento = entidad.tipoDeEvento,
                fechaDeEvento = entidad.fechaDeEvento,
                descripcionDeEvento = entidad.descripcionDeEvento,
                datosAnteriores = entidad.datosAnteriores,
                datosPosteriores = entidad.datosPosteriores,
                stackTrace = entidad.stackTrace
            };
        }
    }
}
