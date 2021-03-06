﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ASP.NET_ECOMMERCE.DataContext;
using ASP.NET_ECOMMERCE.DataProvider;
using ASP.NET_ECOMMERCE.Models;
using Microsoft.Ajax.Utilities;

namespace ASP.NET_ECOMMERCE.Controllers
{
    public class ProducersController : Controller
    {

        private readonly IProducerDataProvider _producerDataProvider;

        public ProducersController(IProducerDataProvider producerDataProvider)
        {
            _producerDataProvider = producerDataProvider;
        }

        public ActionResult Index()
        {
            return View(_producerDataProvider.GetAllProducers().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producer = _producerDataProvider.GetProducerById(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producer producer)
        {
            if (ModelState.IsValid)
            {
                _producerDataProvider.SaveProducer(producer);
                return RedirectToAction("Index");
            }

            return View(producer);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producer = _producerDataProvider.GetProducerById(id);
            if (producer == null)
            {
                return HttpNotFound();
            }

            return View(producer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producer producer)
        {
            if (ModelState.IsValid)
            {
                _producerDataProvider.SaveProducer(producer);
                return RedirectToAction("Index");
            }

            return View(producer);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producer = _producerDataProvider.GetProducerById(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _producerDataProvider.DeleteProducer(id);
            return RedirectToAction("Index");
        }



















        //private EcommerceDataContext db = new EcommerceDataContext();

        //// GET: Producers
        //public ActionResult Index()
        //{
        //    return View(db.Producers.ToList());
        //}

        //// GET: Producers/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Producer producer = db.Producers.Find(id);
        //    if (producer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(producer);
        //}

        //// GET: Producers/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Producers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name")] Producer producer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Producers.Add(producer);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(producer);
        //}

        //// GET: Producers/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Producer producer = db.Producers.Find(id);
        //    if (producer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(producer);
        //}

        ////POST: Producers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name")] Producer producer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(producer).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(producer);
        //}

        //// GET: Producers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Producer producer = db.Producers.Find(id);
        //    if (producer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(producer);
        //}

        //// POST: Producers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Producer producer = db.Producers.Find(id);
        //    db.Producers.Remove(producer);
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
