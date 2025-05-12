using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlowVibesDemo.Controller;

namespace SlowVibesDemo
{
    public partial class Precio : Form
    {
        public Precio()
        {
            InitializeComponent();
            InventoryController controller = new InventoryController(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
