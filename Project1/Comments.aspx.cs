using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class Comments : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        string bid;
        protected void Page_Load(object sender, EventArgs e)
        {
            bid = Request.QueryString["idb"];
            if (!IsPostBack)
            {
                if(bid != null)
                {
                    try
                    {
                        con.Open();
                        string query = "select _comment from tblComments where _bid = " + bid;
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmntRptr.DataSource = cmd.ExecuteReader();
                        cmntRptr.DataBind();
                    }
                    catch(Exception ex) { }
                    finally { con.Close(); }
                }
            }
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into tblComments(_bid,_id,_comment,_date) values (@bid,@id,@comment,@date)";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@bid", bid);
                cmd.Parameters.AddWithValue("@id", Session["login"]);
                cmd.Parameters.AddWithValue("@comment", txtComment.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.Date.ToString());

                if(cmd.ExecuteNonQuery()>0) 
                {
                    Response.Write("<script>alert('commented succesfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('error while commenting')</script>");
                }
            }
            catch(Exception ex) { }
            finally { con.Close(); }
        }
    }
}