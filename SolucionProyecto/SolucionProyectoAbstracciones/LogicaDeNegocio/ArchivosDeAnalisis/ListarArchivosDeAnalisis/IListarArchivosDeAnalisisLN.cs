using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.ArchivosDeAnalisis.ListarArchivosDeAnalisis
{
    public interface IListarArchivosDeAnalisisLN
    {
        List<ArchivosDeAnalisisDto> Obtener();
    }
}
