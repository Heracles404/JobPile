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
    public partial class WebForm13 : System.Web.UI.Page
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
            try
            {
                string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
                constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
                OleDbConnection conn = new OleDbConnection(constr);
                conn.Open();

                int empID = employeeID;

                string sqlsmt = "select * from jobpostTBL where jpID in ";
                sqlsmt += "(select jpID from SeekersPerPost where empID = " + empID + ")";
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                jobpostList.DataSource = dataTable;
                jobpostList.DataBind();
                conn.Close();
            }
            catch
            {
                Response.Write("<script>alert('Timeout! \nPlease Login Again!')</script>");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='Main'},1000)", true);
            }
        }

        public int employeeID
        {
            get
            {
                string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
                constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
                OleDbConnection newconn = new OleDbConnection(constr);
                newconn.Open();

                // Fetch companyID based on email
                string empEmail = Session["Email"].ToString();
                string sqlsmt = "select * from employeeTBL where email = '" + empEmail + "' or username = '" + empEmail + "';";

                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, newconn);
                DataTable dtID = new DataTable();
                adapter.Fill(dtID);
                int id = Int32.Parse(dtID.Rows[0]["ID"].ToString());
                newconn.Close();
                return id;
            }
        }
        
        protected void jobpostList_Button_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int jobID = Int32.Parse(jobpostList.DataKeys[rowIndex].Values[0].ToString());
            int seekers = Int32.Parse(jobpostList.DataKeys[rowIndex].Values[1].ToString());
            seekers -= 1;

            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            int empID = employeeID;

            string query = "delete from SeekersPerPost where empID = " + empID + " and jpID = " + jobID;
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "update jobpostTBL set jpseekers = " + seekers + " where jpID = " + jobID;
            cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();

            string sqlsmt = "select * from jobpostTBL where jpID in ";
            sqlsmt += "(select jpID from SeekersPerPost where empID = " + empID + ")";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            jobpostList.DataSource = dataTable;
            jobpostList.DataBind();
            conn.Close();

            Response.Write("<script>alert('The job post has been unapplied')</script>");
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmployeeJobLists");
        }
    }
}