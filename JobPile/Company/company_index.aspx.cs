using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPile
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridData();
            }
        }

        public void GridData()
        {
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            try
            {
                // Fetch companyID based on email
                string empEmail = Session["Email"].ToString();
                string sqlsmt = "select * from companyTBL where email = '" + empEmail + "';";
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);

                DataTable dtID = new DataTable();
                adapter.Fill(dtID);
                int id = Int32.Parse(dtID.Rows[0]["ID"].ToString());


                //Used in Gridview to show every record
                sqlsmt = "SELECT * FROM jobpostTBL WHERE com_id = " + id + ";";
                adapter = new OleDbDataAdapter(sqlsmt, conn);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                applicantGrid.DataSource = dataTable;
                applicantGrid.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('Timeout! \nLogin Again!')</script>");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='Main'},1000)", true);
            }
            
            conn.Close();
        }
    }
}