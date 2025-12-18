using SolucionProyectoAbstracciones.ModelosParaUI.ArchivosDeAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.ArchivosDeAnalisis.DetallesArchivosDeAnalisis
{
    public class DetallesArchivosDeAnalisisLN: IDetallesArchivosDeAnalisisLN
    {
        private readonly IDetallesArchivosDeAnalisisAD _detallesAD;

        public DetallesArchivosDeAnalisisLN()
        {
            _detallesAD = new DetallesArchivosDeAnalisisAD();
        }

        
        public ArchivosDeAnalisisDto Obtener(int idArchivo)
        {
            
            ArchivosDeAnalisisDto archivo = _detallesAD.Obtener(idArchivo);

            
            if (archivo == null)
            {
                throw new Exception("No se encontró el archivo de análisis con el Id proporcionado.");
            }

            return archivo;
        }
    }
}