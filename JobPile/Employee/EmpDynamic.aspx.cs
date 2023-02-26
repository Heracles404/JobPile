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
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string jobID = this.Page.RouteData.Values["jpID"].ToString();
            /*
            // Fetch companyID based on email
            //string empEmail = Session["Email"].ToString();
            string sqlsmt = "select * from employeeTBL where jptitle = '" + jobTitle + "';";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);

            DataTable dtID = new DataTable();
            adapter.Fill(dtID);
            int id = Int32.Parse(dtID.Rows[0]["ID"].ToString());
            
            sqlsmt = "select * from jobpostTBL where " + id + " = SeekersPerPost.ID and";
            sqlsmt += " SeekersPerPost.comID = jobpostTBL.com_id and SeekersPerPost.JobTitle = jobpostTBL.jptitle and jobpostTBL.jptitle = @jobTitle";
            */
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
                            jobTitlelbl.Text = dt.Rows[0]["jptitle"].ToString();
                            salarylbl.Text = dt.Rows[0]["jpsalary"].ToString();
                            shiftlbl.Text = dt.Rows[0]["jpshift"].ToString();
                            typelbl.Text = dt.Rows[0]["jptype"].ToString();
                            locationlbl.Text = dt.Rows[0]["jplocation"].ToString();
                            skillslbl.Text = dt.Rows[0]["jpskills"].ToString();
                            experiencelbl.Text = dt.Rows[0]["jpexperience"].ToString();
                            jobDesclbl.Text = dt.Rows[0]["jpdesc"].ToString();
                        }
                    }
                }
            }

        }
    }
}