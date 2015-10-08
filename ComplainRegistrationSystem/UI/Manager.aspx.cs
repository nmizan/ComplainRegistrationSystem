using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComplainRegistrationSystem
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userName.Text = "Welcome Mr. " + Session["UserName"].ToString();
        }

        protected void viewComplainButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewComplainByManager.aspx");
        }

        protected void chngPassButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void userInfoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInfo.aspx");
        }

        protected void assistantInfoButton0_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssistantInfo.aspx");
        }
    }
}