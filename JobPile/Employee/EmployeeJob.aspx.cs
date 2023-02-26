using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
<<<<<<< HEAD
using System.Net.Mail;
=======
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8

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
<<<<<<< HEAD
            string jobTitle = empGridView.DataKeys[rowIndex].Values[0].ToString();
=======
            string jobID = empGridView.DataKeys[rowIndex].Values[0].ToString();
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
            int seeknum = Int32.Parse(empGridView.DataKeys[rowIndex].Values[1].ToString());
            seeknum += 1;

            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection newconn = new OleDbConnection(constr);
            newconn.Open();

            // Fetch companyID based on email
            string empEmail = Session["Email"].ToString();
<<<<<<< HEAD
            string sqlsmt = "select * from companyTBL where email = '" + empEmail + "';";
=======
            string sqlsmt = "select * from employeeTBL where email = '" + empEmail + "';";
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, newconn);

            DataTable dtID = new DataTable();
            adapter.Fill(dtID);
            int id = Int32.Parse(dtID.Rows[0]["ID"].ToString());

<<<<<<< HEAD
            //Pending emp_Email
            string query = "insert into SeekersPerPost values (" + id;
            query += ",'" + jobTitle + "');";
=======
            sqlsmt = "select * from jobpostTBL where jpID=" + jobID;
            adapter = new OleDbDataAdapter(sqlsmt, newconn);
            dtID = new DataTable();
            adapter.Fill(dtID);
            string jobTitle = dtID.Rows[0]["jptitle"].ToString();
            int compID = Int32.Parse(dtID.Rows[0]["com_ID"].ToString());

            //Pending emp_Email
            string query = "insert into SeekersPerPost values (" + id;
            query += ",'" + jobTitle + "'," + compID + ");";
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
            OleDbCommand sqlcmd = new OleDbCommand(query,newconn);
            sqlcmd.ExecuteNonQuery();

            query = "update jobpostTBL set jpseekers = " + seeknum + " where jptitle = '";
            query += jobTitle + "'";
            sqlcmd = new OleDbCommand(query,newconn);
            sqlcmd.ExecuteNonQuery();

<<<<<<< HEAD

            // Send application notification
            using (MailMessage mail = new MailMessage())
            {
                // Some Changes in Here
                string com_mail = "Change this to company email";
                string applicantName = "Change this to applicant's name";
                string jobname = "Change this to job name";

                mail.From = new MailAddress("jobPileMCL@gmail.com");
                mail.To.Add(com_mail);
                mail.Subject = "JobPile OTP - DO NOT REPLY";
                mail.Body = "Your listing " + jobname + " has received an application from " + applicantName + ".";
                mail.IsBodyHtml = true; using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential("jobPileMCL@gmail.com", "hmmxzaoxdpbvrbhv");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }


=======
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
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
<<<<<<< HEAD

            }

            empsearchtxt.Text = "";

            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            empGridView.DataSource = dataTable;
            empGridView.DataBind();
            conn.Close();

=======
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
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
        }
    }
}