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
    public partial class WebForm8 : System.Web.UI.Page
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
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            // Fetch companyID based on email
            string empEmail = Session["Email"].ToString();
            string sqlsmt = "select * from jobpostTBL;";
            /*OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);

            DataTable dtID = new DataTable();
            adapter.Fill(dtID);
            int id = Int32.Parse(dtID.Rows[0]["ID"].ToString());

            string query = "select * from jobpostTBL where com_id = " + id + ";";*/
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            empGridView.DataSource = dataTable;
            empGridView.DataBind();
            conn.Close();
        }

        protected void empGridView_Button_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            string jobID = empGridView.DataKeys[rowIndex].Values[0].ToString();
            int seeknum = Int32.Parse(empGridView.DataKeys[rowIndex].Values[1].ToString());
            seeknum += 1;

            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection newconn = new OleDbConnection(constr);
            newconn.Open();

            // Fetch companyID based on email
            string empEmail = Session["Email"].ToString();
            string sqlsmt = "select * from employeeTBL where email = '" + empEmail + "';";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, newconn);

            DataTable dtID = new DataTable();
            adapter.Fill(dtID);
            int id = Int32.Parse(dtID.Rows[0]["ID"].ToString());

            sqlsmt = "select * from jobpostTBL where jpID=" + jobID;
            adapter = new OleDbDataAdapter(sqlsmt, newconn);
            dtID = new DataTable();
            adapter.Fill(dtID);
            string jobTitle = dtID.Rows[0]["jptitle"].ToString();
            int compID = Int32.Parse(dtID.Rows[0]["com_ID"].ToString());

            //Pending emp_Email
            string query = "insert into SeekersPerPost values (" + id;
            query += ",'" + jobTitle + "'," + compID + ");";
            OleDbCommand sqlcmd = new OleDbCommand(query,newconn);
            sqlcmd.ExecuteNonQuery();

            query = "update jobpostTBL set jpseekers = " + seeknum + " where jptitle = '";
            query += jobTitle + "'";
            sqlcmd = new OleDbCommand(query,newconn);
            sqlcmd.ExecuteNonQuery();

            Response.Write("<script>alert('Submission Successful')</script>");
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='EmployeeJobLists'},1000)", true);
            newconn.Close();
        }

        public string emp_Email
        {
            get
            {
                string cemail = Session["Email"].ToString();
                return cemail;

            }
        }

        protected void empsearchbtn_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            //Int32.Parse(Session["companyid"].ToString()) to com_id
            //Used in Gridview to show every record
            string sqlsmt = "select * from jobpostTBL where jptitle = '" + empsearchtxt.Text + "'";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt,conn);

            OleDbDataReader dataReader = sqlcmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                sqlsmt = "select * from jobpostTBL where jptitle = '" + empsearchtxt.Text + "'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                empGridView.DataSource = dataTable;
                empGridView.DataBind();
            }
            else
            {
                Response.Write("<script>alert('No Job Post Found')</script>");
                empsearchtxt.Text = "";
            }
            
            conn.Close();
        }
    }
}