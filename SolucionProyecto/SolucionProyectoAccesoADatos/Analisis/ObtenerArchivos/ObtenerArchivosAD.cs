using SolucionProyectoAbstracciones.AccesoADatos.Analisis.ObtenerArchivos;
using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using SolucionProyectoAccesoADatos.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Analisis.ObtenerArchivos
{
    public class ObtenerArchivosAD: IObtenerArchivosAD
    {
        private Contexto _elContexto;
        public ObtenerArchivosAD()
        {
            _elContexto = new Contexto();
        }
        public List<ArchivosDeAnalisisDto> ObtenerDisponibles(int idPersona)
{
            var persona = _elContexto.persona.FirstOrDefault(p => p.IdPersona == idPersona);
            if (persona == null)
                return new List<ArchivosDeAnalisisDto>();

            bool esFisica = persona.tipoIdentificacion == 1;

            string nombre = persona.Nombre.ToLower();
            string apellido1 = (persona.primerApellido ?? string.Empty).ToLower();
            string apellido2 = (persona.segundoApellido ?? string.Empty).ToLower();
            string identificacion = persona.identificacion.ToString();

            List<ArchivosDeAnalisisDto> laListaArchivos =
                (from a in _elContexto.ArchivosDeAnalisis
                 where
                 (
                     esFisica &&
                     (
                         a.textoDelArchivo.ToLower().Contains(nombre) ||
                         a.textoDelArchivo.ToLower().Contains(apellido1) ||
                         a.textoDelArchivo.ToLower().Contains(apellido2) ||
                         a.textoDelArchivo.Contains(identificacion)
                     )
                 )
                 ||
                 (
                     !esFisica &&
                     (
                         a.textoDelArchivo.ToLower().Contains(nombre) ||
                         a.textoDelArchivo.Contains(identificacion)
                     )
                 )
                 select new ArchivosDeAnalisisDto
                 {
                     IdArchivo = a.idArchivo,
                     nombre = a.nombre,
                     textoResumen = a.textoDelArchivo,
                     fuente = a.fuente,
                     fechaDeRegistro = a.fechaDeRegistro
                 }).ToList();

            return laListaArchivos;
        }
    }
}
