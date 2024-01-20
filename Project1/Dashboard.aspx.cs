using System;
using System.Collections;
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
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        int _id = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getDashData();
            }
        }

        void getDashData()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                string query = "select * from tblPlaces where _id = " + _id + " ";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                rptMyBlogs.DataSource = cmd.ExecuteReader();
                rptMyBlogs.DataBind();

            }
            catch (Exception ex) { }
            finally { con.Close(); }
            //Response.Write(_id);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session["login"] = null;
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.CommandName == "delBtnClick")
            {
                Response.Write("<script>console.log("+btn.CommandArgument.ToString()+")</script>");
                try
                {
                    con.Open();
                    string delQuery = "delete from tblPlaces where _bid = " + btn.CommandArgument.ToString() + " ";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = delQuery;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>console.log(" + result + ")</script>");
                    Response.Redirect(Request.Url.AbsoluteUri, false);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex) { }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}