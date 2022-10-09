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

namespace Furnitsal
{
    public partial class MainForm : Form
    {
        public User user;

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
            TableQuery exec = new TableQuery(user.Connection, 201);
            query.AddSql("Select * from managers");
            query.Execute(exec);

            dataGridView1.DataSource = query.TableResult;
            
        }
    }
}
