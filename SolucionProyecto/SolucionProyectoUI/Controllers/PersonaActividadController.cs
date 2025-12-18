
using SolucionProyectoAbstracciones.LogicaDeNegocio.Bitacora.BitacoraEventos;
using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona_Actividad;
using SolucionProyectoAccesoADatos.Bitacora.BitacoraEventos;
using SolucionProyectoLogicaDeNegocio.Persona_Actividad.EliminarPersonaActividad;
using SolucionProyectoLogicaDeNegocio.Persona_Actividad.ObtenerPersonaActividadActiva;
using SolucionProyectoLogicaDeNegocio.Persona_Actividad.RegistrarActividadPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SolucionProyectoUI.Controllers
{
    [Authorize(Roles = "Admin,Analista")]
    public class PersonaActividadController : Controller
    {
        private readonly ObtenerPersonaActividadActivaLN _obtenerPersonaActividadActivaLN;
        private readonly RegistrarActividadPersonaLN registrarActividadPersonaLN;
        private readonly EliminarPersonaActividadLN eliminarPersonaActividadLN;
        private readonly IBitacoraEventosLN _bitacoraEventosLN;
        public PersonaActividadController()
        {
            _obtenerPersonaActividadActivaLN = new ObtenerPersonaActividadActivaLN();
            registrarActividadPersonaLN = new RegistrarActividadPersonaLN();
            eliminarPersonaActividadLN = new EliminarPersonaActividadLN();
            _bitacoraEventosLN = new BitacoraEventosLN();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonaActividad

        public ActionResult ListaDePersonaActividadActiva(int id)
        {
            List<PersonaActividadDto> laListaDeActividadesPersonaActivas = _obtenerPersonaActividadActivaLN.ObtenerDisponibles(id);

            List<PersonaActividadDto> disponiblesParaAgregar =
            registrarActividadPersonaLN.ObtenerDisponiblesParaAgregar(id);

            List<SelectListItem> opciones = disponiblesParaAgregar
                .Select(d => new SelectListItem
                {
                    Value = d.IdActividadFinanciera.ToString(),
                    Text = d.NombreActividadFinanciera + " (Riesgo: " + d.NombreRiesgo + ")"
                })
                .ToList();

            ViewBag.Opciones = opciones;
            ViewBag.IdUsuario = id;
            // BITÁCORA
            _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
            {
                tablaDeEvento = "PERSONA_ACTIVIDAD",
                tipoDeEvento = "CONSULTAR_LISTA",
                descripcionDeEvento = $"Consulta de actividades activas para usuario {id}"
            });
            return View(laListaDeActividadesPersonaActivas);
        }

        // GET: PersonaActividad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonaActividad/Create
        public ActionResult RegistrarActividad()
        {
            return View();
        }

        // POST: PersonaActividad/RegistrarActividad
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegistrarActividad(int idUsuario, int idActividadFinanciera)
        {
            if (idActividadFinanciera <= 0)
            {
                TempData["TipoMensaje"] = "warning";
                TempData["TituloMensaje"] = "Seleccione una actividad";
                TempData["Mensaje"] = "Debe seleccionar una actividad financiera.";

                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "PERSONA_ACTIVIDAD",
                    tipoDeEvento = "ERROR_CREAR",
                    descripcionDeEvento = "Intento de registrar actividad sin seleccionar actividad financiera"
                });

                return RedirectToAction("ListaDePersonaActividadActiva", new { id = idUsuario });
            }

            var dto = new PersonaActividadDto();
            int filas = await registrarActividadPersonaLN.RegistrarActividad(dto, idUsuario, idActividadFinanciera);

            _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
            {
                tablaDeEvento = "PERSONA_ACTIVIDAD",
                tipoDeEvento = "CREAR",
                descripcionDeEvento = $"Usuario {idUsuario} registró actividad {idActividadFinanciera}",
                datosPosteriores = $"Usuario={idUsuario}, Actividad={idActividadFinanciera}"
            });

            if (filas == 0)
            {
                TempData["TipoMensaje"] = "info";
                TempData["TituloMensaje"] = "Actividad ya registrada";
                TempData["Mensaje"] = "La actividad ya estaba activa.";
            }
            else
            {
                TempData["TipoMensaje"] = "success";
                TempData["TituloMensaje"] = "Actividad registrada";
                TempData["Mensaje"] = "Actividad registrada correctamente.";
            }

            return RedirectToAction("ListaDePersonaActividadActiva", new { id = idUsuario });
        }


        // POST: PersonaActividad/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int idActividadPersona, int idUsuario)
        {
            var dto = new PersonaActividadDto
            {
                IdActividadPersona = idActividadPersona
            };

            int filas = await eliminarPersonaActividadLN.Eliminar(dto);

            _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
            {
                tablaDeEvento = "PERSONA_ACTIVIDAD",
                tipoDeEvento = "ELIMINAR",
                descripcionDeEvento = $"El usuario {idUsuario} eliminó la actividad-persona {idActividadPersona}",
                datosAnteriores = $"IdActividadPersona={idActividadPersona}"
            });

            if (filas > 0)
            {
                TempData["TipoMensaje"] = "success";
                TempData["TituloMensaje"] = "Actividad desactivada";
                TempData["Mensaje"] = "La actividad fue desactivada correctamente.";
            }
            else
            {
                TempData["TipoMensaje"] = "info";
                TempData["TituloMensaje"] = "Sin cambios";
                TempData["Mensaje"] = "No se encontró la actividad o ya estaba inactiva.";
            }

            return RedirectToAction("ListaDePersonaActividadActiva", new { id = idUsuario });
        }

        // GET: PersonaActividad/Delete/5
        public ActionResult Delete(int id)
        {
            _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
            {
                tablaDeEvento = "PERSONA_ACTIVIDAD",
                tipoDeEvento = "VISTA_ELIMINAR",
                descripcionDeEvento = $"Vista Delete para id {id}"
            });
            return View();
        }

        // POST: PersonaActividad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "PERSONA_ACTIVIDAD",
                    tipoDeEvento = "ELIMINAR",
                    descripcionDeEvento = $"Delete ejecutado para ID {id}"
                });

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // BITÁCORA
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "PERSONA_ACTIVIDAD",
                    tipoDeEvento = "ERROR_ELIMINAR",
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.ToString()
                });
                return View();
            }
        }
    }
}
