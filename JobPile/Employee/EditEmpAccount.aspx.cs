using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPile
{
    public partial class WebForm11 : System.Web.UI.Page
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
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            //companyEmail to cemail
            //Query to get all data based on jobTitle
<<<<<<< HEAD
            string sqlsmt = "SELECT * FROM [employeeTBL] WHERE [emp_email] = 'active'";
=======
            string email = employeeEmail;
            string sqlsmt = "SELECT * FROM [employeeTBL] WHERE [email] = '" + email + "'";
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);

            OleDbDataReader dataReader = sqlcmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();

                //Input Initial values

<<<<<<< HEAD
                efirstlbl.Text = dataReader["emp_first"].ToString();
                elastlbl.Text = dataReader["emp_last"].ToString();
                userlbl.Text = dataReader["emp_user"].ToString();
                passlbl.Text = dataReader["emp_pass"].ToString();
                mobilelbl.Text = dataReader["emp_mobile"].ToString();
                agelbl.Text = dataReader["emp_age"].ToString();
                birthdaylbl.Text = dataReader["emp_birthday"].ToString();
                genderlbl.Text = dataReader["emp_gender"].ToString();
                biolbl.Text = dataReader["emp_bio"].ToString();
=======
                efirsttxt.Text = dataReader["firstname"].ToString();
                elasttxt.Text = dataReader["lastname"].ToString();
                usertxt.Text = dataReader["username"].ToString();
                passtxt.Text = dataReader["pass"].ToString();
                mobiletxt.Text = dataReader["mobile"].ToString();
                agetxt.Text = dataReader["age"].ToString();
                birthdaytxt.Text = dataReader["birthday"].ToString();
                gendertxt.Text = dataReader["gender"].ToString();
                biotxt.Text = dataReader["bio"].ToString();
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
            }
        }

        public string employeeEmail
        {
            get
            {
<<<<<<< HEAD
                string cemail = Session["emp_email"].ToString();
=======
                string cemail = Session["Email"].ToString();
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
                return cemail;
            }
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
            connstr += Server.MapPath("~/App_Data/JobPileDB.accdb");
            OleDbConnection connection = new OleDbConnection(connstr);
            connection.Open();
<<<<<<< HEAD

            string sqlsmt = "update employeeTBL set emp_first='" + efirstlbl.Text;
            sqlsmt += "',emp_last='" + elastlbl.Text;
            sqlsmt += "',emp_user='" + userlbl.Text + "', emp_pass='" + passlbl.Text;
            sqlsmt += "',emp_mobile='" + mobilelbl.Text + "',emp_age='" + agelbl.Text;
            sqlsmt += "',emp_birthday='" + birthdaylbl.Text + "',emp_gender='" + genderlbl.Text;
            sqlsmt += "',emp_bio='" + biolbl.Text;
            sqlsmt += "' where emp_email = 'active';";
=======
            string email = employeeEmail;

            string sqlsmt = "update employeeTBL set firstname='" + efirsttxt.Text;
            sqlsmt += "',lastname='" + elasttxt.Text;
            sqlsmt += "',username='" + usertxt.Text + "', pass='" + passtxt.Text;
            sqlsmt += "',mobile='" + mobiletxt.Text + "',age=" + agetxt.Text;
            sqlsmt += ",birthday='" + birthdaytxt.Text + "',gender='" + gendertxt.Text;
            sqlsmt += "',bio='" + biotxt.Text;
            sqlsmt += "' where email = '" + email + "';";
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8

            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, connection);
            sqlcmd.ExecuteNonQuery();
            connection.Close();

            //Reset fields
            efirstlbl.Text = "";
            elastlbl.Text = "";
            userlbl.Text = "";
            passlbl.Text = "";
            mobilelbl.Text = "";
            agelbl.Text = "";
            birthdaylbl.Text = "";
            genderlbl.Text = "";
            biolbl.Text = "";

<<<<<<< HEAD
            Response.Redirect("~/EmpAccounts");
=======
            Response.Redirect("~/EmployeeAccounts");
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
        }
    }
}