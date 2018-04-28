using Loja.Domain;
using Loja.Mvc.Models;
using Loja.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Controllers
{
    public class CategoriasController : Controller
    {
        private LojaDbContext db = new LojaDbContext();

        #region List
        // GET: Categorias
        public ActionResult Index()
        {
            return View(Mapear(db.Categorias.ToList()));
        }

        private List<CategoriaViewModel> Mapear(List<Categoria> categorias)
        {
            var viewModel = new List<CategoriaViewModel>();
            foreach (var categoria in categorias)
            {
                viewModel.Add(Mapear(categoria));
            }
            return viewModel;
        }

        private CategoriaViewModel Mapear(Categoria categoria)
        {
            var categoriaView = new CategoriaViewModel();

            categoriaView.Id = categoria.Id;
            categoriaView.Nome = categoria.Nome;
  
            return categoriaView;
        }
        #endregion

        #region List By Id
        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaViewModel categoria = Mapear(db.Categorias.Find(id));
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        #endregion

        #region Create
        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View(Mapear(new Categoria()));
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(Mapear(viewModel));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        private Categoria Mapear(CategoriaViewModel viewModel)
        {
            var categoria = new Categoria();
            categoria.Id = viewModel.Id;
            categoria.Nome = viewModel.Nome;
 
            return categoria;
        }
        #endregion

        #region Edit
        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaViewModel categoria = Mapear(db.Categorias.Find(id));
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var categoria = db.Categorias.Find(viewModel.Id);
                Mapear(viewModel, categoria);
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        private void Mapear(CategoriaViewModel viewModel, Categoria categoria)
        {
            db.Entry(categoria).CurrentValues.SetValues(viewModel);
        }
        #endregion

        #region Delete
        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaViewModel categoria = Mapear(db.Categorias.Find(id));
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            db.Categorias.Remove(categoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}