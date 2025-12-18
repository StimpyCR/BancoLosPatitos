using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.ArchivosDeAnalisis.DetallesArchivosDeAnalisis
{
    public interface IDetallesArchivosDeAnalisisAD
    {
        ArchivosDeAnalisisDto Obtener(int idArchivo);


    }
}