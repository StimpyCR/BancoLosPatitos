using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.RealizarAnalisis;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Bitacora.BitacoraEventos;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Persona.AgregarPersona;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Persona.EditarPersona;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Persona.ListaPersona;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Persona.ObtenerPersonaPorId;
using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.Analisis.RealizarAnalisis;
using SolucionProyectoAccesoADatos.Bitacora.BitacoraEventos;
using SolucionProyectoLogicaDeNegocio.Analisis.ObtenerActividadesFinancierasDeLaPersona;
using SolucionProyectoLogicaDeNegocio.Analisis.ObtenerArchivos;
using SolucionProyectoLogicaDeNegocio.Analisis.ObtenerPalabrasClave;
using SolucionProyectoLogicaDeNegocio.Analisis.ObtenerPersona;
using SolucionProyectoLogicaDeNegocio.Analisis.RealizarAnalisis;
using SolucionProyectoLogicaDeNegocio.Persona.AgregarPersona;
using SolucionProyectoLogicaDeNegocio.Persona.EditarPersona;
using SolucionProyectoLogicaDeNegocio.Persona.ListaPersona;
using SolucionProyectoLogicaDeNegocio.Persona.ObtenerPersonaPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SolucionProyectoUI.Controllers
{
    [Authorize(Roles = "Admin,Analista")]

    public class PersonaController : Controller
    {
        private readonly IRealizarAnalisisLN _realizarAnalisisLN;
        private readonly IListarPersonaLN _listarPersonaLN;
        private readonly IAgregarPersonaLN _agregarPersonaLN;
        private readonly IEditarPersonaLN _editarPersonaLN;
        private readonly IBitacoraEventosLN _BitacoraEventosLN;
        private readonly IObtenerPersonaPorIdLN _obtenerPersonaPorIdLN;
        public PersonaController()
        {
            _obtenerPersonaPorIdLN = new ObtenerPersonaPorIdLN();
            _listarPersonaLN = new ListarPersonaLN();
            _agregarPersonaLN = new AgregarPersonaLN();
            _editarPersonaLN = new EditarPersonaLN();
            _BitacoraEventosLN = new BitacoraEventosLN();
            _realizarAnalisisLN = new RealizarAnalisisLN(
                            new ObtenerPersonaLN(),
                            new ObtenerArchivosLN(),
                            new ObtenerPalabrasClaveLNAdapter(),
                            new ObtenerActividadFinancieraPersonaLNAdapter(),
                            new RealizarAnalisisAD(),
                            new ActualizarRiesgoPersonaLN(new ActualizarRiesgoPersonaAD())
                        );
        }
        // GET: Persona
        public ActionResult ListaPersonas()
        {
            List<PersonaDto> laListaDePersonas = _listarPersonaLN.Obtener();
            _BitacoraEventosLN.RegistrarEvento(new BitacoraDto
            {
                tablaDeEvento = "PERSONA",
                tipoDeEvento = "CONSULTAR_LISTA",
                descripcionDeEvento = "Listado de personas consultado"
            });
            return View(laListaDePersonas);
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Persona/Create
        public ActionResult CrearPersona()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearPersona(PersonaDto persona)
        {
            if (!ModelState.IsValid)
            {
                return View(persona);
            }

            try
            {
                int idGenerado = await _agregarPersonaLN.Agregar(persona);
                BitacoraDto log = new BitacoraDto
                {
                    tablaDeEvento = "PERSONA",
                    tipoDeEvento = "CREAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = "Persona creada correctamente",
                    datosPosteriores = "ID: " + idGenerado
                };
                _BitacoraEventosLN.RegistrarEvento(log);

                TempData["MensajeExito"] = $"Persona registrada correctamente (ID: {idGenerado})";
                return RedirectToAction("ListaPersonas");
            }
            catch (InvalidOperationException ex)
            {
                BitacoraDto log = new BitacoraDto
                {
                    tablaDeEvento = "PERSONA",
                    tipoDeEvento = "ERROR_CREAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.StackTrace
                };
                _BitacoraEventosLN.RegistrarEvento(log);
                ModelState.AddModelError("", ex.Message);
                return View(persona);
            }
            catch (Exception ex)
            {
                BitacoraDto log = new BitacoraDto
                {
                    tablaDeEvento = "PERSONA",
                    tipoDeEvento = "ERROR_CREAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = "Error inesperado al crear persona",
                    stackTrace = ex.ToString()
                };
                _BitacoraEventosLN.RegistrarEvento(log);
                ModelState.AddModelError("", "Error al registrar la persona: " + ex.Message);
                return View(persona);
            }
        }

        // GET: Persona/CrearPersonaVP
        [HttpGet]
        public ActionResult VistaParcialCrearPersona()
        {
            PersonaDto persona = new PersonaDto();
            return PartialView("VistaParcialCrearPersona", persona);
        }

        // POST: Persona/CrearPersonaVP
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VistaParcialCrearPersona(PersonaDto persona)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("VistaParcialCrearPersona", persona);
            }

            try
            {
                int idGenerado = await _agregarPersonaLN.Agregar(persona);

                BitacoraDto log = new BitacoraDto
                {
                    tablaDeEvento = "PERSONA",
                    tipoDeEvento = "CREAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = "Persona creada correctamente",
                    datosPosteriores = "ID: " + idGenerado
                };
                _BitacoraEventosLN.RegistrarEvento(log);

                return Json(new
                {
                    success = true,
                    message = "Persona registrada correctamente.",
                    id = idGenerado,
                    identificacion = persona.Identificacion,
                    nombre = persona.Nombre,
                    primerApellido = persona.PrimerApellido
                });
            }
            catch (InvalidOperationException ex)
            {
                BitacoraDto log = new BitacoraDto
                {
                    tablaDeEvento = "PERSONA",
                    tipoDeEvento = "ERROR_CREAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.StackTrace
                };
                _BitacoraEventosLN.RegistrarEvento(log);

                ModelState.AddModelError("", ex.Message);

                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                BitacoraDto log = new BitacoraDto
                {
                    tablaDeEvento = "PERSONA",
                    tipoDeEvento = "ERROR_CREAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = "Error inesperado al crear persona",
                    stackTrace = ex.ToString()
                };
                _BitacoraEventosLN.RegistrarEvento(log);

                ModelState.AddModelError("", "Error al registrar la persona: " + ex.Message);

                return Json(new
                {
                    success = false,
                    message = "Error al registrar la persona: " + ex.Message
                });
            }
        }

        // GET: Persona/Edit/5
        public ActionResult EditarPersona(int id)
        {
            List<PersonaDto> laListaDePersonas = _listarPersonaLN.Obtener();
            PersonaDto personaAEditar = laListaDePersonas.FirstOrDefault(p => p.Id == id);
            return View(personaAEditar);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPersona(PersonaDto personaEditada)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(personaEditada);
                }

                int resultado = _editarPersonaLN.Editar(personaEditada);

                TempData["MensajeExito"] = $"Persona actualizada correctamente (Filas afectadas: {resultado})";
                return RedirectToAction("ListaPersonas");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al actualizar la persona: " + ex.Message);
                return View(personaEditada);
            }
        }

        // GET: Persona/EditVP
        public ActionResult VistaParcialEditarPersona(int id)
        {
            // Puedes dejarlo así, solo añadí una pequeña validación por si no se encuentra
            List<PersonaDto> laListaDePersonas = _listarPersonaLN.Obtener();
            PersonaDto personaAEditar = laListaDePersonas.FirstOrDefault(p => p.Id == id);

            if (personaAEditar == null)
            {
                return HttpNotFound();
            }

            return PartialView("VistaParcialEditarPersona", personaAEditar);
        }

        // POST: Persona/VistaParcialEditarPersona
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VistaParcialEditarPersona(int id, PersonaDto personaEditada)
        {
            personaEditada.Id = id;

            List <PersonaDto> laListaDePersonas = _listarPersonaLN.Obtener();
            PersonaDto personaOriginal = laListaDePersonas.FirstOrDefault(p => p.Id == id);

            personaEditada.Identificacion = personaOriginal.Identificacion;
            personaEditada.TipoIdentificacion = personaOriginal.TipoIdentificacion;
            personaEditada.estadoDeRiesgo = personaOriginal.estadoDeRiesgo;
            personaEditada.fechaDeRegistro = personaOriginal.fechaDeRegistro;
            personaEditada.fechaDeModificacion = DateTime.Now;

            if (personaOriginal == null)
            {
                return Json(new { success = false, message = "No se encontró la persona a editar." });
            }

            // Aseguramos tipo de identificación original
            personaEditada.TipoIdentificacion = personaOriginal.TipoIdentificacion;

            // Si es jurídica, no permitimos cambiar apellidos
            if (personaOriginal.TipoIdentificacion == 2)
            {
                personaEditada.PrimerApellido = personaOriginal.PrimerApellido;
                personaEditada.SegundoApellido = personaOriginal.SegundoApellido;
            }

            ModelState.Clear();
            TryValidateModel(personaEditada);

            if (!ModelState.IsValid)
            {
                return PartialView("VistaParcialEditarPersona", personaEditada);
            }

            try
            {
                int resultado = _editarPersonaLN.Editar(personaEditada);

                BitacoraDto logExito = new BitacoraDto
                {
                    tablaDeEvento = "PERSONA",
                    tipoDeEvento = "EDITAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = "Persona actualizada correctamente",
                    datosPosteriores =
                        $"ID: {personaEditada.Id}, Identificación: {personaEditada.Identificacion}, Nombre: {personaEditada.Nombre} {personaEditada.PrimerApellido}"
                };
                _BitacoraEventosLN.RegistrarEvento(logExito);

                return Json(new
                {
                    success = true,
                    message = "Persona actualizada correctamente.",
                    filasAfectadas = resultado,
                    id = personaEditada.Id,
                    identificacion = personaEditada.Identificacion,
                    nombre = personaEditada.Nombre,
                    primerApellido = personaEditada.PrimerApellido
                });
            }
            catch (InvalidOperationException ex)
            {
                BitacoraDto logErrorControlado = new BitacoraDto
                {
                    tablaDeEvento = "PERSONA",
                    tipoDeEvento = "ERROR_EDITAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.StackTrace
                };
                _BitacoraEventosLN.RegistrarEvento(logErrorControlado);

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
                    tablaDeEvento = "PERSONA",
                    tipoDeEvento = "ERROR_EDITAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = "Error inesperado al editar persona",
                    stackTrace = ex.ToString()
                };
                _BitacoraEventosLN.RegistrarEvento(logErrorInesperado);

                return Json(new
                {
                    success = false,
                    message = "Error al actualizar la persona: " + ex.Message
                });
            }
        }

        // VISTA PARCIAL PARA LOS DETALLES DE LA PERSONA
        public ActionResult VistaParcialDetallesPersona(int id)
        {
            try
            {
                PersonaDto persona = _obtenerPersonaPorIdLN.ObtenerPersona(id);

                _BitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "PERSONA",
                    tipoDeEvento = "DETALLE",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = $"Consulta de detalles para la persona con ID: {id}",
                    datosPosteriores = $"ID: {id}"
                });

                return PartialView("VistaParcialDetallesPersona", persona);
            }
            catch (Exception ex)
            {
                _BitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "PERSONA",
                    tipoDeEvento = "ERROR_DETALLE",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.ToString()
                });

                ViewBag.Error = "No se pudieron cargar los detalles: " + ex.Message;
                return PartialView("_ErrorPartial");
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Persona/Delete/5
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

        [HttpPost]
        public JsonResult RealizarAnalisis(int idPersona)
        {
            try
            {
                var resultado = _realizarAnalisisLN.RealizarAnalisis(idPersona);

                return Json(new
                {
                    ok = true,
                });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, mensaje = ex.Message });
            }
        }




        [HttpPost]
        public JsonResult RealizarAnalisisPersona(int idPersona)
        {
            try
            {
                var realizarAnalisisLN = new RealizarAnalisisLN(
                    new ObtenerPersonaLN(),
                    new ObtenerArchivosLN(),
                    new ObtenerPalabrasClaveLNAdapter(),
                    new ObtenerActividadFinancieraPersonaLNAdapter(),
                    new RealizarAnalisisAD(),
                    new ActualizarRiesgoPersonaLN(new ActualizarRiesgoPersonaAD())
                );

                // Ejecutamos el análisis
                var resultado = realizarAnalisisLN.RealizarAnalisis(idPersona);

                // Validamos que el resultado no sea nulo y tenga datos válidos
                if (resultado == null)
                    throw new InvalidOperationException("No se pudo generar el análisis para esta persona.");

                // Solo registramos la bitácora si realmente se completó el análisis
                BitacoraDto log = new BitacoraDto
                {
                    tablaDeEvento = "ANALISIS",
                    tipoDeEvento = "EJECUTAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = $"Análisis ejecutado para persona {idPersona}",
                    datosPosteriores = $"Nivel: {resultado.NivelDeRiesgo}, Comentario: {resultado.Comentario}"
                };
                _BitacoraEventosLN.RegistrarEvento(log);

                return Json(new
                {
                    success = true,
                    message = "El análisis se realizó correctamente.",
                    data = new
                    {
                        resultado.IdPersona,
                        resultado.CantidadArchivos,
                        resultado.CantidadPalabrasClave,
                        resultado.NivelDeRiesgo,
                        resultado.Comentario,
                        Fecha = resultado.FechaDeAnalisis
                    }
                });
            }
            catch (Exception ex)
            {
                // Aquí registramos el error real
                BitacoraDto logError = new BitacoraDto
                {
                    tablaDeEvento = "ANALISIS",
                    tipoDeEvento = "ERROR_EJECUTAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.ToString()
                };
                _BitacoraEventosLN.RegistrarEvento(logError);

                return Json(new
                {
                    success = false,
                    message = "Ocurrió un error al realizar el análisis: " + ex.Message
                });
            }
        }



        /*[HttpPost]
        public JsonResult RealizarAnalisisPersona(int idPersona)
        {
            try
            {
              
                var realizarAnalisisLN = new RealizarAnalisisLN(
                    new ObtenerPersonaLN(),                        
                    new ObtenerArchivosLN(),                       
                    new ObtenerPalabrasClaveLNAdapter(),            
                    new ObtenerActividadFinancieraPersonaLNAdapter(),
                    new RealizarAnalisisAD()                        
                );

               
                var resultado = realizarAnalisisLN.RealizarAnalisis(idPersona);

                
                BitacoraDto log = new BitacoraDto
                {
                    tablaDeEvento = "ANALISIS",
                    tipoDeEvento = "EJECUTAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = $"Análisis ejecutado para persona {idPersona}",
                    datosPosteriores = $"Nivel: {resultado?.NivelDeRiesgo}, Comentario: {resultado?.Comentario}"
                };
                _BitacoraEventosLN.RegistrarEvento(log);

                return Json(new
                {
                    success = true,
                    message = "El análisis se realizó correctamente.",
                    data = new
                    {
                        resultado.IdPersona,
                        resultado.CantidadArchivos,
                        resultado.CantidadPalabrasClave,
                        resultado.NivelDeRiesgo,
                        resultado.Comentario,
                        Fecha = resultado.FechaDeAnalisis
                    }
                });
            }
            catch (Exception ex)
            {
                BitacoraDto logError = new BitacoraDto
                {
                    tablaDeEvento = "ANALISIS",
                    tipoDeEvento = "ERROR_EJECUTAR",
                    fechaDeEvento = DateTime.Now,
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.ToString()
                };
                _BitacoraEventosLN.RegistrarEvento(logError);

                return Json(new
                {
                    success = false,
                    message = "Ocurrió un error al realizar el análisis."
                });
            }
        }
    */
    }
}
