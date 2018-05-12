using Loja.Domain;
using Loja.Repository.Migrations;
using Loja.Repository.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Loja.Repository
{
    public class LojaDbContext : IdentityDbContext
    {
        public LojaDbContext() 
            : base("lojaConnectionString")
        {
            //Database.SetInitializer(new LojaDbInitialyzer());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LojaDbContext,Configuration>());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
        }        
    }
}
