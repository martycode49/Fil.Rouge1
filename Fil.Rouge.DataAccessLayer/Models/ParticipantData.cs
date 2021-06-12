namespace Fil.Rouge.DataAccessLayer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ParticipantData
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AgentParticipant")]
        public int QuizId { get; set; }
        [ForeignKey("Quiz")]
        public int QuizQuestionId { get; set; }
        [ForeignKey("Participant")]
        public int QuizParticipId { get; set; }
        public int QuizValidAnswer { get; set; }
        public Nullable<System.DateTime> QuizQstart { get; set; }
        public Nullable<System.DateTime> QuizQend { get; set; }
        public string QuizCommentPart { get; set; }
        public string QuizFreeAnswer { get; set; }
        public Nullable<bool> QuizValidFreeAnswer { get; set; }


        public virtual AgentParticipant AgentParticipant { get; set; }
        public virtual Participant Participant { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
