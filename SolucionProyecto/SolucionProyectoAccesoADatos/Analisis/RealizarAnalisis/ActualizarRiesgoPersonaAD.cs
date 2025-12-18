using SolucionProyectoAbstracciones.AccesoADatos.Analisis.RealizarAnalisis;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Analisis.RealizarAnalisis
{
    public class ActualizarRiesgoPersonaAD : IActualizarRiesgoPersonaAD
    {
        private Contexto _elContexto;

        public ActualizarRiesgoPersonaAD()
        {
            _elContexto = new Contexto();
        }

        public void Actualizar(int idPersona, int nivelDeRiesgo)
        {
            var laPersona = _elContexto.persona
                .FirstOrDefault(p => p.IdPersona == idPersona);

            if (laPersona != null)
            {
                laPersona.estadoDeRiesgo = nivelDeRiesgo;
                laPersona.fechaDeModificacion = DateTime.Now;
                _elContexto.SaveChanges();
            }
        }
    }
}