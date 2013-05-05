using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BoulderCornBreadForWindows.RetrieveData;
using Newtonsoft.Json;

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

            gvJson.DataSource = GetWebs.ParseJsonToJsonDataObj();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

        }

        private List<dynamic> ConvertGridViewToCollection(DataGridView dg)
        {
            var data = (List<dynamic>)dg.DataSource;
            return data;
        }

        private static void SaveFile(List<dynamic> data )
        {
            var dialog = new SaveFileDialog
                {
                    Filter = @"txt files (*.txt)|*.txt|JSON (*.json)|*.json",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var stream = new StreamWriter(dialog.OpenFile());
               
                    var serializer = new JsonSerializer();
                    using (JsonWriter writer = new JsonTextWriter(stream))
                    {

                        serializer.Serialize(writer, data);

                    }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            var data = ConvertGridViewToCollection(gvJson);
            SaveFile(data);

            //var serializer = new JsonSerializer();
            //serializer.Converters.Add(new JavaScriptDateTimeConverter());

            /*using (var sw = new StreamWriter(@"data.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                
                serializer.Serialize(writer, data);

            }
             */


        }

    }   //end class Form1
}   //end namespace
