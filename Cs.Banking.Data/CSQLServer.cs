/*************************
 * [CSQLServer.cs]
 * C# Intermediate
 * Shawn Novak
 * 2012-12-06
 *************************/

using System;
using System.Data;
using System.Data.SqlClient;

namespace Cs.Banking.Data
{
    public class CSQLServer
    {
    // Private Fields
        private SqlConnection sqlConn;

    // Private Methods
        private ConnectionState Open()
        {
            try
            {
                sqlConn = new SqlConnection(Properties.Settings.Default.DBConn);
                sqlConn.Open();

                return sqlConn.State;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Close()
        {
            try
            {
                if (sqlConn != null)
                    sqlConn.Close();

                sqlConn = null;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int DoSQL(string sCommand)
        {
            try
            {
                if (Open() == ConnectionState.Open)
                {
                    SqlCommand oCmd = new SqlCommand(sCommand, sqlConn);
                    int iRows = oCmd.ExecuteNonQuery();

                    oCmd.Dispose();
                    oCmd = null;

                    Close();

                    return iRows;
                }
                else
                    throw new Exception("Error opening connection to SQL Server.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    // Public Methods
        public DataTable GetData(string sCommand)
        {
            try
            {
                if (Open() == ConnectionState.Open)
                {
                    SqlDataAdapter oDA = new SqlDataAdapter(sCommand, sqlConn);
                    DataTable oDT = new DataTable();
                    oDA.Fill(oDT);

                    oDA.Dispose();
                    oDA = null;

                    Close();

                    return oDT;
                }
                else
                    throw new Exception("Error opening connection to SQL Server.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public int Delete(string sCommand)
        {
            try
            {
                return DoSQL(sCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(string sCommand)
        {
            try
            {
                return DoSQL(sCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(string sCommand)
        {
            try
            {
                return DoSQL(sCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
