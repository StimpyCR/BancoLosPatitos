using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ListarAnalisis;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ListarAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.Analisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Analisis.ListarAnalisis
{
    public class ListarAnalisisLN : IListarAnalisisLN
    {
        private readonly IListarAnalisisAD _listarAnalisisAD;

        public ListarAnalisisLN(IListarAnalisisAD listarAnalisisAD)
        {
            _listarAnalisisAD = listarAnalisisAD;
        }

        public List<AnalisisDto> Obtener()
        {
            List<AnalisisDto> lista = _listarAnalisisAD.Obtener();

            return lista; 
        }
    }
}