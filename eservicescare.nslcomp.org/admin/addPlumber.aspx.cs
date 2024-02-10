using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;

public partial class admin_addPlumber : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void addPlumber_Click(object sender, EventArgs e)
    {
        byte[] myphoto = FileUpload1.FileBytes;
        con.Open();
        SqlCommand checkemail = new SqlCommand("select email from [plumbers] where email =@email", con);
        checkemail.Parameters.AddWithValue("@email", email_address.Text.Trim());
        SqlDataReader read = checkemail.ExecuteReader();
        if (read.HasRows)
        {
            lblMsgReg.Text = "Email Address of plumber is already exist. Please try with different email address.";
            lblMsgReg.ForeColor = System.Drawing.Color.Red;
            con.Close();
        }
        else
        {
            con.Close();
            con.Open();
            string insertCmd = "insert into [plumbers](name,per_hour_charge,email,password,mobile,address,photo,created_on) values(@name,@per_hour_charge,@email_address,@password,@mobile,@address,@photo,@created_on)";
            SqlCommand insertUser = new SqlCommand(insertCmd, con);
            insertUser.Parameters.AddWithValue("@name", name.Text);
            insertUser.Parameters.AddWithValue("@per_hour_charge", per_hour_charge.Text);
            insertUser.Parameters.AddWithValue("@email_address", email_address.Text);
            insertUser.Parameters.AddWithValue("@password", MyEncrypt(password.Text));
            insertUser.Parameters.AddWithValue("@mobile", mobile.Text);
            insertUser.Parameters.AddWithValue("@address", address.Text);
            insertUser.Parameters.AddWithValue("@photo", myphoto);
            insertUser.Parameters.AddWithValue("@created_on", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            insertUser.ExecuteNonQuery();
            con.Close();

            MailMessage mail = new MailMessage();
            mail.To.Add(email_address.Text.Trim());
            mail.From = new MailAddress("eservicesofficial@gmail.com");
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
            emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;padding-top:15px;line-height:22px;margin:0px;font-weight:bold;padding-bottom:5px'>Hi " + name.Text + ",</p>";
            emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;color:rgb(41,41,41)'>You are registered in eServices as a Plumber.</p>";
            emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;color:rgb(41,41,41)'>Email: " + email_address.Text + "</p>";
            emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;color:rgb(41,41,41)'>Password: " + password.Text + "</p>";
            emailBody += "<p>&nbsp;</p><p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;margin:0px'>If you have any additional queries, please feel free to reach out us at +91 XXXXX XXXXX or drop us an email at <a href='mailto:Websiteweb.com' style='text-decoration:none;font-style:normal;font-variant:normal;font-weight:normal;font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:normal;color:rgb(162,49,35)' target='_blank'>example@domain.com</a>. We are here to help you.</p>";
            emailBody += "<p>&nbsp;</p>";
            emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;margin:0px;font-weight:bold'>Best Regards,</p>";
            emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;color:rgb(41,41,41);line-height:22px;margin:0px'>eServices Support</p>";
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


            Response.Redirect("carpenters.aspx");
        }
    }
    private string MyEncrypt(string clearText)
    {
        string EncryptionKey = "E5C2B81A3B2B2";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    private string MyDecrypt(string cipherText)
    {
        string EncryptionKey = "E5C2B81A3B2B2";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
}