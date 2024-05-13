using Microsoft.EntityFrameworkCore;
using System.IO;


namespace DataAccess.Models
{
    public partial class DbCrudContext : DbContext    
    {
        public DbCrudContext()
        {
        }

        public DbCrudContext(DbContextOptions<DbCrudContext> options) : base(options)
        {
        }        
        public virtual DbSet<Unidad> Unidades { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Adquisicion> Adquisiciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
