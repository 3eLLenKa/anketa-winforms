using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private string fName;
        private string sName;
        private string email;
        private string phoneNumber;

        private int temp = 1;

        private List<string> data;

        private void button1_Click(object sender, EventArgs e)
        {
            if (check())
            {
                fName = "Имя: " + textBox1.Text;
                sName = "Фамилия: " + textBox2.Text;
                email = "Почта: " + textBox3.Text;
                phoneNumber = "Телефон: " + textBox4.Text;

                data = new List<string>() { "Пользователь: " + temp, fName, sName ,email, phoneNumber, "\n" };

                for (int i = 0; i < data.Count; i++)
                {
                    listBox1.Items.Add(data[i]);
                }

                foreach (var item in this.Controls.OfType<TextBox>())
                {
                    item.Text = string.Empty;
                }
                temp++;
            }
            else MessageBox.Show("Данные заполнены неправильно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool check()
        {
            bool isChecked = true;

            foreach (var item in this.Controls.OfType<TextBox>())
            {
                if (item.Text == string.Empty)
                {
                    isChecked = false;
                    break;
                }
            }

            if (textBox3.Text.Contains("@mail.ru") == false)
            {
                isChecked = false;
            }

            if (textBox4.Text.Contains("+7") == true & textBox4.Text.Length == 12)
            {
                for (int i = 1; i < textBox4.Text.Length; i++)
                {
                    if (char.IsNumber(textBox4.Text[i]) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
            }
            else isChecked = false;

            return isChecked;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString().Contains("Пользователь"))
            {
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
            }
            else
            {
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;

            int count = listBox1.SelectedIndex + 1;

            foreach (var item in this.Controls.OfType<TextBox>().Reverse())
            {
                item.Text = listBox1.Items[count].ToString();
                {
                    item.Text = item.Text.Replace("Имя: ", "");
                    item.Text = item.Text.Replace("Фамилия: ", "");
                    item.Text = item.Text.Replace("Почта: ", "");
                    item.Text = item.Text.Replace("Телефон: ", "");
                }
                count++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = listBox1.SelectedIndex;
            var res = openFileDialog1.ShowDialog();
            string filePath;

            if (res == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                StreamWriter writer = new StreamWriter(filePath);

                for (int i = 0; i < 5; i++)
                {
                    writer.WriteLine(listBox1.Items[count]);
                    count++;
                }
                writer.Close();
                MessageBox.Show("Успешно!", "Инфа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (check())
            {
                fName = "Имя: " + textBox1.Text;
                sName = "Фамилия: " + textBox2.Text;
                email = "Почта: " + textBox3.Text;
                phoneNumber = "Телефон: " + textBox4.Text;

                data = new List<string>() { fName, sName, email, phoneNumber, "\n" };
                int count = listBox1.SelectedIndex + 1;

                foreach (var item in this.Controls.OfType<TextBox>())
                {
                    item.Text = string.Empty;
                }

                for (int i = 0; i < data.Count; i++)
                {
                    listBox1.Items[count] = data[i];
                    count++;
                }
                button4.Visible = false;
                button1.Visible = true;
            }
            else MessageBox.Show("Данные заполнены неправильно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}