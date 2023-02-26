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
            string email = employeeEmail;
            string sqlsmt = "SELECT * FROM [employeeTBL] WHERE [email] = '" + email + "'";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);

            OleDbDataReader dataReader = sqlcmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();

                //Input Initial values

                efirsttxt.Text = dataReader["firstname"].ToString();
                elasttxt.Text = dataReader["lastname"].ToString();
                usertxt.Text = dataReader["username"].ToString();
                passtxt.Text = dataReader["pass"].ToString();
                mobiletxt.Text = dataReader["mobile"].ToString();
                agetxt.Text = dataReader["age"].ToString();
                birthdaytxt.Text = dataReader["birthday"].ToString();
                gendertxt.Text = dataReader["gender"].ToString();
                biotxt.Text = dataReader["bio"].ToString();
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

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
            connstr += Server.MapPath("~/App_Data/JobPileDB.accdb");
            OleDbConnection connection = new OleDbConnection(connstr);
            connection.Open();
            string email = employeeEmail;

            string sqlsmt = "update employeeTBL set firstname='" + efirsttxt.Text;
            sqlsmt += "',lastname='" + elasttxt.Text;
            sqlsmt += "',username='" + usertxt.Text + "', pass='" + passtxt.Text;
            sqlsmt += "',mobile='" + mobiletxt.Text + "',age=" + agetxt.Text;
            sqlsmt += ",birthday='" + birthdaytxt.Text + "',gender='" + gendertxt.Text;
            sqlsmt += "',bio='" + biotxt.Text;
            sqlsmt += "' where email = '" + email + "';";

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

            Response.Redirect("~/EmployeeAccounts");
        }
    }
}