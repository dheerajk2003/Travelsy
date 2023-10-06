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
    public partial class Search : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                    Response.Write(DdlStates.SelectedItem.Text);
                    Response.Write(DdlStates.SelectedItem.Value);
                    con.Close();
                }
            }
        }

        protected void DdlStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write(DdlStates.SelectedItem.Text);
            try
            {
                con.Open();
                SqlDataAdapter adpt;
                DataTable dt = new DataTable();
                string query = "select distinct _city, _id from tblPlaces where _state = '"+DdlStates.SelectedItem.Text.ToString()+"'";
                adpt = new SqlDataAdapter(query, con);
                adpt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DdlCities.Items.Clear();
                    for(int i=0;i < dt.Rows.Count;i++)
                    {
                        ListItem item = new ListItem();
                        item.Text = dt.Rows[i]["_city"].ToString();
                        item.Value = dt.Rows[i]["_id"].ToString();
                        DdlCities.Items.Add(item);
                    }
                }
            }
            catch { }
            finally { con.Close(); }
        }
    }
}