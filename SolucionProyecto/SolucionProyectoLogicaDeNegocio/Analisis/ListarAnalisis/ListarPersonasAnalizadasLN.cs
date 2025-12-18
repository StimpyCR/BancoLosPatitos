using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ListarAnalisis;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ListarAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.Analisis;
using SolucionProyectoAccesoADatos.Analisis.ListarAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.Analisis.ListarAnalisis
{
    public class ListarPersonasAnalizadasLN : IListarPersonasAnalizadasLN
    {
        private readonly IListarPersonasAnalizadasAD _ad;

        public ListarPersonasAnalizadasLN()
        {
            _ad = new ListarPersonasAnalizadasAD(); 
        }

        public List<PersonaAnalizadaDto> Obtener()
        {
            return _ad.Obtener();
        }
    }
}