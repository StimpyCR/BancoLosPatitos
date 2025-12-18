using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerArchivos
{
    public interface IObtenerArchivosLN
    {
        List<ArchivosDeAnalisisDto> ObtenerDisponibles(int idPersona);
    }
}
