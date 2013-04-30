using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BoulderCornBreadForWindows.Publish
{
    internal class Ftp
    {
        private readonly string _host = null;
        private readonly string _user = null;
        private readonly string _pass = null;
        private FtpWebRequest _ftpRequest = null;
        private FtpWebResponse _ftpResponse = null;
        private Stream _ftpStream = null;
        private const int BufferSize = 2048;

        /* Construct Object */

        public Ftp(string hostIp, string userName, string password)
        {
            _host = hostIp;
            _user = userName;
            _pass = password;
        }

        /* Upload File */

        public void Upload(string remoteFile, string localFile)
        {
            try
            {
                /* Create an FTP Request */
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + "/" + remoteFile);
                /* Log in to the FTP Server with the User Name and Password Provided */
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                /* When in doubt, use these options */
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                _ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                /* Establish Return Communication with the FTP Server */
                _ftpStream = _ftpRequest.GetRequestStream();
                /* Open a File Stream to Read the File for Upload */
                FileStream localFileStream = new FileStream(localFile, FileMode.Create);
                /* Buffer for the Downloaded Data */
                byte[] byteBuffer = new byte[BufferSize];
                int bytesSent = localFileStream.Read(byteBuffer, 0, BufferSize);
                /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
                try
                {
                    while (bytesSent != 0)
                    {
                        _ftpStream.Write(byteBuffer, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuffer, 0, BufferSize);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                /* Resource Cleanup */
                localFileStream.Close();
                _ftpStream.Close();
                _ftpRequest = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return;
        }

        
       
       /* Get the Size of a File */

        public string GetFileSize(string fileName)
        {
            try
            {
                /* Create an FTP Request */
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + "/" + fileName);
                /* Log in to the FTP Server with the User Name and Password Provided */
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                /* When in doubt, use these options */
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                _ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                /* Establish Return Communication with the FTP Server */
                _ftpResponse = (FtpWebResponse) _ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                _ftpStream = _ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                if (_ftpStream != null)
                {
                    StreamReader ftpReader = new StreamReader(_ftpStream);
                    /* Store the Raw Response */
                    string fileInfo = null;
                    /* Read the Full Response Stream */
                    try
                    {
                        while (ftpReader.Peek() != -1)
                        {
                            fileInfo = ftpReader.ReadToEnd();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    /* Resource Cleanup */
                    ftpReader.Close();
                    _ftpStream.Close();
                    _ftpResponse.Close();
                    _ftpRequest = null;
                    /* Return File Size */
                    return fileInfo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            /* Return an Empty string Array if an Exception Occurs */
            return "";
        }

        /* List Directory Contents File/Folder Name Only */

        public string[] DirectoryListSimple(string directory)
        {
            try
            {
                /* Create an FTP Request */
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + "/" + directory);
                /* Log in to the FTP Server with the User Name and Password Provided */
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                /* When in doubt, use these options */
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                _ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                /* Establish Return Communication with the FTP Server */
                _ftpResponse = (FtpWebResponse) _ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                _ftpStream = _ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                if (_ftpStream != null)
                {
                    StreamReader ftpReader = new StreamReader(_ftpStream);
                    /* Store the Raw Response */
                    string directoryRaw = null;
                    /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                    try
                    {
                        while (ftpReader.Peek() != -1)
                        {
                            directoryRaw += ftpReader.ReadLine() + "|";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    /* Resource Cleanup */
                    ftpReader.Close();
                    _ftpStream.Close();
                    _ftpResponse.Close();
                    _ftpRequest = null;
                    /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                    try
                    {
                        if (directoryRaw != null)
                        {
                            string[] directoryList = directoryRaw.Split("|".ToCharArray());
                            return directoryList;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            /* Return an Empty string Array if an Exception Occurs */
            return new string[] {""};
        }

        /* List Directory Contents in Detail (Name, Size, Created, etc.) */

        public string[] DirectoryListDetailed(string directory)
        {
            try
            {
                /* Create an FTP Request */
                _ftpRequest = (FtpWebRequest) WebRequest.Create(_host + "/" + directory);
                /* Log in to the FTP Server with the User Name and Password Provided */
                _ftpRequest.Credentials = new NetworkCredential(_user, _pass);
                /* When in doubt, use these options */
                _ftpRequest.UseBinary = true;
                _ftpRequest.UsePassive = true;
                _ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                _ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                /* Establish Return Communication with the FTP Server */
                _ftpResponse = (FtpWebResponse) _ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                _ftpStream = _ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                if (_ftpStream != null)
                {
                    StreamReader ftpReader = new StreamReader(_ftpStream);
                    /* Store the Raw Response */
                    string directoryRaw = null;
                    /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                    try
                    {
                        while (ftpReader.Peek() != -1)
                        {
                            directoryRaw += ftpReader.ReadLine() + "|";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    /* Resource Cleanup */
                    ftpReader.Close();
                    _ftpStream.Close();
                    _ftpResponse.Close();
                    _ftpRequest = null;
                    /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                    try
                    {
                        if (directoryRaw != null)
                        {
                            string[] directoryList = directoryRaw.Split("|".ToCharArray());
                            return directoryList;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            /* Return an Empty string Array if an Exception Occurs */
            return new string[] {""};
        }
    }
}