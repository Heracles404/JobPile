﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

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
            string jobTitle = this.Page.RouteData.Values["jptitle"].ToString();

            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            /*
            // Fetch companyID based on email
            string user = Session["Email"].ToString();
            string jobInfo = "select * from companyTBL where email = '" + user + "';";
            OleDbDataAdapter adapter = new OleDbDataAdapter(jobInfo, conn);

            DataTable dtID = new DataTable();
            adapter.Fill(dtID);
            int id = Int32.Parse(dtID.Rows[0]["ID"].ToString());
            conn.Close();*/

            //Used in Gridview to show every record
            string jobInfo = "SELECT * FROM jobpostTBL WHERE jptitle = '" + jobTitle + "';";
            
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

            OleDbConnection newconn = new OleDbConnection(connstr);
            newconn.Open();

            string query = "select employeeTBL.ID, firstname+' '+lastname as [Candidate], SeekersPerPost.JobTitle  from employeeTBL, SeekersPerPost ";
            query += "where employeeTBL.ID = SeekersPerPost.ID and SeekersPerPost.JobTitle = '" + jobTitle + "';";
            OleDbDataAdapter newadapter = new OleDbDataAdapter(query, newconn);

            DataTable dataTable = new DataTable();
            newadapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();


            newconn.Close();
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

            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection newconn = new OleDbConnection(constr);
            newconn.Open();

            //Pending emp_Email
            string query = "delete from seekerpostTBL where emp_id=" + empID;
            query += " and job_title='" + jobTitle + "';";
            OleDbCommand sqlcmd = new OleDbCommand(query, newconn);
            sqlcmd.ExecuteNonQuery();

            query = "insert into preinterviewTBL values(" + empID;
            query += ",'" + datetxt.Text + "','" + jobTitle + "');";
            sqlcmd = new OleDbCommand(query, newconn);
            sqlcmd.ExecuteNonQuery();

            GridView1.DataBind();


            // Send approval notification
            using (MailMessage mail = new MailMessage())
            {
                // Some Changes in Here
                string applicant = "Change this to applicant email";
                string com_mail = "Change this to company email"; 

                mail.From = new MailAddress("jobPileMCL@gmail.com");
                mail.To.Add(applicant);
                mail.Subject = "JobPile OTP - DO NOT REPLY";
                mail.Body = "Congratulations! You have been approved for an interview on " + datetxt.Text + ". \nPlease Contact " + com_mail + " for more details.";
                mail.IsBodyHtml = true; using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential("jobPileMCL@gmail.com", "hmmxzaoxdpbvrbhv");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }


            Response.Write("<script>alert('Approval Successful')</script>");
            datetxt.Text = "";
        }
    }
}