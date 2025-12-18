using SolucionProyectoAbstracciones.ModelosParaUI.Analisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ListarAnalisis
{
    public interface IListarAnalisisLN
    {
        List<AnalisisDto> Obtener();
    }
}
