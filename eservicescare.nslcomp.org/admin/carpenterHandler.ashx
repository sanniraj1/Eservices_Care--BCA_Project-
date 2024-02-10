<%@ WebHandler Language="C#" Class="carpenterHandler" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class carpenterHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string carpenter_id = context.Request.QueryString["carpenter_id"].ToString();
        string qr = "select photo from [carpenters] where carpenter_id=" + carpenter_id;
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