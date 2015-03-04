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
using cmm.cftproperties;

/// <summary>
/// Summary description for cftmethod
/// </summary>
namespace cmm.cftmethods
{
    
public class cftmethod
{
    public DataAccess dac = new DataAccess();
    static string Connection = ConfigurationManager.AppSettings["ConnectionString"];
    SqlConnection con = new SqlConnection(Connection);
       
	public cftmethod()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}
      

public static bool InsertCFT(string Changeid1,string Department,string Impactanalysis,string Executor,string Reviewer,string Targetdate,string Actiontree,int curstatus)
{
       DataAccess dac = new DataAccess();
 	 SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                connection.Open();
                SqlTransaction myTrans = connection.BeginTransaction();
                SqlParameter[] arParms = new SqlParameter[8];
                //Int32 status = 0;
                arParms[0] = new SqlParameter("@changeid", SqlDbType.NVarChar);
                arParms[0].Value = Changeid1;
                arParms[1] = new SqlParameter("@role", SqlDbType.NVarChar);
                arParms[1].Value = Department;
                arParms[2] = new SqlParameter("@userid", SqlDbType.NVarChar);
                arParms[2].Value = Impactanalysis;
                arParms[3] = new SqlParameter("@activity", SqlDbType.NVarChar);
                arParms[3].Value = Executor;
                arParms[4] = new SqlParameter("@timestamp", SqlDbType.NVarChar);
                arParms[4].Value = Reviewer;
                arParms[5] = new SqlParameter("@rolecode", SqlDbType.NVarChar);
                arParms[5].Value = Targetdate;
                arParms[6] = new SqlParameter("@assignedto", SqlDbType.NVarChar);
                arParms[6].Value = Actiontree;
                arParms[7] = new SqlParameter("@submireviewer", SqlDbType.Int);
                arParms[7].Value = curstatus;

                dac.ExecuteNonQuery("sp_CMS_CFT", arParms);
                //myTrans.Commit();
                connection.Close();
                return true;
}
}
}