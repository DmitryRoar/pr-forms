using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTwentySix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += textBox1_KeyPress;
            textBox3.KeyPress += textBox3_KeyPress;
            textBox4.KeyPress += textBox4_KeyPress;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }


        private double getResult(double a, double b, double x)
        {
            
            return ( Math.Pow(x+a, 2) )/( Math.Sqrt( 3 * Math.Sqrt(x) + a - (1/3) * Math.Pow(b, 2) ) );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text, b = textBox3.Text, x = textBox4.Text;
            label6.Text = "";
            (sender as Button).Enabled = true;
            if (b.StartsWith("-"))
            {
                label6.Text = "Значение x не может быть\nотрицательным";
                return;
            }
            if (a == "" || b == "" || x == "")
            {
                label6.Text = "Должны быть заполнены\nвсе поля";
            } 
            else
            {
                
                textBox2.Text = Math.Round(getResult(double.Parse(a), double.Parse(b), double.Parse(x)), 2).ToString();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textBox3.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            textBox4.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox3.Focus();
            }

            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar))
        && (e.KeyChar != ',') && (e.KeyChar != '-'))
                e.Handled = true;

            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
                e.Handled = true;

            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox4.Focus();
            }

            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar))
        && (e.KeyChar != ','))
                e.Handled = true;

            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
                e.Handled = true;

            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1.Focus();
            }

            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar))
       && (e.KeyChar != ',') && (e.KeyChar != '-'))
                e.Handled = true;

            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
                e.Handled = true;

            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
