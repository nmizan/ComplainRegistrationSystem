using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplainRegistrationSystem.BAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem.UI
{
    public partial class ComplainFrm : System.Web.UI.Page
    {
        ComplainManager aManager=new ComplainManager();
        Complain aComplain=new Complain();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> complainList = new List<string>();

                complainList.Add("Select");
                complainList.Add("Electrical");
                complainList.Add("Cleaning");
                complainList.Add("Plumbing");
                complainList.Add("Carpenter");
                complainList.Add("Others");
                foreach (var list in complainList)
                {
                    categoryDropDownList.Items.Add(list);
                   
                }
                

                List<string> priorityList = new List<string>();

                priorityList.Add("Select");
                priorityList.Add("High");
                priorityList.Add("Low");

                foreach (var list in priorityList)
                {
                    priorityDropDownList.Items.Add(list);
                }

                
            }
            PopulateGridView();
          

        }
        protected void categoryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryDropDownList.SelectedItem.ToString() == "Others")
            {
                otherTextBox.Visible = true;
            }
            else
            {
                otherTextBox.Visible = false;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (categoryDropDownList.SelectedItem.Text == "" || priorityDropDownList.SelectedItem.Text == "" ||
                idTextBox.Text == "" || nameTextBox.Text == "" ||
                hosteNoTextBox.Text == "" || roomNoTextBox.Text == "" || summaryTextBox.Text == ""||contactTextBox.Text=="")
            {
                msgLabel.Text = "please enter the value in the textbox.";
                
            }
            else
            {
                aComplain.ComplainId = idTextBox.Text;
                aComplain.PersonName = nameTextBox.Text;
                aComplain.HostelNo= Convert.ToInt32(hosteNoTextBox.Text);
                aComplain.RoomNo = Convert.ToInt32(roomNoTextBox.Text);
                if (categoryDropDownList.SelectedItem.Text!="Others")
                {
                    aComplain.Category = categoryDropDownList.SelectedItem.Text;
                }
                else
                {
                    aComplain.Category = otherTextBox.Text;
                }
                aComplain.Summary= summaryTextBox.Text;
                aComplain.Priority = priorityDropDownList.SelectedItem.Text;
                aComplain.DateOfComplain =DateTime.Now;
                aComplain.Status = "New";
                aComplain.ContactNo = contactTextBox.Text;
                msgLabel.Text=(aManager.Save(aComplain));
                PopulateGridView();
                complainGridView.Visible = true;
                otherTextBox.Visible = false;
                ClearTextBox();


            }
           
        }

        public void ClearTextBox()
        {
            idTextBox.Text = "";
            nameTextBox.Text = "";
            hosteNoTextBox.Text = "";
            roomNoTextBox.Text = "";
            categoryDropDownList.Items.Clear();
            summaryTextBox.Text = "";
            priorityDropDownList.Items.Clear();
            contactTextBox.Text = "";
        }

       
        public void PopulateGridView()
        {
            complainGridView.DataSource = aManager.ShowAllComplain();
            complainGridView.DataBind();
        }

        protected void complainGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            complainGridView.PageIndex = e.NewPageIndex;
            PopulateGridView();
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Receptionist.aspx");
        }

      

        protected void complainGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int row = e.NewEditIndex;
            complainGridView.DataSource = aManager.ShowAllComplain();
            complainGridView.EditIndex = row;
            complainGridView.DataBind();
            
        }

        protected void complainGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int r = e.RowIndex;
            Label t1 = (Label)complainGridView.Rows[r].FindControl("Label1");
            TextBox t2 = (TextBox)complainGridView.Rows[r].FindControl("pNameTextBox");
            TextBox t3 = (TextBox)complainGridView.Rows[r].FindControl("hostelTextBox");
            TextBox t4 = (TextBox)complainGridView.Rows[r].FindControl("roomTextBox");
            TextBox t5 = (TextBox)complainGridView.Rows[r].FindControl("categoryTextBox");
            TextBox t6 = (TextBox)complainGridView.Rows[r].FindControl("summaryTextBox");
            TextBox t7 = (TextBox)complainGridView.Rows[r].FindControl("priorityTextBox");
            TextBox t8 = (TextBox)complainGridView.Rows[r].FindControl("contactTextBox");

            bool flag = aManager.Update(t1.Text, t2.Text, int.Parse(t3.Text), int.Parse(t4.Text), t5.Text, t6.Text, t7.Text, t8.Text);
            if (flag == true)
            {
                msgLabel.Text = "Update Successfully";
                complainGridView.DataSource = aManager.ShowAllComplain();
                complainGridView.EditIndex = -1;
                complainGridView.DataBind();



            }
            else
            {
                msgLabel.Text = "Not Updated, Sorry!!!!!";
            }

        }

        protected void complainGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            complainGridView.DataSource = aManager.ShowAllComplain();
            complainGridView.EditIndex = -1;
            complainGridView.DataBind();
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

       

       

       
      
    }
}