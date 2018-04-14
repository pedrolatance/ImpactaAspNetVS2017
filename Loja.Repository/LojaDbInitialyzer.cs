using System;
using System.Collections.Generic;
using System.Data.Entity;
using Loja.Domain;

namespace Loja.Repository
{
    internal class LojaDbInitialyzer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            context.Produtos.AddRange(ObterProdutos());

            context.SaveChanges();
        }

        private IEnumerable<Produto> ObterProdutos()
        {
            var grampeador = new Produto();
            grampeador.Categoria = new Categoria { Nome = "Papelaria" };
            grampeador.Nome = "Grampeador";
            grampeador.Preco = 9.38m;
            grampeador.Estoque = 38;
            grampeador.Ativo = false;

            var pendrive = new Produto();
            pendrive.Categoria = new Categoria { Nome = "Informática" };
            pendrive.Nome = "Pendrive";
            pendrive.Preco = 42.25m;
            pendrive.Estoque = 15;
            pendrive.Ativo = false;

            return new List<Produto> { grampeador, pendrive };
        }
    }
}