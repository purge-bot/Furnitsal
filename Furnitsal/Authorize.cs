using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Net.Sockets;
using Furnitsal.Cript;
using DbQuery;
using TCPInteraction;
using Furnitsal.DbCommander;

namespace Furnitsal
{
    public partial class Authorize : Form
    {
        /// <summary> Создание подключения к БД и аутентификация  </summary>
        private void Login(string login, string password, string ip = "127.0.0.1", string port = "5432")
        {
            if (client == null)
            {
                TcpClient socket = new TcpClient("192.168.1.68", 7000);
                client = new TCPInteraction.Client(socket);
            }

            _user = new User(client);
            if (_user.Verification(login, password))
            {
                WindowClose();
            }
            else
            {
                AuthorizeError();
            }
            
        }

        /// <summary> Закрытие окна </summary>
        private void WindowClose()
        {
            canClosingWindow = true;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary> Обработчик ошибки аутентификации </summary>
        private void AuthorizeError()
        {
            client = null;

            PasswordTextBox.Clear();
            
            AuthorizeErrorLabel.Text = "Неверный логин или пароль";
            AuthorizeErrorLabel.Visible = true;

            LoginPanel.BackColor = Color.Red;
            PasswordPanel.BackColor = Color.Red;

            if (LoginTextBox.Text == "")
                ActiveControl = LoginTextBox;
            else
                ActiveControl = PasswordTextBox;
        }

        private static void SaveSettings(string login, string ip, string port, string fileName)
        {
            if (!File.Exists($"Settings/{fileName}.xml"))
            {
                XmlTextWriter textWriter = new XmlTextWriter($"Settings/{fileName}.xml", null);
                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("Win");
                textWriter.WriteEndElement();
                textWriter.Close();
            }

                XmlDocument userSettings = new XmlDocument();
                userSettings.Load($"Settings/{fileName}.xml");
                XmlElement subRoot = userSettings.DocumentElement;

                subRoot.RemoveAll();
                userSettings.Save($"Settings/{fileName}.xml");

                userSettings.Load($"Settings/{fileName}.xml");
                subRoot = userSettings.CreateElement("Login");
                subRoot.InnerText = login;
                userSettings.DocumentElement.AppendChild(subRoot);
                subRoot = userSettings.CreateElement("IP");
                subRoot.InnerText = ip;
                userSettings.DocumentElement.AppendChild(subRoot);
                subRoot = userSettings.CreateElement("Port");
                subRoot.InnerText = port;
                userSettings.DocumentElement.AppendChild(subRoot);
                userSettings.Save($"Settings/{fileName}.xml");
        }

        private void ReadSettings()
        { 
            if (File.Exists("Settings/User_settings.xml"))
                settingsFileName = "User_settings";

            XmlDocument settings = new XmlDocument();
            
            settings.Load($"Settings/{settingsFileName}.xml");

            XmlElement subRoot = settings.DocumentElement;

            foreach (XmlElement element in subRoot)
            {
                if(element.Name == "IP")
                {
                    ip = element.ChildNodes.Item(0).Value;
                    continue;
                }
                else if (element.Name == "Port")
                {
                    port = element.ChildNodes.Item(0).Value;
                    continue;
                }
            }     
        }

        public User _user;
        private string ip;
        private string port;
        private string settingsFileName = "Default_settings";
        TCPInteraction.Client client;


        /// <summary> Возможность закрытия окна, по умолчанию false </summary>
        private bool canClosingWindow = false;

        public Authorize(User user)
        {
            InitializeComponent();
            this.KeyPreview = true;
            AuthorizeErrorLabel.Hide();

            if (!Directory.Exists("Settings"))
                Directory.CreateDirectory("Settings");

            if (!File.Exists($"Settings/{settingsFileName}.xml"))
            {
                XmlTextWriter textWriter = new XmlTextWriter($"Settings/{settingsFileName}.xml", null);
                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("Win");
                textWriter.WriteEndElement();
                textWriter.Close();
            }

            _user = user;
        }

        private void Authorize_Load(object sender, EventArgs e)
        {
            ActiveControl = LoginTextBox;
            ReadSettings();
            IpTextBox.Text = ip;
            PortTextBox.Text = port;
        }

        private void Authorize_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !canClosingWindow;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            canClosingWindow = true;
            Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            string ip = IpTextBox.Text;
            string port = PortTextBox.Text;

            if (IpTextBox.Visible)
                Login(login, password, ip, port);
            else
                Login(login, password);
        }

        private void Authorize_KeyDown(object sender, KeyEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            string ip = IpTextBox.Text;
            string port = PortTextBox.Text;

            if (e.KeyData == Keys.Enter)
            {
                if (IpTextBox.Visible)
                    Login(login, password, ip, port);
                else
                    Login(login, password);
            }
            if (e.KeyData == Keys.Escape)
            {
                canClosingWindow = true;
                Application.Exit();
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            IpTextBox.Visible = true;
            IpLabel.Visible = true;

            PortTextBox.Visible = true;
            PortLabel.Visible = true;

            SaveSettingsButton.Visible = true;
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string ip = IpTextBox.Text;
            string port = PortTextBox.Text;

            if (!File.Exists($"Settings/Default_settings.xml"))
            {
                SaveSettings(login, ip, port, "Default_settings");
            }
            else
            {
                SaveSettings(login, ip, port, "User_settings");
            }
        }
    }
}
