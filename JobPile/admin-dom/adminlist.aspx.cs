//.cs file

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPile.admin_dom
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridData();
            }
        }
        protected void GridData()
        {
            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string query = "select ID, username from adminTBL";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            adminGrid.DataSource = dt;
            adminGrid.DataBind();


        }

        protected void admindelete_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int adminID = Int32.Parse(adminGrid.DataKeys[rowIndex].Values[0].ToString());

            string constr = "Provider=Microsoft.ACE.OleDb.12.0; Data Source=";
            constr += Server.MapPath("~/App_Data/JobpileDB.accdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string query = "delete from adminTBL where ID=" + adminID;
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "select ID, username from adminTBL";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            adminGrid.DataSource = dt;
            adminGrid.DataBind();

            Response.Write("<script>alert('Account Deleted')</script>");
        }

        protected void newAdmin_Click(object sender, EventArgs e)
        {
            if(username.Text.Trim() == "")
            {
                Response.Write("<script>alert('Username is required.')</script>");
                pw.Text = "";
                repw.Text = "";
            }
            else
            {
                if (pw.Text == repw.Text)
                {
                    string uname = username.Text;
                    string pass = pw.Text;

                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;";
                    constr += "Data Source=" + Server.MapPath("~/App_Data/jobpileDB.accdb");
                    OleDbConnection conn = new OleDbConnection(constr);

                    conn.Open();

                    // Check if Number is not yet registered
                    string cont = "SELECT * FROM adminTBL WHERE username = '" + uname + "';";
                    OleDbDataAdapter sqlcont = new OleDbDataAdapter(cont, conn);
                    DataTable dtcont = new DataTable();
                    sqlcont.Fill(dtcont);

                    if (dtcont.Rows.Count > 0)
                    {
                        Response.Write("<script>alert('Username is already taken.')</script>");
                    }
                    else
                    {
                        try
                        {
                            string cmd = "INSERT INTO adminTBL (username, pass) VALUES";
                            cmd += "('" + uname + "','" + pass + "');";

                            OleDbCommand sql = new OleDbCommand(cmd, conn);

                            sql.ExecuteNonQuery();

                            Response.Write("<script>alert('New admin has been created.')</script>");
                        }
                        catch
                        {
                            Response.Write("<script>alert('Please check your input and try again.')</script>");
                        }

                        conn.Close();

                        username.Text = "";
                        pw.Text = "";
                        repw.Text = "";
                    }
                }
                else
                {
                    pw.Text = "";
                    repw.Text = "";
                    Response.Write("<script>alert('Passwords do not match.')</script>");
                    errLbl.Visible = true;
                }
            }
        }
    }
}