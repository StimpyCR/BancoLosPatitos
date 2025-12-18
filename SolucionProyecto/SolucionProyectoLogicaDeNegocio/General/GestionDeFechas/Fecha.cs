using SolucionProyectoAbstracciones.General.GestionDeFechas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.General.GestionDeFechas
{
    public class Fecha: IFecha
    {
        public DateTime ObtenerFecha()
        {
            int zonaHorario = int.Parse(ConfigurationManager.AppSettings["zonaHoraria"]);
            return DateTime.UtcNow.AddHours(zonaHorario);
        }
    }
}
