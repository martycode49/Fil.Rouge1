using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fil.Rouge.Web.Models
{
    using System;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;

    [DataContract]
    public class ParticipantData
    {   
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int QuizId { get; set; }
        [DataMember]
        public int QuizQuestionId { get; set; }
        [DataMember]
        public int QuizParticipId { get; set; }
        [DataMember]
        public int QuizValidAnswer { get; set; }
        [DataMember]
        public Nullable<System.DateTime> QuizQstart { get; set; }
        [DataMember]
        public Nullable<System.DateTime> QuizQend { get; set; }
        [DataMember]
        public string QuizCommentPart { get; set; }
        [DataMember]
        public string QuizFreeAnswer { get; set; }
        [DataMember]
        public Nullable<bool> QuizValidFreeAnswer { get; set; }
    }
}