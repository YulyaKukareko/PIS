using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab6_WebServices_
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SW.KYAServicesSoapClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.client = new SW.KYAServicesSoapClient();
        }

        protected void but_sum_Click(object sender, EventArgs e)
        {
            result.Text = this.client.Sum(Int32.Parse(x.Text), Int32.Parse(y.Text)).ToString();
        }

        protected void but_sub_Click(object sender, EventArgs e)
        {
            result.Text = this.client.Sub(Int32.Parse(x.Text), Int32.Parse(y.Text)).ToString();
        }

        protected void but_mul_Click(object sender, EventArgs e)
        {
            result.Text = this.client.Mul(Int32.Parse(x.Text), Int32.Parse(y.Text)).ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            resultS.Text = this.client.Get();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.client.Add(s.Text);
        }
    }
}