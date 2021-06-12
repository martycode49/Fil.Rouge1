using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Fil.Rouge.Api.Models
{   
    [DataContract]
    public class QuizQuestion
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string SubSubject { get; set; }
        [DataMember]
        public string QuestionType { get; set; }
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
        public int Level { get; set; }
        [DataMember]
        public int Validquestion { get; set; }
        [DataMember]
        public string CommentFalse { get; set; }
    }
}