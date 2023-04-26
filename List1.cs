using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadTextFile
{
    public class List1
    {
        public static string path1;
        public static List<User> usersList = new List<User>(3);

        public List1(string filePath)
        {
            path1 = filePath;
        }
        public static void readList()
        {
            try
            {
                if (File.Exists(path1))
                {
                    List<string> dataLines = File.ReadAllLines(path1).ToList();
                    if (dataLines.Count > 0)
                    {
                        for (var line = 0; line < dataLines.Count; line++)
                        {
                            User u1 = new User();
                            if (line > 0)
                            {
                                List<string> dataParts = dataLines[line].Split(',').ToList();
                                if (dataParts.Count > 0)
                                {
                                    for (var data = 0; data < dataParts.Count; data++)
                                    {
                                        if (data == 0)
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
                                usersList.Add(u1);
                            }
                        }

                        if (usersList.Count > 0)
                        {
                            for (var user = 0; user < usersList.Count; user++)
                            {
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine($"User {user + 1} Details are : ");
                                Console.WriteLine($"User ID : {usersList[user].id} ");
                                Console.WriteLine($"User Name : {usersList[user].name} ");
                                Console.WriteLine($"User Email : {usersList[user].email} ");
                                Console.WriteLine($"User Password : {usersList[user].password} ");
                                Console.WriteLine($"User Status : {usersList[user].status} ");
                                Console.WriteLine("----------------------------------------");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
