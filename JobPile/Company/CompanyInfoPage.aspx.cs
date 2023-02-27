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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //companyEmail to cemail
                string email = companyEmail;
                //Query to get all data based on jobTitle
                string query = "SELECT * FROM [companyTBL] WHERE [email] = '" + email + "'";

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
                                cname.Text = dt.Rows[0]["companyName"].ToString();
                                emailTXT.Text = dt.Rows[0]["email"].ToString();
                                website.Text = dt.Rows[0]["website"].ToString();
                                contact.Text = dt.Rows[0]["contactnum"].ToString();
                                about.Text = dt.Rows[0]["about"].ToString();
                                mission.Text = dt.Rows[0]["mission"].ToString();
                                vision.Text = dt.Rows[0]["vision"].ToString();
                            }
                        }
                    }
                }
            }
            catch
            {
                Response.Write("<script>alert('Session Error!')</script>");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='Main'},3600)", true);
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