using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BoulderCornBreadForWindows.RetrieveData;

namespace BoulderCornBreadForWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            BindGrid();
        }

        private void BindGrid()
        {
            GetWebs gb = new GetWebs();

            this.gvJson.DataSource = gb.ParseJson("http://getsmartschools.org/currentschools.txt");
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked the Save button. You get a swift kick to the groin.");
        }

    }   //end class Form1
}   //end namespace
