﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote.DBsource
{
    public class AccountingManager
    {
       
        public static DataTable GetAccounttingList(string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"SELECT 
                     ID,
                     Caption,
                     Amount,
                     ActType, 
                     CreateDate,
                     Body
                  FROM Accounting
                  WHERE UserID = @userID  
                  ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userID));

            try
            {
                return DBHelper.ReadDataTable(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }

        public static DataRow GetAccounting(int id, string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"SELECT 
                     ID,
                     Caption,
                     Amount,
                     ActType, 
                     CreateDate,
                     Body
                    FROM Accounting
                    WHERE id = @id AND UserID=@userID 
                  ";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@id", id);
                    comm.Parameters.AddWithValue("@userID", userID );
                    try
                    {
                        conn.Open();
                        var reader = comm.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        if(dt.Rows.Count == 0)
                           return null;

                        return dt.Rows[0];
                    }
                    catch (Exception ex)
                    {
                        logger.WriteLog(ex);
                        return null;
                    }
                }

            }
        }

        public static void CreateAccounting(string userID, string caption,
            int amount, int actType, string body)
        {
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1000000.");

            if (actType < 0 || actType > 1)
                throw new ArgumentException("ActType must be 0 or 1.");
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"INSERT INTO [dbo].[Accounting]
                   (
                     UserID
                      ,Caption
                      ,Amount
                      ,ActType
                      ,CreateDate
                      ,Body
                    )
                     VALUES
                    (
                        @userID
                        ,@caption
                        ,@amount
                        ,@acttype
                        ,@createdate
                        ,@body
                       ) ";


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    comm.Parameters.AddWithValue("@userID", userID);
                    comm.Parameters.AddWithValue("@caption", caption);
                    comm.Parameters.AddWithValue("@amount", amount);
                    comm.Parameters.AddWithValue("@acttype", actType);
                    comm.Parameters.AddWithValue("@createdate", DateTime.Now);
                    comm.Parameters.AddWithValue("@body", body);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        logger.WriteLog(ex);

                    }
                }
            }

        }

        public static bool UpdateAccounting(int ID, string userID, string caption,
            int amount, int actType, string body)
        {
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1000000.");

            if (actType < 0 || actType > 1)
                throw new ArgumentException("ActType must be 0 or 1.");
            
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"UPDATE [Accounting]
                      UserID       = @userID
                      ,Caption     = @caption
                      ,Amount      = @amount
                      ,ActType     = @acttype
                      ,CreateDate  = @createdate
                      ,Body        = @body
                   WHERE
                       ID =@id ";


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    comm.Parameters.AddWithValue("@id", ID);
                    comm.Parameters.AddWithValue("@caption", caption);
                    comm.Parameters.AddWithValue("@amount", amount);
                    comm.Parameters.AddWithValue("@acttype", actType);
                    comm.Parameters.AddWithValue("@createdate", DateTime.Now);
                    comm.Parameters.AddWithValue("@body", body); 

                    try
                    {
                        conn.Open();
                        int effectRows = comm.ExecuteNonQuery();

                        if (effectRows == 1)
                            return true;
                        else
                            return false;
                    }

                    catch (Exception ex)
                    {
                        logger.WriteLog(ex);
                        return false;
                    }
                }
            }

        }

        public static void DeleteAccounting(int ID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"DELETE [Accounting]
                    WHERE ID =@id ";


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    comm.Parameters.AddWithValue("@id", ID);
                    
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                                            
                    }

                    catch (Exception ex)
                    {
                        logger.WriteLog(ex);                   
                    }
                }
            }

        }


        public static DataTable GettestcounttingList(string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                @"SELECT [dbo].[UserInfo]
                     ID,
                     Caption,
                     Amount,
                     ActType, 
                     CreateDate,
                     Body
                  FROM Accounting
                  WHERE UserID = @userID  
                  ";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@userID", userID);

                    try
                    {
                        conn.Open();
                        var reader = comm.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        return dt;

                    }
                    catch (Exception ex)
                    {
                        logger.WriteLog(ex);
                        return null;
                    }
                }

            }
        }
    }
}







