using SolucionProyectoAbstracciones.AccesoADatos.PalabraClave.EditarPalabraClave;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.PalabraClave.EditarPalabraClave
{
    public class EditarPalabraClaveAD : IEditarPalabraClaveAD
    {
        private Contexto _contexto;
        public EditarPalabraClaveAD()
        {
            _contexto = new Contexto();
        }
        public int Editar(PalabraClaveDto palabraPorEditar)
        { 
            int cantidadDeFilasAfectadas = 0;

            PalabraClaveAD palabraEnBaseDatps = _contexto.PalabraClave.Where(palabraABuscar => palabraABuscar.IdPalabra == palabraPorEditar.IdPalabra).FirstOrDefault();
            if (palabraEnBaseDatps != null)
            {
                palabraEnBaseDatps.Palabra = palabraPorEditar.Palabra;
                palabraEnBaseDatps.Orden = palabraPorEditar.Orden;
                palabraEnBaseDatps.FechaDeModificacion = DateTime.Now;
                palabraEnBaseDatps.Estado = palabraPorEditar.Estado;
                cantidadDeFilasAfectadas = _contexto.SaveChanges();
            }
            return cantidadDeFilasAfectadas;
        }
        public bool ExisteOtraPalabra(string palabra, int idPalabra)
        {
            return _contexto.PalabraClave
                .Any(p => p.Palabra.ToLower() == palabra.ToLower()
                       && p.IdPalabra != idPalabra
                       && p.Estado == true);
        }
    }
}
