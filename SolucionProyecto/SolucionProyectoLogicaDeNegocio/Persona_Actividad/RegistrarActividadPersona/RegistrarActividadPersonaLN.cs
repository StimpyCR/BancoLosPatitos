
using SolucionProyecto.SolucionProyectoAbstracciones.LogicaDeNegocio.General.GestionDeFechas;
using SolucionProyectoAbstracciones.AccesoADatos.Persona_Actividad.RegistrarActividadPersona;
using SolucionProyectoAbstracciones.General.GestionDeFechas;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Persona_Actividad.RegistrarActividadPersona;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using SolucionProyectoAccesoADatos.Actividad_Persona.RegistrarActividad_Persona;
using SolucionProyectoLogicaDeNegocio.General.GestionDeFechas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Persona_Actividad.RegistrarActividadPersona
{
    public class RegistrarActividadPersonaLN : IRegistrarActividadPersonaLN
    {
        private IRegistrarActividadPersonaAD _registrarActividadPersonaAD;
        private IFecha _fecha;

        public RegistrarActividadPersonaLN()
        {
            _registrarActividadPersonaAD = new RegistrarActividadPersonaAD();
            _fecha = new Fecha();
        }

        public async Task<int> RegistrarActividad(PersonaActividadDto laActividadPersonaParaGuardar, int id_Persona, int id_Actividad)
        {
            laActividadPersonaParaGuardar.FechaDeRegistro = _fecha.ObtenerFecha();

            int cantidadDeFilasAfectadas = await _registrarActividadPersonaAD.RegistrarActividad(laActividadPersonaParaGuardar, id_Persona, id_Actividad);

            return cantidadDeFilasAfectadas;
        }

        public List<PersonaActividadDto> ObtenerDisponiblesParaAgregar(int id_Persona)
        {
            List<PersonaActividadDto> disponibles = _registrarActividadPersonaAD.ObtenerDisponiblesParaAgregar(id_Persona);
            return disponibles;
        }
  }
}
