using SolucionProyectoAbstracciones.AccesoADatos.PalabraClave.AgregarPalabraClave;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.PalabraClave.AgregarPalabraClave
{
    public class AgregarPalabraClaveAD : IAgregarPalabraClaveAD
    {
        private Contexto _contexto;
        public AgregarPalabraClaveAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> Agregar(PalabraClaveDto PalabraPorAgregar)
        { 
            int cantidadDeFilasAfectadas = 0;

            PalabraClaveAD palabraEnEntidad = ConvierteObjetoAEntidad(PalabraPorAgregar);

            _contexto.PalabraClave.Add(palabraEnEntidad);
            cantidadDeFilasAfectadas = await _contexto.SaveChangesAsync();
            return cantidadDeFilasAfectadas;
        }
        private PalabraClaveAD ConvierteObjetoAEntidad(PalabraClaveDto palabra)
        {
            PalabraClaveAD palabraEnEntidad = new PalabraClaveAD
            {
                IdPalabra = palabra.IdPalabra,
                Palabra = palabra.Palabra,
                Orden = palabra.Orden,
                FechaDeRegistro = palabra.FechaDeRegistro,
                FechaDeModificacion = palabra.FechaDeModificacion,
                Estado = palabra.Estado
            };
            return palabraEnEntidad;
        }
        public bool ExistePalabra(string palabra)
        {
            return _contexto.PalabraClave
                .Any(p => p.Palabra.ToLower() == palabra.ToLower()
                       && p.Estado == true);
        }
    }
}
