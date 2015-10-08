using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ComplainRegistrationSystem.DAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem.BAL
{
    public class LoginAfterManager
    {
        LoginAfterGateway aLoginAMan=new LoginAfterGateway();
       
        Assistant aAssistant = new Assistant();


        public List<Assistant> GetAssistantData()
        {
            return aLoginAMan.GetAssistantData();

        }
        public List<Assistant> ViewInlabel(string aName)
        {
            return aLoginAMan.ViewInLabel(aName);
        }
        public List<Complain> ViewInGridview()
        {
            return aLoginAMan.ViewInGridView();
        }
        public List<Complain> ViewInReq()
        {
            return aLoginAMan.ViewInLabelReq();
        }
        public List<Complain> ChangeGridView(string reqType)
        {
            return aLoginAMan.GridViewChangeByLink(reqType);
        }
        public List<Complain> ReqTyp(string reqStatus)
        {
            return aLoginAMan.GridByReq(reqStatus);
        }
        public string ChangeBySol(string[] asd, string sta)
        {
            return aLoginAMan.ChangedByCan(asd, sta);
        }
        public DataTable SearchByDate(string t1, string t2)
        {
            return aLoginAMan.SearchByDate(t1, t2);
        }
        public string AllocateFinal(List<Complain> aLLocate, string[] cid)
        {
            return aLoginAMan.AllocateAssistant(aLLocate, cid);
        }
    }
}