using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.Models
{
    public partial class DataContext : DbContext
    {
        static DataContext()
        {
            Database.SetInitializer<DbContext>(null);
        }

        public DataContext()
            : base("Name=dbConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
