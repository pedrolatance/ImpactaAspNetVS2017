using Loja.Domain;
using Loja.Mvc.Models;
using Loja.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Loja.Mvc.Controllers
{
    public class ProdutosController : Controller
    {
        private LojaDbContext db = new LojaDbContext();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(Mapear(db.Produtos.ToList()));
        }

        private List<ProdutoViewModel> Mapear(List<Produto> produtos)
        {
            var viewModel = new List<ProdutoViewModel>();
            foreach (var produto in produtos)
            {
                viewModel.Add(Mapear(produto));
            }
            return viewModel;
        }

        private ProdutoViewModel Mapear(Produto produto)
        {
            var produtoView = new ProdutoViewModel();

            produtoView.Id = produto.Id;
            produtoView.Nome = produto.Nome;
            produtoView.Preco = produto.Preco;
            produtoView.Estoque = produto.Estoque;
            produtoView.Ativo = produto.Ativo;

            produtoView.CategoriaId = produto.Categoria?.Id;
            produtoView.CategoriaNome = produto.Categoria?.Nome;
            produtoView.Categorias = Mapear(db.Categorias.ToList());

            return produtoView;
        }

        private List<SelectListItem> Mapear(List<Categoria> categorias)
        {
            return categorias.Select(c =>
            new SelectListItem { Text = c.Nome, Value = c.Id.ToString() }).ToList();
        }


        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoViewModel produto = Mapear(db.Produtos.Find(id));
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View(Mapear(new Produto()));
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(Mapear(viewModel));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        private Produto Mapear(ProdutoViewModel viewModel)
        {
            var produto = new Produto();
            produto.Id = viewModel.Id;
            produto.Nome = viewModel.Nome;
            produto.Preco = viewModel.Preco;
            produto.Estoque = viewModel.Estoque;
            produto.Ativo = viewModel.Ativo;
            produto.Categoria = db.Categorias.Find(viewModel.CategoriaId);
            return produto;
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoViewModel produto = Mapear(db.Produtos.Find(id));
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = db.Produtos.Find(viewModel.Id);
                Mapear(viewModel, produto);
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        private void Mapear(ProdutoViewModel viewModel, Produto produto)
        {
            db.Entry(produto).CurrentValues.SetValues(viewModel);

            produto.Categoria = db.Categorias.Find(viewModel.CategoriaId);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoViewModel produto = Mapear(db.Produtos.Find(id));
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
