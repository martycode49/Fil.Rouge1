namespace Fil.Rouge.DataAccessLayer.Context
{
    using System.Data.Entity;
    using Fil.Rouge.DataAccessLayer.Models;

    internal class FilRougeContext : DbContext
    {
        public FilRougeContext() : base("FilRougeContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }


        internal DbSet<Agent> Agents { get; set; }
        internal DbSet<AgentParticipant> AgentParticipants { get; set; }
        internal DbSet<Participant> Participants { get; set; }
        internal DbSet<ParticipantData> ParticipantDatas { get; set; }
        internal DbSet<Quiz> Quizs { get; set; }

    }
}
