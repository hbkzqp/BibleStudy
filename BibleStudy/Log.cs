using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BibleStudy
{
    public class Log
    {
        public static void writeLog(string action,string message)
        {
            object loc = new object();
            lock(loc)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"System\Log\";
                DateTime time = DateTime.Now;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                   

                string fileFullPath = path + time.ToString("yyyy-MM-dd") + ".System.txt";
                StringBuilder str = new StringBuilder();
                str.Append("Time:    " + time.ToString() + "\r\n");
                str.Append("Action:  " + action + "\r\n");
                str.Append("Message: " + message + "\r\n");
                str.Append("-----------------------------------------------------------\r\n\r\n");
                StreamWriter sw;
                if (!File.Exists(fileFullPath))
                {
                    sw = File.CreateText(fileFullPath);
                }
                else
                {
                    sw = File.AppendText(fileFullPath);
                }
                sw.WriteLine(str.ToString());
                sw.Close();

            }
        }
    }
}