using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Entidades
{
    [Table("ARCHIVO_ANALISIS")]
    public class ArchivosDeAnalisisAD
    {
        [Key]
        [Column("IdArchivo")]
        public int idArchivo { get; set; }

        [Column("Nombre")]
        public string nombre { get; set; }

        [Column("TextoDelArchivo")]
        public string textoDelArchivo { get; set; }

        [Column("Fuente")]
        public string fuente { get; set; }

        [Column("FechaDeRegistro")]
        public DateTime fechaDeRegistro { get; set; }
    }
}