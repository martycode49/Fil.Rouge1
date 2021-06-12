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

    public class QuizQuestionController : ApiController
    {
        private readonly QuizAccessLayer quizAccessLayer = new QuizAccessLayer();

        // GET api/pizzas
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<DataAccessLayer.Models.Quiz> result = quizAccessLayer.GetAll();

            return this.Ok(result);
        }

        // GET: api/QuizQuestion/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var fromDB = quizAccessLayer.Get(id);

            if (fromDB == null) // traitement si id n'existe pas
                return this.NotFound();

            var result = new QuizQuestion
            {
                Id = fromDB.Id,
                Subject = fromDB.Subject,
                SubSubject = fromDB.SubSubject,
                QuestionType = fromDB.QuestionType,
                Question = fromDB.Question,
                Rep1 = fromDB.Rep1,
                Rep2 = fromDB.Rep2,
                Rep3 = fromDB.Rep3,
                Rep4 = fromDB.Rep4,
                Level = fromDB.Level,
                Validquestion = fromDB.Validquestion
            };
            return this.Ok(result);
        }

        // api/Create Question
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] QuizQuestion quizquestion) // c'est un post on regarde ce que contient Body
        {
            /*if (!quizAccessLayer.Exists(quizquestion.Id))
            {
                return this.NotFound();
            }*/

            var quizToAdd = new DataAccessLayer.Models.Quiz
            {
                Id = quizquestion.Id,
                Subject = quizquestion.Subject,
                SubSubject = quizquestion.SubSubject,
                QuestionType = quizquestion.QuestionType,
                Question = quizquestion.Question,
                Rep1 = quizquestion.Rep1,
                Rep2 = quizquestion.Rep2,
                Rep3 = quizquestion.Rep3,
                Rep4 = quizquestion.Rep4,
                Level = quizquestion.Level,
                Validquestion = quizquestion.Validquestion
            };

            await quizAccessLayer.AddAsync(quizToAdd);
            return this.Ok("created");
        }

        // Update
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, [FromBody] QuizQuestion quizquestion)
        {
            /*if (!quizAccessLayer.Exists(quizquestion.Id))
            {
                return this.NotFound();
            }*/


            var quizToUpdate = new DataAccessLayer.Models.Quiz
            {
                Id = quizquestion.Id,
                Subject = quizquestion.Subject,
                SubSubject = quizquestion.SubSubject,
                QuestionType = quizquestion.QuestionType,
                Question = quizquestion.Question,
                Rep1 = quizquestion.Rep1,
                Rep2 = quizquestion.Rep2,
                Rep3 = quizquestion.Rep3,
                Rep4 = quizquestion.Rep4,
                Level = quizquestion.Level,
                Validquestion = quizquestion.Validquestion
            };

            await quizAccessLayer.UpdateAsync(quizToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var quizToDelete = quizAccessLayer.Get(id);

            if (quizToDelete == null)
            {
                return this.NotFound();
            }

            await quizAccessLayer.DeleteAsync(quizToDelete.Id);
            return this.Ok("Delete");
        }
    }
}