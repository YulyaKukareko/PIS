using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_5
{
    public partial class _5 : System.Web.UI.Page
    {
        private static string GetDate(HttpContext context)
        {
            return "<b>" + DateTime.Now.Second.ToString() + "</b>";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            labeldate.Text = DateTime.Now.Second.ToString();
        }
    }
}