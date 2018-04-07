using Loja.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repository.ModelConfiguration
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            Property(p => p.Nome).HasMaxLength(100).IsRequired();
            Property(p => p.Preco).HasPrecision(9, 2);

            HasRequired(p=>p.Categoria);
    }
    }
}