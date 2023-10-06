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
            string query = "Select _id,_useremail, _userpass from tblLogin where _useremail = '"+txtemail.Text+"'";
            DataTable dt = new DataTable();
            SqlDataAdapter adpt;
            try
            {
                con.Open();
                adpt = new SqlDataAdapter(query, con);
                adpt.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    string txtEncPass = dt.Rows[0]["_userpass"].ToString();
                    byte[] bytes = System.Convert.FromBase64String(txtEncPass);
                    string realpass = System.Text.Encoding.UTF8.GetString(bytes);
                    if(realpass == txtPass.Text)
                    {
                        Session["login"] = 1;
                        Session["id"] = dt.Rows[0]["_id"].ToString();
                        Response.Redirect("blog.aspx");
                    }
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