using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace printMessage
{
    public class UserDetails
    {
        public string name = "Yamini";
        public char initial = 'N';
        public int age = 23;
        public long mobileNumber = 8341892223;
        public double salary = 1.8;
        public static void displayUserDetails()
        {
            try
            {
                UserDetails ud = new UserDetails();

                string filepath1 = "E:/C#_Programs/printMessage/detailsOfUser123.txt";
                string text1 = " Name : " + ud.name + "\n Intitial: " + ud.initial + "\n Age : " + ud.age + "\n Mobile Number : " + ud.mobileNumber + "\n Salary: " + ud.salary + " LPA";
                File.WriteAllText(filepath1, text1);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
