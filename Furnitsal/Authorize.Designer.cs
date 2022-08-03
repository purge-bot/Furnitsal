
namespace Furnitsal
{
    partial class Authorize
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
            this.exitButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AuthorizeErrorLabel = new System.Windows.Forms.Label();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.PasswordPanel = new System.Windows.Forms.Panel();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.IpTextBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.IpLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.LoginPanel.SuspendLayout();
            this.PasswordPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(196, 249);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(124, 32);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Закрыть";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(12, 249);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(124, 32);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Войти";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.BackColor = System.Drawing.Color.White;
            this.LoginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginTextBox.Location = new System.Drawing.Point(1, 1);
            this.LoginTextBox.MaxLength = 19;
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(304, 29);
            this.LoginTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTextBox.Location = new System.Drawing.Point(1, 1);
            this.PasswordTextBox.MaxLength = 19;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(304, 29);
            this.PasswordTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(8, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя пользователя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль";
            // 
            // AuthorizeErrorLabel
            // 
            this.AuthorizeErrorLabel.AutoSize = true;
            this.AuthorizeErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AuthorizeErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.AuthorizeErrorLabel.Location = new System.Drawing.Point(13, 19);
            this.AuthorizeErrorLabel.Name = "AuthorizeErrorLabel";
            this.AuthorizeErrorLabel.Size = new System.Drawing.Size(163, 16);
            this.AuthorizeErrorLabel.TabIndex = 6;
            this.AuthorizeErrorLabel.Text = "Информация об ошибке";
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LoginPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LoginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginPanel.Controls.Add(this.LoginTextBox);
            this.LoginPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LoginPanel.Location = new System.Drawing.Point(12, 71);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(308, 33);
            this.LoginPanel.TabIndex = 7;
            // 
            // PasswordPanel
            // 
            this.PasswordPanel.BackColor = System.Drawing.SystemColors.Control;
            this.PasswordPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PasswordPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordPanel.Controls.Add(this.PasswordTextBox);
            this.PasswordPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PasswordPanel.Location = new System.Drawing.Point(12, 137);
            this.PasswordPanel.Name = "PasswordPanel";
            this.PasswordPanel.Size = new System.Drawing.Size(308, 33);
            this.PasswordPanel.TabIndex = 8;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Image = global::Furnitsal.Properties.Resources.Icon_Settings;
            this.SettingsButton.Location = new System.Drawing.Point(12, 194);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(32, 32);
            this.SettingsButton.TabIndex = 9;
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // IpTextBox
            // 
            this.IpTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IpTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.IpTextBox.Location = new System.Drawing.Point(50, 196);
            this.IpTextBox.Name = "IpTextBox";
            this.IpTextBox.Size = new System.Drawing.Size(126, 29);
            this.IpTextBox.TabIndex = 10;
            this.IpTextBox.Text = "127.0.0.1";
            this.IpTextBox.Visible = false;
            // 
            // PortTextBox
            // 
            this.PortTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PortTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.PortTextBox.Location = new System.Drawing.Point(185, 197);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(88, 29);
            this.PortTextBox.TabIndex = 11;
            this.PortTextBox.Text = "5432";
            this.PortTextBox.Visible = false;
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IpLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.IpLabel.Location = new System.Drawing.Point(47, 177);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(20, 16);
            this.IpLabel.TabIndex = 12;
            this.IpLabel.Text = "IP";
            this.IpLabel.Visible = false;
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PortLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.PortLabel.Location = new System.Drawing.Point(182, 177);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(41, 16);
            this.PortLabel.TabIndex = 13;
            this.PortLabel.Text = "Порт";
            this.PortLabel.Visible = false;
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Location = new System.Drawing.Point(288, 197);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(32, 29);
            this.SaveSettingsButton.TabIndex = 14;
            this.SaveSettingsButton.UseVisualStyleBackColor = true;
            this.SaveSettingsButton.Visible = false;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // Authorize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 291);
            this.Controls.Add(this.SaveSettingsButton);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.IpLabel);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.IpTextBox);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.PasswordPanel);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.AuthorizeErrorLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(800, 799);
            this.Name = "Authorize";
            this.Text = "Authorize";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Authorize_FormClosing);
            this.Load += new System.EventHandler(this.Authorize_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Authorize_KeyDown);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.PasswordPanel.ResumeLayout(false);
            this.PasswordPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label AuthorizeErrorLabel;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Panel PasswordPanel;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.TextBox IpTextBox;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Button SaveSettingsButton;
    }
}