using SolucionProyectoAbstracciones.LogicaDeNegocio.Bitacora.BitacoraEventos;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Bitacora.ListarBitacoraEventos;
using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using SolucionProyectoAccesoADatos.Bitacora.BitacoraEventos;
using SolucionProyectoLogicaDeNegocio.Bitacora.ListarBitacoraEventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SolucionProyectoUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BitacoraController : Controller
    {
        private readonly IListarBitacoraEventosLN _BitacoraEventosLN;

        public BitacoraController()
        {
            _BitacoraEventosLN = new ListarBitacoraEventosLN();
        }

        // GET: Bitacora
        // public ActionResult ListaDeEventos()
        //  {
        //     List<BitacoraDto> listaEventos = _BitacoraEventosLN.ObtenerEventos();
        ////
        //      return View(listaEventos);
        //  }
        public ActionResult ListaDeEventos()
        {
            List<BitacoraDto> listaEventos;

            try
            {
                // LN devuelve la lista ordenada por fecha
                listaEventos = _BitacoraEventosLN.Obtener();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "No se pudo cargar la bitácora: " + ex.Message;
                listaEventos = new List<BitacoraDto>();
            }

            return View(listaEventos);
        }

        // GET: Bitacora/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bitacora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bitacora/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bitacora/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bitacora/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bitacora/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bitacora/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
