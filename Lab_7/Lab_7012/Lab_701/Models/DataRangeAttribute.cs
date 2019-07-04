using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_701.Models
{
    public class DataRangeAttribute : RangeAttribute
    {
        public DataRangeAttribute(int addYear) : base(typeof(DateTime),
                DateTime.Now.AddYears(addYear).ToShortDateString(),
                DateTime.Now.ToShortDateString())
        { }
    }
}