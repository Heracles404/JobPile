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
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
            connstr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection con = new OleDbConnection(connstr);
            con.Open();
            //companyEmail to cemail
            //Query to get all data based on jobTitle
            string email = Session["Email"].ToString();

            string query = "SELECT * FROM [employeeTBL] WHERE [email] = '" + email + "'";
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                using (con = new OleDbConnection(connstr))
                {
                    using (cmd = new OleDbCommand(query))
                    {
                        using (OleDbDataAdapter sda = new OleDbDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                //Stores query results in data table and set each fields in labels
                                sda.Fill(dt);
                                nametxt.Text = dt.Rows[0]["firstname"].ToString();
                                nametxt.Text += " " + dt.Rows[0]["lastname"].ToString();
                                uname.Text = dt.Rows[0]["username"].ToString();
                                num.Text = dt.Rows[0]["mobile"].ToString();
                                age.Text = dt.Rows[0]["age"].ToString();
                                bday.Text = dt.Rows[0]["birthday"].ToString();
                                gender.Text = dt.Rows[0]["gender"].ToString();
                                bio.Text = dt.Rows[0]["bio"].ToString();
                                skills.Text = dt.Rows[0]["skills"].ToString();
                                resume.Text = dt.Rows[0]["resumelink"].ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                query = "select * from employeeTBL where username = '" + email + "'";
                cmd = new OleDbCommand(query, con);
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                DataTable dt= new DataTable();
                sda.Fill(dt);
                nametxt.Text = dt.Rows[0]["firstname"].ToString();
                nametxt.Text += " " + dt.Rows[0]["lastname"].ToString();
                uname.Text = dt.Rows[0]["username"].ToString();
                num.Text = dt.Rows[0]["mobile"].ToString();
                age.Text = dt.Rows[0]["age"].ToString();
                bday.Text = dt.Rows[0]["birthday"].ToString();
                gender.Text = dt.Rows[0]["gender"].ToString();
                bio.Text = dt.Rows[0]["bio"].ToString();
                skills.Text = dt.Rows[0]["skills"].ToString();
                resume.Text = dt.Rows[0]["resumelink"].ToString();
            }
        }
    }
}