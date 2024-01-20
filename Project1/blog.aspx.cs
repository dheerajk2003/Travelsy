using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Security.AccessControl;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Web.Security;

namespace Project1
{
    public partial class blog : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        int myId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("<script>alert(" + Session["login"] +")</script>");
            //DateTime today = DateTime.Now;
            //today.ToString("d");
            //Response.Write(today.ToString("t"));

            //if (Session["login"] == null)
            //{
            //    Response.Redirect("signin.aspx");
            //}

            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            myId = Convert.ToInt32(authTicket.Name);

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("signin.aspx");
            }


            
            if (!IsPostBack)
            {
                States();
                displayBlogs("select * from tblPlaces");
            }
            


            void States()
            {
                try
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adpt;
                    string query = "Select DISTINCT _state from tblPlaces";
                    adpt = new SqlDataAdapter(query, con);
                    adpt.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DdlStates.Items.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ListItem item = new ListItem();
                            item.Text = dt.Rows[i]["_state"].ToString();
                            //item.Value = dt.Rows[i]["_stateId"].ToString();
                            DdlStates.Items.Add(item);
                        }
                    }
                }
                catch { }
                finally
                {
                    con.Close();
                }
            }
            
        }

        void displayBlogs(string queryPosts)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                string query = queryPosts;
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                rptBlogs.DataSource = cmd.ExecuteReader();
                rptBlogs.DataBind();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
        }

        protected void DdlStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                displayBlogs("select * from tblPlaces where _state = '" + DdlStates.SelectedItem.Text.ToString() + "'");
                con.Open();
                SqlDataAdapter adpt;
                DataTable dt = new DataTable();
                string query = "select DISTINCT _city from tblPlaces where _state = '" + DdlStates.SelectedItem.Text.ToString() + "'";
                adpt = new SqlDataAdapter(query, con);
                adpt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DdlCities.Items.Clear();
                    ListItem item1 = new ListItem();
                    item1.Text = "";
                    item1.Value = "";
                    DdlCities.Items.Add(item1);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListItem item = new ListItem();
                        item.Text = dt.Rows[i]["_city"].ToString();
                        item.Value = dt.Rows[i]["_city"].ToString();
                        DdlCities.Items.Add(item);
                    }
                }
                
            }
            catch { }
            finally { con.Close(); }
        }
        protected void btnLike_Click(object sender, EventArgs e)
        {
            
            Button clickedButton = (Button)sender;
            Control container = clickedButton.Parent;
            HiddenField hiddenField = (HiddenField)container.FindControl("idHidden");
            

            // Access the value of the HiddenField
            if (hiddenField != null)
            {
                string hiddenFieldValue = hiddenField.Value;
                int showLikes()
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select _likes from tblPlaces where _bid = " + hiddenFieldValue;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    int numLikes = Int32.Parse(dt.Rows[0][0].ToString());
                    con.Close();
                    return numLikes;
                }
                void LikeIt(int num)
                {
                    int likes = showLikes();
                    Response.Write("\"<script>alert('"+likes+"')</script>\"");
                    int nk = 1;
                    if(likes !=  null)
                    {
                        nk = likes + num;
                    }
                    con.Close() ;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update tblPlaces set _likes = " + nk + " where _bid = " + hiddenFieldValue;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    //Response.Redirect(Request.RawUrl);

                    Label noLike = (Label)container.FindControl("numLikes");
                    noLike.Text = showLikes().ToString();
                    con.Close() ;
                }
                try
                {
                    Response.Write("<script>alert('inside try')</script>");
                    if (Session["liked"] == null)
                    {
                        //Response.Write("<script>alert('inside if')</script>");
                        //Response.Write("inside if");
                        Session["liked"] = 1;
                        Button clickedBtn = (Button)sender;
                        clickedBtn.BackColor = Color.Red;
                        LikeIt(1);

                    }
                    else
                    {
                        //Response.Write("<script>alert('inside else')</script>");
                        //Response.Write("inside else");
                        Session["liked"] = null;
                        Button clickedBtn = (Button)sender;
                        clickedBtn.BackColor = Color.White;
                        LikeIt(-1);
                    }
                }
                catch(Exception ex) 
                {
                    Response.Write("<script>alert('error' , " + ex.Message + ")</script>");
                }
                //finally { con.Close(); }
            }
        }

        protected void btnuts_Click(object sender, EventArgs e)
        {
            Button btns = (Button)sender;
            Control ctl = btns.Parent;
            Label lbls = (Label)ctl.FindControl("lbltext");
            lbls.Text = "hello there";
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Control container = clickedButton.Parent;
            HiddenField hiddenField = (HiddenField)container.FindControl("idHidden");
            try
            {
                string hiddenFieldValue = hiddenField.Value;
                string url = "Comments.aspx?idb=" + hiddenFieldValue;
                Response.Redirect(url);
            }
            catch (Exception ex) { }
            finally { }
        }

        protected void DdlCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('changed')</script>");
            displayBlogs("select * from tblPlaces where _city = '"+ DdlCities.SelectedItem.Text.ToString() + "'");
        }

        protected void btnSearchBlog_Click(object sender, EventArgs e)
        {
            displayBlogs("Select * from tblPlaces where _name LIKE '%"+txtSearchBlog.Text.ToString()+"%'");
            //Response.Write("<script>alert('"+txtSearchBlog.Text+"')</script>");
        }
    }
}