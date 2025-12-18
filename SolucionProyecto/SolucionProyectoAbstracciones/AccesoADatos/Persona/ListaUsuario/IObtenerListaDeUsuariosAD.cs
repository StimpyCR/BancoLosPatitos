using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.Persona.ListaPersonas
{
    public interface IObtenerListaDeUsuariosAD
    {
        List<PersonaDto> Obtener();
    }
}
