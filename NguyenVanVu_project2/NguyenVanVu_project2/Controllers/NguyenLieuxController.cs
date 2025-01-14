﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NguyenVanVu_project2.Models;

namespace NguyenVanVu_project2.Controllers
{
    public class NguyenLieuxController : Controller
    {
        private NguyenVanVuK22CNT2Entities1 db = new NguyenVanVuK22CNT2Entities1();

        // GET: NguyenLieux
        public ActionResult Index()
        {
            var nguyenLieux = db.NguyenLieux.Include(n => n.SanPham);
            return View(nguyenLieux.ToList());
        }

        // GET: NguyenLieux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(id);
            if (nguyenLieu == null)
            {
                return HttpNotFound();
            }
            return View(nguyenLieu);
        }

        // GET: NguyenLieux/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.SanPhams, "id", "ten");
            return View();
        }

        // POST: NguyenLieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ten,so_luong,don_vi")] NguyenLieu nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                db.NguyenLieux.Add(nguyenLieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.SanPhams, "id", "ten", nguyenLieu.id);
            return View(nguyenLieu);
        }

        // GET: NguyenLieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(id);
            if (nguyenLieu == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.SanPhams, "id", "ten", nguyenLieu.id);
            return View(nguyenLieu);
        }

        // POST: NguyenLieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ten,so_luong,don_vi")] NguyenLieu nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguyenLieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.SanPhams, "id", "ten", nguyenLieu.id);
            return View(nguyenLieu);
        }

        // GET: NguyenLieux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(id);
            if (nguyenLieu == null)
            {
                return HttpNotFound();
            }
            return View(nguyenLieu);
        }

        // POST: NguyenLieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(id);
            db.NguyenLieux.Remove(nguyenLieu);
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
