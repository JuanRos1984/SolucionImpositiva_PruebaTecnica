using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistencia.Contexto
{
    public class SolucionFiscalContext : DbContext
    {
        public SolucionFiscalContext(DbContextOptions<SolucionFiscalContext> op): base(op)
        {
            
        }

        public DbSet<Contribuyente> Contribuyentes { get; set; }
        public DbSet<Comprobante> Comprobantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comprobante>()
                .HasKey(a => new { a.RncCedula, a.NCF});
        }
    }
}
