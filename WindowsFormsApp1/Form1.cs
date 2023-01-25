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
    public partial class MainForm : Form
    {
        private OpenFileDialog ofd;
        private SaveFileDialog sfd;
     
        public MainForm()
        {
            InitializeComponent();
        }
     
        private void buttonResult_Click(object sender, EventArgs e)
        {
            int numericValue;
            if (int.TryParse(richTextBoxKey.Text, out numericValue))
            {
                if (Convert.ToInt32(richTextBoxKey.Text) < 0)
                {
                    string s = richTextBoxInput.Text;
                    int key = Convert.ToInt32(richTextBoxKey.Text);
                    if (richTextBoxKey.Text.Length < richTextBoxInput.Text.Length)
                    {

                        if (radioButtonEncode.Checked)
                        {
                            var gronsfeld = new GronsfeldCipher();
                            string a = gronsfeld.Gronspheld(s, key, 0);

                            richTextBoxOutput.Text = a;
                        }
                        else if (radioButtonDecode.Checked)
                        {
                            var gronsfeld = new GronsfeldCipher();
                            string a = gronsfeld.Gronspheld(s, key, 1);

                            richTextBoxOutput.Text = a;
                        }


                    }
                    else
                    {
                        MessageBox.Show("Ключ не может быть больше пароля");
                    }
                }
                else
                {
                    MessageBox.Show("Ключ введен не корректно");

                }
            }
            else
            {
                MessageBox.Show("Ключ введен не корректно");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            sfd = new SaveFileDialog();
            ofd = new OpenFileDialog();
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;
            string filename =sfd.FileName;
            System.IO.File.WriteAllText(filename, richTextBoxOutput.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = ofd.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBoxInput.Text = fileText;
            MessageBox.Show("Файл открыт");
     
        }
    }
}
