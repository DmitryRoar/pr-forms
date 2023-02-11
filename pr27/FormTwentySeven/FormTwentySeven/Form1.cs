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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace FormTwentySeven
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = richTextBox1.Text.Trim().Split('\n').Length - 1;
            label3.Text = count.ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            RichTextBox el = sender as RichTextBox;
            if ((!System.Text.RegularExpressions.Regex.IsMatch(el.Text, @"^\D+$")) && el.Text != "")
            {
                el.Text = el.Text.Remove(el.Text.Length - 1);
                el.SelectionStart = el.Text.Length;
            }
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter("data.txt");
            writer.Write(richTextBox1.Text);
            writer.Close();

            MessageBox.Show("Текст успешно сохранен!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextReader reader = new StreamReader("data.txt");
            string txt = reader.ReadToEnd();
            reader.Close();
            richTextBox1.Text = txt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // first new System.Drawing.Point(30, 311)
            // second new System.Drawing.Point(30, 353)

            Label searchEl = this.Controls["searchMock"] as Label;
            Label output = this.Controls["removeMock"] as Label;
            if (searchEl.Text.Length > 0)
            {
                output.Location = new System.Drawing.Point(30, 353);
            } else
            {
                output.Location = new System.Drawing.Point(30, 311);
            } 
            output.Text = "";
            TextReader reader = new StreamReader("data.txt");
            Regex myR = new Regex(@"\b" + textBox2.Text.Trim() + @"\w+\b", RegexOptions.IgnoreCase);
            string txt = reader.ReadToEnd(), newStr = "";

            List<int> removedLinesList = new List<int>();
            string[] lines = txt.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] words = line.Split(' ');
                for (int j = 0; j < words.Length; j++)
                {
                    string word = words[j];
                    if (!myR.IsMatch(word.Trim()))
                    {
                        newStr += (j+ 1) == word.Length ? word : word + " ";
                    } else
                    {
                        removedLinesList.Add(i);
                    }
                    
                }
                newStr += "\n";
            }

            int[] removedLines = removedLinesList.Distinct().ToArray();

            output.Text = "Номера строк, в которых было произведено\nудаление: ";

            foreach (int idx in removedLines)
            {
                output.Text += $"{idx + 1}, ";
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, KeyEventArgs e)
        {
            TextBoxBase el = sender as TextBoxBase;
            if (el.Text.Split(' ').Length > 1)
            {
                el.ReadOnly = true;
            }
            if (e.KeyCode == Keys.Back)
            {
                el.ReadOnly = false;
                el.Text = "";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Label removeEl = this.Controls["removeMock"] as Label;
            Label output = this.Controls["searchMock"] as Label;
            output.Text = "";
            // first new System.Drawing.Point(30, 311)
            // second new System.Drawing.Point(30, 353)

            if (removeEl.Text.Length > 0)
            {
                output.Location = new System.Drawing.Point(30, 353);
            }
            else
            {
                output.Location = new System.Drawing.Point(30, 311);
            }

            TextBoxBase el = this.textBox1 as TextBoxBase;
            TextReader reader = new StreamReader("data.txt");
            Regex myR = new Regex(@"^\b" + el.Text.Trim() + @"\b", RegexOptions.IgnoreCase);
            string txt = reader.ReadToEnd();

            List<int> removedLinesList = new List<int>();
            string[] lines = txt.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] words = line.Split(' ');
                for (int j = 0; j < words.Length; j++)
                {
                    string word = words[j];
                    if (myR.IsMatch(word.Trim()))
                    {
                        removedLinesList.Add(i);
                    }

                }
            }
            reader.Close();

            int[] removedLines = removedLinesList.Distinct().ToArray();

            if (removedLines.Length > 0)
            {
                richTextBox3.ForeColor = Color.Green;
                output.Text += "Номера строк текста, в которых содержится за\nданное пользователем слово: ";
                richTextBox3.ForeColor = Color.Black;

                foreach (int idx in removedLines)
                {
                    output.Text += $"{idx + 1}, ";
                }
            }
        }

        private void boldClick(object sender, EventArgs e)
        {
            Font oldFont; Font newFont;
            oldFont = this.richTextBox1.SelectionFont;
            if (oldFont.Bold) newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
            this.richTextBox1.SelectionFont = newFont;
            this.richTextBox1.Focus();
        }

        private void italicClick(object sender, EventArgs e)
        {
            Font oldFont; Font newFont;
            oldFont = this.richTextBox1.SelectionFont;
            if (oldFont.Italic) newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            else newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);
            this.richTextBox1.SelectionFont = newFont;
            this.richTextBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
