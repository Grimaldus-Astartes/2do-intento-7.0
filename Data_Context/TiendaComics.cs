using Microsoft.EntityFrameworkCore;
using Quiero_revisar.Data_Entities;

namespace Quiero_revisar.Data_Context
{
    public class TiendaComics : DbContext
    {
        public TiendaComics(DbContextOptions<TiendaComics> options) : base(options) { 
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #region mi DbSet
        public DbSet<CatalogoEntity> Catalogos { get; set; }
        #endregion
    }
}
