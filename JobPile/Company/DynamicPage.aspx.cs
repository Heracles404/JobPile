using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Net.Mail;
using System.Collections;
using System.Data.SqlTypes;

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
            //Store jobID data from HyperLink
            string temp = this.Page.RouteData.Values["jpID"].ToString();
            string tempid = temp.Replace("{", "").Replace("}", "");
            int jobID = Int32.Parse(tempid);

            Session["jpID"] = jobID;

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
            string query = "select employeeTBL.ID, employeeTBL.resumelink, employeeTBL.firstname+' '+employeeTBL.lastname as [Candidate], ";
            query += "jobpostTBL.jptitle, employeeTBL.email from (jobpostTBL INNER JOIN SeekersPerPost ON jobpostTBL.jpID = SeekersPerPost.jpID) INNER JOIN ";
            query += "employeeTBL ON SeekersPerPost.empID = employeeTBL.ID where jobpostTBL.jpID = " + jobID;
            OleDbDataAdapter newadapter = new OleDbDataAdapter(query, conn);

            DataTable dataTable = new DataTable();
            newadapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            conn.Close();
        }

        protected void approve_Click(object sender, EventArgs e)
        {
            try
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

                //Get the value of column from the DataKeys using the RowIndex.
                string jobTitle = GridView1.DataKeys[rowIndex].Values[0].ToString();
                int empID = Int32.Parse(GridView1.DataKeys[rowIndex].Values[1].ToString());
                string resumelink = GridView1.DataKeys[rowIndex].Values[2].ToString();
                string empEmail = GridView1.DataKeys[rowIndex].Values[3].ToString();

                string temp = this.Page.RouteData.Values["jpID"].ToString();
                string tempid = temp.Replace("{", "").Replace("}", "");
                int jobID = Int32.Parse(tempid);

                string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
                constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
                OleDbConnection newconn = new OleDbConnection(constr);
                newconn.Open();

                // Fetch companyID based on email
                string compEmail = Session["Email"].ToString();
                string sqlsmt = "select * from companyTBL where email = '" + compEmail + "';";
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, newconn);

                DataTable dtID = new DataTable();
                adapter.Fill(dtID);
                int id = Int32.Parse(dtID.Rows[0]["ID"].ToString());
                string companyName = dtID.Rows[0]["companyName"].ToString();

                string query = "delete from SeekersPerPost where empID=" + empID;
                query += " and jpID=" + jobID;

                // string query = "insert into interviewTBL status VALUES('Approved')";
                // adapter = new OleDbDataAdapter(query, newconn);

                OleDbCommand sqlcmd = new OleDbCommand(query, newconn);
                sqlcmd.ExecuteNonQuery();

                query = "select * from jobpostTBL where jpID = " + jobID;
                adapter = new OleDbDataAdapter(query, newconn);
                dtID = new DataTable();
                adapter.Fill(dtID);
                int seeknum = Int32.Parse(dtID.Rows[0]["jpseekers"].ToString());
                seeknum -= 1;

                query = "update jobpostTBL set jpseekers = " + seeknum + " where jpID = " + jobID;
                sqlcmd = new OleDbCommand(query, newconn);
                sqlcmd.ExecuteNonQuery();

                query = "insert into preinterviewTBL(empID,interviewDate,jobtitle,compID,status) values(" + empID;
                query += ",'" + datetxt.Text + "','" + jobTitle + "'," + id + ",'Approved');";
                sqlcmd = new OleDbCommand(query, newconn);
                sqlcmd.ExecuteNonQuery();

                string emp_mail = empEmail;
                string job = jobTitle;
                string resume = resumelink;

                string mess = "You are invited for an interview for " + job + " at " + datetxt.Text;
                mess += ". \n Please contact " + companyName + " at " + compEmail + " for more details.";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("jobpilemcl@gmail.com");
                    mail.To.Add(emp_mail);
                    mail.Subject = "Received an Application";
                    mail.Body = mess;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("jobpilemcl@gmail.com", "xtfgxxqpcsggpnhw");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                query = "select employeeTBL.ID, employeeTBL.resumelink, employeeTBL.firstname+' '+employeeTBL.lastname as [Candidate], ";
                query += "jobpostTBL.jptitle from (jobpostTBL INNER JOIN SeekersPerPost ON jobpostTBL.jpID = SeekersPerPost.jpID) INNER JOIN ";
                query += "employeeTBL ON SeekersPerPost.empID = employeeTBL.ID where jobpostTBL.jpID = " + jobID;
                OleDbDataAdapter newadapter = new OleDbDataAdapter(query, newconn);

                DataTable dataTable = new DataTable();
                newadapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();

                Response.Write("<script>alert('Approval Successful')</script>");
                datetxt.Text = "";
                newconn.Close();
            }
            catch
            {
                Response.Write("<script>alert('Timeout! \nLogin Again!')</script>");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='Main'},3600)", true);
            }
        }
        
        protected void deny_Click(object sender, EventArgs e)
        {
            //try
            //{
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

                //Get the value of column from the DataKeys using the RowIndex.
                string jobTitle = GridView1.DataKeys[rowIndex].Values[0].ToString();
                int empID = Int32.Parse(GridView1.DataKeys[rowIndex].Values[1].ToString());
                string temp = this.Page.RouteData.Values["jpID"].ToString();
                string tempid = temp.Replace("{", "").Replace("}", "");
                int jobID = Int32.Parse(tempid);

                string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
                constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
                OleDbConnection newconn = new OleDbConnection(constr);
                newconn.Open();

                // Fetch companyID based on email
                string compEmail = Session["Email"].ToString();
                string sqlsmt = "select * from companyTBL where email = '" + compEmail + "';";
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, newconn);

                DataTable dtID = new DataTable();
                adapter.Fill(dtID);
                int id = Int32.Parse(dtID.Rows[0]["ID"].ToString());
                string companyName = dtID.Rows[0]["companyName"].ToString();

                string query = "delete from SeekersPerPost where empID=" + empID;
                query += " and jpID=" + jobID;
                OleDbCommand sqlcmd = new OleDbCommand(query, newconn);
                sqlcmd.ExecuteNonQuery();

                query = "select * from jobpostTBL where jpID = " + jobID;
                adapter = new OleDbDataAdapter(query, newconn);
                dtID = new DataTable();
                adapter.Fill(dtID);
                int seeknum = Int32.Parse(dtID.Rows[0]["jpseekers"].ToString());
                seeknum -= 1;

                query = "update jobpostTBL set jpseekers = " + seeknum + " where jpID = " + jobID;
                sqlcmd = new OleDbCommand(query, newconn);
                sqlcmd.ExecuteNonQuery();

                query = "insert into preinterviewTBL(empID,interviewDate,jobtitle,compID,status) values(" + empID;
                query += ",'" + datetxt.Text + "','" + jobTitle + "'," + id + ",'Denied');";
                sqlcmd = new OleDbCommand(query, newconn);
                sqlcmd.ExecuteNonQuery();

                query = "select employeeTBL.ID, employeeTBL.resumelink, employeeTBL.firstname+' '+employeeTBL.lastname as [Candidate], ";
                query += "jobpostTBL.jptitle from (jobpostTBL INNER JOIN SeekersPerPost ON jobpostTBL.jpID = SeekersPerPost.jpID) INNER JOIN ";
                query += "employeeTBL ON SeekersPerPost.empID = employeeTBL.ID where jobpostTBL.jpID = " + jobID;
                OleDbDataAdapter newadapter = new OleDbDataAdapter(query, newconn);

                DataTable dataTable = new DataTable();
                newadapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();

                Response.Write("<script>alert('Application Denied')</script>");
                datetxt.Text = "";
                newconn.Close();
            /*}
            catch
            {
                Response.Write("<script>alert('Timeout! \nLogin Again!')</script>");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='Main'},3600)", true);
            }*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/JobPosts");
        }
    }
}