using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers.WellComePage
{
    public class WellComeController : Controller
    {
        //
        // GET: /WellCome/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /WellCome/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /WellCome/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WellCome/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /WellCome/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /WellCome/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /WellCome/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /WellCome/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
