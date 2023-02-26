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
    public partial class com_signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                email.Text = Session["email"].ToString();
            }
            catch (NullReferenceException ex)
            {
                Response.Write("<script>alert('Please log in or sign up.')</script>");
                Response.Redirect("~/index.aspx");
            }
        }

        protected void Register(object sender, EventArgs e)
        {
            string mail = email.Text;
            string pw = pass.Text;
            string name = company.Text;
            string num = contact.Text;
            string bio = about.Text;
            string mission = missiontxt.Text;
            string vision = visiontxt.Text;
            string site = website.Text;

            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;";
            constr += "Data Source=" + Server.MapPath("~/App_Data/jobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);


            // Check if Company is not yet registered
            string usernm = "SELECT * FROM companyTBL WHERE companyName = '" + name + "';";
            OleDbDataAdapter sqluser = new OleDbDataAdapter(usernm, conn);
            DataTable dtUser = new DataTable();
            sqluser.Fill(dtUser);

            // Check if Number is not yet registered
            string cont = "SELECT * FROM companyTBL WHERE companyName = '" + name + "';";
            OleDbDataAdapter sqlcont = new OleDbDataAdapter(cont, conn);
            DataTable dtcont = new DataTable();
            sqlcont.Fill(dtcont);

            if ((dtUser.Rows.Count > 0) && (dtcont.Rows.Count > 0))
            {
                Response.Write("<script>alert('Your company already have an account. Please sign in instead.')</script>");
            }
            else
            {
                conn.Open();
                string cmd = "INSERT INTO companyTBL (companyName, email, contactnum, pass, about, mission, vision, website) VALUES";
                cmd += "('" + name + "','" + mail + "','" + num + "','" + pw + "','" + bio + "','" + mission + "','" + vision + "','" + site + "');";

                OleDbCommand sql = new OleDbCommand(cmd, conn);

                sql.ExecuteNonQuery();

                conn.Close();

                email.Text = "";
                pass.Text = "";
                company.Text = "";
                contact.Text = "";
                about.Text = "";
                missiontxt.Text = "";
                visiontxt.Text = "";
                website.Text = "";

                // Session["Email"] = email.Text;
                Response.Redirect("company_index.aspx");
            }

        }
    }
}