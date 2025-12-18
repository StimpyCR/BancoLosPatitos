using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Entidades
{
    [Table("ACTIVIDAD_FINANCIERA")]
    public class ActividadFinancieraAD
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdActividadFinanciera")]
        public int IdActividadFinanciera { get; set; }
        [Column("NombreActividadFinanciera")]
        public string NombreActividadFinanciera { get; set; }
        [Column("DescripcionActividadFinanciera")]
        public string DescripcionActividadFinanciera { get; set; }
        [Column("NivelDeRiesgo")]
        public int NivelDeRiesgo { get; set; }
        [Column("FechaDeRegistro")]
        public DateTime FechaDeRegistro { get; set; }
        [Column("FechaDeModificacion")]
        public DateTime? FechaDeModificacion { get; set; }
        [Column("Estado")]
        public bool Estado { get; set; }
    }
}
