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
    public partial class AdminIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridData();
            }
        }
        protected void GridData()
        {
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string query = "select ID, firstname+' '+lastname as [Candidates], email, username from employeeTBL";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            applicantGrid.DataSource = dt;
            applicantGrid.DataBind();
        }

        protected void empdelete_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int empID = Int32.Parse(applicantGrid.DataKeys[rowIndex].Values[0].ToString());
            
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string query = "delete from employeeTBL where ID=" + empID;
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "delete from preInterviewTBL where ID=" + empID;
            cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "delete from SeekersPerPost where ID=" + empID;
            cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "select ID, firstname+' '+lastname as [Candidates], email, username from employeeTBL";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            applicantGrid.DataSource = dt;
            applicantGrid.DataBind();

            Response.Write("<script>alert('Account Deleted')</script>");
        }

        protected void compdelete_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int compID = Int32.Parse(GridView1.DataKeys[rowIndex].Values[0].ToString());

            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string query = "delete from companyTBL where ID=" + compID;
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "select ID, companyName, email, website from companyTBL";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Response.Write("<script>alert('Account Deleted')</script>");
        }


        protected void jobseekers_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            applicantGrid.Visible = true;
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string query = "select ID, firstname+' '+lastname as [Candidates], email, username from employeeTBL";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            applicantGrid.DataSource = dt;
            applicantGrid.DataBind();
        }

        protected void company_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            applicantGrid.Visible= false;
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string query = "select ID, companyName, email, website from companyTBL";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}