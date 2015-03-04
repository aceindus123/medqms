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
namespace cmm.audithistoryproperties
{  
    /// <summary>
    /// Summary description for audithistoryproperties
    /// </summary>
    public class audithistoryproperties
    {
        
        public audithistoryproperties()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private string Changeid;
        private string role;
        private string userid;
        private string activity;
        private string timestamp;
        private int rolecode;
        private string assignedto;
        private string submitreviewer;

        public string Submitreviewer
        {
            get { return submitreviewer; }
            set { submitreviewer = value; }
        }

        public string auditChangeid
        {
            get { return Changeid; }
            set { Changeid = value; }
        }

        public string auditrole
        {
            get { return role; }
            set { role = value; }
        }
        public string audituserid
        {
            get { return userid; }
            set { userid = value; }
        }
        public string auditactivity
        {
            get { return activity; }
            set { activity = value; }
        }

        public string audittimestamp
        {
            get { return timestamp; }
            set { timestamp = value; }

        }
        public int auditrolecode
        {
            get { return rolecode; }
            set { rolecode = value; }
        }
        public string auditassignedto
        {
            get { return assignedto; }
            set { assignedto = value; }

        }

    }
}