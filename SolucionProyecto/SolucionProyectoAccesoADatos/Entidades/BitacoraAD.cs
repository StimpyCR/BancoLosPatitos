using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionProyectoAccesoADatos.Entidades
{
 
        [Table("BITACORA_EVENTOS")]
        public class BitacoraAD
        {
            [Key]
            [Column("IdEvento")]
            public int idEvento { get; set; }

            [Column("TablaDeEvento")]
            public string tablaDeEvento { get; set; }

            [Column("TipoDeEvento")]
            public string tipoDeEvento { get; set; }

            [Column("FechaDeEvento")]
            public DateTime fechaDeEvento { get; set; }

            [Column("DescripcionDeEvento")]
            public string descripcionDeEvento { get; set; }

            [Column("StackTrace")]
            public string stackTrace { get; set; }

            [Column("DatosAnteriores")]
            public string datosAnteriores { get; set; }

            [Column("DatosPosteriores")]
            public string datosPosteriores { get; set; }
        }
    }