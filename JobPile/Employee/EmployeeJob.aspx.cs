using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

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
            int jobID = Int32.Parse(empGridView.DataKeys[rowIndex].Values[0].ToString());
            int seeknum = Int32.Parse(empGridView.DataKeys[rowIndex].Values[1].ToString());
            seeknum += 1;
            int compID = Int32.Parse(empGridView.DataKeys[rowIndex].Values[2].ToString());
            string jobTitle = empGridView.DataKeys[rowIndex].Values[3].ToString();

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

            //Pending emp_Email
            string query = "insert into SeekersPerPost values (" + id;
            query += "," + jobID + ");";
            OleDbCommand sqlcmd = new OleDbCommand(query,newconn);
            sqlcmd.ExecuteNonQuery();

            query = "update jobpostTBL set jpseekers = " + seeknum + " where jpID = ";
            query += jobID;
            sqlcmd = new OleDbCommand(query,newconn);
            sqlcmd.ExecuteNonQuery();

            query = "select * from jobpostTBL where not (jpID = " + jobID + ")";
            adapter = new OleDbDataAdapter(query, newconn);
            dtID = new DataTable();
            adapter.Fill(dtID);
            empGridView.DataSource = dtID;
            empGridView.DataBind();

            Response.Write("<script>alert('Submission Successful')</script>");
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
            string sqlsmt = "select * from jobpostTBL where jptitle like '%" + empsearchtxt.Text + "%'";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt,conn);

            OleDbDataReader dataReader = sqlcmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                sqlsmt = "select * from jobpostTBL where jptitle like '%" + empsearchtxt.Text + "%'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                empGridView.DataSource = dataTable;
                empGridView.DataBind();
            }
            else
            {
                Response.Write("<script>alert('No Job Post Found')</script>");
            }

            empsearchtxt.Text = "";

            conn.Close();
        }
    }
}