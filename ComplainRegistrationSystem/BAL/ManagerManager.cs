﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComplainRegistrationSystem.DAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem.BAL
{
    public class ManagerManager
    {
        ManagerGateway aGateway=new ManagerGateway();

        public string Save(UserAccount aUserAccount)
        {
            if (aGateway.IsUserIdExists(aUserAccount))
            {
                return "User ID is already Exixts !!";
            }
            else
            {
                if (aGateway.Save(aUserAccount)>0)
                {
                    return "Successfully Inserted !";
                }
                else
                {
                    return "Insertion Failed!!";
                }
            }
        }

        public int AddUserNew()
        {
            return aGateway.AddUserNew();
        }

        public List<UserAccount> ShowAllUser()
        {
           return  aGateway.ShowAllUser();
        }

        public bool Delete(int userId)
        {
            if (aGateway.Delete(userId)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int userId, string uName, string uType, string pass)
        {
            if (aGateway.Update(userId,uName,uType,pass)> 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<UserAccount> GetUserByType(string type)
        {
            return aGateway.GetUserByType(type);
        }
    }
}