using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Employee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            Employees[] employees = new Employees[4];

            employees[0] = new Employees();
            employees[1] = new FullTimeEmployees();
            employees[2] = new PartTimeEmployees();
            employees[3] = new TemporaryTimeEmployees();

            

            //this.Text = ;
            MessageBox.Show(employees[1].Rate(17.57M).ToString());
        }


    }
}
