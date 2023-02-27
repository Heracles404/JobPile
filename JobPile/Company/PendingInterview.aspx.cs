using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPile
{
    public partial class WebForm12 : System.Web.UI.Page
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

            /*SELECT employeeTBL.firstname + " " + employeeTBL.lastname as [Candidate], preInterviewTBL.jobtitle, preInterviewTBL.interviewDate
            FROM employeeTBL RIGHT JOIN preInterviewTBL ON employeeTBL.ID = preInterviewTBL.empID
            WHERE(((preInterviewTBL.compID) = 1));*/
            string query = "SELECT employeeTBL.firstname + ' ' + employeeTBL.lastname as [Candidate], ";
            query += "preInterviewTBL.jobtitle, preInterviewTBL.interviewDate, preInterviewTBL.interviewID FROM employeeTBL RIGHT JOIN preInterviewTBL ";
            query += "ON employeeTBL.ID = preInterviewTBL.empID WHERE preInterviewTBL.compID = " + companyID;
            query += " order by preInterviewTBL.interviewDate asc";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            applicantGrid.DataSource= dt;
            applicantGrid.DataBind();
        }

        protected void applicantGrid_Button_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int interviewID = Int32.Parse(applicantGrid.DataKeys[rowIndex].Values[0].ToString());

            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/jobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string query = "delete from preInterviewTBL where interviewID =" + interviewID;
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "SELECT employeeTBL.firstname + ' ' + employeeTBL.lastname as [Candidate], ";
            query += "preInterviewTBL.jobtitle, preInterviewTBL.interviewDate, preInterviewTBL.interviewID FROM employeeTBL RIGHT JOIN preInterviewTBL ";
            query += "ON employeeTBL.ID = preInterviewTBL.empID WHERE preInterviewTBL.compID = " + companyID;
            query += " order by preInterviewTBL.interviewDate asc";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            applicantGrid.DataSource = dt;
            applicantGrid.DataBind();

            Response.Write("<script>alert('Candidate Employee has confirmed the interview!');</script>");
            conn.Close();
        }

        public int companyID
        {
            get
            {
                string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
                constr += Server.MapPath("~/App_Data/jobpileDB.accdb");
                OleDbConnection conn = new OleDbConnection(constr);
                conn.Open();


                // Fetch companyID based on email
                string user = Session["Email"].ToString();
                string sqlsmt = "select * from companyTBL where email = '" + user + "';";
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);

                DataTable dtID = new DataTable();
                adapter.Fill(dtID);
                conn.Close();

                return Int32.Parse(dtID.Rows[0]["ID"].ToString());
            }
        }

        protected void backbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/JobPosts");
        }
    }
}