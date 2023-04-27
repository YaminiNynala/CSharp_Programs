using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.SqlClient;
using System.Data;

namespace ReadXMLFile
{
    public class XMLFileReading
    {
        public static string xmlFilePath = "E:/C#_Programs/ReadXMLFile/TeamsXML.xml";

        public static List<UserClass> usersList = new List<UserClass>();

        public static void readXMLFileData()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);
                XmlNodeList xmlNodeList = xmlDoc.SelectNodes("teammembers/member");
                if (xmlNodeList.Count>0)
                {
                    foreach(XmlNode xmlNode in xmlNodeList)
                    {
                        int userId = Convert.ToInt32(xmlNode.SelectSingleNode("id").InnerText);
                        string userName = xmlNode.SelectSingleNode("name").InnerText;
                        string userEmail = xmlNode.SelectSingleNode("email").InnerText;
                        string userPassword = xmlNode.SelectSingleNode("password").InnerText;
                        bool userStatus = Convert.ToBoolean(xmlNode.SelectSingleNode("status").InnerText);

                        UserClass uc = new UserClass();
                        uc.id = userId;
                        uc.name = userName;
                        uc.email = userEmail;
                        uc.password = userPassword;
                        uc.status = userStatus;

                        usersList.Add(uc);
                    }
                    if (usersList.Count>0)
                    {
                        foreach(var user in usersList)
                        {
                            //Console.WriteLine("--------------------------------------");
                            //Console.WriteLine($"ID of User: {user.id}");
                            //Console.WriteLine($"Name of User: {user.name}");
                            //Console.WriteLine($"Email of User: {user.email}");
                            //Console.WriteLine($"Password of User: {user.password}");
                            //Console.WriteLine($"Status of User: {user.status}");
                            //Console.WriteLine("--------------------------------------");

                            //data base method calling

                            insertXMLDataIntable(user);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception Occured :" + e.Message);
            }

        }
        public static void insertXMLDataIntable(UserClass userData)
        {
            string address = "Data Source = 192.168.1.9; Database = Training2022; User Id = tuser; Password = tecra1@3";

            //Establishing the connection
            SqlConnection conn = new SqlConnection(address);
            //opening the connection
            conn.Open();

            #region inserting using query

            //string query = $"insert _txtFileUser values({userData.id},'{userData.name}','{userData.email}','{userData.password}',{(userData.status ? 1 : 0)})";
            //SqlCommand cmd = new SqlCommand(query, conn);

            #endregion

            #region inserting through parameters

            //string query = $"insert _txtFileUser values(@id,@name,@email,@password,@status)";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //cmd.Parameters.AddWithValue("@id", userData.id);
            //cmd.Parameters.AddWithValue("@name", userData.name);
            //cmd.Parameters.AddWithValue("@email", userData.email);
            //cmd.Parameters.AddWithValue("@password", userData.password); 
            //cmd.Parameters.AddWithValue("@status", userData.status);

            #endregion

            #region inserting through a stored procedure

            SqlCommand cmd = new SqlCommand("sp_insertUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = userData.id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = userData.name;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = userData.email;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = userData.password;
            cmd.Parameters.Add("@status", SqlDbType.Bit).Value = userData.status;

            #endregion

            //Execution
            cmd.ExecuteNonQuery();
            //Close the connection
            conn.Close();
            Console.WriteLine("User added Succesfully");

        }
    }
}
