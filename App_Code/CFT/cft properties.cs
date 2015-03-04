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
/// <summary>
/// Summary description for cft_properties
/// </summary>
namespace cmm.cftproperties
{
    public class cft_properties
    {
        public cft_properties()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private string Changeid;

        public string Changeid1
        {
            get { return Changeid; }
            set { Changeid = value; }
        }
        private string department;

        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        private string impactanalysis;

        public string Impactanalysis
        {
            get { return impactanalysis; }
            set { impactanalysis = value; }
        }
        private string actiontree;

        public string Actiontree
        {
            get { return actiontree; }
            set { actiontree = value; }
        }
        private string executor;

        public string Executor
        {
            get { return executor; }
            set { executor = value; }
        }
        private string reviewer;

        public string Reviewer
        {
            get { return reviewer; }
            set { reviewer = value; }
        }
        private string targetdate;

        public string Targetdate
        {
            get { return targetdate; }
            set { targetdate = value; }
        }
        public int curstatus;
     
    
public int Curstatus
{
  get { return curstatus; }
  set { curstatus = value; }
}}
}