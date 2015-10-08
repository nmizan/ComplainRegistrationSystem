using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplainRegistrationSystem.BAL;

namespace ComplainRegistrationSystem
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        LoginManager aManager=new LoginManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void backButton_Click(object sender, EventArgs e)
        {


            if (Session["UserType"].ToString() == "Hostel Manager")
            {
                Response.Redirect("Manager.aspx");
            }
            else
            {
                Response.Redirect("Receptionist.aspx");
            }
            
        }

        protected void changePassButton_Click(object sender, EventArgs e)
        {
            string username = Session["UserName"].ToString();
            string password = oldPassTextBox.Text;
            string newPass = newPassTextBox.Text;
            string conPass = conPassTextBox.Text;
            if (password==aManager.GetPassword(username))
            {
                if (newPass== conPass)
                {
                    aManager.UpdatePassword(username,newPass);

                    msgLabel.Text = "Changed Password!";
                }
                else
                {
                    msgLabel.Text = "Change Failed!";
                }

            
            }
            else
            {
                msgLabel.Text = "Wrong Password ! Pls Try Again !";
            }

            oldPassTextBox.Text = "";
            newPassTextBox.Text = "";
            conPassTextBox.Text = "";
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
        
    }
}