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

public partial class contact : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //checking session id email
            if (Session["email"] != null)
            {
                // redirect after session check
                Response.Redirect("Home.aspx");
            }
        }
    }
    protected void button_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
            con.Open();
        Random rnd = new Random();
        int myRandomNo = rnd.Next(10000000, 99999999);
        string activation_code = myRandomNo.ToString();
        string insertCmd = "insert into [contact](first_name,last_name,mobile,message,email,created_on) values(@firstname,@lastname,@mobile,@message,@email,@created_on)";
        SqlCommand insertUser = new SqlCommand(insertCmd, con);
        insertUser.Parameters.AddWithValue("@firstname", fname.Text);
        insertUser.Parameters.AddWithValue("@lastname", lname.Text);
        insertUser.Parameters.AddWithValue("@mobile", mobile.Text);
        insertUser.Parameters.AddWithValue("@message", message.Text);
        insertUser.Parameters.AddWithValue("@email", email.Text);
        insertUser.Parameters.AddWithValue("@created_on", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        try
        {
            insertUser.ExecuteNonQuery();
            con.Close();

            MailMessage mail = new MailMessage();
            mail.To.Add(email.Text.Trim());
            mail.From = new MailAddress("chiragapna@gmail.com");
            mail.Subject = "Thankyou for registering with us.";
            string emailBody = "";
            emailBody += "<div style='background:#FFFFFF; font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px; margin:0; padding:0;'>";
            emailBody += "<table cellspacing='0' cellpadding='0' border='0' width='100%' style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;'>";
            emailBody += "<tbody>";
            emailBody += "<tr>";
            emailBody += "<td valign='top' style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;'>";
            emailBody += "<div style='width:600px;margin-left:auto;margin-right:auto;clear:both;'>";
            emailBody += "<div style='float:left;width:600px;min-height:35px;font-size:26px;font-weight:bold;text-align:left'>";
            emailBody += "<div style='clear:both;width:100%;text-align:center;'>&nbsp;&nbsp;&nbsp;Eservices</div>";
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
            emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;padding-top:15px;line-height:22px;margin:0px;font-weight:bold;padding-bottom:5px'>Hi " + fname.Text + ",</p>";
            emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;color:rgb(41,41,41)'>Thanks for reaching us.. We ll contact you ASAP.</p>";
            emailBody += "<p>&nbsp;</p><p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;margin:0px'>If you have any additional queries, please feel free to reach out us at +91 XXXXX XXXXX or drop us an email at <a href='mailto:Websiteweb.com' style='text-decoration:none;font-style:normal;font-variant:normal;font-weight:normal;font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:normal;color:rgb(162,49,35)' target='_blank'>example@domain.com</a>. We are here to help you.</p>";
            emailBody += "<p>&nbsp;</p>";
            emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;margin:0px;font-weight:bold'>Best Regards,</p>";
            emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;color:rgb(41,41,41);line-height:22px;margin:0px'>WebsiteSupport</p>";
            emailBody += "</td>";
            emailBody += "</tr>";
            emailBody += "</tbody>";
            emailBody += "</table>";
            emailBody += "</div>";

            mail.Body = emailBody;
            mail.IsBodyHtml = true;

            //smtp details for sending registration email 
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential("eservicesofficial@gmail.com", "happynewyear2020");
            smtp.Send(mail);

            lblCaptchaMsg.Text = "You Register successfully. Please check your email inbox/spam folder for the activation link.";
            lblCaptchaMsg.ForeColor = System.Drawing.Color.Red;
            //Response.Redirect("SignUp.aspx");
        }
        catch (Exception er)
        {
            lblCaptchaMsg.Text = "something going wrong." + er;
            lblCaptchaMsg.ForeColor = System.Drawing.Color.Red;
        }
        finally
        {

        }
    }
}