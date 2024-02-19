using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
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

                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, encCk);

                ck.Expires = ticket.Expiration;

                ck.Path = FormsAuthentication.FormsCookiePath;

                Response.Cookies.Add(ck);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('error' + " + ex.Message + ") </script");
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string query = "select * from tblAdmin where Name='"+txtname.Text+"' AND Password='"+txtPass.Text+"'";
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(query, con);
            adpt.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                WriteCk(Convert.ToInt32(dt.Rows[0]["AdminId"]));
                Response.Redirect("AdminPage.aspx");
            }
            else
            {
                txtlbl.Text = "name or password is incorrect";
            }
        }
    }
}