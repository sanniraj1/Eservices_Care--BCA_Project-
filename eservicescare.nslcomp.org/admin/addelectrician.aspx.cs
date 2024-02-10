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

public partial class admin_addelectrician : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void addElectrician_Click(object sender, EventArgs e)
    {

        byte[] myphoto = FileUpload1.FileBytes;
        con.Open();
        SqlCommand checkemail = new SqlCommand("select email from [electrician] where email =@email", con);
        checkemail.Parameters.AddWithValue("@email", email_address.Text.Trim());
        SqlDataReader read = checkemail.ExecuteReader();
        if (read.HasRows)
        {
            lblMsgReg.Text = "Email Address of electrician is already exist. Please try with different email address.";
            lblMsgReg.ForeColor = System.Drawing.Color.Red;
            con.Close();
        }
        else
        {
            con.Close();
            con.Open();
            string insertCmd = "insert into [electrician](name,per_hour_charge,email,password,mobile,address,photo,created_on) values(@name,@per_hour_charge,@email_address,@password,@mobile,@address,@photo,@created_on)";
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
            Response.Redirect("electrician.aspx");
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