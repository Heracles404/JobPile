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
    public partial class WebForm6 : System.Web.UI.Page
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
            //Store jobTitle data from HyperLink
            string jobID = this.Page.RouteData.Values["jpID"].ToString();
            string jobTitle;
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            //Used in Gridview to show every record
            string jobInfo = "SELECT * FROM jobpostTBL WHERE jpID = " + jobID + ";";

            string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
            connstr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(jobInfo))
                {
                    using (OleDbDataAdapter sda = new OleDbDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            //Stores query results in data table and set each fields in labels
                            sda.Fill(dt);
                            jobTitle = dt.Rows[0]["jptitle"].ToString();
                            jobTitlelbl.Text = jobTitle;
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

            string query = "select employeeTBL.ID, firstname+' '+lastname as [Candidate], ";
            query += "SeekersPerPost.JobTitle  from employeeTBL, SeekersPerPost ";
            query += "where employeeTBL.ID = SeekersPerPost.ID and SeekersPerPost.JobTitle = '" + jobTitle + "';";
            OleDbDataAdapter newadapter = new OleDbDataAdapter(query, conn);

            DataTable dataTable = new DataTable();
            newadapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }

        // Temporary Store Email for server transfer
        public string emailSrc
        {
            get
            {
                return Session["Email"].ToString();
            }
        }

        protected void approve_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            string jobTitle = GridView1.DataKeys[rowIndex].Values[0].ToString();
            int empID = Int32.Parse(GridView1.DataKeys[rowIndex].Values[1].ToString());
            string jobID = this.Page.RouteData.Values["jpID"].ToString();

            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection newconn = new OleDbConnection(constr);
            newconn.Open();

            // Fetch companyID based on email
            string empEmail = Session["Email"].ToString();
            string sqlsmt = "select * from companyTBL where email = '" + empEmail + "';";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, newconn);

            DataTable dtID = new DataTable();
            adapter.Fill(dtID);
            int id = Int32.Parse(dtID.Rows[0]["ID"].ToString());

            //Pending emp_Email
            string query = "delete from SeekersPerPost where ID=" + empID;
            query += " and JobTitle='" + jobTitle + "' and comID = " + id;
            OleDbCommand sqlcmd = new OleDbCommand(query, newconn);
            sqlcmd.ExecuteNonQuery();

            query = "select * from jobpostTBL where jpID = " + jobID;
            adapter = new OleDbDataAdapter(query,newconn);
            dtID = new DataTable();
            adapter.Fill(dtID);
            int seeknum = Int32.Parse(dtID.Rows[0]["jpseekers"].ToString());
            seeknum -= 1;

            query = "update jobpostTBL set jpseekers = " + seeknum + " where jpID = " + jobID;
            sqlcmd = new OleDbCommand(query, newconn);
            sqlcmd.ExecuteNonQuery();

            query = "insert into preinterviewTBL(empID,interviewDate,jobtitle,compID) values(" + empID;
            query += ",'" + datetxt.Text + "','" + jobTitle + "'," + id + ");";
            sqlcmd = new OleDbCommand(query, newconn);
            sqlcmd.ExecuteNonQuery();

            GridView1.DataBind();

            Response.Write("<script>alert('Approval Successful')</script>");
            datetxt.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/JobPosts");
        }
    }
}