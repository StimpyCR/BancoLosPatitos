using SolucionProyectoAccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;


namespace SolucionProyectoAccesoADatos.AccesoADatos
{
    public class Contexto :DbContext
    {
        public Contexto() 
        {
            Database.SetInitializer<Contexto>(null);
        }
        public DbSet<PersonaAD> persona { get; set; }
   

        public DbSet<ActividadFinancieraAD> ActividadFinanciera { get; set; }
        public DbSet<ArchivosDeAnalisisAD> ArchivosDeAnalisis { get; set; }
        public DbSet<BitacoraAD> Bitacora { get; set; }

        public DbSet<PersonaActividadAD> PersonaActividad { get; set; }

        public DbSet<PalabraClaveAD> PalabraClave { get; set; }
        public DbSet<AnalisisAD> Analisis { get; set; }

        public System.Data.Entity.DbSet<SolucionProyectoAbstracciones.ModelosParaUI.ActividadFinanciera.ActividadFinancieraDto> ActividadFinancieraDtoes { get; set; }
    }
}
