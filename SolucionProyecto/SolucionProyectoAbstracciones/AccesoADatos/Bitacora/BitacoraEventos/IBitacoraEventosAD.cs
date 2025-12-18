using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Bitacora.BitacoraEventos
{
    public interface IBitacoraEventosAD
    {
        BitacoraDto Registrar(BitacoraDto elEventoParaGuardar);

    }
    }