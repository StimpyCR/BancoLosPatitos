using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Persona_Actividad.RegistrarActividadPersona
{
    public interface IRegistrarActividadPersonaLN
    {
        Task <int> RegistrarActividad (PersonaActividadDto laActividadPersonaParaGuardarint, int id_Persona, int id_Actividad);
        List<PersonaActividadDto> ObtenerDisponiblesParaAgregar(int id_Persona);
    }
}
