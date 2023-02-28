using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPile.admin_dom
{
    public partial class admin_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {           
            // Stores the input into temporary variables
            string user = email.Text;
            string pass = pw.Text;

            string constr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/jobpileDB.accdb");
            constr += ";Persist Security Info=True";
            OleDbConnection conn = new OleDbConnection(constr);

            // Log In Syntax - Check Username
            string username = "SELECT * FROM adminTBL WHERE username = '" + user + "' AND pass = '" + pass + "';";
            OleDbCommand sqlcmd = new OleDbCommand(username, conn);
            OleDbDataAdapter sqladapt = new OleDbDataAdapter(sqlcmd);
            DataTable dtUser = new DataTable();
            sqladapt.Fill(dtUser);

            if (dtUser.Rows.Count > 0) 
            {
                Response.Write("<script>alert('Logged in Successfully', 'Welcome!')</script>");
                Response.Redirect("~/ApplicantsList");
            }
            else
            {
                Response.Write("<script>alert('Admin account not found.', 'Warning!')</script>");
                errLbl.Visible = true;
            }
        }
    }
}