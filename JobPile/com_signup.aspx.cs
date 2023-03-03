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
    public partial class com_signup : System.Web.UI.Page
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
            string pw = pass.Text;
            string name = company.Text;
            string num = contact.Text;
            string bio = about.Text;
            string mission = missiontxt.Text;
            string vision = visiontxt.Text;
            string site = website.Text;

            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;";
            constr += "Data Source=" + Server.MapPath("~/App_Data/jobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            if (pw != repass.Text)
            {
                Response.Write("<script>alert('Passwords do not match', 'Warning!')</script>");
            }
            else
            {
                string cmd = "INSERT INTO companyTBL (companyName, email, contactnum, pass, about, mission, vision, website) VALUES";
                cmd += "('" + name + "','" + mail + "','" + num + "','" + pw + "','" + bio + "','" + mission + "','" + vision + "','" + site + "');";
                OleDbCommand sql = new OleDbCommand(cmd, conn);
                sql.ExecuteNonQuery();

                cmd = "select ID from companyTBL where email = '" + mail + "'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                int id = Int32.Parse(dt.Rows[0]["ID"].ToString());

                cmd = "insert into accountsTBL values(" + id + ",'" + mail + "','" + mail + "','comp')";
                sql = new OleDbCommand(cmd, conn);
                sql.ExecuteNonQuery();

                email.Text = "";
                pass.Text = "";
                company.Text = "";
                contact.Text = "";
                about.Text = "";
                missiontxt.Text = "";
                visiontxt.Text = "";
                website.Text = "";

                // Session["Email"] = email.Text;
                Response.Redirect("~/JobPosts");
            }
            conn.Close();
        }
    }
}