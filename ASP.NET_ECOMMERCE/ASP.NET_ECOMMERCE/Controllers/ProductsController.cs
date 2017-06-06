using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ASP.NET_ECOMMERCE.DataContext;
using ASP.NET_ECOMMERCE.DataProvider;
using ASP.NET_ECOMMERCE.Models;

namespace ASP.NET_ECOMMERCE.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICategoryDataProvider _categoryDataProvider;
        private readonly IProducerDataProvider _producerDataProvider;
        private readonly IProductDataProvider _productDataProvider;

        public ProductsController(IProductDataProvider productDataProvider, IProducerDataProvider producerDataProvider, ICategoryDataProvider categoryDataProvider)
        {
            _producerDataProvider = producerDataProvider;
            _categoryDataProvider = categoryDataProvider;
            _productDataProvider = productDataProvider;
        }

        public ActionResult Index()
        {
            return View(_productDataProvider.GetAllProducts().ToList());
        }

        public ActionResult Details(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productDataProvider.GetProductByName(name);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryDataProvider.GetAllCategories(), "CategoryId", "Name");
            ViewBag.ProducerId = new SelectList(_producerDataProvider.GetAllProducers(), "ProducerId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                
                _productDataProvider.SaveProduct(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_categoryDataProvider.GetAllCategories(), "CategoryId", "Name");
            ViewBag.ProducerId = new SelectList(_producerDataProvider.GetAllProducers(), "ProducerId", "Name");
            return View(product);
        }

        public ActionResult Edit(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productDataProvider.GetProductByName(name);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_categoryDataProvider.GetAllCategories(), "CategoryId", "Name");
            ViewBag.ProducerId = new SelectList(_producerDataProvider.GetAllProducers(), "ProducerId", "Name");
            return View(product);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productDataProvider.SaveProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_categoryDataProvider.GetAllCategories(), "CategoryId", "Name");
            ViewBag.ProducerId = new SelectList(_producerDataProvider.GetAllProducers(), "ProducerId", "Name");
            return View(product);

        }

        public ActionResult Delete(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productDataProvider.GetProductByName(name);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string name)
        {
            var product = _productDataProvider.GetProductByName(name);
            //musisz sobie analogicznie napisac repozytoriumktore ci znajdzie po nazwie progudkt a nastepnie usunie (linq)
           // _productDataProvider.DeleteProduct(product.Name);
            return RedirectToAction("Index");
        }




        //private EcommerceDataContext db = new EcommerceDataContext();

        //// GET: Products
        //public ActionResult Index()
        //{
        //    var products = db.Products.Include(p => p.Category).Include(p => p.Producer);
        //    return View(products.ToList());
        //}

        //// GET: Products/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        //// GET: Products/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
        //    ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name");
        //    return View();
        //}

        //// POST: Products/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Price,CategoryId,ProducerId")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Products.Add(product);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
        //    ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", product.ProducerId);
        //    return View(product);
        //}

        //// GET: Products/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
        //    ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", product.ProducerId);
        //    return View(product);
        //}

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Price,CategoryId,ProducerId")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(product).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
        //    ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", product.ProducerId);
        //    return View(product);
        //}

        //// GET: Products/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    db.Products.Remove(product);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
