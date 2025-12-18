using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.ArchivosDeAnalisis.RegistrarNuevosArchivosDeAnalisis
{
    public interface IRegistrarNuevosArchivosDeAnalisisAD
    {
        Task<int> Crear(ArchivosDeAnalisisDto elArchivoParaGuardar);
    }
}