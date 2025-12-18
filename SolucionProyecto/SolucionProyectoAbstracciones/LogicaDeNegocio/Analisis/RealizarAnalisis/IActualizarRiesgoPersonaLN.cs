using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.RealizarAnalisis
{
    public interface IActualizarRiesgoPersonaLN
    {
        void Actualizar(int idPersona, int nivelDeRiesgo);
    }
}
