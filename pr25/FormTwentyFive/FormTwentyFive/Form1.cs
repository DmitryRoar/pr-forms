using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTwentyFive
{

    public partial class Form1 : Form
    {
        Font MediumFont = new Font("Arial", 10);
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Gray;
            label1.Font = MediumFont;
            label1.ForeColor = Color.Red;
            label2.ForeColor = Color.Red;
            label2.Font = MediumFont;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RichTextBox reklamaEl = richTextBox2;
            reklamaEl.Text = $"Добро пожаловаться, {textBox1.Text}!\n";
                reklamaEl.Text += "Представляем вашему вниманию Visual Studio! \n 5 причин выбрать именно эту IDE:\n";
                reklamaEl.Text += "* Поддержка нескольких языков программирования\n";
                reklamaEl.Text += "* Кроссплатформенная поддержка\n";
                reklamaEl.Text += "* Расширения и поддержка\n";
                reklamaEl.Text += "* Web-поддержка\n";
                reklamaEl.Text += "* Структура иерархии\n";
        }
    }
}
