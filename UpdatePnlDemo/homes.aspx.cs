using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpdatePnlDemo
{
    public partial class homes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Label l = (Label)FindControl("lbl");
            l.Text = "hlo";
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            lbl.Text = "hello there";
        }
    }
}