using System;
using System.IO;
using System.Reflection;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst
{
    public class LogWriter
    {
        private string m_exePath = string.Empty;
        private static string _logFileName = "UITest_" + System.DateTime.Now.ToString("yyyyMMddHHmm") + "." + "log";
        public static void LogWrt(string logMessage)
        {
            LogWrite(logMessage);
        }
        public static void LogWrite(string logMessage)
        {
            //            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dir1 = @"D:\TestAuto\Log\";
            string dir2 = @"C:\Users\Pacific\Documents\CUIT\Log\";
            string dir3 = @"C:\Users\HoonH\Documents\Hyun\Test Automation\CUIT\CUITLog\";
            string m_exePath = "";
            if (Directory.Exists(dir1))
            {
                m_exePath = dir1;
            }
            else if (Directory.Exists(dir2))
            {
                m_exePath = dir2;
            }
            else if (Directory.Exists(dir3))
            {
                m_exePath = dir3;
            }

            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + _logFileName))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                //                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.Write("  {0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToShortDateString());
                txtWriter.WriteLine("  {0}     ", logMessage);
                //                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }

    }

}
