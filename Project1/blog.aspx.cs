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

namespace Project1
{
    public partial class blog : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("signin.aspx");
            }

            if (!IsPostBack)
            {
                States();
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

        protected void DdlStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlDataAdapter adpt;
                DataTable dt = new DataTable();
                string query = "select DISTINCT _city from tblPlaces where _state = '" + DdlStates.SelectedItem.Text.ToString() + "'";
                adpt = new SqlDataAdapter(query, con);
                adpt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DdlCities.Items.Clear();
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
    }
}