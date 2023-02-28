using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPile
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            //Query to get all data based on jobTitle
            string email = employeeEmail;
            string sqlsmt = "SELECT * FROM [employeeTBL] WHERE [email] = '" + email + "'";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);

            OleDbDataReader dataReader = sqlcmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();

                //Input Initial values

                fname.Text = dataReader["firstname"].ToString();
                lname.Text = dataReader["lastname"].ToString();
                uname.Text = dataReader["username"].ToString();
                pw.Text = dataReader["pass"].ToString();
                num.Text = dataReader["mobile"].ToString();
                age.Text = dataReader["age"].ToString();
                bday.Text = dataReader["birthday"].ToString();
                gender.Text = dataReader["gender"].ToString();
                bio.Text = dataReader["bio"].ToString();
                skills.Text = dataReader["skills"].ToString();
            }
        }

        public string employeeEmail
        {
            get
            {
                string cemail = Session["Email"].ToString();
                return cemail;
            }
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            if (repw.Text == pw.Text)
            {
                string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
                connstr += Server.MapPath("~/App_Data/JobPileDB.accdb");
                OleDbConnection connection = new OleDbConnection(connstr);
                connection.Open();
                string email = employeeEmail;

                string sqlsmt = "update employeeTBL set firstname='" + fname.Text;
                sqlsmt += "',lastname='" + lname.Text;
                sqlsmt += "',username='" + uname.Text + "', pass='" + pw.Text;
                sqlsmt += "',mobile='" + num.Text + "',age=" + age.Text;
                sqlsmt += ",birthday='" + bday.Text + "',gender='" + gender.Text;
                sqlsmt += "',bio='" + bio.Text;
                sqlsmt += "',skills='" + skills.Text;
                sqlsmt += "',resumelink='" + resume.Text;
                sqlsmt += "' where email = '" + email + "';";

                OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, connection);
                sqlcmd.ExecuteNonQuery();
                connection.Close();

                //Reset fields
                fname.Text = "";
                lname.Text = "";
                uname.Text = "";
                pw.Text = "";
                num.Text = "";
                age.Text = "";
                bday.Text = "";
                gender.Text = "";
                bio.Text = "";
                bio.Text = "";
                skills.Text = "";
                resume.Text = "";

                Response.Write("<script>alert('Changes Saved.')</script>");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='EmployeeAccounts'},1000)", true);
            }
            else
            {
                Response.Write("<script>alert('Passwords do not match.')</script>");
            }
        }
    }
}