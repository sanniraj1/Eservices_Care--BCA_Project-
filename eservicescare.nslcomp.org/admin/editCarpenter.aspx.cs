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

public partial class admin_editCarpenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string carpenter_id = Request.QueryString["carpenter_id"].ToString();
            string qr = "select * from [carpenters] where carpenter_id=" + carpenter_id;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qr, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            con.Close();
            name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            per_hour_charge.Text = ds.Tables[0].Rows[0]["per_hour_charge"].ToString();
            email_address.Text = ds.Tables[0].Rows[0]["email"].ToString();
            password.Text = MyDecrypt(ds.Tables[0].Rows[0]["password"].ToString());
            mobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
            address.Text = ds.Tables[0].Rows[0]["address"].ToString();

            lblfarImg.Text = "<img width='50' height='50' src='carpenterHandler.ashx?carpenter_id=" + carpenter_id + "' alt='' />";

        }
    }
    protected void UpdateCArP_Click(object sender, EventArgs e)
    {
        byte[] myphoto = FileUpload1.FileBytes;
        if (myphoto == null || myphoto.Length == 0)
        {
            string carpenter_id = Request.QueryString["carpenter_id"].ToString();
            string qr = "update [carpenters] set name='" + name.Text.Trim() + "',per_hour_charge='" + per_hour_charge.Text.Trim() + "',mobile='" + mobile.Text.Trim() + "',address='" + address.Text.Trim() + "',password='" + MyEncrypt(password.Text.Trim()) + "' where carpenter_id=" + carpenter_id;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qr;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("user.aspx");
        }
        else
        {
            string carpenter_id = Request.QueryString["carpenter_id"].ToString();
            string qr = "update [carpenters] set name='" + name.Text.Trim() + "',per_hour_charge='" + per_hour_charge.Text.Trim() + "',mobile='" + mobile.Text.Trim() + "',address='" + address.Text.Trim() + "',password='" + MyEncrypt(password.Text.Trim()) + "',photo=@ph where carpenter_id=" + carpenter_id;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qr;
            cmd.Parameters.AddWithValue("@ph", myphoto);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
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