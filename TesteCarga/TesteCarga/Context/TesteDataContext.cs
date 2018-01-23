using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TesteCarga.Mapping;
using TesteCarga.Model;

namespace TesteCarga.Context
{
    public class TesteDataContext : DbContext
    {
        public TesteDataContext():base("Name=TestConnectionString")
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.UseDatabaseNullSemantics = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            Database.SetInitializer<TesteDataContext>(null);
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
