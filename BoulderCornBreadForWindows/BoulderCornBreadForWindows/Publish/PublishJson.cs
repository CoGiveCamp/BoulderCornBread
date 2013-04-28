using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BoulderCornBreadForWindows.Publish
{
    class PublishJson
    {

        public Boolean PublishJsontoFtp(Object json, string filename, string filepath)
        {
            // fuck this shit
            string jsonToWrite =  json.ToString();
            WriteToFile();
            return false;
        }

        void WriteToFile()
        {

            using (StreamWriter writer = new StreamWriter("debug.txt", true))
            {
                writer.WriteLine("whatever you text is");
            }

        }

    }

}
