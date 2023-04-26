using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadFile r1 = new ReadFile("E:/C#_Programs/printMessage/TxtDoc.txt");
            //ReadFile.readFileInConsole();

            //ArrayAndListPractice.arrayData();
            //Console.WriteLine("*****************************");
            //ArrayAndListPractice.listData();

            string filePath = "E:/C#_Programs/ReadTextFile/data.txt";
            //Array a1 = new Array(filePath);
            //Array.readArray();

            //List1 l1 = new List1(filePath);
            //List1.readList();

            DataInTable d1 = new DataInTable(filePath);
            DataInTable.readListInTable();

            Console.ReadKey();

        }
    }
}
