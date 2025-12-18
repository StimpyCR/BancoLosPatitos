using SolucionProyectoAbstracciones.ModelosParaUI.Analisis;
using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.Analisis.RealizarAnalisis
{
    public interface IRealizarAnalisisAD
    {
        void RegistrarAnalisis(AnalisisDto analisis);
    }
}
