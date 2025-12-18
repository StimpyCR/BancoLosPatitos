using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.ArchivosDeAnalisis.DetallesArchivosDeAnalisis
{
    public class DetallesArchivosDeAnalisisAD : IDetallesArchivosDeAnalisisAD
    {
        private readonly Contexto _contexto;

        public DetallesArchivosDeAnalisisAD()
        {
            _contexto = new Contexto();
        }

        public ArchivosDeAnalisisDto Obtener(int idArchivo)
        {
            ArchivosDeAnalisisDto archivo = _contexto.ArchivosDeAnalisis
                .Where(a => a.idArchivo == idArchivo)
                .Select(a => new ArchivosDeAnalisisDto
                {
                    IdArchivo = a.idArchivo,
                    nombre = a.nombre,
                    textoResumen = a.textoDelArchivo,
                    fuente = a.fuente,
                    fechaDeRegistro = a.fechaDeRegistro
                })
                .FirstOrDefault();

            return archivo;
        }
    }
}