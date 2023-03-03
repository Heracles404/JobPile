using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using System.Drawing.Drawing2D;
using System.Net.Mail;
using System.Data.SqlTypes;
using System.Drawing;

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
            try
            {
                string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
                constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
                OleDbConnection conn = new OleDbConnection(constr);
                conn.Open();

                int empID = employeeID;

                string sqlsmt = "select * from jobpostTBL where jpstatus = 'Active' and jpID not in ";
                sqlsmt += "(select jpID from SeekersPerPost where empID = " + empID + ")";
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                empGridView.DataSource = dataTable;
                empGridView.DataBind();

                sqlsmt = "select jpfield from jobpostTBL group by jpfield";
                adapter = new OleDbDataAdapter(sqlsmt, conn);
                dataTable= new DataTable();
                adapter.Fill(dataTable);

                ChkByList.DataSource = dataTable;
                ChkByList.DataTextField = "jpfield";
                ChkByList.DataValueField = "jpfield";
                ChkByList.DataBind();

                conn.Close();
            }
            catch
            {
                Response.Write("<script>alert('Timeout! \nPlease Login Again!')</script>");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='Main'},1000)", true);
            }
        }

        protected void empGridView_Button_Click(object sender, EventArgs e)
        {
            try 
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
                string sqlsmt = "select * from employeeTBL where email = '" + empEmail + "' or username = '" + empEmail +"';";

                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, newconn);
                DataTable dtID = new DataTable();
                adapter.Fill(dtID);
                int id = Int32.Parse(dtID.Rows[0]["ID"].ToString());
                string resumelink = dtID.Rows[0]["resumelink"].ToString();

                string query = "select * from SeekersPerPost where empID = " + id + " and jpID = " + jobID;
                OleDbCommand sqlcmd = new OleDbCommand(query, newconn);
                OleDbDataReader reader = sqlcmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Response.Write("<script>alert('You cannot apply to the same job post!')</script>");
                }
                else
                {
                    query = "insert into SeekersPerPost values (" + id;
                    query += "," + jobID + ");";
                    sqlcmd = new OleDbCommand(query, newconn);
                    sqlcmd.ExecuteNonQuery();

                    query = "update jobpostTBL set jpseekers = " + seeknum + " where jpID = ";
                    query += jobID;
                    sqlcmd = new OleDbCommand(query, newconn);
                    sqlcmd.ExecuteNonQuery();

                    query = "select email from companyTBL where ID = " + compID;
                    adapter = new OleDbDataAdapter(query, newconn);
                    dtID = new DataTable();
                    adapter.Fill(dtID);
                    string compEmail = dtID.Rows[0]["email"].ToString();

                    string com_mail = compEmail;
                    string job = jobTitle;
                    string resume = resumelink;
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("jobpilemcl@gmail.com");
                        mail.To.Add(com_mail);
                        mail.Subject = "Received an Application";
                        mail.Body = "Your job post " + job + " received an application. \n Resumé:  " + resume;
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new System.Net.NetworkCredential("jobpilemcl@gmail.com", "xtfgxxqpcsggpnhw");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }

                    query = "select * from jobpostTBL where jpstatus = 'Active' and jpID not in ";
                    query += "(select jpID from SeekersPerPost where empID = " + id + ")";
                    adapter = new OleDbDataAdapter(query, newconn);
                    dtID = new DataTable();
                    adapter.Fill(dtID);
                    empGridView.DataSource = dtID;
                    empGridView.DataBind();

                    Response.Write("<script>alert('Submission Successful')</script>");
                    newconn.Close();
                }
            }
            catch
            {
                Response.Write("<script>alert('Timeout! \nPlease Login Again!')</script>");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='Main'},3600)", true);
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
                return id;
            }
        }

        protected void empsearchbtn_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

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
        public void Check_Clicked(Object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            int empID = employeeID;

            String fields = "or";
            foreach (ListItem item in ChkByList.Items)
            {
                if (item.Selected)
                {
                    fields = " and jpfield = '" + item.Value + "' or";
                }
            }

            fields = fields.Remove(fields.Length - 2);

            string sqlsmt = "select * from jobpostTBL where jpstatus = 'Active' " + fields + " and jpID not in ";
            sqlsmt += "(select jpID from SeekersPerPost where empID = " + empID + ")";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            empGridView.DataSource = dataTable;
            empGridView.DataBind();

            conn.Close();
        }

        protected void appliedbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AppliedJobList");
        }
    }
}