using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Entidades
{
    [Table("ACTIVIDAD_PERSONA")]
    public class PersonaActividadAD
    {
        [Key]
        [Column("IdActividad")]
        public int IdActividadPersona { get; set; }

        [Column("IdActividadFinanciera")]
        public int IdActividadFinanciera { get; set; }

        [Column("IdPersona")]
        public int IdPersona { get; set; }

        [Column("FechaDeRegistro")]
        public DateTime FechaDeRegistro { get; set; }

        [Column("FechaDeModificacion")]
        public DateTime? FechaDeModificacion { get; set; }

        [Column("Estado")]
        public bool Estado { get; set; }

    }
}
