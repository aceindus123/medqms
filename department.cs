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
/// <summary>
/// Summary description for department
/// </summary>
namespace cmm.departments
{
    public class department
    {
        public DataAccess dac = new DataAccess();
        static string Connection = ConfigurationManager.AppSettings["ConnectionString"];
        SqlConnection con = new SqlConnection(Connection);
  
        public department()
        {
            //
            // TODO: Add constructor logic here
            //

        }
          
        public void departmentbinding(DropDownList dp)
        {
            FillDrop(dp,"select DeptId,DeptDesc from CMM_Departments order by DeptDesc asc", "DeptId", "DeptDesc", "Select One");
            
        }
        public bool FillDrop(System.Web.UI.WebControls.DropDownList dp, string stm, string ValueFld, string TextFld, string dfltTxt)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            con.Open();
            SqlCommand cmd = new SqlCommand(stm, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            try
            {

                dp.DataValueField = ValueFld;
                dp.DataTextField = TextFld;
                dp.DataSource = rdr;
                dp.DataBind();
            }
            finally
            {
                if (!(rdr == null))
                {
                    rdr.Close();
                }
                dp.Items.Insert(0, dfltTxt);
                dp.SelectedIndex = 0;
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            return true;
        }
    }
}
   