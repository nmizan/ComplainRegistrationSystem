using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem.DAL
{
    public class LoginAfterGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ComplainCon"].ConnectionString;
        private SqlDataReader dr;
        public List<Assistant> GetAssistantData()
        {
            List<Assistant> AssistList = new List<Assistant>();

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select AssistantName,AssistantType From AssistantDetails", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Assistant aAssistant = new Assistant();
                aAssistant.AssistantName = dr.GetValue(0).ToString();
                aAssistant.AssistantType = dr.GetValue(1).ToString();

                aAssistant.AssistantName = dr.GetValue(0).ToString() + " (" + dr.GetValue(1).ToString() + " )";
                AssistList.Add(aAssistant);

            }


            dr.Close();
            connection.Close();
            return AssistList;

        }
        public List<Assistant> ViewInLabel(string aName)
        {
            List<Assistant> aViewInLabel = new List<Assistant>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd =new SqlCommand("Select AssistantID,ContactNo from AssistantDetails where AssistantName = '" + aName + "'",connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Assistant aViewLabel = new Assistant();
                aViewLabel.AssistantId = dr.GetValue(0).ToString();
                aViewLabel.ContactNo = dr.GetValue(1).ToString();
                aViewInLabel.Add(aViewLabel);
            }
            
            dr.Close();
            connection.Close();
            return aViewInLabel;

        }

        public List<Complain> ViewInGridView()
        {
            List<Complain> aGridView = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * From Complain", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Complain aComplain = new Complain();
                aComplain.ComplainId = dr.GetValue(0).ToString();
                aComplain.PersonName = dr.GetValue(1).ToString();
                aComplain.HostelNo = int.Parse(dr.GetValue(2).ToString());
                aComplain.RoomNo = int.Parse(dr.GetValue(3).ToString());
                aComplain.Category = dr.GetValue(4).ToString();
                aComplain.Summary = dr.GetValue(5).ToString();
                aComplain.Priority = dr.GetValue(6).ToString();
                aComplain.DateOfComplain = DateTime.Parse(dr.GetValue(7).ToString());
                aComplain.Status = dr.GetValue(8).ToString();
                aComplain.ContactNo = dr.GetValue(9).ToString();
                aComplain.AssistantName = dr.GetValue(10).ToString();
                aComplain.Remarks = dr.GetValue(11).ToString();
                aGridView.Add(aComplain);

            }

            dr.Close();
            connection.Close();
            return aGridView;

        }

        public List<Complain> ViewInLabelReq()
        {
            List<Complain> aViewInLabel = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select status from Complain", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            Complain aView = new Complain();
            while (dr.Read())
            {
               

                if (dr.GetValue(0).ToString() == "New")
                {
                    aView.NewReq++;
                }
                else if (dr.GetValue(0).ToString() == "Pending")
                {
                    aView.PenReq++;
                }
                else if (dr.GetValue(0).ToString() == "Solved")
                {
                    aView.SolReq++;
                }

                else if (dr.GetValue(0).ToString() == "Closed")
                {
                    aView.CanReq++;
                }

                
            }
            aViewInLabel.Add(aView);
            dr.Close();
            connection.Close();
            return aViewInLabel;
        }
        public List<Complain> GridViewChangeByLink(string reqType)
        {
            List<Complain> aChange = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from Complain where Category='" + reqType + "'", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Complain abComplain = new Complain();
                abComplain.ComplainId = dr.GetValue(0).ToString();
                abComplain.PersonName = dr.GetValue(1).ToString();
                abComplain.HostelNo = int.Parse(dr.GetValue(2).ToString());
                abComplain.RoomNo = int.Parse(dr.GetValue(3).ToString());
                abComplain.Category = dr.GetValue(4).ToString();
                abComplain.Summary = dr.GetValue(5).ToString();
                abComplain.Priority = dr.GetValue(6).ToString();
                abComplain.DateOfComplain = DateTime.Parse(dr.GetValue(7).ToString());
                abComplain.Status = dr.GetValue(8).ToString();
                abComplain.ContactNo = dr.GetValue(9).ToString();
                abComplain.AssistantName = dr.GetValue(10).ToString();
                abComplain.Remarks = dr.GetValue(11).ToString();
                aChange.Add(abComplain);
            }
            dr.Close();
            connection.Close();
            return aChange;

        }
        public List<Complain> GridByReq(string reqStatus)
        {
            List<Complain> aChange = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from Complain where Status='" + reqStatus + "'", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Complain abComplain = new Complain();
                abComplain.ComplainId = dr.GetValue(0).ToString();
                abComplain.PersonName = dr.GetValue(1).ToString();
                abComplain.HostelNo = int.Parse(dr.GetValue(2).ToString());
                abComplain.RoomNo = int.Parse(dr.GetValue(3).ToString());
                abComplain.Category = dr.GetValue(4).ToString();
                abComplain.Summary = dr.GetValue(5).ToString();
                abComplain.Priority = dr.GetValue(6).ToString();
                abComplain.DateOfComplain = DateTime.Parse(dr.GetValue(7).ToString());
                abComplain.Status = dr.GetValue(8).ToString();
                abComplain.ContactNo = dr.GetValue(9).ToString();
                abComplain.AssistantName = dr.GetValue(10).ToString();
                abComplain.Remarks = dr.GetValue(11).ToString();
                aChange.Add(abComplain);
            }
            dr.Close();
            connection.Close();
            return aChange;

        }
        public string ChangedByCan(string[] abc, string status)
        {
            int i = 0;

            for (i = 0; i < abc.Length; i++)
            {
                string cid = abc[i];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("update complain set status=@som where ComplainId ='" + cid + "'",
                    connection);
                cmd.Parameters.AddWithValue("@som", status);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return status;
        }

        public DataTable SearchByDate(string dat1, string dat2)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * From Complain where DateOfComplain between @sd and @ed", connection);
            cmd.Parameters.AddWithValue("@sd", dat1.Trim());
            cmd.Parameters.AddWithValue("@ed", dat2.Trim());

            DataTable dt = new DataTable();
            
            connection.Open();
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            connection.Close();
            return dt;


        }

      public  string AllocateAssistant(List<Complain> allocat, string []cid)
        {
            String name = "";
            string remarks = "";
            string cid1 = "";
            string pendin = "";


            List<Complain> aAllocate = allocat;
            foreach(Complain al in aAllocate)
            {
                name = al.AssistantName;
                remarks = al.Remarks;
                pendin = al.Status;
            }
            for (int i = 0; i < cid.Length; i++)
            {

                cid1 = cid[i];

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Update Complain set AssistantName=@aname,Remarks=@rem,Status=@pen where ComplainId= '" + cid1 + "'", connection);
                cmd.Parameters.AddWithValue("@aname", name);
                cmd.Parameters.AddWithValue("@rem", remarks);
                cmd.Parameters.AddWithValue("@pen", pendin);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return "Succcessfully Allocated";

           }
    }
}