using SolucionProyectoAbstracciones.LogicaDeNegocio.Bitacora.BitacoraEventos;
using SolucionProyectoAbstracciones.LogicaDeNegocio.PalabraClave.AgregarPalabraClave;
using SolucionProyectoAbstracciones.LogicaDeNegocio.PalabraClave.EditarPalabraClave;
using SolucionProyectoAbstracciones.LogicaDeNegocio.PalabraClave.ListarPalabraClave;
using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using SolucionProyectoAccesoADatos.Bitacora.BitacoraEventos;
using SolucionProyectoLogicaDeNegocio.PalabraClave.AgregarPalabraClave;
using SolucionProyectoLogicaDeNegocio.PalabraClave.EditarPalabraClave;
using SolucionProyectoLogicaDeNegocio.PalabraClave.ListarPalabraClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SolucionProyectoUI.Controllers
{
    [Authorize(Roles = "Admin,Analista")]
    public class PalabraClaveController : Controller
    {
        private readonly IListarPalabraClaveLN _listarPalabraClaveLN;
        private readonly IAgregarPalabraClaveLN _agregarPalabraClaveLN;
        private readonly IEditarPalabraClaveLN _editarPalabraClaveLN;
        private readonly IBitacoraEventosLN _bitacoraEventosLN; public PalabraClaveController()
        {
            _listarPalabraClaveLN = new ListarPalabraClaveLN();
            _agregarPalabraClaveLN = new AgregarPalabraClaveLN();
            _editarPalabraClaveLN = new EditarPalabraClaveLN();
            _bitacoraEventosLN = new BitacoraEventosLN();
        }
        // GET: PalabraClave
        public ActionResult ListaDePalabrasClaves()
        {
            List <PalabraClaveDto> laListaDePalabrasClaves = _listarPalabraClaveLN.Obtener();
            _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
            {
                tablaDeEvento = "PALABRA_CLAVE",
                tipoDeEvento = "CONSULTAR_LISTA",
                descripcionDeEvento = "Consulta de lista de palabras clave"
            });
            return View(laListaDePalabrasClaves);
        }

        // GET: PalabraClave/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PalabraClave/Create
        public ActionResult Agregar()
        {
            return View();
        }

        // POST: PalabraClave/Create
        [HttpPost]
        public async Task<ActionResult> Agregar(PalabraClaveDto PalabraPorAgregar)
        {
            try
            {
                int cantidadDeFilasAfectadas = await _agregarPalabraClaveLN.Agregar(PalabraPorAgregar);
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "PALABRA_CLAVE",
                    tipoDeEvento = "CREAR",
                    descripcionDeEvento = $"Creación de palabra clave '{PalabraPorAgregar.Palabra}'",
                    datosPosteriores = PalabraPorAgregar.ToString()
                });
                return RedirectToAction("ListaDePalabrasClaves");
            }
            catch (Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "PALABRA_CLAVE",
                    tipoDeEvento = "ERROR_CREAR",
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.ToString()
                });

                return View();
            }
        }

        // GET: PalabraClave/Edit/5
        public ActionResult Editar(int id)
        {
            List<PalabraClaveDto> laListaDePalabrasClaves = _listarPalabraClaveLN.Obtener();
            PalabraClaveDto palabraAEditar = laListaDePalabrasClaves.FirstOrDefault(p => p.IdPalabra == id);
            return View(palabraAEditar);
        }

        // POST: PalabraClave/Edit/5
        [HttpPost]
        public ActionResult Editar(PalabraClaveDto palabraPorEditar)
        {
            try
            {
                int cantidadDeFilasAfectadas = _editarPalabraClaveLN.Editar(palabraPorEditar);
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "PALABRA_CLAVE",
                    tipoDeEvento = "EDITAR",
                    descripcionDeEvento = $"Edición de palabra clave '{palabraPorEditar.Palabra}'",
                    datosPosteriores = palabraPorEditar.ToString()
                });
                return RedirectToAction("ListaDePalabrasClaves");
            }
            catch (Exception ex)
            {
                // >>> REGISTRO DE ERROR
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "PALABRA_CLAVE",
                    tipoDeEvento = "ERROR_EDITAR",
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.ToString()
                });
                return View();
            }
        }

        // [VISTAS PARCIALES]

        // GET: PalabraClave/VistaParcialCrearPalabraClave
        public ActionResult VistaParcialCrearPalabraClave()
        {
            PalabraClaveDto model = new PalabraClaveDto();
            return PartialView("VistaParcialCrearPalabraClave", model);
        }

        // POST: PalabraClave/VistaParcialCrearPalabraClave
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VistaParcialCrearPalabraClave(PalabraClaveDto model)
        {
            // 1. Validaciones de modelo
            if (!ModelState.IsValid)
            {
                // Devuelves la misma vista parcial para que se muestren los mensajes
                return PartialView("VistaParcialCrearPalabraClave", model);
            }

            try
            {
                // 2. Registrar palabra clave en la capa de negocio
                int idGenerado = await _agregarPalabraClaveLN.Agregar(model);

                // 3. Bitácora de éxito
                BitacoraDto logExito = new BitacoraDto
                {
                    tablaDeEvento = "PALABRA_CLAVE",
                    tipoDeEvento = "CREAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = "Palabra clave creada correctamente",
                    datosPosteriores =
                        $"ID: {idGenerado}; " +
                        $"Palabra: {model.Palabra}; " +
                        $"Orden: {model.Orden}; " +
                        $"Estado: {(model.Estado ? "Activo" : "Inactivo")}"
                };
                _bitacoraEventosLN.RegistrarEvento(logExito);

                // 4. Respuesta JSON para cerrar modal y refrescar tabla
                return Json(new
                {
                    success = true,
                    message = "Palabra clave registrada correctamente.",
                    id = idGenerado,
                    palabra = model.Palabra,
                    orden = model.Orden,
                    estado = model.Estado
                });
            }
            catch (InvalidOperationException ex)
            {
                // 5. Errores controlados (por ejemplo, palabra duplicada)
                BitacoraDto logErrorControlado = new BitacoraDto
                {
                    tablaDeEvento = "PALABRA_CLAVE",
                    tipoDeEvento = "ERROR_CREAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.StackTrace
                };
                _bitacoraEventosLN.RegistrarEvento(logErrorControlado);

                ModelState.AddModelError("", ex.Message);

                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                // 6. Errores inesperados
                BitacoraDto logErrorInesperado = new BitacoraDto
                {
                    tablaDeEvento = "PALABRA_CLAVE",
                    tipoDeEvento = "ERROR_CREAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = "Error inesperado al crear palabra clave",
                    stackTrace = ex.ToString()
                };
                _bitacoraEventosLN.RegistrarEvento(logErrorInesperado);

                ModelState.AddModelError("", "Error al registrar la palabra clave: " + ex.Message);

                return Json(new
                {
                    success = false,
                    message = "Error al registrar la palabra clave: " + ex.Message
                });
            }
        }

        // GET: PalabraClave/VistaParcialEditarPalabraClave
        public ActionResult VistaParcialEditarPalabraClave(int id)
        {
            List<PalabraClaveDto> laListaDePalabrasClaves = _listarPalabraClaveLN.Obtener();
            PalabraClaveDto palabraAEditar = laListaDePalabrasClaves
                                                .FirstOrDefault(p => p.IdPalabra == id);

            return PartialView("VistaParcialEditarPalabraClave", palabraAEditar);
        }

        // POST: PalabraClave/VistaParcialEditarPalabraClave
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VistaParcialEditarPalabraClave(int id, PalabraClaveDto palabraEditada)
        {
            palabraEditada.IdPalabra = id;

            if (!ModelState.IsValid)
            {
                return PartialView("VistaParcialEditarPalabraClave", palabraEditada);
            }

            try
            {
                int resultado = _editarPalabraClaveLN.Editar(palabraEditada);

                BitacoraDto logExito = new BitacoraDto
                {
                    tablaDeEvento = "PALABRA_CLAVE",
                    tipoDeEvento = "EDITAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = "Palabra clave actualizada correctamente",
                    datosPosteriores = $"ID: {palabraEditada.IdPalabra}, " +
                                       $"Palabra: {palabraEditada.Palabra}, " +
                                       $"Orden: {palabraEditada.Orden}"
                };
                _bitacoraEventosLN.RegistrarEvento(logExito);

                return Json(new
                {
                    success = true,
                    message = "Palabra clave actualizada correctamente.",
                    filasAfectadas = resultado,
                    id = palabraEditada.IdPalabra,
                    palabra = palabraEditada.Palabra,
                    orden = palabraEditada.Orden
                });
            }
            catch (InvalidOperationException ex)
            {
                BitacoraDto logErrorControlado = new BitacoraDto
                {
                    tablaDeEvento = "PALABRA_CLAVE",
                    tipoDeEvento = "ERROR_EDITAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.StackTrace
                };
                _bitacoraEventosLN.RegistrarEvento(logErrorControlado);

                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                BitacoraDto logErrorInesperado = new BitacoraDto
                {
                    tablaDeEvento = "PALABRA_CLAVE",
                    tipoDeEvento = "ERROR_EDITAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = "Error inesperado al editar palabra clave",
                    stackTrace = ex.ToString()
                };
                _bitacoraEventosLN.RegistrarEvento(logErrorInesperado);

                return Json(new
                {
                    success = false,
                    message = "Error al actualizar la palabra clave: " + ex.Message
                });
            }
        }

        // GET: PalabraClave/Delete/5
        public ActionResult Delete(int id)
        {
            _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
            {
                tablaDeEvento = "PALABRA_CLAVE",
                tipoDeEvento = "VISTA_ELIMINAR",
                descripcionDeEvento = $"Vista de eliminar para ID {id}"
            });
            return View();
        }

        // POST: PalabraClave/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "PALABRA_CLAVE",
                    tipoDeEvento = "ELIMINAR",
                    descripcionDeEvento = $"Palabra clave eliminada (ID {id})"
                });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "PALABRA_CLAVE",
                    tipoDeEvento = "ERROR_ELIMINAR",
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.ToString()
                });

                return View();
            }
        }
    }
}
