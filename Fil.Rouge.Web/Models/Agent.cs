namespace Fil.Rouge.Web.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Agent
    {   
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Civility { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public bool IsAdmin { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}