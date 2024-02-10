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
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;

public partial class changePassword : System.Web.UI.Page
{
    string str;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    SqlCommand com;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        con.Open();
        String cmd = "select user_id from [registration] where password='" + MyEncrypt(oldpassword.Text.ToString()) + "' and email='" + Session["email"] + "'";
        SqlCommand change_password = new SqlCommand(cmd, con);
        SqlDataReader read = change_password.ExecuteReader();
        if (read.Read())
        {
            con.Close();
            if (newpassword.Text.Trim() == cpassword.Text.Trim())
            {
                con.Open();
                string strUPDT = "update [registration] set password='" + MyEncrypt(newpassword.Text.ToString()) + "' where email='" + Session["email"] + "'";
                SqlCommand cmdUpdate = new SqlCommand(strUPDT, con);
                cmdUpdate.ExecuteNonQuery();
                con.Close();
                lblMsg.Text = "Password is changed successfully.";
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                lblMsg.Text = "New password and repeat password is not same.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            lblMsg.Text = "Incorrect Old password.";
            lblMsg.ForeColor = System.Drawing.Color.Red;
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