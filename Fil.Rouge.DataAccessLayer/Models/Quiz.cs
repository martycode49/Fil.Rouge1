namespace Fil.Rouge.DataAccessLayer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Quiz
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Technologie")]
        public string Subject { get; set; }
        [DisplayName("Clé de sujet")]
        public string SubSubject { get; set; }
        [DisplayName("Type de question")]
        public string QuestionType { get; set; }
        public string Question { get; set; }

        [DisplayName("Réponse 1")]
        public string Rep1 { get; set; }
        [DisplayName("Réponse 2")]
        public string Rep2 { get; set; }
        [DisplayName("Réponse 3")]
        public string Rep3 { get; set; }
        [DisplayName("Réponse 4")]
        public string Rep4 { get; set; }
        [DisplayName("Niveau")]
        public int Level { get; set; }
        public int Validquestion { get; set; }
        public string CommentFalse { get; set; }
    
        public virtual ICollection<ParticipantData> ParticipantData { get; set; }
    }
}
