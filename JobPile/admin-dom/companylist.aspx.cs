using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace JobPile.admin_dom
{
    public partial class WebForm1 : System.Web.UI.Page
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

            string query = "select ID, companyName, email, website from companyTBL";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            compGridView.DataSource = dt;
            compGridView.DataBind();
        }

        protected void compdelete_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int compID = Int32.Parse(compGridView.DataKeys[rowIndex].Values[0].ToString());

            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string query = "delete from jobpostTBL where com_id = " + compID;
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "delete from companyTBL where ID=" + compID;
            cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "select ID, companyName, email, website from companyTBL";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            compGridView.DataSource = dt;
            compGridView.DataBind();

            Response.Write("<script>alert('Account Deleted')</script>");
        }
    }
}