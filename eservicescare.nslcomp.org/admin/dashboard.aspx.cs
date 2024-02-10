using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class admin_dashboard : System.Web.UI.Page
{
    string str;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    SqlCommand com;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_email_address"] == null)
        {
            Response.Redirect("admin.aspx");
        }
        try
        {
            if (con.State == ConnectionState.Closed)
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) as totalusers from [registration] ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblTotalCount.Text = dt.Rows[0]["totalusers"].ToString();
            }
        }
        catch { }

        try
        {
            if (con.State == ConnectionState.Closed)
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) as totallec from [carpenters] ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblTotalLecCount.Text = dt.Rows[0]["totallec"].ToString();
            }
        }
        catch { }

        try
        {
            if (con.State == ConnectionState.Closed)
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) as totalftlr from [order] ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblTotalftlsrCount.Text = dt.Rows[0]["totalftlr"].ToString();
            }
        }
        catch { }

        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) as totalcontact from [contact] ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblTotaltotalcontact.Text = dt.Rows[0]["totalcontact"].ToString();
            }
        }
        catch { }

        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) as totalplumbers from [plumbers] ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                lbltotalplumbers.Text = dt.Rows[0]["totalplumbers"].ToString();
            }
        }
        catch { }

        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) as totalelectrician from [electrician] ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblTotaltotalelectrician.Text = dt.Rows[0]["totalelectrician"].ToString();
            }
        }
        catch { }
    }
}