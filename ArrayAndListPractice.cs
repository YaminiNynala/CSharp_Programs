using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadTextFile
{
    class ArrayAndListPractice
    {
        public static void arrayData()
        {
            string[] namesArray = { "VenuGopal", "SudhaRani", "Yamini", "Ramya" };
            try
            {
                if (namesArray.Length > 0)
                {
                    for (var i = 0; i < namesArray.Length; i++)
                    {
                        Console.WriteLine("Name in Array : " + namesArray[i]);
                    }
                }
                else
                {
                    Console.WriteLine("Array is empty");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void listData()
        {
            List<string> namesList = new List<string>();

            namesList.Add("VenuGopal");
            namesList.Add("SudhaRani");
            namesList.Add("Yamini");
            namesList.Add("Ramya");

            try
            {
                if (namesList.Count > 0)
                {
                    for (var i = 0; i < namesList.Count; i++)
                    {
                        Console.WriteLine("Name in List : " + namesList[i]);
                    }
                }
                else
                {
                    Console.WriteLine("list is Empty");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
