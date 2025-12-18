using SolucionProyectoAbstracciones.AccesoADatos.PalabraClave.AgregarPalabraClave;
using SolucionProyectoAbstracciones.General.GestionDeFechas;
using SolucionProyectoAbstracciones.LogicaDeNegocio.PalabraClave.AgregarPalabraClave;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using SolucionProyectoAccesoADatos.PalabraClave.AgregarPalabraClave;
using SolucionProyectoLogicaDeNegocio.General.GestionDeFechas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.PalabraClave.AgregarPalabraClave
{
    public class AgregarPalabraClaveLN : IAgregarPalabraClaveLN
    {
        private IAgregarPalabraClaveAD _agregarPalabraClaveAD;
        private IFecha _fecha;

        public AgregarPalabraClaveLN()
        { 
            _agregarPalabraClaveAD =  new AgregarPalabraClaveAD();
            _fecha = new Fecha();   
        }

        public async Task<int> Agregar(PalabraClaveDto PalabraPorAgregar)
        {
            bool existe = _agregarPalabraClaveAD.ExistePalabra(PalabraPorAgregar.Palabra);

            if (existe)
            {
                throw new InvalidOperationException(
                    $"La palabra clave '{PalabraPorAgregar.Palabra}' ya existe."
                );
            }

            PalabraPorAgregar.FechaDeRegistro = _fecha.ObtenerFecha();
            PalabraPorAgregar.FechaDeModificacion = null;
            PalabraPorAgregar.Estado = true;

            int cantidadDeFilasAfectadas = await _agregarPalabraClaveAD.Agregar(PalabraPorAgregar);
            return cantidadDeFilasAfectadas;
        }
    }
}
