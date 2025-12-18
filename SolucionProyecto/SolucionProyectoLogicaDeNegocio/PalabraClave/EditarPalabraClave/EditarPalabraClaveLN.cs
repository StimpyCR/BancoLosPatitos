using SolucionProyectoAbstracciones.AccesoADatos.PalabraClave.EditarPalabraClave;
using SolucionProyectoAbstracciones.General.GestionDeFechas;
using SolucionProyectoAbstracciones.LogicaDeNegocio.PalabraClave.EditarPalabraClave;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using SolucionProyectoAccesoADatos.PalabraClave.EditarPalabraClave;
using SolucionProyectoLogicaDeNegocio.General.GestionDeFechas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoLogicaDeNegocio.PalabraClave.EditarPalabraClave
{
    public class EditarPalabraClaveLN : IEditarPalabraClaveLN
    {
        private IEditarPalabraClaveAD _editarPalabraClaveAD;

        private IFecha _fecha;
        public EditarPalabraClaveLN()
        {
            _editarPalabraClaveAD = new EditarPalabraClaveAD();
            _fecha = new Fecha();
        }

        public int Editar(PalabraClaveDto palabraPorEditar)
        {
            bool existe = _editarPalabraClaveAD.ExisteOtraPalabra(
            palabraPorEditar.Palabra,
           palabraPorEditar.IdPalabra
             );
            if (existe)
            {
                throw new InvalidOperationException(
                    $"Ya existe otra palabra clave con el nombre '{palabraPorEditar.Palabra}'."
                );
            }
            palabraPorEditar.FechaDeModificacion = _fecha.ObtenerFecha();           
            int cantidadDeFilasAfectadas = _editarPalabraClaveAD.Editar(palabraPorEditar);
            return cantidadDeFilasAfectadas;
        }
    }
}
