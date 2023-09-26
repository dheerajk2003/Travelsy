using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (txtemail.Text == Session["email"].ToString() && txtPass.Text == Session["password"].ToString())
            {
                Session["login"] = 1;
                Response.Redirect("blog.aspx");
            }
            else
            {
                txtlbl.Text = "invalid credentials";
            }
        }
    }
}