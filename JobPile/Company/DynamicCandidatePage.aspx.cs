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
    public partial class WebForm7 : System.Web.UI.Page
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
            //Store emp_id data from HyperLink
            int emp_id = Int32.Parse(this.Page.RouteData.Values["ID"].ToString());

            //Query to get all data based on emp_id
            string jobInfo = "SELECT * FROM [employeeTBL] WHERE [ID] = @emp_id";

            string connstr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source = ";
            connstr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(jobInfo))
                {
                    using (OleDbDataAdapter sda = new OleDbDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@emp_id", emp_id);
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            string name = dt.Rows[0]["firstname"].ToString() + " " + dt.Rows[0]["lastname"].ToString();

                            nameTXT.Text = name;
                            age.Text = dt.Rows[0]["age"].ToString();
                            bday.Text = dt.Rows[0]["birthday"].ToString();
                            gender.Text = dt.Rows[0]["gender"].ToString();
                            skills.Text = dt.Rows[0]["skills"].ToString();
                            exp.Text = dt.Rows[0]["experience"].ToString();
                            bio.Text = dt.Rows[0]["bio"].ToString();
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int jpID  = Int32.Parse(Session["jpID"].ToString());
            Response.Redirect("~/JobPosts/{" + jpID+ "}");
        }
    }
}