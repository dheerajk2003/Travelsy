using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            Session["username"] = txtname.Text;
            Session["email"] = txtemail.Text;
            Session["password"] = txtPass.Text;
            Response.Redirect("signin.aspx");
        }
    }
}