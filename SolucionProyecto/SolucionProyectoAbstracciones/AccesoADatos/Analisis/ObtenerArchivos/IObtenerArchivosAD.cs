using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerArchivos
{
    public interface IObtenerArchivosAD
    {
        List<ArchivosDeAnalisisDto> ObtenerDisponibles(int idPersona);
    }
}
