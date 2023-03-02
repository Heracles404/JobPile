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
    public partial class WebForm9 : System.Web.UI.Page
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
            try
            {
                string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
                constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
                OleDbConnection conn = new OleDbConnection(constr);
                conn.Open();

                string jobID = this.Page.RouteData.Values["jpID"].ToString();
                
                string jobInfo = "SELECT * FROM [jobpostTBL] WHERE [jpID] = @jobID";

                string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
                connstr += Server.MapPath("~/App_Data/jobpileDB.accdb");
                using (OleDbConnection con = new OleDbConnection(connstr))
                {
                    using (OleDbCommand cmd = new OleDbCommand(jobInfo))
                    {
                        using (OleDbDataAdapter sda = new OleDbDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@jobID", jobID);
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                //Stores query results in data table and set each fields in labels
                                sda.Fill(dt);
                                job.Text = dt.Rows[0]["jptitle"].ToString();
                                salary.Text = dt.Rows[0]["jpsalary"].ToString();
                                shift.Text = dt.Rows[0]["jpshift"].ToString();
                                type.Text = dt.Rows[0]["jptype"].ToString();
                                location.Text = dt.Rows[0]["jplocation"].ToString();
                                skills.Text = dt.Rows[0]["jpskills"].ToString();
                                exp.Text = dt.Rows[0]["jpexperience"].ToString();
                                jobdesc.Text = dt.Rows[0]["jpdesc"].ToString();
                            }
                        }
                    }
                }
            }
            catch
            {
                Response.Write("<script>alert('Timeout! \nPlease Login Again!')</script>");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='Main'},1000)", true);
            }

        }
    }
}