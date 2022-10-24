using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Furnitsal
{
    public partial class OrderForm : Form
    {
        private User _user;
        private int _idOrder;

        private void GetCustomer()
        {

        }

        public OrderForm(User user, int idOrder)
        {
            _user = user;
            _idOrder = idOrder;

            

            InitializeComponent();

        }
    }
}
