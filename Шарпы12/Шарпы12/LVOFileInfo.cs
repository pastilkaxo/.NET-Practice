using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Шарпы12
{
    public class LVOFileInfo
    {

        public string filePath;
        public string previousHash;

        public LVOFileInfo(string filePath)
        {
            this.filePath = filePath;
            previousHash = CalculateFileHash(filePath);
        }

        public void GetPath(string FileName)
        {
            string filePath = Path.GetFullPath(FileName);
            Console.WriteLine("Полный путь " +  filePath);
        }

        public void GetFullInfo(string FilePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(FilePath);

                // Выводим информацию о файле
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Размер: {fileInfo.Length} байт");
                Console.WriteLine($"Расширение файла: {fileInfo.Extension}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public void GetFileTime(string FilePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(FilePath);

                // Выводим информацию о файле
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Дата создания: {fileInfo.CreationTime} байт");
                Console.WriteLine($"Изменения: {fileInfo.Extension}");

                string currHash = CalculateFileHash(FilePath);
                if (currHash != previousHash)
                {
                    Console.WriteLine("Файл был изменен.");
                    previousHash = currHash;
                }
                else
                {
                    Console.WriteLine("Файл не изменен.");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public string CalculateFileHash(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }
        }

    }
}
