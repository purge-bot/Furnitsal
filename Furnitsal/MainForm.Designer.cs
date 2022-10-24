
namespace Furnitsal
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuTool = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdersListMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.UserProject_dataGrid = new System.Windows.Forms.DataGridView();
            this.Add_button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserProject_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.ViewMenuTool});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // ViewMenuTool
            // 
            this.ViewMenuTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OrdersListMenu});
            this.ViewMenuTool.Name = "ViewMenuTool";
            this.ViewMenuTool.Size = new System.Drawing.Size(76, 20);
            this.ViewMenuTool.Text = "Просмотр";
            // 
            // OrdersListMenu
            // 
            this.OrdersListMenu.Name = "OrdersListMenu";
            this.OrdersListMenu.Size = new System.Drawing.Size(207, 22);
            this.OrdersListMenu.Text = "Открыть список заказов";
            this.OrdersListMenu.Click += new System.EventHandler(this.OrdersListMenu_Click);
            // 
            // UserProject_dataGrid
            // 
            this.UserProject_dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UserProject_dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserProject_dataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserProject_dataGrid.Location = new System.Drawing.Point(0, 51);
            this.UserProject_dataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.UserProject_dataGrid.Name = "UserProject_dataGrid";
            this.UserProject_dataGrid.RowHeadersWidth = 51;
            this.UserProject_dataGrid.RowTemplate.Height = 24;
            this.UserProject_dataGrid.Size = new System.Drawing.Size(600, 315);
            this.UserProject_dataGrid.TabIndex = 1;
            this.UserProject_dataGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UserProject_dataGrid_CellMouseDoubleClick);
            // 
            // Add_button
            // 
            this.Add_button.Location = new System.Drawing.Point(12, 23);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(75, 23);
            this.Add_button.TabIndex = 2;
            this.Add_button.Text = "Добавить";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.Add_button);
            this.Controls.Add(this.UserProject_dataGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserProject_dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuTool;
        private System.Windows.Forms.ToolStripMenuItem OrdersListMenu;
        private System.Windows.Forms.DataGridView UserProject_dataGrid;
        private System.Windows.Forms.Button Add_button;
    }
}