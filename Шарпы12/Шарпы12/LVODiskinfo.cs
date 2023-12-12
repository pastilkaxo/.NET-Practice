using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;


namespace Шарпы12
{
    public class LVODiskinfo
    {

        public void HasFreeSpace(string dName)
        {

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                 if(drive.Name == dName)
                {
                    double totalFreeSpaceInGB = (double)drive.TotalFreeSpace / (1024 * 1024 * 1024);
                    Console.WriteLine($"Название: {drive.Name}");
                    Console.WriteLine($"Свободное пространство: {Math.Round(totalFreeSpaceInGB),4} Гб");
                }
                else
                {
                    Console.WriteLine($"No that disk!");
                    return;
                }
            }
           
        }

        public void GetFileSysInfo(string dName)
        {

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                if (drive.Name == dName)
                {
                    Console.WriteLine($"Информация о файловой системе: {drive.DriveFormat}");
                }
                else
                {
                    Console.WriteLine($"No that disk!");
                    return;
                }
            }

        }

        public void FullDisksInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            Console.WriteLine("==============");
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                if (drive.IsReady)
                {
                    double totalSizeInGb = (double)drive.TotalSize / (1024 * 1024 * 1024);
                    string t1 = string.Join("", totalSizeInGb);
                    Console.WriteLine($"Объем диска: {t1.Substring(0,6)} Гб");
                    double totalFreeSpaceInGB = (double)drive.TotalFreeSpace / (1024 * 1024 * 1024);
                    string t2 = string.Join("" , totalFreeSpaceInGB);
                    
                    Console.WriteLine($"Свободное пространство: {t2.Substring(0,4)} ГБ");
                    Console.WriteLine($"Метка диска: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("==============");
        }


    }
}
