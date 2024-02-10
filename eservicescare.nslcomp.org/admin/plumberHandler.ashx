<%@ WebHandler Language="C#" Class="plumberHandler" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class plumberHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string plumber_id = context.Request.QueryString["plumber_id"].ToString();
        string qr = "select photo from [plumbers] where plumber_id=" + plumber_id;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand(qr, con);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        con.Close();
        context.Response.ContentType = "application/Image";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + context.Request.QueryString[0].ToString());
        byte[] myphoto = (byte[])ds.Tables[0].Rows[0]["photo"];
        context.Response.BinaryWrite(myphoto);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}