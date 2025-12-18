using SolucionProyectoAbstracciones.ModelosParaUI.Analisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SolucionProyectoAbstracciones.AccesoADatos.Analisis.ListarAnalisis
{
    public interface IListarAnalisisAD
    {
        List<AnalisisDto> Obtener();
    }
}
