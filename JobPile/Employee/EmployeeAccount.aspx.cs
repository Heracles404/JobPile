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
<<<<<<< HEAD
            string query = "SELECT * FROM [employeeTBL] WHERE [emp_email] = 'active'";
=======
            string email = employeeEmail;

            string query = "SELECT * FROM [employeeTBL] WHERE [email] = '" + email + "'";
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8

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
<<<<<<< HEAD
                            efirstlbl.Text = dt.Rows[0]["emp_first"].ToString();
                            elastlbl.Text = dt.Rows[0]["emp_last"].ToString();
                            userlbl.Text = dt.Rows[0]["emp_user"].ToString();
                            passlbl.Text = dt.Rows[0]["emp_pass"].ToString();
                            mobilelbl.Text = dt.Rows[0]["emp_mobile"].ToString();
                            agelbl.Text = dt.Rows[0]["emp_age"].ToString();
                            birthdaylbl.Text = dt.Rows[0]["emp_birthday"].ToString();
                            genderlbl.Text = dt.Rows[0]["emp_gender"].ToString();
                            biolbl.Text = dt.Rows[0]["emp_bio"].ToString();
=======
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
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
                        }
                    }
                }
            }
        }

        public string employeeEmail
        {
            get
            {
<<<<<<< HEAD
                string cemail = Session["emp_id"].ToString();
=======
                string cemail = Session["Email"].ToString();
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
                return cemail;
            }
        }
    }
}