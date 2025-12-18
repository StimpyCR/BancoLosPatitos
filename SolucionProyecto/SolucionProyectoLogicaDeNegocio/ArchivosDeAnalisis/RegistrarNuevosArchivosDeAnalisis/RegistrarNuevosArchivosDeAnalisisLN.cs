using SolucionProyectoAbstracciones.AccesoADatos.ArchivosDeAnalisis.RegistrarNuevosArchivosDeAnalisis;
using SolucionProyectoAbstracciones.LogicaDeNegocio.ArchivosDeAnalisis.RegistrarNuevosArchivosDeAnalisis;
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
    public class RegistrarNuevosArchivosDeAnalisisLN : IRegistrarNuevosArchivosDeAnalisisLN
    {
        private readonly IRegistrarNuevosArchivosDeAnalisisAD _RegistrarNuevosArchivosDeAnalisisAD;

        public RegistrarNuevosArchivosDeAnalisisLN()
        {
            _RegistrarNuevosArchivosDeAnalisisAD = new RegistrarNuevosArchivosDeAnalisisAD();
        }

        public async Task<int> CrearArchivo(ArchivosDeAnalisisDto elArchivoParaGuardar)
        {
            if (string.IsNullOrWhiteSpace(elArchivoParaGuardar.nombre))
            {
                throw new ArgumentException("El nombre del archivo no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(elArchivoParaGuardar.textoResumen))
            {
                throw new ArgumentException("El texto del archivo no puede estar vacío.");
            }

            if (elArchivoParaGuardar.fechaDeRegistro == default(DateTime))
            {
                elArchivoParaGuardar.fechaDeRegistro = DateTime.Now;
            }

            return await _RegistrarNuevosArchivosDeAnalisisAD.Crear(elArchivoParaGuardar);
        }
    }
}