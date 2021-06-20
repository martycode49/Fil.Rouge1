namespace Fil.Rouge.DataAccessLayer.AccessLayer
{
    using DataAccessLayer.Context;
    using DataAccessLayer.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Data.Entity;

    public class AgentAccessLayer
    {
        private readonly FilRougeContext context;
        private readonly DbSet<Agent> agents;

        public AgentAccessLayer()
        {
            this.context = new FilRougeContext();
            this.agents = this.context.Set<Agent>();
        }

        public List<Agent> GetAll()
        {
            return this.agents.ToList();
        }

        public Agent Get(int id)
        {
            return this.agents.AsQueryable().AsNoTracking()
                .FirstOrDefault(q => q.Id == id);
        }

        public async Task<bool> AddAsync(Agent agent)
        {
            this.agents.Add(agent);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> UpdateAsync(Agent agent)
        {
            var agentToEdit = this.agents.Include(q => q.Id).FirstOrDefault(q => q.Id == agent.Id);

            if (agentToEdit == null)
                return false;

            agentToEdit.Civility = agent.Civility;
            agentToEdit.Lastname = agent.Lastname;
            agentToEdit.Firstname = agent.Firstname;
            agentToEdit.Phone = agent.Phone;
            agentToEdit.IsAdmin = agent.IsActive;
            agentToEdit.IsAdmin = agent.IsAdmin;
            agentToEdit.Password = agent.Password;

            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var agentToRemove = this.agents.AsQueryable().FirstOrDefault(q => q.Id == id);
            this.agents.Remove(agentToRemove);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }
    }
}
