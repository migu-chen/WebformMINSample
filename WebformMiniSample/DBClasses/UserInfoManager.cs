using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClasses
{
     public class UserInfoManager
     {
        public static void InsertIntoData(string username, string pwd)
        {
            string connectionString = GetConnectionString();

            string dbCommandString =
                @"INSERT INTO UserInfo
                        (Name, PWD)
                  VALUES
                        (@name, @pwd)    
                 ";

            //@"DELETE TestTable WHERE ID = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand comm = new SqlCommand(dbCommandString, conn))
                {
                    comm.Parameters.AddWithValue("@name", username);
                    comm.Parameters.AddWithValue("@pwd", pwd);
                    // comm.Parameters.AddWithValue("@numberCol", 240);

                    try
                    {
                        conn.Open();
                        int effectRows = comm.ExecuteNonQuery();
                        Console.WriteLine($" {effectRows } has changed. ");
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }


        }

        public static DataTable GetUserInfoList()
        {
            string connectionString = GetConnectionString();
            string dbCommandString =
                @"SELECT ID, Name
                   FROM UserInfo 
                    
                  ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(dbCommandString, connection))
                {
                    //command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();

                        return dt;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
            }
        }

        public static DataRow GetUserInfo(string id)
        {
            string connectionString = GetConnectionString();
            string dbCommandString =
                @"SELECT ID, Name
                   FROM UserInfo 
                   where ID = @id     
                  ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(dbCommandString, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();
                        if (dt.Rows.Count == 0)
                            return null;

                        DataRow dr = dt.Rows[0];
                        return dr;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
            }
        }

        public static DataRow GetUserInfoByAccount(string account)
        {
            string connectionString = GetConnectionString();
            string dbCommandString =
                @"SELECT ID, Name, PWD
                   FROM UserInfo 
                   where name = @name    
                  ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(dbCommandString, connection))
                {
                    command.Parameters.AddWithValue("@name", account);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();

                        if (dt.Rows.Count == 0)
                            return null;

                        DataRow dr = dt.Rows[0];
                        return dr;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
            }
        }
        private static string GetConnectionString()
        {
           
            string val =
                ConfigurationManager.ConnectionStrings
                ["DefaultConnection"].ConnectionString;
            return val;

        }

    }
}
