using SolucionProyectoAbstracciones.LogicaDeNegocio.ActividadFinanciera.EditarActividadFinanciera;
using SolucionProyectoAbstracciones.LogicaDeNegocio.ActividadFinanciera.ListaActividadFinanciera;
using SolucionProyectoAbstracciones.LogicaDeNegocio.ActividadFinanciera.RegistrarActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Bitacora.BitacoraEventos;
using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using SolucionProyectoLogicaDeNegocio.ActividadFinanciera.EditarActividadFinanciera;
using SolucionProyectoLogicaDeNegocio.ActividadFinanciera.ListaActividadFinanciera;
using SolucionProyectoLogicaDeNegocio.ActividadFinanciera.RegistrarActividadFinanciera;
using SolucionProyectoAccesoADatos.Bitacora.BitacoraEventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SolucionProyectoUI.Controllers
{
    [Authorize(Roles = "Admin,Analista")]
    public class ActividadFinancieraController : Controller
    {
        private readonly IRegistrarActividadFinancieraLN _registrarActividadFinancieraLN;
        private readonly IObtenerListaDeActividadFinancieraLN _obtenerListaDeActividadFinancieraLN;
        private readonly IEditarActividadFinancieraLN _editarActividadFinancieraLN;
        private readonly IBitacoraEventosLN _bitacoraEventosLN;

        public ActividadFinancieraController()
        {
            _obtenerListaDeActividadFinancieraLN = new ObtenerListaDeActividadFinancieraLN();
            _registrarActividadFinancieraLN = new RegistrarActividadFinancieraLN();
            _editarActividadFinancieraLN = new EditarActividadFinancieraLN();
            _bitacoraEventosLN = new BitacoraEventosLN();
        }

        // GET: ActividadFinanciera
        public ActionResult ListaDeActividadFinanciera()
        {
            List<ActividadFinancieraDto> laListaDeActividadFinanciera = _obtenerListaDeActividadFinancieraLN.Obtener();
            _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
            {
                tablaDeEvento = "ACTIVIDAD_FINANCIERA",
                tipoDeEvento = "CONSULTAR_LISTA",
                descripcionDeEvento = "Consulta de lista realizada",
            });
            return View(laListaDeActividadFinanciera);
        }

        // GET: ActividadFinanciera/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActividadFinanciera/Create
        public ActionResult RegistrarActividad()
        {
            return View();
        }

        // POST: ActividadFinanciera/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegistrarActividad(ActividadFinancieraDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                int filas = await _registrarActividadFinancieraLN.RegistrarActividadFinanciera(model);

                if (filas > 0)
                {
                    _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                    {
                        tablaDeEvento = "ACTIVIDAD_FINANCIERA",
                        tipoDeEvento = "CREAR",
                        descripcionDeEvento = "Se ejecutó la creación de actividad financiera",
                        datosPosteriores = $"Nombre:{model.NombreActividadFinanciera};Descripcion:{model.DescripcionActividadFinanciera};NivelRiesgo:{model.NivelDeRiesgo}"
                    });

                    TempData["Mensaje"] = "Actividad financiera registrada correctamente.";
                    return RedirectToAction("ListaDeActividadFinanciera");
                }

                ModelState.AddModelError("", "Ya existe una actividad con ese nombre o no se pudo registrar.");
                return View(model);
            }
            catch (Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ACTIVIDAD_FINANCIERA",
                    tipoDeEvento = "ERROR_CREAR",
                    descripcionDeEvento = "Error al registrar actividad financiera",
                    stackTrace = ex.ToString()
                });

                ModelState.AddModelError("", "Error al registrar. Intente nuevamente.");
                return View(model);
            }
        }

        // GET: ActividadFinanciera/Editar/5
        public ActionResult Editar(int id)
        {
            List<ActividadFinancieraDto> laListaDeActividades = _obtenerListaDeActividadFinancieraLN.Obtener();
            ActividadFinancieraDto actividadAEditar = laListaDeActividades.FirstOrDefault(a => a.IdActividadFinanciera == id);

            if (actividadAEditar == null)
            {
                return HttpNotFound();
            }

            return View(actividadAEditar);
        }

        // POST: ActividadFinanciera/Editar
        [HttpPost]
        [ActionName("Editar")]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPost(ActividadFinancieraDto model)
        {
            if (!ModelState.IsValid)
                return View("Editar", model);

            try
            {
                int filas = _editarActividadFinancieraLN.Editar(model);

                if (filas > 0)
                {
                    _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                    {
                        tablaDeEvento = "ACTIVIDAD_FINANCIERA",
                        tipoDeEvento = "EDITAR",
                        descripcionDeEvento = $"Edición ejecutada para ID {model.IdActividadFinanciera}",
                        datosPosteriores = $"Nombre:{model.NombreActividadFinanciera};Descripcion:{model.DescripcionActividadFinanciera};Estado:{model.Estado}"
                    });

                    TempData["Mensaje"] = "Actividad financiera actualizada correctamente.";
                    return RedirectToAction("ListaDeActividadFinanciera");
                }

                ModelState.AddModelError("", "No se pudo actualizar la actividad financiera.");
                return View("Editar", model);
            }
            catch (Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ACTIVIDAD_FINANCIERA",
                    tipoDeEvento = "ERROR_EDITAR",
                    descripcionDeEvento = "Error al editar actividad financiera",
                    stackTrace = ex.ToString()
                });

                ModelState.AddModelError("", "Error al editar. Intente nuevamente.");
                return View("Editar", model);
            }
        }

        // [VISTAS PARCIALES] 

        // GET: ActividadFinanciera/VistaParcialRegistrarActividad
        public ActionResult VistaParcialRegistrarActividad()
        {
            ActividadFinancieraDto model = new ActividadFinancieraDto();
            return PartialView("VistaParcialRegistrarActividad", model);
        }

        // POST: ActividadFinanciera/VistaParcialRegistrarActividad
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VistaParcialRegistrarActividad(ActividadFinancieraDto model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("VistaParcialRegistrarActividad", model);
            }

            try
            {
                int filas = await _registrarActividadFinancieraLN.RegistrarActividadFinanciera(model);

                if (filas > 0)
                {
                    _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                    {
                        tablaDeEvento = "ACTIVIDAD_FINANCIERA",
                        tipoDeEvento = "CREAR",
                        descripcionDeEvento = "Se ejecutó la creación de actividad financiera",
                        datosPosteriores =
                            $"Nombre:{model.NombreActividadFinanciera};" +
                            $"Descripcion:{model.DescripcionActividadFinanciera};" +
                            $"NivelRiesgo:{model.NivelDeRiesgo}"
                    });

                    return Json(new
                    {
                        success = true,
                        message = "Actividad financiera registrada correctamente."
                    });
                }

                ModelState.AddModelError("",
                    "Ya existe una actividad con ese nombre o no se pudo registrar.");
                return PartialView("VistaParcialRegistrarActividad", model);
            }
            catch (Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ACTIVIDAD_FINANCIERA",
                    tipoDeEvento = "ERROR_CREAR",
                    descripcionDeEvento = "Error al registrar actividad financiera",
                    stackTrace = ex.ToString()
                });

                return Json(new
                {
                    success = false,
                    message = "Error al registrar la actividad financiera. Intente nuevamente."
                });
            }
        }

        // GET: ActividadFinanciera/VistaParcialEditarActividad/5
        public ActionResult VistaParcialEditarActividad(int id)
        {
            List<ActividadFinancieraDto> laListaDeActividades =
                _obtenerListaDeActividadFinancieraLN.Obtener();

            ActividadFinancieraDto actividadAEditar =
                laListaDeActividades.FirstOrDefault(a => a.IdActividadFinanciera == id);

            if (actividadAEditar == null)
            {
                return HttpNotFound();
            }

            return PartialView("VistaParcialEditarActividad", actividadAEditar);
        }

        // POST: ActividadFinanciera/VistaParcialEditarActividad
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VistaParcialEditarActividad(ActividadFinancieraDto model)
        {
            ModelState.Remove("NivelDeRiesgo");

            if (!ModelState.IsValid)
            {
                return PartialView("VistaParcialEditarActividad", model);
            }

            try
            {
                int filas = _editarActividadFinancieraLN.Editar(model);

                if (filas > 0)
                {
                    _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                    {
                        tablaDeEvento = "ACTIVIDAD_FINANCIERA",
                        tipoDeEvento = "EDITAR",
                        descripcionDeEvento = $"Edición ejecutada para ID {model.IdActividadFinanciera}",
                        datosPosteriores =
                            $"Nombre:{model.NombreActividadFinanciera};" +
                            $"Descripcion:{model.DescripcionActividadFinanciera};" +
                            $"Estado:{model.Estado}"
                    });

                    return Json(new
                    {
                        success = true,
                        message = "Actividad financiera actualizada correctamente."
                    });
                }

                ModelState.AddModelError("",
                    "No se pudo actualizar la actividad financiera.");
                return PartialView("VistaParcialEditarActividad", model);
            }
            catch (Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ACTIVIDAD_FINANCIERA",
                    tipoDeEvento = "ERROR_EDITAR",
                    descripcionDeEvento = "Error al editar actividad financiera",
                    stackTrace = ex.ToString()
                });

                return Json(new
                {
                    success = false,
                    message = "Error al editar la actividad financiera. Intente nuevamente."
                });
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////

        // GET: ActividadFinanciera/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActividadFinanciera/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // Si existe un servicio de eliminación, invócalo aquí.
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ACTIVIDAD_FINANCIERA",
                    tipoDeEvento = "ELIMINAR",
                    descripcionDeEvento = $"Eliminación ejecutada para ID {id}"
                });

                return RedirectToAction("ListaDeActividadFinanciera");
            }
            catch (Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ACTIVIDAD_FINANCIERA",
                    tipoDeEvento = "ERROR_ELIMINAR",
                    descripcionDeEvento = "Error al eliminar actividad financiera",
                    stackTrace = ex.ToString()
                });

                ModelState.AddModelError("", "Error al eliminar. Intente nuevamente.");
                return View();
            }
        }
    }
}