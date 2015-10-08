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
    public partial class UserInfo : System.Web.UI.Page
    {
        private ManagerManager aManager;
        private UserAccount account;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> typeList = new List<string>();
                typeList.Add("Hostel Manager");
                typeList.Add("Receptionist");
                typeDropDownList.Items.Add("Select");
                foreach (var list in typeList)
                {
                    typeDropDownList.Items.Add(list);
                }
            }
            

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            aManager=new ManagerManager();
            if (userIdTextBox.Text==""||userNameTextBox.Text==""||typeDropDownList.SelectedItem.Text==""||userPassTextBox.Text=="")
            {
                msgLabel.Text = "please enter the value";
            }
            else
            {
                account=new UserAccount();

                account.UserId = userIdTextBox.Text;
                account.UserName = userNameTextBox.Text;
                account.UserType = typeDropDownList.SelectedItem.Text;
                account.Password = userPassTextBox.Text;
                
                msgLabel.Text = aManager.Save(account);
                
                GridView1.Visible = true;
                PopulateGridView();
                ClearTextBox();
            }
           
        }

        public void ClearTextBox()
        {
            userIdTextBox.Text = "";
            userNameTextBox.Text = "";
            typeDropDownList.SelectedItem.Text = "";
            userPassTextBox.Text = "";
        }

        protected void addLinkButton_Click(object sender, EventArgs e)
        {
            aManager=new ManagerManager();
           int x = aManager.AddUserNew();
            userIdTextBox.Text = x.ToString();
        }

        public void PopulateGridView()
        {
            
            GridView1.DataSource = aManager.ShowAllUser();
            GridView1.DataBind();
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager.aspx");
        }

       
        protected void searchButton_Click(object sender, EventArgs e)
        {
            aManager = new ManagerManager();
            string utype = typeDropDownList.SelectedItem.Text;
            GridView1.DataSource = aManager.GetUserByType(utype);
            GridView1.DataBind();
            GridView1.Visible = true;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            aManager = new ManagerManager();
            string utype = typeDropDownList.SelectedItem.Text;
            GridView1.DataSource = aManager.GetUserByType(utype);
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
            GridView1.Visible = true;
            
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            aManager = new ManagerManager();
            int r = e.RowIndex;
            TextBox t1 = (TextBox)GridView1.Rows[r].FindControl("idTextBox");
            TextBox t2 = (TextBox)GridView1.Rows[r].FindControl("nameTextBox");
            TextBox t3 = (TextBox)GridView1.Rows[r].FindControl("typeTextBox");
            TextBox t4 = (TextBox)GridView1.Rows[r].FindControl("passTextBox");
          
            bool flag = aManager.Update(int.Parse(t1.Text), t2.Text, t3.Text, t4.Text);
            if (flag == true)
            {
                msgLabel.Text = "Update Successfully";
                GridView1.DataSource = aManager.ShowAllUser();
                GridView1.EditIndex = -1;
                GridView1.DataBind();

            }
            else
            {
                msgLabel.Text = "Not Updated, Sorry!!!!!";
            }

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            aManager = new ManagerManager();
            int row = e.RowIndex;
            Label lbl = (Label)GridView1.Rows[row].FindControl("Label1");

            int userId = Convert.ToInt32(lbl.Text);
            
            bool flag = aManager.Delete(userId);
            if (flag == true)
            {
                msgLabel.Text = "Delete Successfully !";
                GridView1.DataSource = aManager.ShowAllUser();
                GridView1.DataBind();


            }
            else
            {
                msgLabel.Text = "Not Deleted !";
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            aManager = new ManagerManager();
            GridView1.DataSource = aManager.ShowAllUser();
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
       

        
    }
}