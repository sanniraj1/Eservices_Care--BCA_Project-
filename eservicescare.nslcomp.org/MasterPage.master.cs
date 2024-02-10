using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] == null)
        {
            login.Visible = true;
            logout.Visible = false;
        }
        else
        {
            login.Visible = false;
            logout.Visible = true;
            Image1.ImageUrl = "UserPhotoHandler.ashx?user_id=" + Session["user_id"];
        }
    }
}
