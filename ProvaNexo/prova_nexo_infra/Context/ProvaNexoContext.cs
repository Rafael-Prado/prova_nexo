using prova_nexo_domain.Domain;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace prova_nexo_infra.Context
{
    public class ProvaNexoContext : DbContext
    {
        public ProvaNexoContext()
            : base("PROVANEXOCONTEXT")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProvaNexoContext>(null);
            // Pluralizing
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Non delete cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //General Custom Context Properties
            modelBuilder.Properties()
                    .Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id")
                    .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            // Configure

            base.OnModelCreating(modelBuilder);
        }

    }

    public static class Factory
    {
        public static void UndoChanges(this DbContext dbContext)
        {
            var modifiedEntityList =
                dbContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();

            foreach (var entity in modifiedEntityList)
            {
                var propertyValues = entity.OriginalValues;
                foreach (var propertyName in propertyValues.PropertyNames)
                {
                    var property = entity.Entity.GetType().GetProperty(propertyName);
                    property.SetValue(entity.Entity, propertyValues[propertyName]);
                }
            }
        }
    }
}
