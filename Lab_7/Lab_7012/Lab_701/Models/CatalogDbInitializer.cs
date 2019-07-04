using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lab_701.Models
{   
    public class CatalogDbInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context db)
        {
            db.Catalog.Add(new Person { Phone = "1234567", Surname = "saz1", Firstname = "helen1", Middlename = "ser1", BDay = DateTime.Parse("03/11/1998") });
            db.Catalog.Add(new Person { Phone = "2345678", Surname = "saz2", Firstname = "helen2", Middlename = "ser2", BDay = DateTime.Parse("03/12/1998") });
            db.Catalog.Add(new Person { Phone = "3456789", Surname = "saz3", Firstname = "helen3", Middlename = "ser3", BDay = DateTime.Parse("03/10/1998") });

            base.Seed(db);
        }
    }
}