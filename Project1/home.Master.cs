using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cookie = HttpContext.Current.User.Identity.Name;
            if (cookie == null || cookie == "")
            {
                registerLabel.Text = "<a class=\"nav-link scrollto\" href=\"signup.aspx\">Sign Up</a>";
            }
            else
            {
                registerLabel.Text = "<a class=\"nav-link scrollto\" href=\"Dashboard.aspx\"><img src='assets/img/profileIcon.png' style='height: 2rem; ' /></a>";
            }
        }
    }
}