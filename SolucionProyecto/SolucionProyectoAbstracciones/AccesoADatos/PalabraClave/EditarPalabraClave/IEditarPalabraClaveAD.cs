using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.PalabraClave.EditarPalabraClave
{
    public interface IEditarPalabraClaveAD
    {
        int Editar(PalabraClaveDto palabraPorEditar);
        bool ExisteOtraPalabra(string palabra, int idPalabra);
    }
}
