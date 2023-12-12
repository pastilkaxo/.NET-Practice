
using System.Diagnostics;
using Шарпы12;
class Programm
{
    static void Main()
    {

        // 1: 

        List<string> actions = new List<string>{"Открытие","Закрытие","Удаление"};


        LVOLog l1 = new LVOLog("C:\\Users\\Влад\\source\\repos\\Шарпы12\\Шарпы12\\lvologfile.txt");
       l1.InputDataToFile();


        foreach(string a in actions)
        {
            l1.SearchLog(a);

        }
        Console.WriteLine("-------------------");

        // 2: 


        LVODiskinfo ds = new LVODiskinfo();

        ds.HasFreeSpace("C:\\");
        ds.GetFileSysInfo("C:\\");
        ds.FullDisksInfo();

        // 3: 
        string fileP = "C:\\Users\\Влад\\source\\repos\\Шарпы12\\Шарпы12\\FileInfo.txt";

        LVOFileInfo lv = new LVOFileInfo(fileP);

        lv.GetPath("FileInfo");

        lv.GetFullInfo(fileP);
        Console.WriteLine("-------------------");

        lv.CalculateFileHash(fileP);
        lv.GetFileTime(fileP);

        // 4:

        LVODirInfo dr = new LVODirInfo();
        Console.WriteLine("-------------------");
        dr.CreateDir();
        Console.WriteLine("-------------------");
        dr.DirAdd();
        Console.WriteLine("-------------------");
        dr.FullInfo();

        // 5: 

        LVOFileManager fm = new LVOFileManager();

        //fm.InspectDisk("C:\\Users\\Влад\\source\\repos\\Шарпы12\\Шарпы12");

        //fm.MoveFilesAndInspect("C:\\Users\\Влад\\source\\repos\\Шарпы12\\Шарпы12\\Dir", "txt");

        //fm.ZipDir();


        // 6:



        DateTime startTime = DateTime.Now.AddHours(-1);
        DateTime endTime = DateTime.Now; 

        l1.GetDataFromLog(startTime, endTime);




    }
}