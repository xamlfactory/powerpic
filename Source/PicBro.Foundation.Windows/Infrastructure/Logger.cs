using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicBro.Foundation.Windows.Infrastructure
{
    public class Logger
    {
        public static void Log(string message, string stacktrace = "")
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            string[] lines = { DateTime.Now.ToString(), message, stacktrace, " " };
            File.AppendAllLines(dir + "log.txt", lines);
        }
    }
}
