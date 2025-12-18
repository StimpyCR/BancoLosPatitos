using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Entidades
{
    [Table("PALABRACLAVE")]
    public class PalabraClaveAD
    {
        [Column("idPalabra")]
        [Key]
        public int IdPalabra { get; set; }
        [Column("Palabra")]
        public string Palabra { get; set; }
        [Column("Orden")]
        public int Orden { get; set; }
        [Column("FechaDeRegistro")]
        public DateTime FechaDeRegistro { get; set; }
        [Column("FechaDeModificacion")]
        public DateTime? FechaDeModificacion { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }
    }
}
