using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataGridViewButtonColumn buttonColumn =
                new DataGridViewButtonColumn();

            DataGridTextBox textBoxCololumn =
                new DataGridTextBox();

            buttonColumn.Name = "data";
            buttonColumn.Text = "Заполните, пожалуйста, ячейки";

            // Use the Text property for the button text for all cells rather
            // than using each cell's value as the text for its own button.
            buttonColumn.UseColumnTextForButtonValue = true;

            // Add the button column to the control.

            this.dataGridView1.ColumnCount = 6;
            this.dataGridView1.RowCount = 7;

            this.dataGridView1.Rows.Insert(0, buttonColumn);
            this.dataGridView1.Rows[0].Text = "Заполните, пожалуйста, ячейки";
        }
    }
}
