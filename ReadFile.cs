using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadTextFile
{
    class ReadFile
    {
        public static string filePath;
        public ReadFile(string path)
        {
            filePath = path;
        }

        public static void readFileInConsole()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    if (string.IsNullOrEmpty(data))
                    {
                        Console.WriteLine("There is no data in the file");
                    }
                    else
                    {
                        Console.WriteLine(data);
                    }

                }
                else
                {
                    Console.WriteLine("File Not Found");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
