using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace DIWebApplication
{
    public class FileLogger : ILog
    {
        public void Info(string str)
        {
            var text = string.Format("{0} ***************************** {1} *****************************", DateTime.Now,str);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), @"LogFile.txt");


            using (System.IO.StreamWriter file = File.AppendText(filePath))
            {
                file.WriteLine(text);
            }
        }
    }
}
