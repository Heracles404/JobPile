using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Xml.Linq;

namespace JobPile
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                email.Text = Session["email"].ToString();
            }
            catch (NullReferenceException ex)
            {
                Response.Write("<script>alert('Please log in or sign up.')</script>");
                Response.Redirect("~/Main");
            }
        }
        protected void Register(object sender, EventArgs e)
        {
            string mail = email.Text;
            string user = username.Text;
            string num = mobile.Text;
            string pw = pass.Text;
            string lname = lastname.Text;
            string fname = firstname.Text;
            string bday = birthday.Text;
            string gender = genderChoose.SelectedValue;
            string res = resume.Text;


            DateTime birth = DateTime.Parse(bday);
            int ageIn = new DateTime(DateTime.Now.Subtract(birth).Ticks).Year - 1;

            string about = bioTxt.Text;

            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;";
            constr += "Data Source=" + Server.MapPath("~/App_Data/jobpileDB.accdb");

            OleDbConnection conn = new OleDbConnection(constr);

            // Check if Username is not yet taken
            string usernm = "SELECT * FROM employeeTBL WHERE username = '" + user + "';";
            OleDbDataAdapter sqluser = new OleDbDataAdapter(usernm, conn);
            DataTable dtUser = new DataTable();
            sqluser.Fill(dtUser);


            // Check if Number is not yet registered
            string cont = "SELECT * FROM employeeTBL WHERE mobile = '" + num + "';";
            OleDbDataAdapter sqlcont = new OleDbDataAdapter(cont, conn);
            DataTable dtcont = new DataTable();
            sqlcont.Fill(dtcont);

            if ((dtUser.Rows.Count > 0) || (dtcont.Rows.Count > 0))
            {
                Response.Write("<script>alert('Username or Mobile number is already registered', 'Warning!')</script>");
            }else if (ageIn < 15)
            {
                Response.Write("<script>alert('You are not allowed to register due to age restrictions.\n\nIn accordance to R.A.9023 ART. 137. Minimum Employable Age. – (a) No child below fifteen (15) years of age shall be employed, except when he works directly under the sole responsibility of his parents or guardian, and his employment does not in any way interfere with his schooling.', 'Restricted!')</script>");
            }else if (pw != repass.Text)
            {
                Response.Write("<script>alert('Passwords do not match', 'Warning!')</script>");
            }else
            {
                conn.Open();
                string cmd = "INSERT INTO employeeTBL (email, username, mobile, pass, lastname, firstname, age, birthday, gender, bio, resume) VALUES";
                cmd += "('" + mail + "','" + user + "','" + num + "','" + pw + "','" + lname + "','" + fname + "','" + ageIn + "','" + bday + "','" + gender + "','" + about + "','" + res + "');";

                OleDbCommand sql = new OleDbCommand(cmd, conn);

                sql.ExecuteNonQuery();

                conn.Close();

                email.Text = "";
                username.Text = "";
                mobile.Text = "";
                pass.Text = "";
                lastname.Text = "";
                firstname.Text = "";

                Response.Redirect("~/EmpJobLists");
            }
        }
    }
}