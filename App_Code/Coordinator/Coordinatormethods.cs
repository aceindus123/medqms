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
using System.Web;
using cmm.DataAccessLayer;
using cmm.coordinatorpop;
using cmm.DataBaseAccessLayer;

/// <summary>
/// Summary description for Coordinatormethods
/// </summary>
namespace cmm.coordbindmethods
{
    public class Coordinatormethods
    {
        public DataAccess dac = new DataAccess();
        static string Connection = ConfigurationManager.AppSettings["ConnectionString"];
        SqlConnection con = new SqlConnection(Connection);
        string ds1;
        public Coordinatormethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }
       
        public bool insertcoord(string comments, string crossfunreviwer, string tgtcmpltndate, string Reviewer, string Timeline, string actnitmdesc, 
            string Executor, string changeid, string submit, string Reviewer1, string department, string depthod, string Timeline1, 
            int status, int Curstatus, string priority, string actitmtree, string funreview,string prioritycode)
        {
          SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                connection.Open();
                //SqlTransaction myTrans = connection.BeginTransaction();
                SqlParameter[] arParms = new SqlParameter[19];
                //Int32 status = 0;
                arParms[0] = new SqlParameter("@Comments", SqlDbType.NVarChar);
                arParms[0].Value = comments;
                arParms[1] = new SqlParameter("@crossfunreviwer", SqlDbType.NVarChar);
                arParms[1].Value = crossfunreviwer;
                arParms[2] = new SqlParameter("@tgtcmpltndate", SqlDbType.NVarChar);
                arParms[2].Value = tgtcmpltndate;
                arParms[3] = new SqlParameter("@Reviewer", SqlDbType.NVarChar);
                arParms[3].Value = Reviewer;
                arParms[4] = new SqlParameter("@Timeline", SqlDbType.NVarChar);
                arParms[4].Value = Timeline;
                arParms[5] = new SqlParameter("@actnitmdesc", SqlDbType.NVarChar);
                arParms[5].Value = actnitmdesc;
                arParms[6] = new SqlParameter("@Executor", SqlDbType.NVarChar);
                arParms[6].Value = Executor;

                arParms[7] = new SqlParameter("@changeid", SqlDbType.NVarChar);
                arParms[7].Value = changeid;
                arParms[8] = new SqlParameter("@submit", SqlDbType.NVarChar);
                arParms[8].Value = submit;
                arParms[9] = new SqlParameter("@Reviewer1", SqlDbType.NVarChar);
                arParms[9].Value = Reviewer1;
                arParms[10] = new SqlParameter("@department", SqlDbType.NVarChar);
                arParms[10].Value = department;
                arParms[11] = new SqlParameter("@depthod", SqlDbType.NVarChar);
                arParms[11].Value =depthod;
                arParms[12] = new SqlParameter("@Timeline1", SqlDbType.NVarChar);
                arParms[12].Value = Timeline1;
                arParms[13] = new SqlParameter("@status", SqlDbType.Int);
                arParms[13].Value = status;
                arParms[14] = new SqlParameter("@Curstatus", SqlDbType.Int);
                arParms[14].Value = Curstatus;
                arParms[15] = new SqlParameter("@priority", SqlDbType.NVarChar);
                arParms[15].Value = priority;
                arParms[16] = new SqlParameter("@actitmtree", SqlDbType.NVarChar);
                arParms[16].Value = actitmtree;
                arParms[17] = new SqlParameter("@funreview", SqlDbType.NVarChar);
                arParms[17].Value = funreview;
                arParms[18] = new SqlParameter("@prioritycode", SqlDbType.NVarChar);
                arParms[18].Value = prioritycode;


         dac.ExecuteNonQuery("sp_CMS_CoOrdinator", arParms);
                //DBOperations.ExecuteNonQuery(myTrans, CommandType.StoredProcedure, "sp_CMS_CoOrdinator", arParms);
                //myTrans.Commit();
                connection.Close();
               return true;
        }

        public bool updatecoordinator(string comments, string crossfunreviwer, string tgtcmpltndate, string Reviewer, string Timeline, string actnitmdesc,
            string Executor, string changeid, string submit, string Reviewer1, string department, string depthod, string Timeline1,
            int status, int Curstatus, string priority, string actitmtree, string funreview, string prioritycode)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();
            //SqlTransaction myTrans = connection.BeginTransaction();
            SqlParameter[] arParms = new SqlParameter[19];
            //Int32 status = 0;
            arParms[0] = new SqlParameter("@Comments", SqlDbType.NVarChar);
            arParms[0].Value = comments;
            arParms[1] = new SqlParameter("@crossfunreviwer", SqlDbType.NVarChar);
            arParms[1].Value = crossfunreviwer;
            arParms[2] = new SqlParameter("@tgtcmpltndate", SqlDbType.NVarChar);
            arParms[2].Value = tgtcmpltndate;
            arParms[3] = new SqlParameter("@Reviewer", SqlDbType.NVarChar);
            arParms[3].Value = Reviewer;
            arParms[4] = new SqlParameter("@Timeline", SqlDbType.NVarChar);
            arParms[4].Value = Timeline;
            arParms[5] = new SqlParameter("@actnitmdesc", SqlDbType.NVarChar);
            arParms[5].Value = actnitmdesc;
            arParms[6] = new SqlParameter("@Executor", SqlDbType.NVarChar);
            arParms[6].Value = Executor;

            arParms[7] = new SqlParameter("@changeid", SqlDbType.NVarChar);
            arParms[7].Value = changeid;
            arParms[8] = new SqlParameter("@submit", SqlDbType.NVarChar);
            arParms[8].Value = submit;
            arParms[9] = new SqlParameter("@Reviewer1", SqlDbType.NVarChar);
            arParms[9].Value = Reviewer1;
            arParms[10] = new SqlParameter("@department", SqlDbType.NVarChar);
            arParms[10].Value = department;
            arParms[11] = new SqlParameter("@depthod", SqlDbType.NVarChar);
            arParms[11].Value = depthod;
            arParms[12] = new SqlParameter("@Timeline1", SqlDbType.NVarChar);
            arParms[12].Value = Timeline1;
            arParms[13] = new SqlParameter("@status", SqlDbType.Int);
            arParms[13].Value = status;
            arParms[14] = new SqlParameter("@Curstatus", SqlDbType.Int);
            arParms[14].Value = Curstatus;
            arParms[15] = new SqlParameter("@priority", SqlDbType.NVarChar);
            arParms[15].Value = priority;
            arParms[16] = new SqlParameter("@actitmtree", SqlDbType.NVarChar);
            arParms[16].Value = actitmtree;
            arParms[17] = new SqlParameter("@funreview", SqlDbType.NVarChar);
            arParms[17].Value = funreview;
            arParms[18] = new SqlParameter("@prioritycode", SqlDbType.NVarChar);
            arParms[18].Value = prioritycode;


            dac.ExecuteNonQuery("SP_UpdateCoordinator", arParms);
            //DBOperations.ExecuteNonQuery(myTrans, CommandType.StoredProcedure, "sp_CMS_CoOrdinator", arParms);
            //myTrans.Commit();
            connection.Close();
            return true;
        }
    }
}