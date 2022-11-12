using Furnitsal.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Furnitsal.ProductForms
{
    public partial class DivanForm : Form
    {
        public Divan divan;

        public DivanForm(string type_name)
        {
            InitializeComponent();

            divan = new Divan();
            divan.type_name = type_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            divan.product_name = ProductName_textBox.Text;
            divan.length = Convert.ToInt32(Length_textBox.Text);
            divan.width = Convert.ToInt32(Width_textBox.Text);
            divan.edge_size = Convert.ToDouble(EdgeSize_textBox.Text);
            divan.softness_name = EdgeSize_textBox.Text;
            divan.textile_name = Textile_textBox.Text;
            divan.mechanism = Mechanism_textBox.Text;
            divan.quantity = Convert.ToInt32(Quantity_textBox.Text);
            divan.fasteners_type = Fastener_textBox.Text;
            divan.back_degree = Convert.ToInt32(BackDegree_textBox.Text);
            this.DialogResult = DialogResult.OK;
        }
    }
}
