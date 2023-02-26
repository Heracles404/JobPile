using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlTypes;
using static System.Net.Mime.MediaTypeNames;

namespace JobPile
{
    public partial class index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        // Log In Function
        protected void login(object sender, EventArgs e)
        {
            // Stores the input into temporary variables
            string user = email.Text;
            string pass = pw.Text;

            string constr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/jobpileDB.accdb");
            constr += ";Persist Security Info=True";
            OleDbConnection conn = new OleDbConnection(constr);

            // Check if user is a job seeker or employer
            if (isSeeker.Checked)
            {
                // Log In Syntax - Check Username
                string username = "SELECT * FROM employeeTBL WHERE username = '" + user + "' AND pass = '" + pass + "';";
                OleDbCommand sqlcmd = new OleDbCommand(username, conn);
                OleDbDataAdapter sqladapt = new OleDbDataAdapter(sqlcmd);
                DataTable dtUser = new DataTable();
                sqladapt.Fill(dtUser);

                // Log In Syntax - Check Email
                string mail = "SELECT * FROM employeeTBL WHERE email = '" + user + "' AND pass = '" + pass + "';";
                sqlcmd = new OleDbCommand(mail, conn);
                sqladapt = new OleDbDataAdapter(sqlcmd);
                DataTable dtMail = new DataTable();
                sqladapt.Fill(dtMail);

                if ((dtUser.Rows.Count > 0) || (dtMail.Rows.Count > 0))
                {
                    Response.Write("<script>alert('Logged in Successfully', 'Welcome!')</script>");
                    Session["Email"] = email.Text;
                    Response.Redirect("~/EmpJobLists");
                }
                else
                {
                    Response.Write("<script>alert('Seeker account not found.', 'Warning!')</script>");
                    errLbl.Visible = true;
                }
            }
            else
            {
                // Log In Syntax - Check Username
                string username = "SELECT * FROM companyTBL WHERE companyName = '" + user + "' AND pass = '" + pass + "';";
                OleDbCommand sqlcmd = new OleDbCommand(username, conn);
                OleDbDataAdapter sqladapt = new OleDbDataAdapter(sqlcmd);
                DataTable dtUser = new DataTable();
                sqladapt.Fill(dtUser);

                // Log In Syntax - Check Email
                string mail = "SELECT * FROM companyTBL WHERE email = '" + user + "' AND pass = '" + pass + "';";
                sqlcmd = new OleDbCommand(mail, conn);
                sqladapt = new OleDbDataAdapter(sqlcmd);
                DataTable dtMail = new DataTable();
                sqladapt.Fill(dtMail);

                if ((dtUser.Rows.Count > 0) || (dtMail.Rows.Count > 0))
                {
                    Response.Write("<script>alert('Logged in Successfully', 'Welcome!')</script>");
                    Session["Email"] = email.Text;
                    Response.Redirect("~/JobPosts");
                }
                else
                {
                    Response.Write("<script>alert('Company account not found.', 'Warning!')</script>");
                    errLbl.Visible = true;
                }
            }
        }

        // Sign Up Process 1 - Confirm email with OTP
        public string sOTP
        {
            get
            {
                var value = ViewState["sOTP"];
                return null != value ? (string)value : "";
            }
            set
            {
                ViewState["sOTP"] = value;
            }
        }
        protected void OTP(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            string constr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/jobpileDB.accdb");
            constr += ";Persist Security Info=True";
            OleDbConnection conn = new OleDbConnection(constr);

            // Check if Email is not yet registered - employeeTBL
            string eaddr = "SELECT * FROM employeeTBL WHERE email = '" + email + "';";
            OleDbDataAdapter sqlmail = new OleDbDataAdapter(eaddr, constr);
            DataTable dtMail = new DataTable();
            sqlmail.Fill(dtMail);

            // Check if Email is not yet registered - companyTBL
            string eadd = "SELECT * FROM companyTBL WHERE email = '" + email + "';";
            OleDbDataAdapter sqlcom = new OleDbDataAdapter(eadd, constr);
            DataTable dtcom = new DataTable();
            sqlcom.Fill(dtcom);

            if ((dtMail.Rows.Count > 0) || (dtcom.Rows.Count > 0))
            {
                Response.Write("<script>alert('Email is already registered', 'Warning!')</script>");
            }
            else
            {
                // Generate Random OTP if Email input is not empty
                if (email.Trim() != "")
                {
                    string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

                    sOTP = String.Empty;
                    string sTempChars = String.Empty;
                    Random rand = new Random();

                    for (int i = 0; i < 6; i++)
                    {

                        int p = rand.Next(0, saAllowedCharacters.Length);

                        sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                        sOTP += sTempChars;
                    }

                    // Send the OTP to email
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("jobPileMCL@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "JobPile OTP - DO NOT REPLY";
                        mail.Body = "Your OTP is " + sOTP;
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new System.Net.NetworkCredential("jobPileMCL@gmail.com", "hmmxzaoxdpbvrbhv");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);

                            sent.Visible = true;
                        }
                    }
                }
                else
                {
                    Response.Write("<script> alert('Email cannot be empty') </script>");
                }
            }



        }

        // Sign Up Process 2 - Verify Email
        public void ver(object sender, EventArgs e)
        {
            if (sOTP == txtOTP.Text)
            {
                if (empChk.Checked)
                {
                    Session["email"] = txtEmail.Text;
                    Response.Redirect("email_signup.aspx");
                }
                else
                {
                    Session["email"] = txtEmail.Text;
                    Response.Redirect("com_signup.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid OTP')</script>");
                txtOTP.Text = "";
                errOTP.Visible = true;
            }
        }
    }
}