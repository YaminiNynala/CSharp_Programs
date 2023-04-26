using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace printMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            PlainText.printMsgViaText();
            UserDetails.displayUserDetails();
            DynamicData.userInput();
        }

    }
}
