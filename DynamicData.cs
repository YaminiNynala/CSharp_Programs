using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO;

namespace printMessage
{
    public class DynamicData
    {
        public static void userInput()
        {
            try
            {
                String filePath = "E:/C#_Programs/printMessage/UserInputData123.txt";

                Console.WriteLine("Enter your Name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter your Age : ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your Mobile Number : ");
                long mobileNumber = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter your grade");
                char grade = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Are you a job holder ");
                bool job = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("Enter your salary : ");
                double salary = Convert.ToDouble(Console.ReadLine());
                
                String text = " Name : " + name + "\n Age : " + age + "\n Mobile Number : " + mobileNumber + "\n Grade : " + grade + "\n Job : " + job + "\n Salary : " + salary;
                File.WriteAllText(filePath, text);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
