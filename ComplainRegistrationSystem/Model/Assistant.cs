using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplainRegistrationSystem.Model
{
    public class Assistant
    {
        public string AssistantId { get; set; }
        public string AssistantName { get; set; }
        public string AssistantType { get; set; }
        public string ContactNo { get; set; }
        public string AsstTypeName { set; get; }
    }
}