using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace ReadTextFile
{
    public class DataInTable
    {
        public static string path1;
        public static List<User> usersList = new List<User>();
        public DataInTable(string filePath)
        {
            path1 = filePath;
        }

        public static void readListInTable()
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
                                //console.writeline("----------------------------------------");
                                //console.writeline($"user {user + 1} details are : ");
                                //console.writeline($"user id : {userslist[user].id} ");
                                //console.writeline($"user name : {userslist[user].name} ");
                                //console.writeline($"user email : {userslist[user].email} ");
                                //console.writeline($"user password : {userslist[user].password} ");
                                //console.writeline($"user status : {userslist[user].status} ");
                                //console.writeline("----------------------------------------");
                                insertUsingQuery(usersList[user]);
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
        public static void insertUsingQuery(User userData)
        {
            try
            {
                String address = "Data Source = 192.168.1.9; Database = Training2022; User Id = tuser; Password = tecra1@3";
                SqlConnection conn = new SqlConnection(address);
                conn.Open();

                #region Insert data with query
                //string query = $"insert _txtFileUser values ({userData.id},'{userData.name}','{userData.email}','{userData.password}',{(userData.status ? 1 : 0)})";
                //SqlCommand cmd = new SqlCommand(query,conn);
                //cmd.ExecuteNonQuery();
                //conn.Close();
                //Console.WriteLine("User added succesfully");
                #endregion

                #region Insert data with parameters

                //string query = $"insert _txtFileUser values(@id,@name,@email,@password,@status)";
                //SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("@id", userData.id);
                //cmd.Parameters.AddWithValue("@name", userData.name);
                //cmd.Parameters.AddWithValue("@email", userData.email);
                //cmd.Parameters.AddWithValue("@password", userData.password);
                //cmd.Parameters.AddWithValue("@status", userData.status);
                //cmd.ExecuteNonQuery();
                //conn.Close();
                //Console.WriteLine("User added succesfully");

                #endregion

                #region Insert data with stored procedure

                SqlCommand cmd = new SqlCommand("sp_insertUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = userData.id;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 250).Value = userData.name;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = userData.email;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 12).Value = userData.password;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = userData.status;

                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("User added succesfully");

                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}