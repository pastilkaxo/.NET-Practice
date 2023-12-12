using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Шарпы12
{
    public class LVODirInfo
    {
       public string directoryPath = "C:\\Users\\Влад\\source\\repos\\Шарпы12\\Шарпы12\\Dir";
        public void CreateDir()
        {

            if (!Directory.Exists(directoryPath))
            {
                // Создаем директорию, только если она не существует
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine("Директория успешно создана.");
            }
            else
            {
                Console.WriteLine("Директория уже существует.");
            }
        }



        public void FullInfo()
        {
           DirectoryInfo dir = new DirectoryInfo(directoryPath);
            Console.WriteLine($"Колличество файлов: {dir.GetFiles().ToList().Count()}");
            Console.WriteLine($"Время создания: {dir.CreationTime}");
            Console.WriteLine($"Колличество поддиректориев: {dir.GetDirectories().Count()}");
            if (dir.GetDirectories().Length > 0)
            {
                Console.WriteLine("Родительские директории:");
                DirectoryInfo parent = dir.Parent;
                while (parent != null)
                {
                    Console.WriteLine(parent.Name);
                    parent = parent.Parent;
                }
            }
        }




        public void DirAdd()
        {

           for(int i = 0; i < 5; i++)
            {
                string fileName = $"newFile_{i}.txt";
                string filePath = Path.Combine(directoryPath, fileName);
                using(StreamWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine($"Это текстовый файл номер {i}");
                    writer.WriteLine("Дополнительная информация...");
                }
            }
            if (Directory.Exists(directoryPath))
            {
                for (int i = 1; i < 2; i++)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
                    dirInfo.CreateSubdirectory($"uDir{i}");
                    Console.WriteLine("Поддириктория создана!");
                }
            }  
        }

    }
}
