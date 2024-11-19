using ECart.DBAccess;
using ECart.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ECart.Controllers
{
    public class ProductController : Controller
    {
        private ECartDBContext db = new ECartDBContext();


        // GET: Product
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var products = db.ProductsTable.Include(p => p.Category)
                                      .OrderBy(p => p.ProductId)
                                      .Skip((page - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToList();

            var totalProducts = db.ProductsTable.Count();
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.CategoryTable, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.ProductsTable.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.CategoryTable, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryId = new SelectList(db.CategoryTable, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.CategoryTable, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.ProductsTable.Find(id);
            db.ProductsTable.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}