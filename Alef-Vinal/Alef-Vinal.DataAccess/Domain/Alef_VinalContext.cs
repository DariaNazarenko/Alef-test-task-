using Alef_Vinal.DataAccess.Domain.Entities;
using Alef_Vinal.DataAccess.Domain.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Alef_Vinal.DataAccess.Domain
{
    public class Alef_VinalContext : DbContext
    {
        #region DbSets

        public DbSet<ValueCode> Codes { get; set; }

        #endregion

        public Alef_VinalContext(DbContextOptions<Alef_VinalContext> options) : base(options) 
        {}

        public void EnsureCreated()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ValueCodeConfiguration());
        }
    }
}
