using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Entidades
{
    [Table("ANALISIS")]
    public class AnalisisAD
    {
        [Key]
        [Column("IdAnalisis")]
        public int IdAnalisis { get; set; }

        [Column("IdPersona")]
        public int IdPersona { get; set; }

        [Column("CantidadArchivos")]
        public int CantidadArchivos { get; set; }

        [Column("CantidadPalabrasClave")]
        public int CantidadPalabrasClave { get; set; }

        [Column("NivelDeRiesgo")]
        public int NivelDeRiesgo { get; set; }

        [Column("Comentario")]
        public string Comentario { get; set; }

        [Column("FechaDeAnalisis")]
        public DateTime FechaDeAnalisis { get; set; }
    }
}