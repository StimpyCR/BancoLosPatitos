using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.Persona_Actividad.RegistrarActividadPersona
{
    public interface IRegistrarActividadPersonaAD
    {
        Task <int> RegistrarActividad(PersonaActividadDto laActividadPersonaParaGuardar, int id_Usuario, int id_ActividadFinanciera);
        List<PersonaActividadDto> ObtenerDisponiblesParaAgregar(int id_Persona);
    }
}
