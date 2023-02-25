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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void resourcebtn_Click(object sender, EventArgs e)
        {
            //Adds skill in textbox
            skillsTXT.Text += "Resourceful, ";
            resourcebtn.Visible = false;
        }

        protected void efficientbtn_Click(object sender, EventArgs e)
        {
            //Adds skill in textbox
            skillsTXT.Text += "Efficient, ";
            efficientbtn.Visible = false;
        }

        protected void Postbtn_Click(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
            connstr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection connection = new OleDbConnection(connstr);
            connection.Open();

            //companyID use as com_id
            int compID = companyID;
            //Insert Job Post Data
            string sqlcmd = "insert into jobpostTBL(jptitle,jpsalary,jpshift,jptype,jplocation,";
            sqlcmd += "jpskills,jpexperience,jpDesc,jpstatus,jpseekers,com_id) values ('" + jobtitleTXT.Text;
            sqlcmd += "'," + Double.Parse(salaryTXT.Text) + ",'" + DDLShift.SelectedItem;
            sqlcmd += "','" + DDLType.SelectedItem + "','" + locationTXT.Text;
            sqlcmd += "','" + skillsTXT.Text + "','" + DDLExperience.SelectedItem;
            sqlcmd += "','" + jobdescTXT.Text + "','" + DDLStatus.SelectedItem;
            sqlcmd += "',0,"+ compID +");";

            OleDbCommand sqlcommand = new OleDbCommand(sqlcmd, connection);
            sqlcommand.ExecuteNonQuery();

            /*
            //Check if job title has seeker(candidate)
            sqlcmd = "select count(SeekersPerPost.JobTitle) as [seekers] from SeekersPerPost ";
            sqlcmd += "group by SeekersPerPost.JobTitle having ((SeekersPerPost.[JobTitle]) = '" + jobtitleTXT.Text + "');";
            sqlcommand = new OleDbCommand(sqlcmd, connection);

            OleDbDataReader dataReader = sqlcommand.ExecuteReader();
            if (dataReader.HasRows)
            {
                //Insert candidate count
                dataReader.Read();
                sqlcmd = "update jobPostTBL set jpseekers = " + Int32.Parse(dataReader["seekers"].ToString());
                sqlcmd += " where jptitle = '" + jobtitleTXT.Text + "';";
                sqlcommand = new OleDbCommand(sqlcmd, connection);
                sqlcommand.ExecuteNonQuery();
            }*/

            Response.Write("<script>alert('The job has been posted!')</script>");
            connection.Close();

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='JobPosts'},1000)", true);
        }

        protected void skillsTXT_TextChanged(object sender, EventArgs e)
        {
            string FieldSearch = skillsTXT.Text;
            string Resourceful = "Resourceful";
            string Efficient = "Efficient";

            //To check if skills are in the textbox
            if (FieldSearch.Length > 0)
            {
                if (FieldSearch.IndexOf(Resourceful) > -1)
                {
                    resourcebtn.Visible = false;
                }
                else if (FieldSearch.IndexOf(Efficient) > -1)
                {
                    efficientbtn.Visible = false;
                }
                else
                {
                    resourcebtn.Visible = true;
                    efficientbtn.Visible = true;
                }
            }

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
                /*
                string id = dtID.Rows[0]["ID"].ToString();

                //Used in Gridview to show every record
                sqlsmt = "select com_id from companyTBL where com_id = '" + id + "';";
                OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
                OleDbDataReader datareader = sqlcmd.ExecuteReader();

                datareader.Read();*/
                conn.Close();

                return Int32.Parse(dtID.Rows[0]["ID"].ToString());
            }
        }
    }
}