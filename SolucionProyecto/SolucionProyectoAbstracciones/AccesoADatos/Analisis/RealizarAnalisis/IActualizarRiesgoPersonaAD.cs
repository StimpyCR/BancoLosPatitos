using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.Analisis.RealizarAnalisis
{
    public interface IActualizarRiesgoPersonaAD
    {
        void Actualizar(int idPersona, int nuevoNivelRiesgo);
    }
}
