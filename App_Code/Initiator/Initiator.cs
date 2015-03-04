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
using cmm.Initiatorproperties;

namespace cmm.Initiator
{
    /// <summary>
    /// Summary description for Initiator
    /// </summary>
    public class Initiator
    {
        public DataAccess dac = new DataAccess();
        static string Connection = ConfigurationManager.AppSettings["ConnectionString"];
        SqlConnection con = new SqlConnection(Connection);
        string ds1;
       
        public Initiator()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
        public bool Insertinitiator(string changeid, string initdate, string initby, string typechange, string changeperiod, string cclassification,
            string unit, string dept, string csource, string ccategory, string refid, string customer, string market, string license, string cdesc, string existing, 
            string proposal, string relchngs, string reschnge, string submit, string attachments, string pimpact, string simpact, 
            string rimpact, string productname,
            string dosfrom, string safetyass, string regimpdesc, int status, int cstatus, string searchcc, string updatedate,int cftstatus)
        {
              SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                connection.Open();
                SqlTransaction myTrans = connection.BeginTransaction();
                SqlParameter[] arParms = new SqlParameter[32];
                //Int32 status = 0;
                arParms[0] = new SqlParameter("@Changeid", SqlDbType.NVarChar);
                arParms[0].Value = changeid;
                arParms[1] = new SqlParameter("@initdate", SqlDbType.NVarChar);
                arParms[1].Value = initdate;
                arParms[2] = new SqlParameter("@initby", SqlDbType.NVarChar);
                arParms[2].Value = initby;
                arParms[3] = new SqlParameter("@typechange", SqlDbType.NVarChar);
                arParms[3].Value = typechange;
                arParms[4] = new SqlParameter("@changeperiod", SqlDbType.NVarChar);
                arParms[4].Value = changeperiod;
                arParms[5] = new SqlParameter("@cclassification", SqlDbType.NVarChar);
                arParms[5].Value = cclassification;
                arParms[6] = new SqlParameter("@Unit", SqlDbType.NVarChar);
                arParms[6].Value = unit;
                arParms[7] = new SqlParameter("@Dept", SqlDbType.NVarChar);
                arParms[7].Value = dept;
                arParms[8] = new SqlParameter("@csource", SqlDbType.NVarChar);
                arParms[8].Value = csource;
                arParms[9] = new SqlParameter("@ccategory", SqlDbType.NVarChar);
                arParms[9].Value = ccategory;
                arParms[10] = new SqlParameter("@Refid", SqlDbType.NVarChar);
                arParms[10].Value = refid;
                arParms[11] = new SqlParameter("@Customer", SqlDbType.NVarChar);
                arParms[11].Value = customer;
                arParms[12] = new SqlParameter("@Market", SqlDbType.NVarChar);
                arParms[12].Value = market;
                arParms[13] = new SqlParameter("@License", SqlDbType.NVarChar);
                arParms[13].Value = license;
                arParms[14] = new SqlParameter("@CDesc", SqlDbType.NVarChar);
                arParms[14].Value = cdesc;
                arParms[15] = new SqlParameter("@existing", SqlDbType.VarChar);
                arParms[15].Value = existing;
                arParms[16] = new SqlParameter("@proposal", SqlDbType.VarChar);
                arParms[16].Value = proposal;
                arParms[17] = new SqlParameter("@relchngs", SqlDbType.NVarChar);
                arParms[17].Value = relchngs;
                arParms[18] = new SqlParameter("@reschnge", SqlDbType.NVarChar);
                arParms[18].Value = reschnge;
                arParms[19] = new SqlParameter("@submit", SqlDbType.NVarChar);
                arParms[19].Value = submit;
                arParms[20] = new SqlParameter("@Attachments", SqlDbType.NVarChar);
                arParms[20].Value = attachments;
                arParms[21] = new SqlParameter("@pimpact", SqlDbType.NVarChar);
                arParms[21].Value = pimpact;
                arParms[22] = new SqlParameter("@simpact", SqlDbType.NVarChar);
                arParms[22].Value = simpact;
                arParms[23] = new SqlParameter("@rimpact", SqlDbType.NVarChar);
                arParms[23].Value = rimpact;
                arParms[24] = new SqlParameter("@productname", SqlDbType.NVarChar);
                arParms[24].Value = productname;
                arParms[25] = new SqlParameter("@dosfrom", SqlDbType.NVarChar);
                arParms[25].Value = dosfrom;
                arParms[26] = new SqlParameter("@safetyass", SqlDbType.NVarChar);
                arParms[26].Value = safetyass;
                arParms[27] = new SqlParameter("@regimpdesc", SqlDbType.NVarChar);
                arParms[27].Value = regimpdesc;
                arParms[28] = new SqlParameter("@status", SqlDbType.Int);
                arParms[28].Value = status;
                arParms[29] = new SqlParameter("@cstatus", SqlDbType.Int);
                arParms[29].Value = cstatus;
                arParms[30] = new SqlParameter("@searchcc", SqlDbType.NVarChar);
                arParms[30].Value = searchcc;
                arParms[30] = new SqlParameter("@updatedate", SqlDbType.NVarChar);
                arParms[30].Value = updatedate;
                arParms[31] = new SqlParameter("@cftstatus", SqlDbType.Int);
                arParms[31].Value = cftstatus;

                dac.ExecuteNonQuery("Sp_InsertInitiator", arParms);
                //myTrans.Commit();
                connection.Close();
               return true;
        }
    }
}