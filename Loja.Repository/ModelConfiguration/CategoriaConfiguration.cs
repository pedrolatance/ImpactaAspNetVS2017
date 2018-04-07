using Loja.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repository.ModelConfiguration
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            Property(c => c.Nome).HasMaxLength(100).IsRequired();

            
        }
    }
}