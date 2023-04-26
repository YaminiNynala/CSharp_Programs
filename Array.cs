using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadTextFile
{
    public class Array
    {
        public static string path1;
        public static User[] usersArr = new User[3];

        public Array(string filePath)
        {
            path1 = filePath;
        }
        public static void readArray()
        {
            try
            {
                if (File.Exists(path1))
                {
                    string[] dataLines = File.ReadAllLines(path1);
                    if (dataLines.Length>0)
                    {
                        for (var line=0; line<dataLines.Length; line++)
                        {
                            User u1 = new User();
                            if (line>0)
                            {
                                string[] dataParts = dataLines[line].Split(',');
                                if (dataParts.Length>0)
                                {
                                    for (var data=0; data<dataParts.Length; data++)
                                    {
                                        if (data ==0)
                                            u1.id = Convert.ToInt32(dataParts[data]);
                                        if (data == 1)
                                            u1.name = dataParts[data];
                                        if (data == 2)
                                            u1.email = dataParts[data];
                                        if (data == 3)
                                            u1.password = dataParts[data];
                                        if (data == 4)
                                            u1.status = Convert.ToBoolean(dataParts[data]);
                                    }
                                }
                                usersArr[line - 1] = u1;
                            }
                        }

                        if (usersArr.Length > 0)
                        {
                            for (var user = 0; user < usersArr.Length; user++)
                            {
                                Console.WriteLine("***************************************");
                                Console.WriteLine($"User {user + 1} Details are : ");
                                Console.WriteLine($"User ID : {usersArr[user].id} ");
                                Console.WriteLine($"User Name : {usersArr[user].name} ");
                                Console.WriteLine($"User Email : {usersArr[user].email} ");
                                Console.WriteLine($"User Password : {usersArr[user].password} ");
                                Console.WriteLine($"User Status : {usersArr[user].status} ");
                                Console.WriteLine("***************************************");
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

    }
}
