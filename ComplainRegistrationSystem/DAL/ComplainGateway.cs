using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem.DAL
{
    
    public class ComplainGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ComplainCon"].ConnectionString;

        public int Save(Complain aComplain)
        {
          
            string query = string.Format(@"INSERT INTO Complain(ComplainID,PersonName,HostelNo,RoomNo,Category,Summary,Priority,DateOfComplain,Status,ContactNo) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", aComplain.ComplainId, aComplain.PersonName, aComplain.HostelNo, aComplain.RoomNo, aComplain.Category, aComplain.Summary, aComplain.Priority, aComplain.DateOfComplain, aComplain.Status, aComplain.ContactNo);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Complain> ShowAllComplain()
        {
            List<Complain> complainList = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * From Complain ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                Complain aComplain = new Complain();
                aComplain.ComplainId = reader["ComplainID"].ToString();
                aComplain.PersonName = reader["PersonName"].ToString();
                aComplain.HostelNo = int.Parse(reader["HostelNo"].ToString());
                aComplain.RoomNo = int.Parse(reader["RoomNo"].ToString());
                aComplain.Category = reader["Category"].ToString();
                aComplain.Summary = reader["Summary"].ToString();
                aComplain.Priority = reader["Priority"].ToString();
                aComplain.DateOfComplain =DateTime.Parse(reader["DateOfComplain"].ToString());
                aComplain.Status = reader["Status"].ToString();
                aComplain.ContactNo = reader["ContactNo"].ToString();
                aComplain.AssistantName = reader["AssistantName"].ToString();
                aComplain.Remarks = reader["Remarks"].ToString();
                complainList.Add(aComplain);
                
            }
            reader.Close();
            connection.Close();
            return complainList;



        }
        public List<Complain> GetComplainById(string id)
        {
            List<Complain> complainList = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * From Complain where ComplainID='"+id+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Complain aComplain = new Complain();
                aComplain.ComplainId = reader["ComplainID"].ToString();
                aComplain.PersonName = reader["PersonName"].ToString();
                aComplain.HostelNo = int.Parse(reader["HostelNo"].ToString());
                aComplain.RoomNo = int.Parse(reader["RoomNo"].ToString());
                aComplain.Category = reader["Category"].ToString();
                aComplain.Summary = reader["Summary"].ToString();
                aComplain.Priority = reader["Priority"].ToString();
                aComplain.DateOfComplain = DateTime.Parse(reader["DateOfComplain"].ToString());
                aComplain.Status = reader["Status"].ToString();
                aComplain.ContactNo = reader["ContactNo"].ToString();
                aComplain.AssistantName = reader["AssistantName"].ToString();
                aComplain.Remarks = reader["Remarks"].ToString();
                complainList.Add(aComplain);

            }
            reader.Close();
            connection.Close();
            return complainList;



        }
        public List<Complain> GetComplainByRoomNo(int roomNo)
        {
            List<Complain> complainList = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * From Complain where RoomNo='" + roomNo + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Complain aComplain = new Complain();
                aComplain.ComplainId = reader["ComplainID"].ToString();
                aComplain.PersonName = reader["PersonName"].ToString();
                aComplain.HostelNo = int.Parse(reader["HostelNo"].ToString());
                aComplain.RoomNo = int.Parse(reader["RoomNo"].ToString());
                aComplain.Category = reader["Category"].ToString();
                aComplain.Summary = reader["Summary"].ToString();
                aComplain.Priority = reader["Priority"].ToString();
                aComplain.DateOfComplain = DateTime.Parse(reader["DateOfComplain"].ToString());
                aComplain.Status = reader["Status"].ToString();
                aComplain.ContactNo = reader["ContactNo"].ToString();
                aComplain.AssistantName = reader["AssistantName"].ToString();
                aComplain.Remarks = reader["Remarks"].ToString();

                complainList.Add(aComplain);

            }
            reader.Close();
            connection.Close();
            return complainList;



        }
        public bool IsComplainIdExists(Complain aComplain)
        {
            bool isComplainIdExists = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select ComplainID  From Complain Where ComplainID='" + aComplain.ComplainId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                isComplainIdExists = true;
                break;
            }
            reader.Close();
            connection.Close();
            return isComplainIdExists;


        }
        public int Update(string compId,string pName,int hNo,int rNo,string catg,string sumry,string priority,string cntctNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Update Complain Set PersonName=@pname, HostelNo=@hno, RoomNo=@rno, Category=@cat,  Summary=@sum, Priority=@prio,  ContactNo=@contct WHERE ComplainID =@comId ", connection);
            cmd.Parameters.AddWithValue("@comId", compId);
            cmd.Parameters.AddWithValue("@pname", pName);
            cmd.Parameters.AddWithValue("@hno", hNo);
            cmd.Parameters.AddWithValue("@rno", rNo);
            cmd.Parameters.AddWithValue("@cat", catg);
            cmd.Parameters.AddWithValue("@sum", sumry);
            cmd.Parameters.AddWithValue("@prio", priority);
            cmd.Parameters.AddWithValue("@contct", cntctNo);
            connection.Open();
            int n = cmd.ExecuteNonQuery();
            connection.Close();
            return n;
        }
        public List<Complain> GetComplainByStatus(string status)
        {
            List<Complain> complainList = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * From Complain where Status='" + status + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Complain aComplain = new Complain();
                aComplain.ComplainId = reader["ComplainID"].ToString();
                aComplain.PersonName = reader["PersonName"].ToString();
                aComplain.HostelNo = int.Parse(reader["HostelNo"].ToString());
                aComplain.RoomNo = int.Parse(reader["RoomNo"].ToString());
                aComplain.Category = reader["Category"].ToString();
                aComplain.Summary = reader["Summary"].ToString();
                aComplain.Priority = reader["Priority"].ToString();
                aComplain.DateOfComplain = DateTime.Parse(reader["DateOfComplain"].ToString());
                aComplain.Status = reader["Status"].ToString();
                aComplain.ContactNo = reader["ContactNo"].ToString();
                aComplain.AssistantName = reader["AssistantName"].ToString();
                aComplain.Remarks = reader["Remarks"].ToString();
                complainList.Add(aComplain);

            }
            reader.Close();
            connection.Close();
            return complainList;



        }
    }
}