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
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //companyEmail to cemail
            //Query to get all data based on jobTitle
            string email = employeeEmail;

            string query = "SELECT * FROM [employeeTBL] WHERE [email] = '" + email + "'";

            string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
            connstr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(query))
                {
                    using (OleDbDataAdapter sda = new OleDbDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            //Stores query results in data table and set each fields in labels
                            sda.Fill(dt);
                            nametxt.Text = dt.Rows[0]["firstname"].ToString();
                            nametxt.Text += " " + dt.Rows[0]["lastname"].ToString();
                            uname.Text = dt.Rows[0]["username"].ToString();
                            num.Text = dt.Rows[0]["mobile"].ToString();
                            age.Text = dt.Rows[0]["age"].ToString();
                            bday.Text = dt.Rows[0]["birthday"].ToString();
                            gender.Text = dt.Rows[0]["gender"].ToString();
                            bio.Text = dt.Rows[0]["bio"].ToString();
                            educ.Text = dt.Rows[0]["education"].ToString();
                            degr.Text = dt.Rows[0]["degree"].ToString();
                            exp.Text = dt.Rows[0]["experience"].ToString();
                            skills.Text = dt.Rows[0]["skills"].ToString();
                            resume.Text = dt.Rows[0]["resumelink"].ToString();
                        }
                    }
                }
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
    }
}