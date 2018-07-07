using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using Omu.ValueInjecter;

namespace MVC5Course.Controllers
{
    public class ProductsController : Controller
    {
        private FabricsEntities db = new FabricsEntities();

        public ProductsController()
        {
            //db.Configuration.LazyLoadingEnabled = false;
        }

        // GET: Products
        public ActionResult Index()
        {
            var data = db.Product.OrderByDescending(x => x.ProductId).Take(10).ToList();

            return View(data);
        }

        public ActionResult ProductsRead()
        {
            var data = db.Product
                .Where(x => x.Active == true)
                .OrderByDescending(x => x.ProductId)
                .Take(10).Select(x => new ViewModels.Products.ProductsReadViewModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    Stock = x.Stock
                }).ToList();

            return View(data);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductCreate(ViewModels.Products.ProductCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Product product = new Product
            {
                ProductName = viewModel.ProductName,
                Price = viewModel.Price,
                Stock = viewModel.Stock,
                Active = true
            };

            db.Product.Add(product);
            db.SaveChanges();

            return RedirectToAction("ReadProducts");
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult ProductUpdate(int id)
        {
            var product = db.Product.Find(id);

            ViewModels.Products.ProductUpdateViewModel viewModel = new ViewModels.Products.ProductUpdateViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Stock = product.Stock,
                Price = product.Price
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ProductUpdate(ViewModels.Products.ProductUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var product = db.Product.Find(viewModel.ProductId);
            //product.Price = viewModel.Price;
            //product.ProductName = viewModel.ProductName;
            //product.Stock = product.Stock;

            product.InjectFrom(viewModel);

            db.SaveChanges();


            return RedirectToAction("ProductsRead");
        }

        public ActionResult ProductDelete(int id)
        {
            var product = db.Product.Find(id);

            if (null == product)
            {
                return HttpNotFound();
            }

            db.Product.Remove(product);
            db.SaveChanges();


            return RedirectToAction("ProductsRead");
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
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
