using SolucionProyectoAbstracciones.AccesoADatos.ArchivosDeAnalisis.RegistrarNuevosArchivosDeAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SolucionProyectoAccesoADatos.ArchivosDeAnalisis.RegistrarNuevosArchivosDeAnalisis
{
    public class RegistrarNuevosArchivosDeAnalisisAD : IRegistrarNuevosArchivosDeAnalisisAD
    {
        private readonly Contexto _elContexto;

        public RegistrarNuevosArchivosDeAnalisisAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Crear(ArchivosDeAnalisisDto elArchivoParaGuardar)
        {
            ArchivosDeAnalisisAD elArchivoEnEntidad = ConvierteObjetoAEntidad(elArchivoParaGuardar);
            _elContexto.ArchivosDeAnalisis.Add(elArchivoEnEntidad);

            return await _elContexto.SaveChangesAsync();
        }

        private ArchivosDeAnalisisAD ConvierteObjetoAEntidad(ArchivosDeAnalisisDto elArchivoParaGuardar)
        {
            return new ArchivosDeAnalisisAD
            {
                nombre = elArchivoParaGuardar.nombre,
                textoDelArchivo = elArchivoParaGuardar.textoResumen,
                fuente = elArchivoParaGuardar.fuente,
                fechaDeRegistro = elArchivoParaGuardar.fechaDeRegistro
            };
        }
    }
}