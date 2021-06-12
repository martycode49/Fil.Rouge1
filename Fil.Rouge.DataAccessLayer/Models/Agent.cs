namespace Fil.Rouge.DataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Agent
    {
        
        [Key]
        public int Id { get; set; }
        [DisplayName("Civilité")]
        public string Civility { get; set; }
        [DisplayName("Nom")]
        public string Lastname { get; set; }
        [DisplayName("Prénom")]
        public string Firstname { get; set; }
        [DisplayName("Téléphone")]
        public string Phone { get; set; }
        [DisplayName("Actif")]
        public bool IsActive { get; set; }
        [DisplayName("Administrateur")]
        public bool IsAdmin { get; set; }
        [DisplayName("Mot de passe")]
        public string Password { get; set; }
    
        public virtual ICollection<AgentParticipant> AgentParticipants { get; set; }
    }
}
