using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using cmm.DataAccessLayer;

namespace cmm.errorexcep
{
    /// <summary>
    /// Summary description for error
    /// </summary>
 
    public class error
    {
     //   public DBOperations obj = new DBOperations();
        public DataAccess dac = new DataAccess();
        static string Connection = ConfigurationManager.AppSettings["ConnectionString"];
        SqlConnection con = new SqlConnection(Connection);
        string ds1;
        public error()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet insert_exception(Exception ex, string excep_page)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();
            SqlTransaction myTrans = connection.BeginTransaction();
            DataSet ds = new DataSet();
            //try
            //{
            string excep1 = ex.StackTrace.ToString();
            string  line = excep1.Substring(excep1.LastIndexOf("line"), (excep1.Length - excep1.LastIndexOf("line")));
                string exception_msg = ex.Message;
                string excep_date = System.DateTime.Now.ToString();
                string excep_status = "0";
               
               
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@excepdesc", exception_msg);
                parm[1] = new SqlParameter("@exceppdate", excep_date);
                parm[2] = new SqlParameter("@excepstatus", excep_status);
                parm[3] = new SqlParameter("@exceppage", excep_page);
                parm[4] = new SqlParameter("@explineno",line);
               // error err = new error();
                ds = dac.ExecuteSQL("SP_CMMErrorsproc", parm);
         
            return ds;
        }

      
    }
}