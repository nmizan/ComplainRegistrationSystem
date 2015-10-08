using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComplainRegistrationSystem
{
    public partial class Receptionist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userName.Text = "Welcome Mr."  + Session["UserName"].ToString();
        }

        protected void complainButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComplainFrm.aspx");
        }

        protected void viewButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewComplain.aspx");
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
            Session["UserName"] = "";
        }

        protected void chngPassButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        
    }
}