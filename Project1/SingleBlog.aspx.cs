using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class SingleBlog : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        long myId;
        string bid;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Page.IsPostBack)
            //{
            //    return;
            //}
            try
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                myId = Convert.ToInt64(authTicket.Name);
                bid = Request.QueryString["idb"];
                loadBlogs();
                loadName();
                loadComments();
                loadLikeIcon();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch 
            {
                
            }
            //finally { con.Close(); }

            void loadLikeIcon()
            {
                try
                {
                    con.Open();
                    string getIconQuery = "select * from tblLikes where _bid = "+bid+" AND id = " + myId + " ";
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adpt = new SqlDataAdapter(getIconQuery, con);
                    adpt.Fill(dataTable);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    con.Close();
                    Response.Write(dataTable.Rows.Count);
                    if(dataTable.Rows.Count > 0)
                    {
                        btnLike.Text = "<i class='bi bi-heart'></i>";
                    }
                    else
                    {
                        btnLike.Text = "<i class='bi bi-heart-fill'></i>";
                    }

                    //< i class="bi bi-heart"></i>
                    //        <i class="bi bi-heart-fill"></i>
                }
                catch(Exception ex) { }
            }

            void loadBlogs()
            {
                try
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    string query = "select * from tblPlaces where _bid = " + bid;
                    SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                    adpt.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count > 0)
                    {
                        blogLikes.Text = "";
                        blogTitle.Text = dt.Rows[0]["_name"].ToString();
                        blogImg.ImageUrl = "images/" + dt.Rows[0]["_img"].ToString();
                        blogImg.AlternateText = dt.Rows[0]["_img"].ToString();
                        //blogLikes.Text = dt.Rows[0]["_likes"].ToString();
                        int liken = Convert.ToInt16(dt.Rows[0]["_likes"]);
                        //Response.Write("<script>alert('likes = " + liken + "')</script>");
                        blogLikes.Text = liken.ToString();
                        blogTime.Text = dt.Rows[0]["_dateTime"].ToString();
                        blogDesc.Text = dt.Rows[0]["_description"].ToString();
                        blogTips.Text = dt.Rows[0]["_tips"].ToString();

                        // Additional components
                        blogPerson.Text = "Author Name";
                        blogState.Text = dt.Rows[0]["_state"].ToString();
                        blogCity.Text = dt.Rows[0]["_city"].ToString();
                        blogLink.NavigateUrl = dt.Rows[0]["_mapsAddress"].ToString();
                    }
                }
                catch { }
            }

            void loadName()
            {
                con.Open();
                DataTable dt = new DataTable();
                string queryId = "select _id from tblPlaces where _bid = " + Convert.ToInt16(bid) + " ";
                SqlDataAdapter adpt = new SqlDataAdapter(queryId, con);
                adpt.Fill(dt);
                int userId = Convert.ToInt16(dt.Rows[0][0]);

                string queryName = "select _username from tblLogin where _id = " + userId + " ";
                DataTable dt2 = new DataTable();
                adpt = new SqlDataAdapter(queryName, con);
                adpt.Fill(dt2);
                con.Close();
                string userName = dt2.Rows[0]["_username"].ToString();
                txtNameUser.Text = userName;
                Response.Write("<script>alert("+userName+")</script>");
            }

            void loadComments()
            {
                try
                {
                    string queryCom = "select * from tblComments where _bid = "+bid+" ";
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adpt = new SqlDataAdapter(queryCom, con);
                    adpt.Fill(dt);
                    con.Close();

                    txtComCount.Text = dt.Rows.Count.ToString();

                    for (int i = 0; i<dt.Rows.Count; i++)
                    {
                        Label lb = new Label();
                        lb.Text = "<div id='comment-1' class='comment'>" +
                        "<div class='d-flex'>" +
                        "<div class='comment-img'><img src='assets/img/blog/comments-1.jpg' alt=''></div>" +
                        "<div>" +
                        "<h5><a href=''>"+ dt.Rows[i]["_name"] + "</a> <a href='#' class='reply'><i class='bi bi-reply-fill'></i> Reply</a></h5>" +
                        "<time datetime='2020-01-01'>" + dt.Rows[i]["_date"] +"</time>" +
                        "<p>" + dt.Rows[i]["_comment"] +".</p>" +
                        "</div>" +
                        "</div>" +
                        "</div>";

                        //"<div id='comment-1' class='comment'>" +
                        //"<div class='d-flex'>" +
                        //"<div class='comment-img'><img src='assets/img/blog/comments-1.jpg' alt=''></div>" +
                        //"<div>" +
                        //"<h5><a href=''>Georgia Reader</a> <a href='#' class='reply'><i class='bi bi-reply-fill'></i> Reply</a></h5>" +
                        //"<time datetime='2020-01-01'>01 Jan, 2020</time>" +
                        //"<p>Et rerum totam nisi. Molestiae vel quam dolorum vel voluptatem et et. Est ad aut sapiente quis molestiae est qui cum soluta. Vero aut rerum vel. Rerum quos laboriosam placeat ex qui. Sint qui facilis et.</p>" +
                        //"</div>" +
                        //"</div>" +
                        //"</div>"

                        lb.CssClass = "m-5";
                        commentPanel.Controls.Add(lb);
                    }
                }
                catch { }
            }
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            try
            {
                //if not exists(select * from tblLikes where _bid = 5 AND id = 6) insert into tblLikes(_bid, id) values(5, 6)
                string query = "if not exists (select * from tblLikes where _bid = "+bid+" AND id = " + myId + ") insert into tblLikes(_bid,id) values("+bid+","+myId+")";
                con.Open();
                cmd = new SqlCommand(query, con);
                int execLike = cmd.ExecuteNonQuery();
                con.Close();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                //Response.Write("<script>alert('running main query'+" + execLike + ")</script>");
                if (execLike > 0)
                {
                    int likes = numLikes();
                    //Response.Write("<script>alert(" + likes + ")</script>");
                    blogLikes.Text = likes.ToString();
                    updateLikes(likes);
                }
                else
                {
                    try
                    {
                        string query4 = "delete from tblLikes where _bid = "+bid+" AND id = "+myId+" ";
                        con.Open();
                        cmd = new SqlCommand(query4, con);
                        int delEx = cmd.ExecuteNonQuery();
                        //Response.Write("<script>alert('executing delete query = "+delEx+"')</script>");
                        con.Close();
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                        //Response.Write("<script>alert('executing delete query - '+" + delEx + ")</script>");
                        int nLikes = numLikes();
                        //Response.Write("<script>alert('l - " + nLikes + "')</script>");
                        blogLikes.Text = nLikes.ToString();
                        updateLikes(nLikes);
                    }
                    catch { }
                }
                int numLikes()
                {
                    try
                    {
                        string query2 = "select * from tblLikes where _bid = "+bid+" ";
                        con.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter adpt = new SqlDataAdapter(query2, con);
                        adpt.Fill(dt);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                        return dt.Rows.Count;
                    }
                    catch { return 0; }
                    finally { con.Close(); }
                }

                void updateLikes(int like)
                {
                    try
                    {
                        //update tblPlaces set _likes = 0 where _bid = 1;
                        string query3 = "update tblPlaces set _likes = "+like+" where _bid = "+bid+" ";
                        con.Open();
                        cmd = new SqlCommand(query3, con);
                        int isSuccess = cmd.ExecuteNonQuery();
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                        //Response.Write("<script>alert('executing update query - '+" + isSuccess + ")</script>");
                        //if (isSuccess > 0)
                        //{

                        //}
                    }
                    catch (Exception ex)
                    {

                    }
                    finally { con.Close(); }
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('error in likking')</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            try
            {
                //insert into tblComments(_bid, _id, _comment, _date, _name) values(1, 2, 'water is wet', GETDATE(), 'dheeraj')

                string queryComment = "insert into tblComments(_bid,_id,_comment,_date,_name) values ("+bid+" ,"+myId+" , '"+txtComment.Text.ToString()+"' , '"+DateTime.Now.ToString().Substring(0,9) +"' , '"+txtComName.Text.ToString() +"')";
                con.Open();
                SqlCommand cmd = new SqlCommand(queryComment, con);
                int comSuccess = cmd.ExecuteNonQuery();
                con.Close();
                queryComment = null;
                cmd = null;
                if(comSuccess > 0)
                {
                    Response.Write("<script>alert('commented successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('comment failed')</script>");
                }
                comSuccess = 0;
                Response.Redirect(Request.Url.AbsoluteUri, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch { }
            finally { 
                txtComment.Text = null;
                txtComName.Text = null;
            }
            //Response.Write("<script>alert('working')</script>");
        }
    }
}