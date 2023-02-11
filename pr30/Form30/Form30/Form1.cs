using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form30
{
    struct User
    {
        public string name;
        public string sex;
        public string phone;
    }

    public class Fine {
        User trigger;
        string car_passwrd;
        string type;
        string cost;
        string time;
        string date;
    }

    public partial class Form1 : Form
    {
        const int fineSize = 10;
        public Fine[] fines = new Fine[fineSize];

        public Form1()
        {
            InitializeComponent();

        }
    }
}
