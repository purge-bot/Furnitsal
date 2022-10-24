using DbQuery;
using Furnitsal.DbCommander;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPInteract;

namespace Furnitsal
{
    public partial class MainForm : Form
    {
        public User user;
        private DataTable _tableOrders;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Authorize authorizeForm = new Authorize(user);
            DialogResult dialogResult = authorizeForm.ShowDialog(this);
            user = authorizeForm._user;
        }

        private void OrdersListMenu_Click(object sender, EventArgs e)
        {
            Query query = new Query();
            TableQuery exec = new TableQuery(user.Connection, (byte)ExecuteCode.Get);
            query.AddSql("Select * from orders");
            query.Execute(exec);

            _tableOrders = query.TableResult;
            UserProject_dataGrid.DataSource = _tableOrders;
            
        }

        private void Add_button_Click(object sender, EventArgs e)
        {

        }

        private void UserProject_dataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_tableOrders.Rows.Count == 0 || _tableOrders.Rows.Count < e.RowIndex)
                return;

            int id = _tableOrders.Rows[e.RowIndex].Field<int>("id");

            MessageBox.Show(id.ToString());

            OrderForm order = new OrderForm(user, id);
            DialogResult dialogResult = order.ShowDialog(this);
            
        }
    }
}
