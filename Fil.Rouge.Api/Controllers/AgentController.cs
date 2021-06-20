namespace Fil.Rouge.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Threading.Tasks;
    using Fil.Rouge.Api.Models;
    using Fil.Rouge.DataAccessLayer.AccessLayer;
    using Fil.Rouge.DataAccessLayer.Models;

    public class AgentController : ApiController
    {
        private readonly AgentAccessLayer quizAccessLayer = new AgentAccessLayer();

        // GET: Agent
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<DataAccessLayer.Models.Agent> result = quizAccessLayer.GetAll();

            return this.Ok(result);
        }

        // GET: api/QuizQuestion/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var fromDB = quizAccessLayer.Get(id);

            if (fromDB == null) // traitement si id n'existe pas
                return this.NotFound();

            var result = new Agent
            {
                Id = fromDB.Id,
                Civility = fromDB.Civility,
                Lastname = fromDB.Lastname,
                Firstname = fromDB.Firstname,
                Phone = fromDB.Phone,
                IsActive = fromDB.IsActive,
                IsAdmin = fromDB.IsAdmin,
                Password= fromDB.Password,
            };
            return this.Ok(result);
        }

        // api/Create Question
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Agent agent) // c'est un post on regarde ce que contient Body
        {

            var agentToAdd = new DataAccessLayer.Models.Agent
            {
                Id = agent.Id,
                Civility = agent.Civility,
                Lastname = agent.Lastname,
                Firstname = agent.Firstname,
                Phone = agent.Phone,
                IsActive = agent.IsActive,
                IsAdmin = agent.IsAdmin,
                Password = agent.Password
            };

            await quizAccessLayer.AddAsync(agentToAdd);
            return this.Ok("created");
        }

        // Update
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, [FromBody] Agent agent)
        {
            try
            {
                var agentToUpdate = new DataAccessLayer.Models.Agent
                {
                    Id = agent.Id,
                    Civility = agent.Civility,
                    Lastname = agent.Lastname,
                    Firstname = agent.Firstname,
                    Phone = agent.Phone,
                    IsActive = agent.IsActive,
                    IsAdmin = agent.IsAdmin,
                    Password = agent.Password
                };

                await quizAccessLayer.UpdateAsync(agentToUpdate);

                return this.Ok("updated");
            }

            catch
            {
                return this.NotFound();
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var agentToDelete = quizAccessLayer.Get(id);

            if (agentToDelete == null)
            {
                return this.NotFound();
            }

            await quizAccessLayer.DeleteAsync(agentToDelete.Id);
            return this.Ok("Delete");
        }
    }
}