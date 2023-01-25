using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormReg : Form
    {
        public FormReg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MyString = textBoxPassword1.Text;
            string MyString1 = textBoxLogin.Text;
            if (MyString.Contains(' ') == false && MyString1.Contains(' ') == false)
            {
                Database db = new Database("Data Source=dataBase.db;Version=3;");
                if (textBoxPassword1.Text.Length > 5 && textBoxLogin.Text.Length > 5)
                {
                    if (textBoxPassword1.Text == textBoxPassword2.Text)
                    {
                        string password = db.Hash(textBoxPassword1.Text);
                        if (db.CheckName(textBoxLogin.Text) == false)
                        {
                            db.createUser(textBoxLogin.Text, password);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким именем уже есть");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введенные пароли не совпадают");
                    }
                }
                else
                {
                    MessageBox.Show("Логин и пароль должны содержать больше 5 знаков");

                }
            }
            else
            {
                MessageBox.Show("Логин и пароль не должны содержать пробелы");
            }       
        }
    }
}
