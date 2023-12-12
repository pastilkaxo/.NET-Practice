using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Шарпы12
{
    public class LVOLog
    {

        public string logFilePath;


        public LVOLog(string filePath)
        {
            logFilePath = filePath;
         
        }

        public void InputDataToFile()
        {

            WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();


            string? directory = Directory.GetCurrentDirectory();
            string? logFileName = Path.GetFileName(logFilePath);

            string action = "Открытие документа";
            string details = $"Открыто: {currentIdentity?.Name}";

            string logEntry = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {action}: {details} - Directory: {directory} - {logFileName}";

            using (StreamWriter stream = File.AppendText(logFilePath))
            {
                stream.WriteLine(logEntry);
            }
        }

        public void GetDataFromLog()
        {
            try
            {
                using ( StreamReader reader = File.OpenText(logFilePath))
                {
                    string? line;
                    while((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SearchLog(string actionToFind)
        {
            using(StreamReader reader = File.OpenText(logFilePath))
            {
                string logContent = reader.ReadToEnd();
                if (logContent.Contains(actionToFind))
                {
                     Console.WriteLine("We found: " + logContent + "\n" );
                }
                else
                {
                    Console.WriteLine("Not found! - " + actionToFind);
                    return;
                }
            }

        }


        public void GetDataFromLog(DateTime startTime, DateTime endTime)
        {
            try
            {
                using (StreamReader reader = File.OpenText(logFilePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Parse the timestamp from the log entry
                        if (DateTime.TryParseExact(
                            line.Substring(0, 19),
                            "yyyy-MM-dd HH:mm:ss",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime logEntryTime))
                        {
                            // Check if the timestamp is within the specified range
                            if (logEntryTime >= startTime && logEntryTime <= endTime)
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



    }
}
