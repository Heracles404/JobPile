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

            Response.Write("<script>alert('The job has been posted!')</script>");
            connection.Close();

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='JobPosts'},1000)", true);
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
    }
}