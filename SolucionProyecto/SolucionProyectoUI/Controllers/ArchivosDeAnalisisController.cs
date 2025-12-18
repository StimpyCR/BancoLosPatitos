using SolucionProyectoAbstracciones.LogicaDeNegocio.ArchivosDeAnalisis.ListarArchivosDeAnalisis;
using SolucionProyectoAbstracciones.LogicaDeNegocio.ArchivosDeAnalisis.RegistrarNuevosArchivosDeAnalisis;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Bitacora.BitacoraEventos;
using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using SolucionProyectoAccesoADatos.ArchivosDeAnalisis.DetallesArchivosDeAnalisis;
using SolucionProyectoAccesoADatos.ArchivosDeAnalisis.ListarArchivosDeAnalisis;
using SolucionProyectoAccesoADatos.ArchivosDeAnalisis.RegistrarNuevosArchivosDeAnalisis;
using SolucionProyectoAccesoADatos.Bitacora.BitacoraEventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SolucionProyectoUI.Controllers
{
    [Authorize(Roles = "Admin,Analista")]
    public class ArchivosDeAnalisisController : Controller
    {
        private readonly IListarArchivosDeAnalisisLN _ListarArchivosDeAnalisisLN;
        private readonly IRegistrarNuevosArchivosDeAnalisisLN _RegistrarNuevosArchivosDeAnalisisLN;
        private readonly IDetallesArchivosDeAnalisisLN _DetallesArchivosDeAnalisisLN;
        private readonly IBitacoraEventosLN _bitacoraEventosLN;
        public ArchivosDeAnalisisController()
        {
            _ListarArchivosDeAnalisisLN = new ListarArchivosDeAnalisisLN();
            _RegistrarNuevosArchivosDeAnalisisLN = new RegistrarNuevosArchivosDeAnalisisLN();
            _DetallesArchivosDeAnalisisLN = new DetallesArchivosDeAnalisisLN();
            _bitacoraEventosLN = new BitacoraEventosLN();
        }
        // GET: ArchivosDeAnalisis
        public ActionResult ListarArchivosDeAnalisis()
        {
            List<ArchivosDeAnalisisDto> lista = _ListarArchivosDeAnalisisLN.Obtener();
            _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
            {
                tablaDeEvento = "ARCHIVOS_ANALISIS",
                tipoDeEvento = "CONSULTAR_LISTA",
                descripcionDeEvento = "Listado de archivos consultado"
            });
            return View(lista);
        }

        // GET: ArchivosDeAnalisis/Details/5
        public ActionResult DetallesArchivosDeAnalisis(int id)
        {
            ArchivosDeAnalisisDto archivo;

            try
            {
                archivo = _DetallesArchivosDeAnalisisLN.Obtener(id);
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ARCHIVOS_ANALISIS",
                    tipoDeEvento = "DETALLE",
                    descripcionDeEvento = $"Consulta de detalles para ID {id}"
                });
            }
            catch (System.Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ARCHIVOS_ANALISIS",
                    tipoDeEvento = "ERROR_DETALLE",
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.ToString()
                });
                TempData["Error"] = ex.Message;
                return RedirectToAction("ListarArchivosDeAnalisis");
            }

            return View(archivo);
        }

        // GET: ArchivosDeAnalisis/Create
        public ActionResult RegistrarNuevosArchivosDeAnalisis()
        {
            return View();
        }

        // POST: ArchivosDeAnalisis/Create
        [HttpPost]
        public async Task<ActionResult> RegistrarNuevosArchivosDeAnalisis(ArchivosDeAnalisisDto elArchivoParaGuardar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _RegistrarNuevosArchivosDeAnalisisLN.CrearArchivo(elArchivoParaGuardar);
                    _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                    {
                        tablaDeEvento = "ARCHIVOS_ANALISIS",
                        tipoDeEvento = "CREAR",
                        descripcionDeEvento = "Archivo de análisis creado",
                        datosPosteriores = elArchivoParaGuardar.ToString()
                    });
                    return RedirectToAction("ListarArchivosDeAnalisis");
                }

                return View(elArchivoParaGuardar);
            }
            catch (Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ARCHIVOS_ANALISIS",
                    tipoDeEvento = "ERROR_CREAR",
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.ToString()
                });
                ModelState.AddModelError("", "Error al crear el archivo: " + ex.Message);
                return View(elArchivoParaGuardar);
            }
        }

        // VISTAS PARCIALES

        // GET: ArchivosDeAnalisis/VistaParcialRegistrarArchivo
        public ActionResult VistaParcialRegistrarArchivo()
        {
            ArchivosDeAnalisisDto archivo = new ArchivosDeAnalisisDto();
            return PartialView("VistaParcialRegistrarArchivo", archivo);
        }


        // POST: ArchivosDeAnalisis/VistaParcialRegistrarArchivo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VistaParcialRegistrarArchivo(ArchivosDeAnalisisDto archivo)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("VistaParcialRegistrarArchivo", archivo);
            }

            try
            {
                int idGenerado = await _RegistrarNuevosArchivosDeAnalisisLN.CrearArchivo(archivo);

                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ARCHIVO_ANALISIS",
                    tipoDeEvento = "CREAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = "Archivo de análisis creado correctamente",
                    datosPosteriores = archivo.ToString()
                });

                return Json(new
                {
                    success = true,
                    message = "Archivo registrado correctamente.",
                    
                    id = idGenerado,
                    nombreArchivo = archivo.nombre,
                    fuenteArchivo = archivo.fuente,
                    fechaDeRegistroArchivo = archivo.fechaDeRegistro
                });
            }
            catch (InvalidOperationException ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ARCHIVO_ANALISIS",
                    tipoDeEvento = "ERROR_CREAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.StackTrace
                });

                ModelState.AddModelError("", ex.Message);

                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ARCHIVO_ANALISIS",
                    tipoDeEvento = "ERROR_CREAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = "Error inesperado al crear archivo de análisis",
                    stackTrace = ex.ToString()
                });

                ModelState.AddModelError("", "Error al registrar el archivo: " + ex.Message);

                return Json(new
                {
                    success = false,
                    message = "Error al registrar el archivo: " + ex.Message
                });
            }
        }

        // GET: ArchivosDeAnalisis/VistaParcialDetallesArchivo?id=5
        public ActionResult VistaParcialDetallesArchivo(int id)
        {
            try
            {
                ArchivosDeAnalisisDto archivo = _DetallesArchivosDeAnalisisLN.Obtener(id);

                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ARCHIVO_ANALISIS",
                    tipoDeEvento = "DETALLE",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = $"Consulta de detalles para el archivo con ID: {id}",
                    datosPosteriores = $"ID: {id}"
                });

                return PartialView("VistaParcialDetallesArchivo", archivo);
            }
            catch (Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ARCHIVO_ANALISIS",
                    tipoDeEvento = "ERROR_DETALLE",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.ToString()
                });

                ViewBag.Error = "No se pudieron cargar los detalles: " + ex.Message;
                return PartialView("_ErrorPartial");
            }
        }


        // GET: ArchivosDeAnalisis/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArchivosDeAnalisis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ARCHIVOS_ANALISIS",
                    tipoDeEvento = "EDITAR",
                    descripcionDeEvento = $"Archivo editado (ID {id})",
                    datosPosteriores = collection.ToString()
                });

                return RedirectToAction("Index");
            }
            catch
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ARCHIVOS_ANALISIS",
                    tipoDeEvento = "ERROR_EDITAR",
                    descripcionDeEvento = "",
                    stackTrace = ""
                });

                return View();
            }
        }

        // GET: ArchivosDeAnalisis/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArchivosDeAnalisis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ARCHIVOS_ANALISIS",
                    tipoDeEvento = "ELIMINAR",
                    descripcionDeEvento = $"Archivo eliminado (ID {id})"
                });

                return RedirectToAction("Index");
            }
            catch
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ARCHIVOS_ANALISIS",
                    tipoDeEvento = "ERROR_ELIMINAR",
                    descripcionDeEvento = "",
                    stackTrace = ""
                });
                return View();
            }
        }
    }
}
