namespace Fil.Rouge.DataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Participant
    {
        [Key]
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public System.DateTime TimeStart { get; set; }
        public Nullable<System.DateTime> TimeLastQuiz { get; set; }
    
        public virtual ICollection<ParticipantData> ParticipantData { get; set; }
    }
}
