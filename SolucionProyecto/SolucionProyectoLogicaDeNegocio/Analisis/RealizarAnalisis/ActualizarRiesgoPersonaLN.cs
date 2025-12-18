using SolucionProyectoAbstracciones.AccesoADatos.Analisis.RealizarAnalisis;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.RealizarAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Analisis.RealizarAnalisis
{
    public class ActualizarRiesgoPersonaLN : IActualizarRiesgoPersonaLN
    {
        private readonly IActualizarRiesgoPersonaAD _actualizarRiesgoPersonaAD;

        public ActualizarRiesgoPersonaLN(IActualizarRiesgoPersonaAD actualizarRiesgoPersonaAD)
        {
            _actualizarRiesgoPersonaAD = actualizarRiesgoPersonaAD;
        }

        public void Actualizar(int idPersona, int nivelDeRiesgo)
        {
            _actualizarRiesgoPersonaAD.Actualizar(idPersona, nivelDeRiesgo);
        }
    }
}
