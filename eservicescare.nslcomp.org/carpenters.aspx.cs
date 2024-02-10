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
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

public partial class carpenters : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
            bindEmp();
    }
    private void bindEmp()
    {
        //try
        //{
            
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("select carpenter_id,name, per_hour_charge,email, mobile,address,photo from carpenters", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

            //if (i % 4 == 0 && i != 0)
            //{
            //    lblEmp.Text += " <div class='clearfix'></div>";
            //}
            //lblEmp.Text += "<article class='grid_3 team'><img src='" + dt.Rows[i]["photo"].ToString() + "' alt='team member' height='150' width='130'/><section class='team-info'><div class='name-position'><h6>" + dt.Rows[i]["name"].ToString() + "</h6><span class='position'>" + dt.Rows[i]["email"].ToString() + "</span> </div> </section><p>" + dt.Rows[i]["address"].ToString() + " </p> </article>";
            lblEmp.Text += "<article class='grid_3 team' style='float:left;padding:10px;border:1px solid #dadada; margin:5px;'><img src='admin/carpenterHandler.ashx?carpenter_id=" + dt.Rows[i]["carpenter_id"].ToString() + "' height='150' width='130'/><section class='team-info'><div class='name-position'><h6>" + dt.Rows[i]["name"].ToString() + "</h6><span class='position'> Email : " + dt.Rows[i]["email"].ToString() + "</span> </div> </section><p> Address: " + dt.Rows[i]["address"].ToString() + " </p> <p>per_hour_charge : Rs. " + dt.Rows[i]["per_hour_charge"].ToString() + " </p><p><a href='viewCarpenter.aspx?carpenter_id=" + dt.Rows[i]["carpenter_id"].ToString() + "'>View Details</a></p></article>";
            //lblEmp.Text += "<article class='grid_3 team'>";
            //lblEmp.Text += "<p><img width='150' height='150' src='admin/carpenterHandler.ashx?carpenter_id=" + dt.Rows[i]["carpenter_id"].ToString() + "' alt='' /></p>";
            //lblEmp.Text += "<p>Name" + dt.Rows[i]["name"].ToString() + "</p>";
            //lblEmp.Text += "<p>per_hour_charge" + dt.Rows[i]["per_hour_charge"].ToString() + "</p>";
            //lblEmp.Text += "<p>Email " + dt.Rows[i]["email"].ToString() + "</p>";
            //lblEmp.Text += "<p>mobile" + dt.Rows[i]["mobile"].ToString() + "</p>";
            //lblEmp.Text += "<p>address" + dt.Rows[i]["address"].ToString() + "</p>";
            //lblEmp.Text += "<article>";

    }
        //}
        //catch { }
    }
}