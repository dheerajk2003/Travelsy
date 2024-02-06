using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
            //string query = "insert into tblPlaces(_id,_name,_description,_state,_city,_tips,_mapsAddress) values(@id,@place,@desc,@state,@city,@tips,@maps)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spCreateBlog";
            cmd.Connection = con;
            try
            {

                string uploadsFolder = Server.MapPath("~/images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imgPlace.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                imgPlace.SaveAs(filePath);

                con.Open();
                cmd.Parameters.AddWithValue("@id", Session["id"]);
                cmd.Parameters.AddWithValue("@place",txtname.Text);
                cmd.Parameters.AddWithValue("@desc",txtdesc.Text);
                cmd.Parameters.AddWithValue("@state",txtState.Text);
                cmd.Parameters.AddWithValue("@city",txtCity.Text);
                cmd.Parameters.AddWithValue("@tips", txttips.Text);
                cmd.Parameters.AddWithValue("@maps", txtMaps.Text);
                cmd.Parameters.AddWithValue("@img", uniqueFileName);
                if(cmd.ExecuteNonQuery() > 0)
                {
                    Response.Write("<script>alert('Blog created successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error occured while uploading')</script>");
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Response.Write("<script>console.log("+ex.Message+")</script>");
                Response.Write("<script>alert('Error occured while uploading ' + "+ex.Message+")</script>");
            }
            finally 
            { 
                con.Close();
                
            }
        }
    }
}