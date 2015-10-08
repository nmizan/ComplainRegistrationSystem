﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem.DAL
{
    public class ManagerGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ComplainCon"].ConnectionString;

        public int Save(UserAccount aUserAccount)
        {

            string query = string.Format(@"INSERT INTO UserAccount VALUES('{0}','{1}','{2}','{3}')", aUserAccount.UserId,aUserAccount.UserType,aUserAccount.UserName,aUserAccount.Password);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public bool IsUserIdExists(UserAccount aUserAccount)
        {
            bool isUserIdExists = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select UserID  From UserAccount Where UserID='" + aUserAccount.UserId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                isUserIdExists = true;
                break;
            }
            reader.Close();
            connection.Close();
            return isUserIdExists;


        }

        public int AddUserNew()
        {
            int maxUserId = 1001;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("select max(UserID) from UserAccount", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                maxUserId = int.Parse(reader.GetValue(0).ToString());
                maxUserId++;
            }
            reader.Close();
            connection.Close();
            return maxUserId;
        }
        public List<UserAccount> ShowAllUser()
        {
            List<UserAccount> userList = new List<UserAccount>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * From UserAccount ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                UserAccount account = new UserAccount();
                account.UserId = reader["UserID"].ToString();
                account.UserType = reader["UserType"].ToString();
                account.UserName = reader["UserName"].ToString();
                account.Password = reader["Password"].ToString();
              
                userList.Add(account);

            }
            reader.Close();
            connection.Close();
            return userList;

        }
        public int Delete(int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM UserAccount WHERE UserID =@userId ", connection);
            cmd.Parameters.AddWithValue("@userId", userId);
            connection.Open();
            int n = cmd.ExecuteNonQuery();
            connection.Close();
            return n;

        }
        public int Update(int userId, string uName,string uType, string pass)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Update UserAccount Set UserType=@uType,UserName=@uname,Password=@pass WHERE UserID =@userId ", connection);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@uname", uName);
            cmd.Parameters.AddWithValue("@uType", uType);
            cmd.Parameters.AddWithValue("@pass", pass);
           
            connection.Open();
            int n = cmd.ExecuteNonQuery();
            connection.Close();
            return n;
        }
        public List<UserAccount> GetUserByType(string type)
        {
            List<UserAccount> userList = new List<UserAccount>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * From UserAccount where UserType='" + type + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                UserAccount account=new UserAccount();

                account.UserId = reader["UserID"].ToString();
                account.UserType = reader["UserType"].ToString();
                account.UserName= reader["UserName"].ToString();
                account.Password = reader["Password"].ToString();
               
                userList.Add(account);

            }
            reader.Close();
            connection.Close();
            return userList;



        }
    }
}