using DbQuery;
using Furnitsal.DbCommander;
using Furnitsal.Models;
using Furnitsal.Models.Counterparty;
using Furnitsal.Models.Products;
using Furnitsal.ProductForms;
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
    public partial class OrderForm : Form
    {
        private User _user;
        private int _idOrder;
        public List<int> ProductsDB = new List<int>(); // Список продуктов, которые есть в БД на момент открытия формы
        public List<BaseProduct> AddedProducts = new List<BaseProduct>(); // Добавленные/измененные товары в данной сессии 
        public DataTable ProductTable;

        public Customer customer;
        public Order order;

        public Condition condition;

        public enum Condition
        {
            NewOrder,
            UpdateOrder
        }

        public OrderForm(User user, int idOrder = -1)
        {
            _user = user;
            _idOrder = idOrder;

            condition = idOrder >= 0 ? Condition.UpdateOrder : Condition.NewOrder;

            InitializeComponent();

            Query query = new Query();
            query.AddSql(Constants.GetProductType);
            query.Execute(new TableQuery(_user.Connection, (byte)ExecuteCode.Get));
            List<string> typesProd = new List<string>();
            foreach (DataRow row in query.TableResult.Rows)
            {
                typesProd.Add(row.Field<string>("тип товара"));
            }
            ProductSelector_comboBox.DataSource = typesProd;
            query.Clear();

            GetProductsInfo(query);

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            if (condition == Condition.NewOrder) return;

            Query query = new Query();

            GetOrderInfo(query);

            ClientAddress_textBox.Text = customer.address;
            ClientFullName_textBox.Text = customer.full_name;
            ClientPhoneNumber_textBox.Text = customer.phone_number;

            OrderManager_textBox.Text = order.manager_login;
            OrderSubmanager_textBox.Text = order.submanager_login;
            OrderStatus_textBox.Text = order.status_order;
            OrderId_label.Text = order.id.ToString();
        }

        private void GetProductsInfo(Query query)
        {
            query.AddSql(Constants.GetOrderProducts);
            query.AddParam("id_order", _idOrder);

            query.Execute(new TableQuery(_user.Connection, (byte)ExecuteCode.Get));
            ProductTable = query.TableResult;
            query.Clear();

            foreach (DataRow item in ProductTable.Rows)
            {
                ProductsDB.Add(item.Field<int>("артикль"));
            }

            ProductTable.Columns.Remove("артикль");

            Products_dataGridView.DataSource = ProductTable;
        }

        private void GetOrderInfo(Query query)
        {
            customer = new Customer();

            order = new Order();
            order.id = _idOrder;

            query.AddSql("Select orders.id, manager_login, submanager_login, id_client, status_order, address, full_name, phone_number from orders" +
                " join clients on clients.id = orders.id_client where orders.id = :id");
            query.AddParam("id", order.id);
            query.Execute(new TableQuery(_user.Connection, (byte)ExecuteCode.Get));
            DataRow orderRow = query.TableResult.Rows[0];
            customer.address = orderRow.Field<string>("адрес");
            customer.full_name = orderRow.Field<string>("ФИО");
            customer.phone_number = orderRow.Field<string>("телефон");
            customer.id = orderRow.Field<int>("id_client");

            order.id_client = customer.id;
            order.manager_login = orderRow.Field<string>("менеджер");
            order.submanager_login = orderRow.Field<string>("соучастник");
            order.status_order = orderRow.Field<string>("статус");
        }

        private void AddOrderConfirm()
        {
            NonQuery executor = new NonQuery(_user.Connection, (byte)ExecuteCode.Post);
            Query query = new Query();

            Customer cust = new Customer();
            cust.full_name = ClientFullName_textBox.Text;
            cust.phone_number = ClientPhoneNumber_textBox.Text;
            cust.address = ClientAddress_textBox.Text;
            cust.extra_info = ClientExtraInfo_textBox.Text;

            cust.Insert(query, executor);
            query.Clear();

            Order order = new Order();
            order.manager_login = _user.Login;
            order.status_order = OrderStatus_textBox.Text;
            order.id_client = cust.id;

            order.Insert(query, executor);
            query.Clear();

            OrderStructure ordStruct = new OrderStructure();
            ordStruct.id_order = order.id;

            foreach (BaseProduct item in AddedProducts)
            {
                item.Insert(query, executor);
                query.Clear();

                ordStruct.quantity = item.quantity;
                ordStruct.article = item.article;

                if (item is Divan)
                {
                    Divan divan = (Divan)item;
                    divan.Insert(query, executor);
                    query.Clear();
                }

                ordStruct.Insert(query, executor);
                query.Clear();
            }
        }

        private void UpdateOrderConfirm()
        {

        }

        private void AddProduct_button_Click(object sender, EventArgs e)
        {
            switch (ProductSelector_comboBox.Text)
            {
                case "диван":
                    using (DivanForm dForm = new DivanForm("диван"))
                    {
                    dForm.ShowDialog(this);
                    Divan addedDivan = dForm.divan;

                    if(dForm.DialogResult == DialogResult.OK)
                        {
                            AddedProducts.Add(addedDivan);
                            ProductTable.Rows.Add(addedDivan.length, addedDivan.width, addedDivan.edge_size, addedDivan.has_drawing, addedDivan.quantity);
                        }
                    }
                    break;
            }
        }

        private void Confirm_button_Click(object sender, EventArgs e)
        {
            switch (condition)
            {
                case Condition.NewOrder:
                    AddOrderConfirm();
                    break;
                case Condition.UpdateOrder:
                    UpdateOrderConfirm();
                    break;
            }
        }
    }
}
