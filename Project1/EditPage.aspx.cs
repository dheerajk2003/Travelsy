using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class EditPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        long myId;
        string bid;
        string imgVar;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                myId = Convert.ToInt64(authTicket.Name);
                bid = Request.QueryString["idb"];

                if(!IsPostBack)
                {
                    getEditable(bid);
                }
            }
            catch(Exception ex) { }
        }

        void getEditable(string bId)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string query = "select * from tblPlaces where _bid = " + bid + "AND _id = " + myId + " ";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                adpt.Fill(dt);
                con.Close();
                //Response.Write(dt.Rows[0]["_img"]);
                
                if(dt.Rows.Count > 0)
                {
                    txtname.Text = dt.Rows[0]["_name"].ToString();
                    txtState.Text = dt.Rows[0]["_state"].ToString();
                    txtCity.Text = dt.Rows[0]["_city"].ToString();
                    txtdesc.Text = dt.Rows[0]["_description"].ToString();
                    txttips.Text = dt.Rows[0]["_tips"].ToString();
                    txtMaps.Text = dt.Rows[0]["_mapsAddress"].ToString();
                    imgVar = dt.Rows[0]["_img"].ToString();
                }
            }
            catch (Exception ex) { }
        }

        protected void btnEditBlog_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgPlace.HasFile)
                {
                    delImage();
                    string uploadsFolder = Server.MapPath("~/images");
                    imgVar = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imgPlace.FileName);
                    string filePath = Path.Combine(uploadsFolder, imgVar);

                    imgPlace.SaveAs(filePath);
                }
                updtBlog();
            }
            catch { }
        }

        void delImage()
        {
            try
            {
                string getImage = "select _img from tblPlaces where _bid = " + bid + " AND _id = " + myId + " ";
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(getImage, con);
                adapter.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    string path = Server.MapPath("~/images/");
                    string delImg = String.Concat(path, dt.Rows[0][0]);
                    System.IO.File.Delete(delImg);
                }
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch { }
        }

        void updtBlog()
        {
            try
            {
                string updtQuery = String.Format("update tblPlaces set _name = '{0}' , _description = '{1}', _state = '{2}', _city = '{3}', _mapsAddress = '{4}', _tips = '{5}', _img = '{6}' where _bid = {7};",txtname.Text.ToString(), txtdesc.Text.ToString(), txtState.Text.ToString(), txtCity.Text.ToString(), txtMaps.Text.ToString(), txttips.Text.ToString(), imgVar, bid);
                Response.Write("<script>alert(" + updtQuery + ")</script>");
                con.Open();
                cmd = new SqlCommand(updtQuery, con);
                int result = cmd.ExecuteNonQuery();
                Response.Write(result);
                con.Close();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                if(result > 0)
                {
                    Response.Write("<script>alert("+result+")</script>");
                }
            }
            catch
            { }
        }
    }
}