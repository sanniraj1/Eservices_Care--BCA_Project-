﻿using System;
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

public partial class ActivateAccount : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        //string activation_code = !string.IsNullOrEmpty(Request.QueryString["activation_code"]) ? Request.QueryString["activation_code"] : Guid.Empty.ToString();
        //string email_url = !string.IsNullOrEmpty(Request.QueryString["email"]) ? Request.QueryString["email"] : Guid.Empty.ToString();

        string activation_code = Request.QueryString["activation_code"];
        string email_url = Request.QueryString["email"];

        if (con.State == ConnectionState.Closed)
            con.Open();
        String cmd = "select activation_code,email from [registration] where is_active=0 and email='" + Base64Decode(email_url) + "' and activation_code='" + activation_code + "'";
        SqlCommand login = new SqlCommand(cmd, con);
        SqlDataReader read = login.ExecuteReader();
        if (read.Read())
        {
            con.Close();
            if (con.State == ConnectionState.Closed)
                con.Open();
            string insertCmd = "update [registration] set is_active=@is_active,activation_code='' where email= '" + Base64Decode(email_url) + "'";
            SqlCommand insertUser = new SqlCommand(insertCmd, con);
            insertUser.Parameters.AddWithValue("@is_active", 1);
            try
            {
                insertUser.ExecuteNonQuery();
                con.Close();

                MailMessage mail = new MailMessage();
                mail.To.Add(Base64Decode(email_url));
                //mail.From = new MailAddress("chiragapna@gmail.com");
                mail.From = new MailAddress("eservicesofficial@gmail.com");
                mail.Subject = "Welcome to eservicesofficial. Your account is activated successfully.";
                string emailBody = "";
                emailBody += "<div style='background:#FFFFFF; font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px; margin:0; padding:0;'>";
                emailBody += "<table cellspacing='0' cellpadding='0' border='0' width='100%' style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;'>";
                emailBody += "<tbody>";
                emailBody += "<tr>";
                emailBody += "<td valign='top' style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;'>";
                emailBody += "<div style='width:600px;margin-left:auto;margin-right:auto;clear:both;'>";
                emailBody += "<div style='float:left;width:600px;min-height:35px;font-size:26px;font-weight:bold;text-align:left'>";
                emailBody += "<div style='clear:both;width:100%;text-align:center;'>&nbsp;&nbsp;&nbsp;eservicesofficial</div>";
                emailBody += "<div style='clear:both;width:100%;text-align:center;font-size:11px;font-style:italic;'>&nbsp;&nbsp;&nbsp;&nbsp;website World!</div>";
                emailBody += "</div>";
                emailBody += "</div>";
                emailBody += "</td>";
                emailBody += "</tr>";
                emailBody += "</tbody>";
                emailBody += "</table>";
                emailBody += "<table cellspacing='0' cellpadding='0' border='0' width='600' style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;margin-left:auto;margin-right:auto;'>";
                emailBody += "<tbody>";
                emailBody += "<tr>";
                emailBody += "<td valign='top' colspan='2' style='width:600px;padding-left:20px;padding-right:20px;font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;'>";
                emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;padding-top:15px;line-height:22px;margin:0px;font-weight:bold;padding-bottom:5px'>Hi,</p>";
                emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;color:rgb(41,41,41)'>Your account is activated successfully.</p>";
                emailBody += "<p>&nbsp;</p><p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;margin:0px'>If you have any additional queries, please feel free to reach out us at +91 XXXXX XXXXX or drop us an email at <a href='mailto:Websiteweb.com' style='text-decoration:none;font-style:normal;font-variant:normal;font-weight:normal;font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:normal;color:rgb(162,49,35)' target='_blank'>example@domain.com</a>. We are here to help you.</p>";
                emailBody += "<p>&nbsp;</p>";
                emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;margin:0px;font-weight:bold'>Best Regards,</p>";
                emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;color:rgb(41,41,41);line-height:22px;margin:0px'>eservicesofficial</p>";
                emailBody += "</td>";
                emailBody += "</tr>";
                emailBody += "</tbody>";
                emailBody += "</table>";
                emailBody += "</div>";

                mail.Body = emailBody;
                mail.IsBodyHtml = true;

                /*//smtp details for sending registration email 
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential("eservicesofficial@gmail.com", "happynewyear2020");
                smtp.Send(mail);*/

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.nslcomp.org";
                smtp.Port = 25;
                smtp.Credentials = new System.Net.NetworkCredential("studenttraining@nslcomp.org", "Bmd&1t21");
                smtp.Send(mail);

                lblMsgReg.Text = "Account is actived successfully. Please login with your login credentials.";
                lblMsgReg.ForeColor = System.Drawing.Color.Red;

                Response.Redirect("login.aspx");
            }
            catch (Exception er)
            {
                lblMsgReg.Text = "something going wrong." + er;
                lblMsgReg.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {

            }
        }
        else
        {
            con.Close();
            lblMsgReg.Text = "Reset link is expired";
            lblMsgReg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
}