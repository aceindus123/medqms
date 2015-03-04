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
namespace cmm.audithistory
{
    /// <summary>
    /// Summary description for audithistorymethod
    /// </summary>
    public class audithistorymethod
    {
        //   public DBOperations obj = new DBOperations();
        public DataAccess dac = new DataAccess();
        static string Connection = ConfigurationManager.AppSettings["ConnectionString"];
        SqlConnection con = new SqlConnection(Connection);
        public audithistorymethod()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public bool Insertaudithistory(string changeid, string role, string userid, string activity, string timestamp, int rolecode, string assignedto,string submitreviewer)
        {
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                connection.Open();
                SqlTransaction myTrans = connection.BeginTransaction();
                SqlParameter[] arParms = new SqlParameter[8];
                //Int32 status = 0;
                arParms[0] = new SqlParameter("@changeid", SqlDbType.NVarChar);
                arParms[0].Value = changeid;
                arParms[1] = new SqlParameter("@role", SqlDbType.NVarChar);
                arParms[1].Value = role;
                arParms[2] = new SqlParameter("@userid", SqlDbType.NVarChar);
                arParms[2].Value = userid;
                arParms[3] = new SqlParameter("@activity", SqlDbType.NVarChar);
                arParms[3].Value = activity;
                arParms[4] = new SqlParameter("@timestamp", SqlDbType.NVarChar);
                arParms[4].Value = timestamp;
                arParms[5] = new SqlParameter("@rolecode", SqlDbType.Int);
                arParms[5].Value = rolecode;
                arParms[6] = new SqlParameter("@assignedto", SqlDbType.NVarChar);
                arParms[6].Value = assignedto;
                arParms[7] = new SqlParameter("@submireviewer", SqlDbType.NVarChar);
                arParms[7].Value = submitreviewer;

                dac.ExecuteNonQuery("Sp_AuditHistory", arParms);
                //myTrans.Commit();
                connection.Close();
                return true;
            }
        }
    }
}