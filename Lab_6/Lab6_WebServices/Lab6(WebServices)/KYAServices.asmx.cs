using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Lab6_WebServices_
{
    /// <summary>
    /// Сводное описание для KYAServices
    /// </summary>
    [WebService(Namespace = "http://kya.by/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class KYAServices : System.Web.Services.WebService
    {

        private string s = "";

        [WebMethod(Description = "sum")]
        public int Sum(int x, int y)
        {
            return x + y;
        }

        [WebMethod(Description = "sub")]
        public int Sub(int x, int y)
        {
            return x - y;
        }

        [WebMethod(Description = "mul")]
        public int Mul(int x, int y)
        {
            return x * y;
        }

        [WebMethod(Description = "add", EnableSession = true)]
        public void Add(string x)
        {
            this.Session["s"] = x;
            this.Application["s"] = x;
        }

        [WebMethod(Description = "get", EnableSession = true)]
        public string Get()
        {
            if (this.Session["s"] != null)
                return this.Session["s"].ToString();
            else
                return "NotFound";
        }
    }
}
