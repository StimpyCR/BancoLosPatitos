using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAbstracciones.AccesoADatos.PalabraClave.AgregarPalabraClave
{
    public interface IAgregarPalabraClaveAD
    {
        Task<int> Agregar(PalabraClaveDto PalabraPorAgregar);
        bool ExistePalabra(string palabra);
    }
}
