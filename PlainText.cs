using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace printMessage
{
    public class PlainText
    {
        public static void printMsgViaText()
        {
            try
            {
                string text = "I am Yamini Nynala";
                string filepath = "E:/C#_Programs/printMessage/plainText12.txt";
                File.WriteAllText(filepath, text);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
