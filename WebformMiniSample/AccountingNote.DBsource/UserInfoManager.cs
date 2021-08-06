using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote.DBsource
{
    public class UserInfoManager
    {
        //private static string GetConnectionString()
        //{
        //    string val =
        //        ConfigurationManager.ConnectionStrings
        //        ["DefaultConnection"].ConnectionString;
        //    return val;
        //}


        public static DataRow GetUserInfoListtest(string account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @"SELECT [ID],[Account],[PWD],[Name],[Email] 
                    FROM UserInfo 
                    where [Account] = @account    
                  ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(dbCommandString, connection))
                {
                    command.Parameters.AddWithValue("@account",account);

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
                        logger.WriteLog(ex);
                        //Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
            }
        }

        public static DataTable aGetUserInfoListtest(string account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @"SELECT [ID],[Account],[PWD],[Name],[Email] 
                    FROM UserInfo 
                    where [Account] = @account    
                  ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(dbCommandString, connection))
                {
                    command.Parameters.AddWithValue("@account", account);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        //reader.Close();
                        return dt;
                        
                    }
                    catch (Exception ex)
                    {
                        logger.WriteLog(ex);
                        //Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
            }
        }


    }
}
