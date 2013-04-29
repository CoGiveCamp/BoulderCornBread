using System;
using System.IO;
using System.Net;

namespace BoulderCornBreadForWindows.Publish
{
    public class PublishJson
    {
        private readonly string _filepath = AppDomain.CurrentDomain.BaseDirectory + @"\";
        

        // called by user, passing json to save and ftp to site
        public Boolean PublishJsontoFtp(Object json, string filename, string ftppath, string username, string password)
        {
            try
            {

                string jsonText = json.ToString();
                WriteToFile(filename, jsonText);

                SendtoFtp(username, password, ftppath, filename);

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        // write the file to application path ready to upload
        private void WriteToFile(string filename, string jsonText)
        {

            StreamWriter streamWriter = File.CreateText(_filepath + filename);

            streamWriter.Write(jsonText);

            streamWriter.Close();
        }

        // upload local file to ftp
        private void SendtoFtp(string username, string password, string ftppath, string filename)
        {

            /* Create Object Instance */
            Ftp ftpClient = new Ftp(@"ftp://10.10.10.10/", "user", "password");

            /* Upload a File */
            ftpClient.Upload("etc/test.txt", @"C:\Users\metastruct\Desktop\test.txt");
                

        }

    }

}
