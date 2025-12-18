using SolucionProyectoAbstracciones.AccesoADatos.ActividadFinanciera.EditarActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.ActividadFinanciera.EditarActividadFinanciera
{
    public class EditarActividadFinancieraAD: IEditarActividadFinancieraAD
    {
        private Contexto _contexto;
        public EditarActividadFinancieraAD()
        {
            _contexto = new Contexto();
        }
        public int Editar(ActividadFinancieraDto actividadPorEditar)
        {
            int cantidadDeFilasAfectadas = 0;

            ActividadFinancieraAD actividadEnBaseDatos = _contexto.ActividadFinanciera.Where(actividadABuscar => actividadABuscar.IdActividadFinanciera == actividadPorEditar.IdActividadFinanciera).FirstOrDefault();
            if (actividadEnBaseDatos != null)
            {
                actividadEnBaseDatos.NombreActividadFinanciera = actividadPorEditar.NombreActividadFinanciera;
                actividadEnBaseDatos.DescripcionActividadFinanciera = actividadPorEditar.DescripcionActividadFinanciera;
                actividadEnBaseDatos.Estado = actividadPorEditar.Estado;
                actividadEnBaseDatos.FechaDeModificacion = DateTime.Now;
                cantidadDeFilasAfectadas = _contexto.SaveChanges();
            }
            return cantidadDeFilasAfectadas;
        }

    }
}
