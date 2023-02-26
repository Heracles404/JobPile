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
            //companyEmail to cemail
            //Query to get all data based on jobTitle
            string email = employeeEmail;

            string query = "SELECT * FROM [employeeTBL] WHERE [email] = '" + email + "'";

            string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
            connstr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(query))
                {
                    using (OleDbDataAdapter sda = new OleDbDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            //Stores query results in data table and set each fields in labels
                            sda.Fill(dt);
                            efirstlbl.Text = dt.Rows[0]["firstname"].ToString();
                            elastlbl.Text = dt.Rows[0]["lastname"].ToString();
                            userlbl.Text = dt.Rows[0]["username"].ToString();
                            passlbl.Text = dt.Rows[0]["pass"].ToString();
                            mobilelbl.Text = dt.Rows[0]["mobile"].ToString();
                            agelbl.Text = dt.Rows[0]["age"].ToString();
                            birthdaylbl.Text = dt.Rows[0]["birthday"].ToString();
                            genderlbl.Text = dt.Rows[0]["gender"].ToString();
                            biolbl.Text = dt.Rows[0]["bio"].ToString();
                            educationlbl.Text = dt.Rows[0]["education"].ToString();
                            experiencelbl.Text = dt.Rows[0]["experience"].ToString();
                            skillslbl.Text = dt.Rows[0]["skills"].ToString();
                        }
                    }
                }
            }
        }

        public string employeeEmail
        {
            get
            {
                string cemail = Session["Email"].ToString();
                return cemail;
            }
        }
    }
}