using Loja.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;

namespace Loja.Repository.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        LojaDbContext _db = new LojaDbContext();

        public LojaDbContextTests()
        {
            _db.Database.Log = LogarQueries;

        }

        private void LogarQueries(string query)
        {
            Debug.Write(query);
        }

        [TestMethod()]
        public void SelecionarTodasCategoriasTest()
        {
            var categorias = _db.Categorias.ToList();
        }

        [TestMethod]
        public void IsnserirProdutoTest()
        {
            var produto = new Produto();

            produto.Nome = "Secador de Cabelo";
            produto.Preco = 159.21m;
            produto.Estoque = 2;
            produto.Categoria = _db.Categorias.Where(c => c.Id == 3).First();

            _db.Produtos.Add(produto);
            _db.SaveChanges(); 
        }

        [TestMethod]
        public void EditarProdutoTest()
        {
            var produto = _db.Produtos.Where(p => p.Id == 2).First();

            produto.Nome = "Playstation 4";
            produto.Preco = 2500.00m;

            _db.SaveChanges();
        }

        [TestMethod]
        public void ExcluirProdutoTest()
        {
            var produto = _db.Produtos.Single(p => p.Id == 4);

            _db.Produtos.Remove(produto);
            _db.SaveChanges();
        }

        [TestMethod]
        public void LazyLoadEnableTest()
        {
            var produto = _db.Produtos.Single(p => p.Id == 1);

            Console.WriteLine($"Produto: {produto.Nome} - Categoria: {produto.Categoria.Nome}" );
        }

        [TestMethod]
        public void IncludeTest()
        {
            var produto = _db.Produtos.Include(p => p.Categoria).Single(c => c.Id == 2);

            Assert.IsTrue(produto.Categoria.Nome == "Perfumaria");
        }

        [TestMethod]
        public void QueryableTest()
        {
            //Where e OrderBy não disparam consulta no banco.
            var query = _db.Produtos.Where(p => p.Preco > 10);

            if (query != null)
            {
                query = query.OrderBy(p => p.Preco);
            }


            //First dispara consulta no banco e retorna o primeiro.
            var primeiro = query.First();

            //Single dispara consulta no banco e retorna um unico resultado.
            var unico = query.Single();

            //Last dispara consulta no banco e retorna o ultimo resultado.
            var ultimo = query.Last();

            //ToList dispara consulta no banco e retorna todos.
            var todos = query.ToList();


        }
    }
}