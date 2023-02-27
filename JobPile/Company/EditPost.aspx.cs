using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPile
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/jobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            //Deletes record base on jobTitle
            string sqlsmt = "delete from jobpostTBL where jptitle ='";
            sqlsmt += searchjobtitletxt.Text + "'";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            //sqlsmt = "delete "

            Response.Write("<script>alert('Job Post has been deleted!');</script>");
            searchjobtitletxt.Text = "";

            conn.Close();
        }

        protected void cmdSearch_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            //Search if jobTitle in JobPosts
            string sqlsmt = "select * from jobpostTBL where jptitle = '";
            sqlsmt += searchjobtitletxt.Text + "'";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);

            OleDbDataReader dataReader = sqlcmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();

                //Input Initial values
                jobtitleTXT.Text = dataReader["jptitle"].ToString();
                salaryTXT.Text = dataReader["jpsalary"].ToString();
                locationTXT.Text = dataReader["jplocation"].ToString();
                skillsTXT.Text = dataReader["jpskills"].ToString();
                jobdescTXT.Text = dataReader["jpdesc"].ToString();

                //Set initial shift
                if (dataReader["jpshift"].ToString() == "Day Shift")
                {
                    DDLShift.Text = "1";
                }
                else
                {
                    DDLShift.Text = "2";
                }

                //Set initial type
                if (dataReader["jptype"].ToString() == "Full Time")
                {
                    DDLType.Text = "1";
                }
                else
                {
                    DDLType.Text = "2";
                }

                //Set initial experience
                if (dataReader["jpexperience"].ToString() == "No Experience")
                {
                    DDLExperience.Text = "1";
                }
                else if (dataReader["jpexperience"].ToString() == "1-2 Years Experience")
                {
                    DDLExperience.Text = "2";
                }
                else if (dataReader["jpexperience"].ToString() == "3-5 Years Experience")
                {
                    DDLExperience.Text = "3";
                }
                else
                {
                    DDLExperience.Text = "4";
                }

                //Set initial status
                if (dataReader["jpstatus"].ToString() == "Active")
                {
                    DDLStatus.Text = "1";
                }
                else
                {
                    DDLStatus.Text = "2";
                }
            }
            else
            {
                Response.Write("<script>alert('Job Title not found!');</script>");
                searchjobtitletxt.Text = "";
            }

            conn.Close();
        }
        protected void cmdSave_Click(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
            connstr += Server.MapPath("~/App_Data/JobPileDB.accdb");
            OleDbConnection connection = new OleDbConnection(connstr);
            connection.Open();

            //Update Job Post Data
            string sqlsmt = "UPDATE jobpostTBL SET jobpostTBL.jptitle = '" + jobtitleTXT.Text;
            sqlsmt += "',jobpostTBL.jpsalary=" + int.Parse(salaryTXT.Text) + ",jobpostTBL.jpshift='" + DDLShift.SelectedItem;
            sqlsmt += "',jobpostTBL.jptype='" + DDLType.SelectedItem + "',jobpostTBL.jplocation='" + locationTXT.Text;
            sqlsmt += "',jobpostTBL.jpskills='" + skillsTXT.Text + "',jobpostTBL.jpexperience='" + DDLExperience.SelectedItem;
            sqlsmt += "',jobpostTBL.jpdesc='" + jobdescTXT.Text + "',jobpostTBL.jpstatus='" + DDLStatus.SelectedItem;
            sqlsmt += "' WHERE((jobpostTBL.[jptitle]) = '" + searchjobtitletxt.Text + "')";

            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, connection);
            sqlcmd.ExecuteNonQuery();

            Response.Write("<script>alert('The job post has been updated!')</script>");
            connection.Close();

            //Reset fields
            searchjobtitletxt.Text = "";
            jobtitleTXT.Text = "";
            salaryTXT.Text = "";
            DDLShift.SelectedIndex = -1;
            DDLType.SelectedIndex = -1;
            locationTXT.Text = "";
            skillsTXT.Text = "";
            DDLExperience.SelectedIndex = -1;
            jobdescTXT.Text = "";

            DDLStatus.SelectedIndex = -1;

            DDLStatus.SelectedIndex = -1;

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='JobPosts'},3600)", true);

            //Show Initial Search
            cmdSearch.Visible = true;
            deletebtn.Visible = true;
        }

        protected void skillsTXT_TextChanged(object sender, EventArgs e)
        {
            string FieldSearch = skillsTXT.Text;
            string Resourceful = "Resourceful";
            string Efficient = "Efficient";

            //Search if skills in textbox
            if (FieldSearch.Length > 0)
            {
                if (FieldSearch.IndexOf(Resourceful) > -1)
                {
                    resourcefulbtn.Visible = false;
                }
                else if (FieldSearch.IndexOf(Efficient) > -1)
                {
                    efficientbtn.Visible = false;
                }
                else
                {
                    resourcefulbtn.Visible = true;
                    efficientbtn.Visible = true;
                }
            }
        }

        protected void resourcebtn_Click(object sender, EventArgs e)
        {
            //Adds to skills textbox
            skillsTXT.Text += "Resourceful, ";
            resourcefulbtn.Visible = false;
        }

        protected void efficientbtn_Click(object sender, EventArgs e)
        {
            //Adds to skills textbox
            skillsTXT.Text += "Efficient, ";
            efficientbtn.Visible = false;
        }
    }
}