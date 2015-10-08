using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplainRegistrationSystem.BAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem
{
    public partial class ViewComplainByManager : System.Web.UI.Page
    {
        LoginAfterManager aManagerBal =new LoginAfterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Assistant> aAssistants = aManagerBal.GetAssistantData();
              
                searchAssisDropDownList0.Items.Add("Select");
                solvedButton.Visible = false;
                CancelButton.Visible = false;

                foreach (Assistant a1 in aAssistants)
                {
                    searchAssisDropDownList0.Items.Add(a1.AssistantName);
                }

                List<Complain> lb = aManagerBal.ViewInReq();
                foreach (Complain l in lb)
                {
                    NewR_Label1.Text = l.NewReq.ToString();
                    PenR_Label2.Text = l.PenReq.ToString();
                    Sol_Label3.Text = l.SolReq.ToString();
                    CanR_Label4.Text = l.CanReq.ToString();
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager.aspx");
        }

        protected void searchAssisDropDownList0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchAssisDropDownList0.SelectedIndex > 0)
            {
                string nDrop = searchAssisDropDownList0.SelectedItem.ToString();
                int Nameindex = nDrop.IndexOf("(");
                string oName1 = nDrop.Substring(0, Nameindex - 1);
                List<Assistant> aLabelView = aManagerBal.ViewInlabel(oName1);

                foreach (Assistant t in aLabelView)
                {
                    assistantLabel.Text = "Assistant Id : " + t.AssistantId + "    & Contact No :" + t.ContactNo;
                }

            }
        }

        protected void viewComplainButton_Click(object sender, EventArgs e)
        {
            List<Complain> b = aManagerBal.ViewInGridview();
            solvedButton.Visible = true;
            CancelButton.Visible = true;
            Panel1.Visible = true;
            Label4.Visible = true;
            searchCatDropDownList.Visible = true;
            complainGridView1.DataSource = b;
            complainGridView1.DataBind();
            searchCatDropDownList.Items.Clear();
            searchCatDropDownList.Items.Add("Select");
            for (int i = 0; i < complainGridView1.Rows.Count; i++)
            {
                Label c = (Label)complainGridView1.Rows[i].FindControl("Label1");
                ListItem ll = new ListItem(c.Text);

                if (searchCatDropDownList.Items.IndexOf(ll) < 0)
                    searchCatDropDownList.Items.Add(c.Text);

            }
        }

        protected void Nreq_LinkButton1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = true;


            List<Complain> te = aManagerBal.ReqTyp("New");
            complainGridView1.Columns[9].Visible = false;
            solvedButton.Visible = false;
            CancelButton.Visible = true;
            searchCatDropDownList.Visible = false;
            Label4.Visible = false;
            complainGridView1.DataSource = te;
            complainGridView1.DataBind();
            Session["status"] = "New";
        }

        protected void pendingReqLinkButton_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            List<Complain> te = aManagerBal.ReqTyp("Pending");
            solvedButton.Visible = true;
            CancelButton.Visible = true;
            complainGridView1.Columns[9].Visible = false;
            complainGridView1.DataSource = te;
            complainGridView1.DataBind();
            Session["status"] = "Pending";
        }

        protected void solvedReqLinkButton_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            CancelButton.Visible = false;
            solvedButton.Visible = false;

            List<Complain> te = aManagerBal.ReqTyp("Solved");
            Label4.Visible = false;
            complainGridView1.DataSource = te;
            complainGridView1.DataBind();
            Session["status"] = "Solved";
        }

        protected void cancelReqLinkButton4_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            solvedButton.Visible = false;
            CancelButton.Visible = false;
            List<Complain> te = aManagerBal.ReqTyp("Closed");
            complainGridView1.DataSource = te;
            complainGridView1.DataBind();
        }

      
        protected void allocateButton_Click(object sender, EventArgs e)
        {
                   AllocateWithClick();
            List<Complain> te = aManagerBal.ReqTyp("New");
            complainGridView1.DataSource = te;
            complainGridView1.DataBind();
            List<Complain> lb = aManagerBal.ViewInReq();
            foreach (Complain l in lb)
            {
                NewR_Label1.Text = l.NewReq.ToString();
                PenR_Label2.Text = l.PenReq.ToString();

            }


        }

         public void AllocateWithClick()
        {
            int r = complainGridView1.Rows.Count;
            string[] cid = new string[r];
            int j = 0;
            bool flag = false;
            for (int i = 0; i < complainGridView1.Rows.Count; i++)
            {
                CheckBox ch = (CheckBox)complainGridView1.Rows[i].FindControl("CheckBox1");
                Label l = (Label)complainGridView1.Rows[i].FindControl("Label2");
              
                if (ch.Checked == true) {
                    cid[j++] = l.Text;
                    flag = true;
                }
            }
            if (flag == true && searchAssisDropDownList0.SelectedIndex > 0 && summaryTextBox.Text != null)
            {
                List<Complain> aAllocate = new List<Complain>();
                Complain allocate = new Complain();
                string aName = searchAssisDropDownList0.SelectedItem.ToString();
                int bIn = aName.IndexOf("(");

                allocate.AssistantName = aName.Substring(0, bIn - 1);
                allocate.Remarks = summaryTextBox.Text;
                allocate.Status = "Pending";
                aAllocate.Add(allocate);

                string msg = aManagerBal.AllocateFinal(aAllocate, cid);
                Please_Select_Label7.Text = j + " Row IS " + msg;
            }

            else
                Please_Select_Label7.Text = "Please Check The Box";



           
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            int r = complainGridView1.Rows.Count;
            string[] cid = new string[r];
            int j = 0;
            for (int i = 0; i < complainGridView1.Rows.Count; i++)
            {
                CheckBox ch = (CheckBox)complainGridView1.Rows[i].FindControl("CheckBox1");
                Label l = (Label)complainGridView1.Rows[i].FindControl("Label2");
               
                if (ch.Checked == true)
                    cid[j++] = l.Text;

            }



            if (Session["status"].ToString() == "New")
            {
                string n = aManagerBal.ChangeBySol(cid, "Closed");
                List<Complain> te = aManagerBal.ReqTyp("New");
                complainGridView1.DataSource = te;
                complainGridView1.DataBind();

                List<Complain> lb = aManagerBal.ViewInReq();
                foreach (Complain l in lb)
                {
                    NewR_Label1.Text = l.NewReq.ToString();
                    CanR_Label4.Text = l.CanReq.ToString();

                }
                Please_Select_Label7.Text = j + "  Status is Changed from new to Closed ";
            }
            else if (Session["status"].ToString() == "Pending")
            {
                string n = aManagerBal.ChangeBySol(cid, "Closed");
                List<Complain> te = aManagerBal.ReqTyp("Pending");
                complainGridView1.DataSource = te;
                complainGridView1.DataBind();
                List<Complain> lb = aManagerBal.ViewInReq();
                foreach (Complain l in lb)
                {
                    Sol_Label3.Text = l.SolReq.ToString();
                    CanR_Label4.Text = l.CanReq.ToString();

                }
                Please_Select_Label7.Text = j + "  Status is Changed from Pending to Closed ";

            }
        }

        protected void searchCatDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchCatDropDownList.SelectedIndex > 0)
            {
                string reType = searchCatDropDownList.SelectedItem.ToString();
                List<Complain> cd = aManagerBal.ChangeGridView(reType);
                complainGridView1.Columns[9].Visible = false;
                complainGridView1.DataSource = cd;
                complainGridView1.DataBind();
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void searchDateButton_Click(object sender, EventArgs e)
        {
            string sd = viewDateTextBox1.Text;
            string ed = viewDateTextBox2.Text;
            DataTable ddTime = aManagerBal.SearchByDate(sd, ed);
            complainGridView1.DataSource = ddTime;
            complainGridView1.DataBind();
        }

        protected void solvedButton_Click(object sender, EventArgs e)
        {
            StatusViewById();
        }
        public void StatusViewById()
        {

            int r = complainGridView1.Rows.Count;
            string[] cid = new string[r];
            int j = 0;
            for (int i = 0; i < complainGridView1.Rows.Count; i++)
            {
                CheckBox ch = (CheckBox)complainGridView1.Rows[i].FindControl("CheckBox1");
                Label l = (Label)complainGridView1.Rows[i].FindControl("Label2");

                if (ch.Checked == true)
                    cid[j++] = l.Text;

            }


            Please_Select_Label7.Text = j + "  Row is Updated";
            string n = aManagerBal.ChangeBySol(cid, "Solved");
            List<Complain> te = aManagerBal.ReqTyp("Pending");
            complainGridView1.DataSource = te;
            complainGridView1.DataBind();

            List<Complain> lb = aManagerBal.ViewInReq();
            foreach (Complain l in lb)
            {
                PenR_Label2.Text = l.PenReq.ToString();
                Sol_Label3.Text = l.SolReq.ToString();

            }

        }
    }
}