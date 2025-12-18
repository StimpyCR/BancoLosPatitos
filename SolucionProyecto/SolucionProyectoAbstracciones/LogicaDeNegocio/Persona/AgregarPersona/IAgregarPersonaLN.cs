using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Persona.AgregarPersona
{
    public  interface IAgregarPersonaLN
    {
        Task<int> Agregar(PersonaDto laPersonaParaGuardar);
    }
}
