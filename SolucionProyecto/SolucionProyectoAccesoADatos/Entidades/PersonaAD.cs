using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Entidades
{
    [Table("PERSONA")]
    public class PersonaAD
    {
        [Key]
        [Column("IdPersona")]
        public int IdPersona { get; set; }
        [Column("Identificacion")]
        public int identificacion { get; set; }
        [Column("TipoIdentificacion")]
        public int tipoIdentificacion { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("PrimerApellido")]
        public string primerApellido { get; set; }
        [Column("SegundoApellido")]
        public string segundoApellido { get; set; }
        [Column("Telefono")]
        public string telefono { get; set; }
        [Column("CorreoElectronico")]
        public string correo { get; set; }
        [Column("Direccion")]
        public string direccion { get; set; }
        [Column("EstadoDeRiesgo")]
        public int estadoDeRiesgo { get; set; }
        [Column("FechaDeRegistro")]
        public DateTime fechaDeRegistro { get; set; }
        [Column("FechaDeModificacion")]
        public DateTime? fechaDeModificacion { get; set; }
        [Column("Estado")]
        public bool estado { get; set; }
    }
}
