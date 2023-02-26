using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPile
{
    public partial class WebForm5 : System.Web.UI.Page
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
            string sqlsmt = "SELECT * FROM [companyTBL] WHERE [cemail] = 'active'";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);

            OleDbDataReader dataReader = sqlcmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();

                //Input Initial values
                nametxt.Text = dataReader["cname"].ToString();
                emailtxt.Text = dataReader["cemail"].ToString();
                websitetxt.Text = dataReader["cwebsite"].ToString();
                numtxt.Text = dataReader["cphonenum"].ToString();
                aboutustxt.Text = dataReader["caboutus"].ToString();
                missiontxt.Text = dataReader["cmission"].ToString();
                visiontxt.Text = dataReader["cvision"].ToString();
            }

            conn.Close();
            
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
            connstr += Server.MapPath("~/App_Data/JobPileDB.accdb");
            OleDbConnection connection = new OleDbConnection(connstr);
            connection.Open();

            //change cemail based on session
            string sqlsmt = "update companyTBL set cname = '" + nametxt.Text;
            sqlsmt += "',cwebsite='" + websitetxt.Text;
            sqlsmt += "',cphonenum='" + numtxt.Text + "',caboutus='" + aboutustxt.Text;
            sqlsmt += "',cmission='" + missiontxt.Text + "',cvision='" + visiontxt.Text;
            sqlsmt += "' where cemail = 'active';";

            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, connection);
            sqlcmd.ExecuteNonQuery();
            connection.Close();

            //Reset fields
            nametxt.Text = "";
            emailtxt.Text = "";
            websitetxt.Text = "";
            numtxt.Text = "";
            aboutustxt.Text = "";
            missiontxt.Text = "";
            visiontxt.Text = "";

            Response.Redirect("~/CompanyInfo");
        }

        public string companyEmail
        {
            get
            {
                string cemail = Session["cemail"].ToString();
                return cemail;
            }
        }
    }
}