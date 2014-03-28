using System.Collections.Generic;
using System.Data.Entity;
using ILUMINACAO_PUBLICA.Models;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace ILUMINACAO_PUBLICA.Models
{
    public class ILUMINACAO_PUBLICAContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<Prefeitura> Prefeituras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}