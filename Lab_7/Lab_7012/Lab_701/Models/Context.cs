using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lab_701.Models
{
    public class Context : DbContext
    {
        public DbSet<Person> Catalog { get; set; }
    }
}