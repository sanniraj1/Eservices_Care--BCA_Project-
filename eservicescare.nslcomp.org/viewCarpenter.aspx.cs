using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Security.Cryptography;

public partial class viewCarpenter : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            string qr = "select * from [registration] where user_id = '" + Session["user_id"] + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(qr, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            con.Close();
            Image1.ImageUrl = "admin/userHandler.ashx?user_id=" + Session["user_id"] + "&email=" + Session["email"];
            first_name.Text = ds.Tables[0].Rows[0]["first_name"].ToString();
            last_name.Text = ds.Tables[0].Rows[0]["last_name"].ToString();
            email_address.Text = ds.Tables[0].Rows[0]["email"].ToString();

            //Session["user_first_name"] = ds.Tables[0].Rows[0]["first_name"].ToString();
            //Session["user_last_name"] = ds.Tables[0].Rows[0]["last_name"].ToString();
            Session["order_by_email"] = ds.Tables[0].Rows[0]["email"].ToString();

        }
        if (!IsPostBack)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            string carpenter_id = Request.QueryString["carpenter_id"].ToString();
            string qr = "select * from [carpenters] where carpenter_id = " + carpenter_id.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand(qr, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            con.Close();
            Image1.ImageUrl = "admin/carpenterHandler.ashx?carpenter_id=" + carpenter_id.ToString();
            name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            per_hour_charge.Text = ds.Tables[0].Rows[0]["per_hour_charge"].ToString();
            email.Text = ds.Tables[0].Rows[0]["email"].ToString();
            mobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
            address.Text = ds.Tables[0].Rows[0]["address"].ToString();

            Session["worker_per_hour_charge"] = ds.Tables[0].Rows[0]["per_hour_charge"].ToString();
            Session["worker_name"] = ds.Tables[0].Rows[0]["name"].ToString();
            Session["worker_email"] = ds.Tables[0].Rows[0]["email"].ToString();
            //Session["worker_mobile"] = ds.Tables[0].Rows[0]["mobile"].ToString();
            //Session["worker_address"] = ds.Tables[0].Rows[0]["address"].ToString();
        }
    }

    protected void addOrder_Click(object sender, EventArgs e)
    {
        string insertCmd = "insert into [order](order_for,worker_name,worker_email,location_address,details,per_hour_charge,order_on,order_by_email) values(@order_for,@worker_name,@worker_email,@location_address,@details,@per_hour_charge,@order_on,@order_by_email)";
        con.Open();
        SqlCommand insertUser = new SqlCommand(insertCmd, con);
        insertUser.Parameters.AddWithValue("@order_for", "Carpenter");
        insertUser.Parameters.AddWithValue("@worker_name", Session["worker_name"].ToString());
        insertUser.Parameters.AddWithValue("@worker_email", Session["worker_email"].ToString());
        insertUser.Parameters.AddWithValue("@per_hour_charge", Session["worker_per_hour_charge"].ToString());
        insertUser.Parameters.AddWithValue("@order_by_email", Session["order_by_email"].ToString()); 
        insertUser.Parameters.AddWithValue("@location_address", location_address.Text);
        insertUser.Parameters.AddWithValue("@details", details.Text);
        insertUser.Parameters.AddWithValue("@order_on", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        insertUser.ExecuteNonQuery();
        con.Close();
        Response.Redirect("myOrders.aspx");
    }
}