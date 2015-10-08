using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplainRegistrationSystem.BAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem
{
    public partial class AssistantInfo : System.Web.UI.Page
    {
        AssistantManager aManager=new AssistantManager();
        Assistant aAssistant=new Assistant();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> typeList = new List<string>();
                typeList.Add(" Electrical");
                typeList.Add("Cleaner");
                typeList.Add("Carpenter");
                typeList.Add("Plumber");
                typeList.Add("Others");
                asisTypeDropDownList.Items.Add("Select");
                foreach (var list in typeList)
                {
                    asisTypeDropDownList.Items.Add(list);
                }
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (asisIdTextBox.Text == "" || asisNameTextBox.Text == "" || asisTypeDropDownList.SelectedItem.Text == "" || asisCntctTextBox.Text == "")
            {
                msgLabel.Text = "please enter the value";
            }
            else
            {
                

                aAssistant.AssistantId = asisIdTextBox.Text;
                aAssistant.AssistantName = asisNameTextBox.Text;
                aAssistant.ContactNo = asisCntctTextBox.Text;
                aAssistant.AssistantType = asisTypeDropDownList.SelectedItem.Text;
                msgLabel.Text = aManager.Save(aAssistant);
                assistantGridView.Visible = true;
                PopulateGridView();
                ClearTextBox();
            }
        }
        public void ClearTextBox()
        {
            asisIdTextBox.Text = "";
            asisNameTextBox.Text = "";
            asisCntctTextBox.Text = "";
        }


       
        public void PopulateGridView()
        {

            assistantGridView.DataSource = aManager.ShowAllAssistants();
            assistantGridView.DataBind();
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string utype = asisTypeDropDownList.SelectedItem.Text;
            assistantGridView.DataSource = aManager.GetAssistantsByType(utype);
            assistantGridView.DataBind();
            assistantGridView.Visible = true;
        }

        protected void assistantGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            assistantGridView.DataSource = aManager.ShowAllAssistants();
            assistantGridView.EditIndex = e.NewEditIndex;
            assistantGridView.DataBind();
            assistantGridView.EditIndex = e.NewEditIndex;
        
            assistantGridView.Visible = true;
        }

        protected void assistantGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int r = e.RowIndex;
            TextBox t1 = (TextBox)assistantGridView.Rows[r].FindControl("idTextBox");
            TextBox t2 = (TextBox)assistantGridView.Rows[r].FindControl("nameTextBox");
            TextBox t3 = (TextBox)assistantGridView.Rows[r].FindControl("typeTextBox");
            TextBox t4 = (TextBox)assistantGridView.Rows[r].FindControl("contactTextBox");

            bool flag = aManager.Update(t1.Text, t2.Text, t3.Text, t4.Text);
            if (flag == true)
            {
                msgLabel.Text = "Update Successfully";
                assistantGridView.DataSource = aManager.ShowAllAssistants();
                assistantGridView.EditIndex = -1;
                assistantGridView.DataBind();

            }
            else
            {
                msgLabel.Text = "Not Updated, Sorry!!!!!";
            }
        }

        protected void assistantGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int row = e.RowIndex;
            Label lbl = (Label)assistantGridView.Rows[row].FindControl("Label1");

            string userId = lbl.Text;

            bool flag = aManager.Delete(userId);
            if (flag == true)
            {
                msgLabel.Text = "Delete Successfully !";
                assistantGridView.DataSource = aManager.ShowAllAssistants();
                assistantGridView.DataBind();


            }
            else
            {
                msgLabel.Text = "Not Deleted !";
            }
        }

        protected void assistantGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            assistantGridView.DataSource = aManager.ShowAllAssistants();
            assistantGridView.EditIndex = -1;
            assistantGridView.DataBind();
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}