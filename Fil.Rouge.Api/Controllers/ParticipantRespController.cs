namespace Fil.Rouge.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Threading.Tasks;
    using Fil.Rouge.Api.Models;
    using Fil.Rouge.DataAccessLayer.AccessLayer;
    using Fil.Rouge.Web.Models;

    public class ParticipantRespController : ApiController
    {
               //private FilRougeContext db = new FilRougeContext();
        private readonly QuizParticipantAccessLayer quizparticipantAccessLayer = new QuizParticipantAccessLayer();

        // GET api
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<DataAccessLayer.Models.ParticipantData> result = quizparticipantAccessLayer.GetAll();

            return this.Ok(result);
        }

        // Update
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, [FromBody] ParticipantResponse participantResponse)
        {
            //if (!quizparticipantAccessLayer.Exists(participantResponse.Id))
            //{
            //    return this.NotFound();
            //}


            var quizToUpdate = new DataAccessLayer.Models.ParticipantData
            {
                QuizValidAnswer = participantResponse.QuizValidAnswer,
            };

            await quizparticipantAccessLayer.UpdateAsync(quizToUpdate);

            return this.Ok("updated");
        }

    }
}
