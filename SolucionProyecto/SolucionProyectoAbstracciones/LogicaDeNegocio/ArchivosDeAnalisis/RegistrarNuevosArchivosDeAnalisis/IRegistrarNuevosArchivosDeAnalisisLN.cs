using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.ArchivosDeAnalisis.RegistrarNuevosArchivosDeAnalisis
{
    public interface IRegistrarNuevosArchivosDeAnalisisLN
    {
        Task<int> CrearArchivo(ArchivosDeAnalisisDto elArchivoParaGuardar);
    }
}