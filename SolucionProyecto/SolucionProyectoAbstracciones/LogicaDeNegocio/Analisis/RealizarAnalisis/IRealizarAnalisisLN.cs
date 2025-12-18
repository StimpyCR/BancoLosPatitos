using SolucionProyectoAbstracciones.ModelosParaUI.Analisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SolucionProyectoAbstracciones.ModelosParaUI.Analisis.AnalisisRequestDto;

namespace SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.RealizarAnalisis
{
    public interface IRealizarAnalisisLN
    {
        AnalisisDto RealizarAnalisis(int idPersona);
    }
}