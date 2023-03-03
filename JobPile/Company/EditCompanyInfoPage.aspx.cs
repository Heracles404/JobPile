using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPile
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pw.Attributes["type"] = "Password";
            if (!this.IsPostBack)
            {
                this.PopulatePage();
            }
        }

        private void PopulatePage()
        {
            
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            //companyEmail to cemail
            string email = companyEmail;
            //Query to get all data based on jobTitle
            string sqlsmt = "SELECT * FROM [companyTBL] WHERE [email] = '" + email + "'";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);

            OleDbDataReader dataReader = sqlcmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();

                //Input Initial values
                nametxt.Text = dataReader["companyName"].ToString();
                pw.Text = dataReader["pass"].ToString();
                emailtxt.Text = dataReader["email"].ToString();
                websitetxt.Text = dataReader["website"].ToString();
                numtxt.Text = dataReader["contactnum"].ToString();
                aboutustxt.Text = dataReader["about"].ToString();
                missiontxt.Text = dataReader["mission"].ToString();
                visiontxt.Text = dataReader["vision"].ToString();
            }

            conn.Close();
            
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            if(pw.Text == repw.Text)
            {
                string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
                connstr += Server.MapPath("~/App_Data/JobPileDB.accdb");
                OleDbConnection connection = new OleDbConnection(connstr);
                connection.Open();
                string email = companyEmail;

                //change cemail based on session
                string sqlsmt = "update companyTBL set companyName = '" + nametxt.Text;
                sqlsmt += "',website='" + websitetxt.Text;
                sqlsmt += "',contactnum='" + numtxt.Text + "',about='" + aboutustxt.Text;
                sqlsmt += "',mission='" + missiontxt.Text + "',vision='" + visiontxt.Text;
                sqlsmt += "' where email = '" + email + "';";

                OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, connection);
                sqlcmd.ExecuteNonQuery();
                connection.Close();

                Response.Write("<script>alert('Company Info Page updated!')</script>");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='CompanyInfo'},1000)", true);
            }
            else
            {
                Response.Write("<script>alert('Passwords do not match')</script>");
            }
        }

        public string companyEmail
        {
            get
            {
                string cemail = Session["Email"].ToString();
                return cemail;
            }
        }
    }
}