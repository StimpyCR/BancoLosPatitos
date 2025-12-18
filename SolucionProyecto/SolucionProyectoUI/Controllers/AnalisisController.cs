using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ListarAnalisis;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Bitacora.BitacoraEventos;
using SolucionProyectoAbstracciones.ModelosParaUI.Analisis;
using SolucionProyectoAbstracciones.ModelosParaUI.Bitacora;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.Analisis.ListarAnalisis;
using SolucionProyectoAccesoADatos.Analisis.ObtenerActividadesFinancierasDeLaPersona;
using SolucionProyectoAccesoADatos.Analisis.ObtenerPalabrasClave;
using SolucionProyectoAccesoADatos.Analisis.RealizarAnalisis;
using SolucionProyectoAccesoADatos.Bitacora.BitacoraEventos;
using SolucionProyectoLogicaDeNegocio.Analisis.ListarAnalisis;
using SolucionProyectoLogicaDeNegocio.Analisis.ObtenerActividadesFinancierasDeLaPersona;
using SolucionProyectoLogicaDeNegocio.Analisis.ObtenerArchivos;
using SolucionProyectoLogicaDeNegocio.Analisis.ObtenerPalabrasClave;
using SolucionProyectoLogicaDeNegocio.Analisis.ObtenerPersona;
using SolucionProyectoLogicaDeNegocio.Analisis.RealizarAnalisis;
using SolucionProyectoLogicaDeNegocio.Persona.ListaPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SolucionProyectoUI.Controllers
{
    [Authorize(Roles = "Admin,Analista")]
    public class AnalisisController : Controller
    {

        private readonly IListarAnalisisLN _listarAnalisisLN; 
        private readonly IListarAnalisisPorPersonaIdLN _ListarAnalisisPorPersonaIdLN;
        private readonly IBitacoraEventosLN _bitacoraEventosLN;
        private readonly IListarPersonasAnalizadasLN _listarPersonasAnalizadasLN;

        public AnalisisController()
        {
            _listarAnalisisLN = new ListarAnalisisLN(new ListarAnalisisAD());
            _bitacoraEventosLN = new BitacoraEventosLN();
            _listarPersonasAnalizadasLN = new ListarPersonasAnalizadasLN();
            _ListarAnalisisPorPersonaIdLN = new ListarAnalisisPorPersonaIdLN();


        }
        // GET: Analisis
        /*public ActionResult ListarAnalisis()
        {
            List<AnalisisDto> lista = _listarAnalisisLN.Obtener(); 
            _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
            {
                tablaDeEvento = "ANALISIS",
                tipoDeEvento = "CONSULTAR_LISTA",
                descripcionDeEvento = "Listado de análisis consultado"
            });

            return View(lista);
        }*/

        public ActionResult ListarAnalisis()
        {
            List<PersonaAnalizadaDto> lista = _listarPersonasAnalizadasLN.Obtener();

            _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
            {
                tablaDeEvento = "ANALISIS",
                tipoDeEvento = "CONSULTAR_PERANALI",
                descripcionDeEvento = "Listado de personas analizadas consultado"
            });

            return View(lista); 
        }


        public ActionResult RealizarAnalisis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RealizarAnalisis(int idPersona)
        {
            try
            {

                ListarPersonaLN obtenerPersonaLN = new ListarPersonaLN();
                List<PersonaDto> listaPersonas = obtenerPersonaLN.Obtener(); 
          
                PersonaDto persona = listaPersonas.FirstOrDefault(p => p.Id == idPersona);

                if (persona == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "No se encontró la persona."
                    });
                }

                if (!persona.estado)
                {
                    return Json(new
                    {
                        success = false,
                        message = "No se puede realizar el análisis porque la persona está inactiva."
                    });
                }

                var realizarAnalisisLN = new RealizarAnalisisLN(
                    new ObtenerPersonaLN(),
                    new ObtenerArchivosLN(),
                    new ObtenerPalabrasClaveLNAdapter(),
                    new ObtenerActividadFinancieraPersonaLNAdapter(),
                    new RealizarAnalisisAD(),
                    new ActualizarRiesgoPersonaLN(new ActualizarRiesgoPersonaAD())
                );

                var resultado = realizarAnalisisLN.RealizarAnalisis(idPersona);

                return Json(new
                {
                    success = true,
                    message = "Análisis realizado correctamente."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Error inesperado: " + ex.Message
                });
            }
        }

        [HttpPost]
        public ActionResult EjecutarAnalisis(int idPersona)
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

                var resultado = realizarAnalisisLN.RealizarAnalisis(idPersona);

                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ANALISIS",
                    tipoDeEvento = "REALIZAR_ANALISIS",
                    descripcionDeEvento = $"Análisis rápido desde Persona - ID: {idPersona}",
                    datosPosteriores = resultado.ToString()
                });

                return Json(new { ok = true, mensaje = "Análisis realizado correctamente." });
            }
            catch (Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ANALISIS",
                    tipoDeEvento = "ERROR_ANALISAR",
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.ToString()
                });

                return Json(new { ok = false, mensaje = "Error al realizar el análisis." });
            }
        }

        public ActionResult ListarAnalisisPorPersona(int idPersona)
        {
            try
            {
                List<AnalisisDto> listaAnalisisxPersona = _ListarAnalisisPorPersonaIdLN.Ejecutar(idPersona);

                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ANALISIS",
                    tipoDeEvento = "ANALISIS_X_PERSONA",
                    descripcionDeEvento = "Consulta de análisis por persona",
                    datosPosteriores = "IdPersona: " + idPersona
                });

                return View(listaAnalisisxPersona);
            }
            catch (Exception ex)
            {
                _bitacoraEventosLN.RegistrarEvento(new BitacoraDto
                {
                    tablaDeEvento = "ANALISIS",
                    tipoDeEvento = "ERROR_ANALISAR",
                    descripcionDeEvento = ex.Message,
                    stackTrace = ex.ToString()
                });

                return Json(new { ok = false, mensaje = ex.Message });
            }
        }

        // GET: Analisis/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Analisis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Analisis/Create
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

        // GET: Analisis/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Analisis/Edit/5
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

        // GET: Analisis/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Analisis/Delete/5
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
