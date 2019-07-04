using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        ServiceHost host;
        public Form1()
        {
            InitializeComponent();
            this.host = new ServiceHost(typeof(WcfServiceLibrary.Service1));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.host.Open();
        }
    }
}
