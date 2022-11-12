
namespace Furnitsal
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OrderStatus_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OrderSubmanager_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.OrderManager_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OrderId_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ClientExtraInfo_textBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ClientPhoneNumber_textBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ClientAddress_textBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ClientFullName_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Confirm_button = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DeleteProduct_button = new System.Windows.Forms.Button();
            this.ProductSelector_comboBox = new System.Windows.Forms.ComboBox();
            this.AddProduct_button = new System.Windows.Forms.Button();
            this.Products_dataGridView = new System.Windows.Forms.DataGridView();
            this.Empty_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Products_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Empty_errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.OrderStatus_textBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.OrderSubmanager_textBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.OrderManager_textBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.OrderId_label);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сведения о заказе";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(692, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "????";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(642, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Дата создания заказа";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // OrderStatus_textBox
            // 
            this.OrderStatus_textBox.Location = new System.Drawing.Point(453, 24);
            this.OrderStatus_textBox.Name = "OrderStatus_textBox";
            this.OrderStatus_textBox.Size = new System.Drawing.Size(100, 20);
            this.OrderStatus_textBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Статус";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // OrderSubmanager_textBox
            // 
            this.OrderSubmanager_textBox.Location = new System.Drawing.Point(313, 24);
            this.OrderSubmanager_textBox.Name = "OrderSubmanager_textBox";
            this.OrderSubmanager_textBox.Size = new System.Drawing.Size(100, 20);
            this.OrderSubmanager_textBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Соучастник";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // OrderManager_textBox
            // 
            this.OrderManager_textBox.Location = new System.Drawing.Point(169, 24);
            this.OrderManager_textBox.Name = "OrderManager_textBox";
            this.OrderManager_textBox.Size = new System.Drawing.Size(100, 20);
            this.OrderManager_textBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Менеджер";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // OrderId_label
            // 
            this.OrderId_label.AutoSize = true;
            this.OrderId_label.Location = new System.Drawing.Point(102, 27);
            this.OrderId_label.Name = "OrderId_label";
            this.OrderId_label.Size = new System.Drawing.Size(13, 13);
            this.OrderId_label.TabIndex = 14;
            this.OrderId_label.Text = "?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Номер Заказа:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ClientExtraInfo_textBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.ClientPhoneNumber_textBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.ClientAddress_textBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.ClientFullName_textBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 369);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Клиент";
            // 
            // ClientExtraInfo_textBox
            // 
            this.ClientExtraInfo_textBox.Location = new System.Drawing.Point(6, 289);
            this.ClientExtraInfo_textBox.Name = "ClientExtraInfo_textBox";
            this.ClientExtraInfo_textBox.Size = new System.Drawing.Size(188, 20);
            this.ClientExtraInfo_textBox.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 273);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Дополнительная информация";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ClientPhoneNumber_textBox
            // 
            this.ClientPhoneNumber_textBox.Location = new System.Drawing.Point(6, 212);
            this.ClientPhoneNumber_textBox.MaxLength = 64;
            this.ClientPhoneNumber_textBox.Name = "ClientPhoneNumber_textBox";
            this.ClientPhoneNumber_textBox.Size = new System.Drawing.Size(188, 20);
            this.ClientPhoneNumber_textBox.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Номер телефона";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ClientAddress_textBox
            // 
            this.ClientAddress_textBox.Location = new System.Drawing.Point(6, 134);
            this.ClientAddress_textBox.MaxLength = 128;
            this.ClientAddress_textBox.Name = "ClientAddress_textBox";
            this.ClientAddress_textBox.Size = new System.Drawing.Size(188, 20);
            this.ClientAddress_textBox.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Адрес";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ClientFullName_textBox
            // 
            this.ClientFullName_textBox.Location = new System.Drawing.Point(6, 59);
            this.ClientFullName_textBox.MaxLength = 128;
            this.ClientFullName_textBox.Name = "ClientFullName_textBox";
            this.ClientFullName_textBox.Size = new System.Drawing.Size(188, 20);
            this.ClientFullName_textBox.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "ФИО";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Confirm_button);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(200, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 54);
            this.panel1.TabIndex = 2;
            // 
            // Confirm_button
            // 
            this.Confirm_button.Location = new System.Drawing.Point(409, 19);
            this.Confirm_button.Name = "Confirm_button";
            this.Confirm_button.Size = new System.Drawing.Size(75, 23);
            this.Confirm_button.TabIndex = 11;
            this.Confirm_button.Text = "button1";
            this.Confirm_button.UseVisualStyleBackColor = true;
            this.Confirm_button.Click += new System.EventHandler(this.Confirm_button_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(490, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DeleteProduct_button);
            this.groupBox3.Controls.Add(this.ProductSelector_comboBox);
            this.groupBox3.Controls.Add(this.AddProduct_button);
            this.groupBox3.Controls.Add(this.Products_dataGridView);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(200, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(577, 315);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Состав заказа";
            // 
            // DeleteProduct_button
            // 
            this.DeleteProduct_button.Location = new System.Drawing.Point(490, 103);
            this.DeleteProduct_button.Name = "DeleteProduct_button";
            this.DeleteProduct_button.Size = new System.Drawing.Size(75, 23);
            this.DeleteProduct_button.TabIndex = 10;
            this.DeleteProduct_button.Text = "Удалить";
            this.DeleteProduct_button.UseVisualStyleBackColor = true;
            // 
            // ProductSelector_comboBox
            // 
            this.ProductSelector_comboBox.FormattingEnabled = true;
            this.ProductSelector_comboBox.Location = new System.Drawing.Point(421, 19);
            this.ProductSelector_comboBox.Name = "ProductSelector_comboBox";
            this.ProductSelector_comboBox.Size = new System.Drawing.Size(121, 21);
            this.ProductSelector_comboBox.TabIndex = 8;
            // 
            // AddProduct_button
            // 
            this.AddProduct_button.Location = new System.Drawing.Point(490, 74);
            this.AddProduct_button.Name = "AddProduct_button";
            this.AddProduct_button.Size = new System.Drawing.Size(75, 23);
            this.AddProduct_button.TabIndex = 9;
            this.AddProduct_button.Text = "Добавить";
            this.AddProduct_button.UseVisualStyleBackColor = true;
            this.AddProduct_button.Click += new System.EventHandler(this.AddProduct_button_Click);
            // 
            // Products_dataGridView
            // 
            this.Products_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Products_dataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.Products_dataGridView.Location = new System.Drawing.Point(3, 16);
            this.Products_dataGridView.Name = "Products_dataGridView";
            this.Products_dataGridView.Size = new System.Drawing.Size(412, 296);
            this.Products_dataGridView.TabIndex = 0;
            // 
            // Empty_errorProvider
            // 
            this.Empty_errorProvider.ContainerControl = this;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 430);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Products_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Empty_errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox OrderStatus_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox OrderSubmanager_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label OrderId_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ClientPhoneNumber_textBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ClientAddress_textBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ClientFullName_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ClientExtraInfo_textBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button DeleteProduct_button;
        private System.Windows.Forms.ComboBox ProductSelector_comboBox;
        private System.Windows.Forms.Button AddProduct_button;
        private System.Windows.Forms.DataGridView Products_dataGridView;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ErrorProvider Empty_errorProvider;
        private System.Windows.Forms.TextBox OrderManager_textBox;
        private System.Windows.Forms.Button Confirm_button;
    }
}