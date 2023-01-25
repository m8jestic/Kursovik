using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {   
            Database db=new Database("Data Source=dataBase.db;Version=3;");
            if (textBoxLogin.Text == "" && textBoxPassword.Text == "")
                MessageBox.Show("Заполните все поля");
            else
            {
                string password = db.Hash(textBoxPassword.Text);
                if (db.ValidUser(textBoxLogin.Text, password))
                {
                    this.Hide();
                    var formMain = new MainForm();
                    formMain.Closed += (s, args) => this.Close();
                    formMain.Show();
                }
                else
                {
                    MessageBox.Show("Неверно введенные логин или пароль!");
                }
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form Reg = new FormReg();
            Reg.ShowDialog();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
