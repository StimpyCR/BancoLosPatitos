
using SolucionProyecto.SolucionProyectoAbstracciones.LogicaDeNegocio.General.GestionDeFechas;
using SolucionProyectoAbstracciones.AccesoADatos.Persona_Actividad.EliminarPersonaActividad;
using SolucionProyectoAbstracciones.General.GestionDeFechas;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using SolucionProyectoAccesoADatos.Actividad_Persona.EliminarActividadPersona;
using SolucionProyectoLogicaDeNegocio.General.GestionDeFechas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Persona_Actividad.EliminarPersonaActividad
{
    public class EliminarPersonaActividadLN : IEliminarActividadPersonaAD
    {
        private EliminarActividadPersonaAD _eliminarPersonaActividadAD;
        private IFecha _fecha;

        public EliminarPersonaActividadLN()
        {
            _eliminarPersonaActividadAD = new EliminarActividadPersonaAD();
            _fecha = new Fecha();
        }
        public async Task<int> Eliminar(PersonaActividadDto laPersonaActividadParaEliminar)
        {
            if (laPersonaActividadParaEliminar == null)
            {
                throw new ArgumentNullException("El cliente para guardar no puede ser nulo");
            }

            if (laPersonaActividadParaEliminar.IdActividadPersona <= 0)
            {
                throw new ArgumentOutOfRangeException("El id del cliente no puede ser menor o igual a cero");
            }

            int cantidadDeFilasAfectadas = await _eliminarPersonaActividadAD.Eliminar(laPersonaActividadParaEliminar);
            return cantidadDeFilasAfectadas;
        }
    }
}
