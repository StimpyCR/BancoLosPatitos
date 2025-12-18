using SolucionProyectoAbstracciones.AccesoADatos.ArchivosDeAnalisis.ListarArchivosDeAnalisis;
using SolucionProyectoAbstracciones.LogicaDeNegocio.ArchivosDeAnalisis.ListarArchivosDeAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.ArchivosDeAnalisis.ListarArchivosDeAnalisis
{
    public class ListarArchivosDeAnalisisLN: IListarArchivosDeAnalisisLN
    {

        private readonly IListarArchivosDeAnalisisAD _listarArchivosDeAnalisisAD;

        public ListarArchivosDeAnalisisLN()
        {
            _listarArchivosDeAnalisisAD = new ListarArchivosDeAnalisisAD();
        }

        public List<ArchivosDeAnalisisDto> Obtener()
        {
            List<ArchivosDeAnalisisDto> lista = _listarArchivosDeAnalisisAD.Listar();

            foreach (ArchivosDeAnalisisDto archivo in lista)
            {
                if (archivo.textoResumen.Length > 50)
                {
                    archivo.textoResumen = archivo.textoResumen.Substring(0, 50) + "...";
                }
            }

            return lista;
        }
    }
}