using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Fil.Rouge.Api.Models
{
    [DataContract]
    public class QuizParticipant
    {   
        [DataMember]
        public string Question { get; set; }
        [DataMember]
        public string Rep1 { get; set; }
        [DataMember]
        public string Rep2 { get; set; }
        [DataMember]
        public string Rep3 { get; set; }
        [DataMember]
        public string Rep4 { get; set; }
        [DataMember]
        public string QuestionType { get; set; }
        [DataMember]
        public string QuestionQty { get; set; }
        [DataMember]
        public string AgentFName { get; set; }
        [DataMember]
        public string AgentLName { get; set; }
        [DataMember]
        public string PartFName { get; set; }
        [DataMember]
        public string PartLName { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
    }
}