
namespace Fil.Rouge.DataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AgentParticipant
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Agent")]
        public int IdAgent { get; set; }
        public Nullable<System.DateTime> Datecreate { get; set; }
        public int QuestionQty { get; set; }
        public string Status { get; set; }
    
        public virtual Agent Agent { get; set; }
        public virtual ICollection<ParticipantData> ParticipantData { get; set; }
    }
}
