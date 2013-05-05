using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BoulderCornBreadForWindows.RetrieveData;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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

            this.gvJson.DataSource = GetWebs.ParseJsonToJsonDataObj();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

        }

        private List<dynamic> ConvertGridViewToCollection(DataGridView dg)
        {
            var data = (List<dynamic>)dg.DataSource;
            return data;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());

            using (var sw = new StreamWriter(@"data.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                var data = ConvertGridViewToCollection(gvJson);
                serializer.Serialize(writer, data);

            }

        }

    }   //end class Form1
}   //end namespace
