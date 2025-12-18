using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolucionProyectoAccesoADatos.Entidades
{
    [Table("ACTIVIDAD_PERSONA")]
    public class UsuarioActividadAD
    {
        [Key]
        [Column("IdActividad")] // ✅ Coincide exactamente con la BD
        public int IdActividad { get; set; }

        [Column("IdPersona")]
        public int IdPersona { get; set; }

        [Column("IdActividadFinanciera")]
        public int IdActividadFinanciera { get; set; }

        [Column("FechaDeRegistro")]
        public DateTime FechaDeRegistro { get; set; }

        [Column("FechaDeModificacion")]
        public DateTime? FechaDeModificacion { get; set; }

        [Column("Estado")]
        public bool Estado { get; set; }
    }
}
