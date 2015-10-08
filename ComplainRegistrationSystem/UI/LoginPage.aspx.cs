using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplainRegistrationSystem.BAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private LoginManager aLoginManager = new LoginManager();
        private UserAccount account = new UserAccount();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (userTextBox.Text==""||passwordTextBox.Text=="")
            {
                msgLabel.Text = "Please Enter the Value";
            }
            else
            {
                account.UserName = userTextBox.Text;
                account.Password = passwordTextBox.Text;
                
            
                string userType = aLoginManager.Login(account.UserName, account.Password);
                if (userType!="")
                {
                    Session["UserName"] = account.UserName;
                    Session["UserType"] = userType;
                    if (userType == "Hostel Manager")
                    {
                       
                        Response.Redirect("Manager.aspx");
                        
                    }
                    else
                    {
                        Response.Redirect("Receptionist.aspx");
                    }
                }
                else
                {
                    msgLabel.Text = "Username or Password is Incorrect! Pls Try Again!";
                } 
            }
           
        }
    }
}