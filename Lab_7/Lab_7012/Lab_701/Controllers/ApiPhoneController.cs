using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab_701.Models;

namespace Lab_701.Controllers
{
    public class ApiPhoneController : ApiController
    {
        private Context context = new Context();

        public JsonResult<List<Person>> Get()
        {
            var catalog = context.Catalog.ToList();
            return Json(catalog);
        }

        public JsonResult<Person> Get(int id)
        {
            var catalog = context.Catalog.Where(x => x.ID == id).Single();
            return Json(catalog);
        }

        public JsonResult<Person> Post([FromBody]Person person)
        {
            context.Catalog.Add(person);
            context.SaveChanges();
            return Json(person);
        }

        public JsonResult<Person> Put([FromBody]Person person)
        {
            var per = context.Catalog.Find(person.ID);
            context.Entry(per).CurrentValues.SetValues(person);
            context.SaveChanges();
            return Json(person);
        }

        public JsonResult<int> Delete(int id)
        {
            var person = context.Catalog.Where(x => x.ID == id).Single();
            context.Catalog.Remove(person);
            context.SaveChanges();
            return Json(id);
        }
    }
}