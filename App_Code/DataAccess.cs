using System;
using System.Web; 
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
namespace cmm.DataAccessLayer
{

    public class DataAccess
    {

        protected SqlConnection Conn; ///SQLConnection object 
        protected SqlTransaction sqlTrans;

        /// <summary>
        /// public functions
        /// </summary>
        #region "public Functions"
        ///
        /// <summary>
        /// Opens the connection to the database.
        /// </summary>
        protected void OpenConnection()
        {

            String strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            Conn = new SqlConnection();
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();

            }
            else
            {
                Conn.ConnectionString = strConnectionString;
                Conn.Open();
            }
        }

        /// 
        /// <summary>
        /// Closes the Connection
        /// </summary>
        protected void CloseConnection()
        {
            if (Conn != null)
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                Conn = null;
            }
        }

        /// <summary>
        /// Executes the Stored Procedure with the SqlParameter array object passed
        /// and returns the DataSet
        /// </summary>
        /// <param name="CommandText"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        public DataSet ExecuteSQL(String CommandText, SqlParameter[] Params)
        {
            OpenConnection();
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.CommandType = CommandType.StoredProcedure;
            cmdObj.Connection = Conn;
            cmdObj.CommandText = CommandText;
            if (Params.Length > 0)
            {
                for (int i = 0; i < Params.Length; i++)
                {
                    cmdObj.Parameters.Add(Params[i]);
                }
            }

            SqlDataAdapter daSP = new SqlDataAdapter(cmdObj);
            DataSet dsRes = new DataSet();

            daSP.Fill(dsRes);
            daSP.Dispose();

            cmdObj.Dispose();
            CloseConnection();

            return dsRes;
        }

        // new 

        public DataSet ExecuteSQLDataset(String CommandText)
        {
            OpenConnection();
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.Connection = Conn;
            cmdObj.CommandText = CommandText;

            SqlDataAdapter daSP = new SqlDataAdapter(cmdObj);
            DataSet dsRes = new DataSet();

            daSP.Fill(dsRes);
            daSP.Dispose();

            cmdObj.Dispose();
            CloseConnection();

            return dsRes;
        }

        public DataTable ExecuteSQL(String CommandText, int StartIndex, int MaxCount)
        {
            OpenConnection();
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.Connection = Conn;
            cmdObj.CommandText = CommandText;
            SqlDataAdapter daSP = new SqlDataAdapter(cmdObj);
            DataSet dsRes = new DataSet();

            daSP.Fill(dsRes, StartIndex, MaxCount, "FilteredTable");
            daSP.Dispose();

            cmdObj.Dispose();
            CloseConnection();

            return dsRes.Tables["FilteredTable"];
        }

        public int ExecuteSQL(string CommandText)
        {
            OpenConnection();
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.CommandText = CommandText;
            cmdObj.Connection = Conn;
            int x = Convert.ToInt32(cmdObj.ExecuteScalar());
            CloseConnection();
            return (x);
        }


        /// <summary>
        /// Executes the Stored Procedure with the SqlParameterCollection object passed
        /// and returns the DataSet
        /// </summary>
        /// <param name="CommandText"></param>
        /// <param name="ParamsCollection"></param>
        /// <returns></returns>
        public DataSet ExecuteSQL(String CommandText, SqlParameterCollection ParamsCollection)
        {
            OpenConnection();
            //SqlCommand cmdObj=new SqlCommand(CommandText,Conn);
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.CommandType = CommandType.StoredProcedure;
            cmdObj.Connection = Conn;
            cmdObj.CommandText = CommandText;

            if (ParamsCollection.Count > 0)
            {
                for (int i = 0; i < ParamsCollection.Count; i++)
                {
                    cmdObj.Parameters.Add(ParamsCollection[i]);
                }
            }
            SqlDataAdapter daSP = new SqlDataAdapter(cmdObj);
            DataSet dsRes = new DataSet();

            daSP.Fill(dsRes);
            daSP.Dispose();

            cmdObj.Dispose();
            CloseConnection();

            return dsRes;
        }

        public DataSet ExecuteSQL1(String CommandText)
        {
            OpenConnection();
            //SqlCommand cmdObj=new SqlCommand(CommandText,Conn);
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.CommandType = CommandType.StoredProcedure;
            cmdObj.Connection = Conn;
            cmdObj.CommandText = CommandText;


            SqlDataAdapter daSP = new SqlDataAdapter(cmdObj);
            DataSet dsRes = new DataSet();

            daSP.Fill(dsRes);
            daSP.Dispose();

            cmdObj.Dispose();
            CloseConnection();

            return dsRes;
        }

        #endregion

        #region "public Functions"



        /// <summary>
        /// Executes the Stored Procedure with the SqlParameter array object passed
        /// and returns the DataSet
        /// </summary>
        /// <param name="CommandText"></param>
        /// <param name="Params"></param>
        /// <returns></returns>


        public DataSet ExcuteQryProc(String CommandText, SqlParameter[] Params)
        {
            OpenConnection();
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.CommandType = CommandType.StoredProcedure;
            cmdObj.CommandText = CommandText;
            cmdObj.Connection = Conn;

            if (Params.Length > 0)
            {
                for (int i = 0; i < Params.Length; i++)
                {
                    cmdObj.Parameters.Add(Params[i]);
                }
            }

            SqlDataAdapter daRes = new SqlDataAdapter(cmdObj);
            DataSet dsRes = new DataSet();
            daRes.Fill(dsRes);
            daRes.Dispose();
            cmdObj.Dispose();
            CloseConnection();
            return (dsRes);
        }

        public int ExecuteSqlQry(String CommandText)
        {
            OpenConnection();
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.CommandText = CommandText;
            cmdObj.Connection = Conn;
            int xres = cmdObj.ExecuteNonQuery();
            cmdObj.Dispose();
            CloseConnection();
            return (xres);

        }



        //public int ExecuteSQL(string CommandText)
        //{
        //    OpenConn();
        //    SqlCommand cmdObj = new SqlCommand();
        //    cmdObj.CommandText = CommandText;
        //    cmdObj.Connection = connection;
        //    int x = Convert.ToInt32(cmdObj.ExecuteScalar());
        //    return (x);
        //}


        public string ExecuteSQLstr(string CommandText)
        {
            OpenConnection();
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.CommandText = CommandText;
            cmdObj.Connection = Conn;
            string x = cmdObj.ExecuteScalar().ToString();
            return (x);
        }

        public DataSet ExcuteQry(String CommandText)
        {
            OpenConnection();
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.CommandText = CommandText;
            cmdObj.Connection = Conn;
            SqlDataAdapter daRes = new SqlDataAdapter(cmdObj);
            DataSet dsRes = new DataSet();
            daRes.Fill(dsRes);
            daRes.Dispose();
            cmdObj.Dispose();
            CloseConnection();
            return (dsRes);
        }


        //public int ExecuteSQL(String CommandText, SqlParameter[] Params)
        //{
        //    OpenConn();
        //    SqlCommand cmdObj = new SqlCommand();
        //    cmdObj.CommandType = CommandType.StoredProcedure;
        //    cmdObj.Connection = connection;
        //    cmdObj.CommandText = CommandText;
        //    if (Params.Length > 0)
        //    {
        //        for (int i = 0; i < Params.Length; i++)
        //        {
        //            cmdObj.Parameters.Add(Params[i]);
        //        }

        //    }

        //    int xx = cmdObj.ExecuteNonQuery();
        //    cmdObj.Dispose();
        //    CloseConn();
        //    return xx;
        //}



        //public DataTable ExecuteSQL(String CommandText, int StartIndex, int MaxCount)
        //{
        //    OpenConn();
        //    SqlCommand cmdObj = new SqlCommand();
        //    cmdObj.Connection = Conn;
        //    cmdObj.CommandText = CommandText;
        //    SqlDataAdapter daSP = new SqlDataAdapter(cmdObj);
        //    DataSet dsRes = new DataSet();

        //    daSP.Fill(dsRes, StartIndex, MaxCount, "FilteredTable");
        //    daSP.Dispose();

        //    cmdObj.Dispose();
        //    CloseConn();

        //    return dsRes.Tables["FilteredTable"];
        //}


        /// <summary>
        /// Executes the Stored Procedure with the SqlParameterCollection object passed
        /// and returns the DataSet
        /// </summary>
        /// <param name="CommandText"></param>
        /// <param name="ParamsCollection"></param>
        /// <returns></returns>
        //public DataSet ExecuteSQL(String CommandText, SqlParameterCollection ParamsCollection)
        //{
        //    OpenConn();
        //    //SqlCommand cmdObj=new SqlCommand(CommandText,Conn);
        //    SqlCommand cmdObj = new SqlCommand();
        //    cmdObj.CommandType = CommandType.StoredProcedure;
        //    cmdObj.Connection = Conn;
        //    cmdObj.CommandText = CommandText;

        //    if (ParamsCollection.Count > 0)
        //    {
        //        for (int i = 0; i < ParamsCollection.Count; i++)
        //        {
        //            cmdObj.Parameters.Add(ParamsCollection[i]);
        //        }
        //    }
        //    SqlDataAdapter daSP = new SqlDataAdapter(cmdObj);
        //    DataSet dsRes = new DataSet();

        //    daSP.Fill(dsRes);
        //    daSP.Dispose();

        //    cmdObj.Dispose();
        //    CloseConn();

        //    return dsRes;
        //}

        //public DataSet ExecuteSQL1(String CommandText)
        //{
        //    OpenConn();
        //    //SqlCommand cmdObj=new SqlCommand(CommandText,Conn);
        //    SqlCommand cmdObj = new SqlCommand();
        //    cmdObj.CommandType = CommandType.StoredProcedure;
        //    cmdObj.Connection = Conn;
        //    cmdObj.CommandText = CommandText;


        //    SqlDataAdapter daSP = new SqlDataAdapter(cmdObj);
        //    DataSet dsRes = new DataSet();

        //    daSP.Fill(dsRes);
        //    daSP.Dispose();

        //    cmdObj.Dispose();
        //    CloseConn();

        //    return dsRes;
        //}

        #endregion


        #region "Public functions"
        /// <summary>
        /// Executes the stored procedure with the Parameter array and
        /// returns the DataTable.
        /// </summary>
        /// <param name="CommandText">Name of the Stored Procedure</param>
        /// <param name="Params">Array of Sql Parameters</param>
        /// <returns></returns>
        public DataTable ExecuteSelectDataTable(String CommandText, SqlParameter[] Params)
        {
            return ExecuteSQL(CommandText, Params).Tables[0];
        }
        public DataTable ExecuteSelectDataTable_Without(String CommandText, SqlParameter[] Params)
        {
            return ExecuteSQL(CommandText, Params).Tables[0];
        }
        /// <summary>
        /// /// Executes the stored procedure with the Parameter Collection and
        /// returns the DataTable.
        /// </summary>
        /// <param name="CommandText">Name of the Storec Procedure</param>
        /// <param name="ParamsCollection">SqlParameterCollection object</param>
        /// <returns></returns>
        public DataTable ExecuteSelectDataTable(String CommandText, SqlParameterCollection ParamsCollection)
        {
            return ExecuteSQL(CommandText, ParamsCollection).Tables[0];
        }

        /// <summary>
        /// Executes the stored procedure and
        /// returns the DataTable.
        /// </summary>
        /// <param name="CommandText">Name of the Stored Procedure</param>
        /// <returns></returns>
        public DataTable ExecuteSelectDataTable(String CommandText)
        {
            return ExecuteSQLDataset(CommandText).Tables[0];
        }

        /// <summary>
        /// Executes the stored procedure with the Sql Parameter array and
        /// returns the DataSet.
        /// </summary>
        /// <param name="CommandText">Name of the Stored Procedure</param>
        /// <param name="Params">Array of SqlParameter object</param>
        /// <returns></returns>
        public DataSet ExecuteSelectDataSet(String CommandText, SqlParameter[] Params)
        {
            return ExecuteSQL(CommandText, Params);

        }

        /// <summary>
        /// Executes the stored procedure with the Parameter collection and
        /// returns the DataSet.
        /// </summary>
        /// <param name="CommandText">Name of the Stored Procedure</param>
        /// <param name="ParamsCollection">SqlParameterCollection object</param>
        /// <returns></returns>
        public DataSet ExecuteSelectDataSet(String CommandText, SqlParameterCollection ParamsCollection)
        {
            return ExecuteSQL(CommandText, ParamsCollection);
        }

        /// <summary>
        /// Executes the Stored Procedure and Returns the DataSet
        /// </summary>
        /// <param name="CommandText">Name of the Stored Procedure</param>
        /// <returns></returns>
        public DataSet ExecuteSelectDataSet(String CommandText)
        {
            return ExecuteSQLDataset(CommandText);
        }



        public int ExecuteNonQuery(String CommandText)
        {
            OpenConnection();
            //			SqlCommand cmdObj=new SqlCommand(CommandText,Conn);
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.Connection = Conn;
            cmdObj.CommandText = CommandText;
            int intRecordsAffected = cmdObj.ExecuteNonQuery();
            cmdObj.Dispose();
            CloseConnection();

            return intRecordsAffected;
        }

        public int ExecuteScalarint(String CommandText)
        {
            OpenConnection();
            //			SqlCommand cmdObj=new SqlCommand(CommandText,Conn);
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.Connection = Conn;
            cmdObj.CommandText = CommandText;
            int intRecords = Convert.ToInt16(cmdObj.ExecuteScalar().ToString());
            cmdObj.Dispose();
            CloseConnection();

            return intRecords;
        }


        /// <summary>
        /// Executes the stored procedure with the Parameter collection and 
        /// returns the numebr of records affected.
        /// </summary>
        /// <param name="CommandText"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(String CommandText, SqlParameter[] Params)
        {
            OpenConnection();
            //			SqlCommand cmdObj=new SqlCommand(CommandText,Conn);
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.CommandType = CommandType.StoredProcedure;
            cmdObj.Connection = Conn;
            cmdObj.CommandText = CommandText;

            if (Params.Length > 0)
            {
                for (int i = 0; i < Params.Length; i++)
                {
                    cmdObj.Parameters.Add(Params[i]);
                }
            }

            int intRecordsAffected = cmdObj.ExecuteNonQuery();
            cmdObj.Dispose();
            CloseConnection();

            return intRecordsAffected;
        }



        /// <summary>
        /// Executes the stored procedure with the Parameter collection and 
        /// returns the numebr of records affected.
        /// </summary>
        /// <param name="CommandText"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        public string ExecuteScalar(String CommandText, SqlParameter[] Params)
        {
            OpenConnection();
            //			SqlCommand cmdObj=new SqlCommand(CommandText,Conn);
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.CommandType = CommandType.StoredProcedure;
            cmdObj.Connection = Conn;
            cmdObj.CommandText = CommandText;

            if (Params.Length > 0)
            {
                for (int i = 0; i < Params.Length; i++)
                {
                    cmdObj.Parameters.Add(Params[i]);
                }
            }

            string intRecordsAffected = cmdObj.ExecuteScalar().ToString();
            cmdObj.Dispose();
            CloseConnection();

            return intRecordsAffected;
        }





        /// <summary>
        /// Executes the stored procedure with the Parameter collection and 
        /// returns the numebr of records affected.
        /// </summary>
        /// <param name="CommandText"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        /// 

        public string ExecuteScalar(String CommandText)
        {
            OpenConnection();
            //			SqlCommand cmdObj=new SqlCommand(CommandText,Conn);
            SqlCommand cmdObj = new SqlCommand();

            cmdObj.Connection = Conn;
            cmdObj.CommandText = CommandText;

            string intRecordsAffected = cmdObj.ExecuteScalar().ToString();
            cmdObj.Dispose();
            CloseConnection();

            return intRecordsAffected;
        }





        /// <summary>
        /// Executes the Stored Procedure with the SqlParameterCollection and
        /// returns the number of records affected.
        /// </summary>
        /// <param name="CommandText">Name of the Stored Procedure</param>
        /// <param name="ParamsCollection">SqlParameterCollection object</param>
        /// <returns></returns>
        public int ExecuteNonQuery(String CommandText, SqlParameterCollection ParamsCollection)
        {
            OpenConnection();
            //			SqlCommand cmdObj=new SqlCommand(CommandText,Conn);
            SqlCommand cmdObj = new SqlCommand();
            cmdObj.CommandType = CommandType.StoredProcedure;
            cmdObj.Connection = Conn;
            cmdObj.CommandText = CommandText;

            if (ParamsCollection.Count > 0)
            {
                for (int i = 0; i < ParamsCollection.Count; i++)
                {
                    cmdObj.Parameters.Add(ParamsCollection[i]);
                }
            }

            int intRecordsAffected = cmdObj.ExecuteNonQuery();
            cmdObj.Dispose();
            CloseConnection();

            return intRecordsAffected;
        }

        /// <summary>
        /// Opens the Connection and Begins the Transaction
        /// </summary>
        public void BeginTransaction()
        {
            OpenConnection();

            //Begin the transaction
            sqlTrans = Conn.BeginTransaction();
        }

        /// <summary>
        /// Commits the Transaction
        /// </summary>
        public void CommitTransaction()
        {
            sqlTrans.Commit();
            sqlTrans.Dispose();
            CloseConnection();
        }

        /// <summary>
        /// Rolls Back the Transaction
        /// </summary>
        public void RollBackTransaction()
        {
            sqlTrans.Rollback();
            sqlTrans.Dispose();
            CloseConnection();
        }

        /// <summary>
        /// Executes a Non Query inside a Transaction. Throws an exception
        /// if called before calling BeginTransaction()
        /// </summary>
        /// <param name="CommandText">Query or Stored Procedure Name</param>
        /// <param name="colParams">Array of Sql Parameters</param>
        /// <returns></returns>
        public DataTable ExecuteSQLWithTransaction(String CommandText, SqlParameter[] Params)
        {
            //Check whether the transaction is started
            if (sqlTrans == null)
            {
                throw new Exception("Transaction not started");
            }

            SqlCommand cmdObj = new SqlCommand(CommandText, sqlTrans.Connection);
            cmdObj.CommandType = CommandType.StoredProcedure;
            ///Assign the transaction object
            cmdObj.Transaction = sqlTrans;

            if (Params.Length > 0)
            {
                for (int i = 0; i < Params.Length; i++)
                {
                    cmdObj.Parameters.Add(Params[i]);
                }
            }
            SqlDataAdapter daSP = new SqlDataAdapter(cmdObj);
            DataTable dtTbl = new DataTable();

            daSP.Fill(dtTbl);
            daSP.Dispose();

            cmdObj.Dispose();

            return dtTbl;
        }
        #endregion

    }
}
