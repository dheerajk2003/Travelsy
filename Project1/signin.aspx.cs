using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class signin : System.Web.UI.Page
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string query = "Select * from tblLogin where _useremail = '"+txtemail.Text+"' and _userpass = '"+txtPass.Text+"'";
            DataTable dt = new DataTable();
            SqlDataAdapter adpt;
            try
            {
                con.Open();
                adpt = new SqlDataAdapter(query, con);
                adpt.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    Response.Write(s: "<script>alert('valid user');</script>");
                    Session["login"] = 1;
                    Response.Redirect("blog.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid user');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { con.Close(); }
        }
    }
}