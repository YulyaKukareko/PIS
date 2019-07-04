using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_701.Models;

namespace Lab_701.Controllers
{
    public class PhoneController : Controller
    {
        Context db = new Context();

        public ActionResult Browse()
        {
            ViewBag.Catalog = db.Catalog;
            return View();
        }

        //ADD
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            try
            {
                db.Catalog.Add(person);
                db.SaveChanges();
                ViewBag.Catalog = db.Catalog;
                return View("Browse");
            }
            catch (Exception em)
            {
                db.Catalog.Remove(person);
                db.SaveChanges();
                ViewBag.Catalog = db.Catalog;
                ViewBag.err = em.Message;
                return View("Browse");
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Person = db.Catalog.SingleOrDefault(x => x.ID == id);
            return View();
        }

        [HttpPost]
        public ActionResult Update(Person person)
        {
            Person p = db.Catalog.SingleOrDefault(x => x.ID == person.ID);
            DateTime dT = p.BDay;
            try
            {
                p.Firstname = person.Firstname;
                p.Surname = person.Surname;
                p.Middlename = person.Middlename;
                p.Phone = person.Phone;
                p.BDay = person.BDay;
                db.SaveChanges();

                ViewBag.Catalog = db.Catalog;
                return View("Browse");
            }
            catch (Exception em)
            {
                p.BDay = dT;
                ViewBag.Catalog = db.Catalog;

                ViewBag.err = em.Message;
            }
            db.SaveChanges();
            return View("Browse");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Person p = db.Catalog.SingleOrDefault(x => x.ID == id);
                ViewBag.Person = db.Catalog.Remove(p);
                db.SaveChanges();

                ViewBag.Catalog = db.Catalog;
                return View("Browse");
            }
            catch (Exception em)
            {
                ViewBag.Catalog = db.Catalog;
                ViewBag.err = em.Message;
                return View("Browse");
            }
        }
    }
}