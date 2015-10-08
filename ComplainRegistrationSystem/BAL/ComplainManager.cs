using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComplainRegistrationSystem.DAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem.BAL
{
    public class ComplainManager
    {
        ComplainGateway aGateway=new ComplainGateway();

        public string Save(Complain aComplain)
        {
            if (aGateway.IsComplainIdExists(aComplain))
            {
                return " Complain ID is already Exists!";
            }
            else
            {
                if (aGateway.Save(aComplain) > 0)
                {
                    return "Successfully Inserted !!";
                }
                else
                {
                    return "Save Failed!";
                }

            }
            

        }

        public List<Complain> ShowAllComplain()
        {
            return aGateway.ShowAllComplain();
        }

        public List<Complain> GetComplainById(string id)
        {
            return aGateway.GetComplainById(id);
        }

        public List<Complain> GetComplainByRoomNo(int roomNo)
        {
            return aGateway.GetComplainByRoomNo(roomNo);
        }

        public bool Update(string compId, string pName, int hNo, int rNo, string catg, string sumry, string priority,
            string cntctNo)
        {
            if (aGateway.Update(compId, pName, hNo, rNo, catg, sumry, priority, cntctNo)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Complain> GetComplainByStatus(string status)
        {
            return aGateway.GetComplainByStatus(status);
        }
    }
}