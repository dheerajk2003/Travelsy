using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
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

        protected void WriteCk(int _id)
        {
            try 
            {
                //FormsAuthentication.RedirectFromLoginPage(_id.ToString(), false);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,
                    _id.ToString(),
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    true,
                    ""
                );

                string encCk = FormsAuthentication.Encrypt(ticket);

                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName , encCk);

                ck.Expires = ticket.Expiration;

                ck.Path = FormsAuthentication.FormsCookiePath;

                Response.Cookies.Add( ck );

                Response.Redirect( "blog.aspx" );
            } 
            catch(Exception ex) 
            {
                Response.Write("<script>alert('error' + " + ex.Message + ") </script");
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            //string query = "Select _id,_useremail, _userpass from tblLogin where _useremail = '"+txtemail.Text+"'";
            DataTable dt = new DataTable();
            SqlDataAdapter adpt;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spLogin";
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    string txtEncPass = dt.Rows[0]["_userpass"].ToString();
                    if(txtEncPass == txtPass.Text)
                    {
                        Session["id"] = dt.Rows[0]["_id"].ToString();
                        WriteCk(Convert.ToInt16(dt.Rows[0]["_id"]));
                        Response.Redirect("blog.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Password');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid user');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert("+ex.Message+") </script");
            }
            finally { con.Close(); }
        }
    }
}