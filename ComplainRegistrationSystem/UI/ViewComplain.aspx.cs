using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplainRegistrationSystem.BAL;

namespace ComplainRegistrationSystem
{
    public partial class ViewComplain : System.Web.UI.Page
    {
        ComplainManager aManager = new ComplainManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               List<string> statusList = new List<string>();

            statusList.Add("Select");
            statusList.Add("New");
            statusList.Add("Pending");
            statusList.Add("Solved");
            statusList.Add("Closed");

            foreach (var list in statusList)
            {
                statusDropDownList.Items.Add(list);
            } 
         }
            
        }

        public void PopulateGridviewById()
        {
            string id = viewIdTextBox.Text;
            viewGridView.DataSource = aManager.GetComplainById(id);
            viewGridView.DataBind();
        }
        public void PopulateGridviewByRoomNo()
        {
            int roomNo = int.Parse(viewroomTextBox.Text);
            viewGridView.DataSource = aManager.GetComplainByRoomNo(roomNo);
            viewGridView.DataBind();
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Receptionist.aspx");
        }

       
        protected void viewGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            viewGridView.PageIndex = e.NewPageIndex;
            viewGridView.DataSource = aManager.ShowAllComplain();
            viewGridView.DataBind();
        }

      
        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (viewIdTextBox.Text != "")
            {
                PopulateGridviewById();
                viewIdTextBox.Text = "";
            }
            else if (viewroomTextBox.Text != "")
            {
                PopulateGridviewByRoomNo();
                viewroomTextBox.Text = "";
            }
            else if (statusDropDownList.SelectedItem.Text != "")
            {
                string status = statusDropDownList.SelectedItem.Text;
                viewGridView.DataSource = aManager.GetComplainByStatus(status);
                viewGridView.DataBind();

            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

    }
}