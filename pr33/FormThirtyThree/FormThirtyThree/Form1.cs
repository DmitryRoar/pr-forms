using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormThirtyThree
{
    delegate int EventHandler(int[] arr);
    public partial class Form1 : Form
    {
        int[] data = new int[11];
        public Form1()
        {
            InitializeComponent();
        }


    }
}

class MyEvent
{
    public event EventHandler EventEmitter;
    public int OnSumFirstAndLastElements(int[] arr)
    {
        if (EventEmitter != null) return EventEmitter(arr);
        else return 0;
    }

    public int OnEvenLength()
    {

    }
}