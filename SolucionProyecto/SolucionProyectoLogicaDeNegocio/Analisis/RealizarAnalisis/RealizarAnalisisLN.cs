
using SolucionProyectoAbstracciones.AccesoADatos.Analisis.RealizarAnalisis;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerActividadesFinancierasDeLaPersona;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerArchivos;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerPalabrasClave;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.ObtenerPersona;
using SolucionProyectoAbstracciones.LogicaDeNegocio.Analisis.RealizarAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera;
using SolucionProyectoAbstracciones.ModelosParaUI.Analisis;
using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using SolucionProyectoAbstracciones.ModelosParaUI.PalabraClave;
using SolucionProyectoAbstracciones.ModelosParaUI.Persona;
using SolucionProyectoAccesoADatos.AccesoADatos;
using SolucionProyectoAccesoADatos.Analisis.ObtenerActividadesFinancierasDeLaPersona;
using SolucionProyectoAccesoADatos.Analisis.ObtenerArchivos;
using SolucionProyectoAccesoADatos.Analisis.ObtenerPalabrasClave;
using SolucionProyectoAccesoADatos.Analisis.ObtenerPersona;
using SolucionProyectoAccesoADatos.Analisis.RealizarAnalisis;
using SolucionProyectoAccesoADatos.Entidades;
using SolucionProyectoLogicaDeNegocio.Analisis.ObtenerActividadesFinancierasDeLaPersona;
using SolucionProyectoLogicaDeNegocio.Analisis.ObtenerArchivos;
using SolucionProyectoLogicaDeNegocio.Analisis.ObtenerPalabrasClave;
using SolucionProyectoLogicaDeNegocio.Analisis.ObtenerPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SolucionProyectoAbstracciones.ModelosParaUI.Analisis.AnalisisRequestDto;

namespace SolucionProyectoLogicaDeNegocio.Analisis.RealizarAnalisis
{
    public class RealizarAnalisisLN : IRealizarAnalisisLN
    {
        private readonly IObtenerPersonaLN _obtenerPersonaLN;
        private readonly IObtenerArchivosLN _obtenerArchivosLN;
        private readonly IObtenerPalabrasClaveLN _obtenerPalabrasClaveLN;
        private readonly IObtenerActividadFinancieraPersonaLN _obtenerActividadFinancieraPersonaLN;
        private readonly IRealizarAnalisisAD _realizarAnalisisAD;
        private readonly IActualizarRiesgoPersonaLN _actualizarRiesgoPersonaLN;

        public RealizarAnalisisLN(
            IObtenerPersonaLN obtenerPersonaLN,
            IObtenerArchivosLN obtenerArchivosLN,
            IObtenerPalabrasClaveLN obtenerPalabrasClaveLN,
            IObtenerActividadFinancieraPersonaLN obtenerActividadFinancieraPersonaLN,
            IRealizarAnalisisAD realizarAnalisisAD,
            IActualizarRiesgoPersonaLN actualizarRiesgoPersonaLN)
        {
            _obtenerPersonaLN = obtenerPersonaLN;
            _obtenerArchivosLN = obtenerArchivosLN;
            _obtenerPalabrasClaveLN = obtenerPalabrasClaveLN;
            _obtenerActividadFinancieraPersonaLN = obtenerActividadFinancieraPersonaLN;
            _realizarAnalisisAD = realizarAnalisisAD;
            _actualizarRiesgoPersonaLN = actualizarRiesgoPersonaLN;
        }

        public AnalisisDto RealizarAnalisis(int idPersona)
        {
            PersonaDto persona = _obtenerPersonaLN.ObtenerDisponibles(idPersona).FirstOrDefault();
            if (persona == null)
                throw new Exception("Persona no encontrada o inactiva.");

            List<ArchivosDeAnalisisDto> archivos = _obtenerArchivosLN.ObtenerDisponibles(idPersona);
            List<PalabraClaveDto> palabrasClave = _obtenerPalabrasClaveLN.ObtenerDisponibles();
            List<ActividadFinancieraDto> actividades = _obtenerActividadFinancieraPersonaLN.ObtenerDisponibles(idPersona);

            int totalPalabrasEncontradas = 0;

            foreach (PalabraClaveDto palabra in palabrasClave)
            {
                string p = (palabra.Palabra ?? string.Empty).Trim();
                if (string.IsNullOrWhiteSpace(p))
                    continue;

                foreach (ArchivosDeAnalisisDto archivo in archivos)
                {
                    string texto = archivo.textoResumen ?? string.Empty;

                    if (texto.IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        totalPalabrasEncontradas++;
                    }
                }
            }

            int actBajo = 0;
            int actMedio = 0;
            int actAlto = 0;

            foreach (ActividadFinancieraDto act in actividades)
            {
                int nivel = act.NivelDeRiesgo;

                if (nivel == 1) actBajo++;
                else if (nivel == 2) actMedio++;
                else if (nivel == 3) actAlto++;
            }

            int cantidadArchivos = archivos.Count;
            int nivelRiesgo;
            string comentario;

            bool riesgoCritico =
                (actAlto > 1) &&
                (cantidadArchivos > 10) &&
                (totalPalabrasEncontradas > 10);

            bool riesgoAlto =
                ((actMedio > 4) || (actAlto >= 1)) &&
                (cantidadArchivos >= 5 && cantidadArchivos <= 9) &&
                (totalPalabrasEncontradas >= 5 && totalPalabrasEncontradas <= 10);

            bool riesgoMedio =
                ((actBajo > 5) || (actMedio >= 1 && actMedio <= 3)) &&
                (cantidadArchivos > 4) &&
                (totalPalabrasEncontradas >= 1 && totalPalabrasEncontradas <= 5);

            bool riesgoBajo =
                (actBajo >= 1 && actBajo <= 5) &&
                (cantidadArchivos >= 1) &&
                (totalPalabrasEncontradas == 0);

            if (riesgoCritico)
            {
                nivelRiesgo = 4;
                comentario = "La persona queda bloqueada del sistema financiero.";
            }
            else if (riesgoAlto)
            {
                nivelRiesgo = 3;
                comentario = "La persona no es apta para brindar créditos.";
            }
            else if (riesgoMedio)
            {
                nivelRiesgo = 2;
                comentario = "La persona se le puede brindar créditos con tope y tasa media.";
            }
            else
            {
                nivelRiesgo = 1;
                comentario = "La persona no es un riesgo crediticio para el banco.";
            }
      
            AnalisisDto resultado = new AnalisisDto
            {
                IdPersona = idPersona,
                CantidadArchivos = cantidadArchivos,
                CantidadPalabrasClave = totalPalabrasEncontradas, 
                NivelDeRiesgo = nivelRiesgo,
                Comentario = comentario,
                FechaDeAnalisis = DateTime.Now
            };

            _realizarAnalisisAD.RegistrarAnalisis(resultado);

            _actualizarRiesgoPersonaLN.Actualizar(idPersona, nivelRiesgo);

            return resultado;
        }
    }
}