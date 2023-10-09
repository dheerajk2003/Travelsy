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
    public partial class CreateBlog : System.Web.UI.Page
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            UploadBlg();
        }
        
        public void UploadBlg()
        {
            string query = "insert into tblPlaces(_id,_name,_description,_state,_city,_mapsAddress) values(@id,@place,@desc,@state,@city,@maps)";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@id", Session["id"]);
                cmd.Parameters.AddWithValue("@place",txtname.Text);
                cmd.Parameters.AddWithValue("@desc",txtdesc.Text);
                cmd.Parameters.AddWithValue("@state",txtState.Text);
                cmd.Parameters.AddWithValue("@city",txtCity.Text);
                cmd.Parameters.AddWithValue("@maps", txtMaps.Text);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Blog created successfully')</script>");
            }
            catch(Exception ex) 
            {
                Response.Write(ex.ToString());
                Response.Write(ex.Message);
                Console.WriteLine(ex.Message);    
            }
            finally 
            { 
                con.Close();
                
            }
        }
    }
}