﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_5
{
    public partial class _4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labeldate.Text = DateTime.Now.Second.ToString();
        }
    }
}