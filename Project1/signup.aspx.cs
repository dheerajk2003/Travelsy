using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class signup : System.Web.UI.Page
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
           // string query = "insert into tblLogin(_username,_useremail,_userpass) values(@name,@email,@password)";
            
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.CommandText = "spRegister";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@name", txtname.Text.ToString().Replace("'", ""));
                cmd.Parameters.AddWithValue("@email", txtemail.Text.ToString().Replace("'", ""));
                //byte[] txtBytes = System.Text.Encoding.UTF8.GetBytes(txtPass.Text);
                //string txtEncPass = System.Convert.ToBase64String(txtBytes);
                //byte[] bytes = System.Convert.FromBase64String(txtEncPass);
                //string realPass = System.Text.Encoding.UTF8.GetString(bytes);
                //Response.Write(realPass);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text.ToString().Replace("'", ""));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    Response.Write("<script>alert('user registered succesfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('error in registration')</script>");
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
                //Response.Redirect("signin.aspx");
            }
            
        }
    }
}