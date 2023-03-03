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
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='Main'},1000)", true);
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
            string about = bioTxt.Text;

            DateTime birth = DateTime.Parse(bday);
            try
            {
                int ageIn = new DateTime(DateTime.Now.Subtract(birth).Ticks).Year - 1;
                if (pw != repass.Text)
                {
                    Response.Write("<script>alert('Passwords do not match!', 'Warning!')</script>");
                    //Response.Write("<script>alert('You are not allowed to register due to age restrictions.\n\nIn accordance to R.A.9023 ART. 137. Minimum Employable Age. – (a) No child below fifteen (15) years of age shall be employed, except when he works directly under the sole responsibility of his parents or guardian, and his employment does not in any way interfere with his schooling.', 'Restricted!')</script>");
                }
                else
                {
                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;";
                    constr += "Data Source=" + Server.MapPath("~/App_Data/jobpileDB.accdb");
                    OleDbConnection conn = new OleDbConnection(constr);
                    conn.Open();

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
                    } 
                    else if (ageIn < 15)
                    {
                        Response.Write("<script>alert('You are underage!', 'Warning!')</script>");
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "setTimeout(function(){window.location.href='Main'},1000)", true);
                    }
                    else
                    {
                        string cmd = "INSERT INTO employeeTBL (email, username, mobile, pass, lastname, firstname, age, birthday, gender, bio, resumelink) VALUES";
                        cmd += "('" + mail + "','" + user + "','" + num + "','" + pw + "','" + lname + "','" + fname + "','" + ageIn + "','" + bday + "','" + gender + "','" + about + "','" + res + "');";
                        OleDbCommand sql = new OleDbCommand(cmd, conn);
                        sql.ExecuteNonQuery();

                        cmd = "select ID from employeeTBL where email = '" + mail + "'";
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        int id = Int32.Parse(dt.Rows[0]["ID"].ToString());

                        cmd = "insert into accountsTBL values(" + id + ",'" + user + "','" + mail + "','emp')";
                        sql = new OleDbCommand(cmd, conn);
                        sql.ExecuteNonQuery();

                        conn.Close();

                        email.Text = "";
                        username.Text = "";
                        mobile.Text = "";
                        pass.Text = "";
                        lastname.Text = "";
                        firstname.Text = "";

                        Response.Redirect("~/EmployeeJobLists");
                    }
                    conn.Close();
                }
            }
            catch
            {
                Response.Write("<script>alert('Please select a proper birthdate', 'Warning!')</script>");
            }
        }
    }
}