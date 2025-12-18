using SolucionProyectoAbstracciones.AccesoADatos.Persona_Actividad.EliminarPersonaActividad;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Actividad_Persona.EliminarActividadPersona
{
    public class EliminarActividadPersonaAD: IEliminarActividadPersonaAD
    {
        private Contexto _elContexto;

        public EliminarActividadPersonaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Eliminar(PersonaActividadDto laPersonaActividadParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;
            PersonaActividadAD laPersonaActividadEnBaseDeDatos = _elContexto.PersonaActividad
                .Where(PersonaActividadABuscar =>
                PersonaActividadABuscar.IdActividadPersona == laPersonaActividadParaGuardar.IdActividadPersona).FirstOrDefault();
            if (laPersonaActividadEnBaseDeDatos != null)
            {
                laPersonaActividadEnBaseDeDatos.Estado = false;
                laPersonaActividadEnBaseDeDatos.FechaDeModificacion = laPersonaActividadParaGuardar.FechaDeModificacion;
                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }
            return cantidadDeFilasAfectadas;
        }
    }
}
