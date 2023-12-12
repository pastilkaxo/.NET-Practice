using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шарпы12
{
    public class LVOFileManager
    {

        public void InspectDisk(string diskLetter)
        {

            // Получаем список файлов и папок заданного диска
            string[] filesAndDirs = Directory.GetFileSystemEntries(diskLetter + "\\");

            string inspectDirectoryPath = Path.Combine(diskLetter + "\\", "LVOInspect");
            Directory.CreateDirectory(inspectDirectoryPath);



            // Создаем текстовый файл xxxdirinfo.txt и записываем информацию
            string infoFilePath = Path.Combine(inspectDirectoryPath, "lvodirinfo.txt");
            using (StreamWriter writer = File.CreateText(infoFilePath))
            {
                foreach (var entry in filesAndDirs)
                {
                    writer.WriteLine(entry);
                }
            }

            string copyFilePath = Path.Combine(inspectDirectoryPath, "cop.txt");
            File.Copy(infoFilePath, copyFilePath);
            Console.WriteLine($"Копия файла успешно создана: {copyFilePath}");

            File.Delete(infoFilePath);
            Console.WriteLine($"Первоначальный файл успешно удален: {infoFilePath}");
        }


        public void MoveFilesAndInspect(string userDirectory, string fileExtension)
        {
            string baseDirectory = "C:\\Users\\Влад\\source\\repos\\Шарпы12\\Шарпы12\\";
            string filesDirectoryPath = Path.Combine(baseDirectory, "LVOFiles");
            string inspectDirectoryPath = Path.Combine(baseDirectory, "LVOInspect");

            Directory.CreateDirectory(filesDirectoryPath);
            Directory.CreateDirectory(inspectDirectoryPath);

            CopyFilesWithExtension(userDirectory, fileExtension, filesDirectoryPath);

            // Перемещаем XXXFiles в XXXInspect
            string movedFilesDirectoryPath = Path.Combine(inspectDirectoryPath, "LVOFiles");
            Directory.Move(filesDirectoryPath, movedFilesDirectoryPath);

            Console.WriteLine($"Директория LVOFiles успешно перемещена в LVOInspect.");
        }

        private void CopyFilesWithExtension(string sourceDirectory, string fileExtension, string destinationDirectory)
        {
            // Получаем список файлов с заданным расширением
            string[] filesToCopy = Directory.GetFiles(sourceDirectory, $"*.{fileExtension}");

            foreach (var file in filesToCopy)
            {
                string fileName = Path.GetFileName(file);
                string destinationFilePath = Path.Combine(destinationDirectory, fileName);
                File.Copy(file, destinationFilePath);
                Console.WriteLine($"Файл {fileName} успешно скопирован в {destinationDirectory}.");
            }
        }



        public void ZipDir()
        {
            string baseDirectory = "C:\\Users\\Влад\\source\\repos\\Шарпы12\\Шарпы12\\LVOInspect\\LVOFiles";
            string newDirectory = "C:\\Users\\Влад\\source\\repos\\Шарпы12\\Шарпы12\\NewDir";
            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }

            //    string filesToArhPath = Path.Combine(baseDirectory, "LVOInspect", "LVOFiles");
            //    string[] dirFiles = Directory.GetFiles(filesToArhPath);

            //    string compressedFile = Path.Combine(newDirectory, "Main.zip");

            //    using (FileStream targetStream = File.Create(compressedFile))
            //    {
            //        using (ZipArchive archive = new ZipArchive(targetStream, ZipArchiveMode.Create))
            //        {
            //            foreach (string filePath in dirFiles)
            //            {
            //                string entryName = Path.GetFileName(filePath);
            //                archive.CreateEntryFromFile(filePath, entryName);
            //            }
            //        }
            //    }

            //    Console.WriteLine($"Сжатие файла LVOFiles завершено.");

            //    using (ZipArchive archive1 = ZipFile.OpenRead(compressedFile))
            //    {
            //        foreach(ZipArchiveEntry entry in archive1.Entries)
            //        {
            //            string entryFullPath = Path.Combine(newDirectory, entry.FullName);
            //            entry.ExtractToFile(entryFullPath, true);
            //        }
            //    }

            //    Console.WriteLine($" Main.zip разархивирован");
            //}


            string zipFile = Path.Combine(newDirectory + "\\test.zip");

            ZipFile.CreateFromDirectory(baseDirectory, zipFile);
            Console.WriteLine($"Сжатие файла LVOFiles завершено.");
            ZipFile.ExtractToDirectory(zipFile, newDirectory);
            Console.WriteLine($" test.zip разархивирован");
        }
    }
}
