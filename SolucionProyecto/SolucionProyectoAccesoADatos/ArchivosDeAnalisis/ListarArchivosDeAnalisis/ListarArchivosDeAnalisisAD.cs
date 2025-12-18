using SolucionProyectoAbstracciones.AccesoADatos.ArchivosDeAnalisis.ListarArchivosDeAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.ArchivosDeAnalisis.ListarArchivosDeAnalisis
{
    public class ListarArchivosDeAnalisisAD: IListarArchivosDeAnalisisAD
    {
        private Contexto _elContexto;

        public ListarArchivosDeAnalisisAD()
        {
            _elContexto = new Contexto();
        }

        public List<ArchivosDeAnalisisDto> Listar()
        {
            List<ArchivosDeAnalisisDto> lista = (from archivo in _elContexto.ArchivosDeAnalisis
                                                 select new ArchivosDeAnalisisDto
                                                {
                                                     IdArchivo = archivo.idArchivo,
                                                     nombre = archivo.nombre,
                                                    textoResumen = archivo.textoDelArchivo.Substring(0, 50),
                                                    fuente = archivo.fuente,
                                                    fechaDeRegistro = archivo.fechaDeRegistro
                                                }).ToList();
            return lista;
        }
    }
}