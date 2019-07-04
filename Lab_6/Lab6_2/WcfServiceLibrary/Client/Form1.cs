using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        ServiceWCF.Service1Client client;
        public Form1()
        {
            InitializeComponent();
            this.client = new ServiceWCF.Service1Client();
            this.client.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result.Text = this.client.Sum(Int32.Parse(x.Text), Int32.Parse(y.Text)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result.Text = this.client.Sub(Int32.Parse(x.Text), Int32.Parse(y.Text)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            result.Text = this.client.ConCat(x.Text, y.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.client.Close();
        }

        private void y_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
