namespace Fil.Rouge.Api.Controllers
{

    using System.Collections.Generic;
    using System.Web.Http;
    using Fil.Rouge.Api.Models;

        public class ApiQuizController : ApiController
    {   
        // GET: ApiQuiz
        [HttpGet]
        public IHttpActionResult GetQuiz(int UserId)
        {
            var data = new List<QuizParticipant>
            {
                new QuizParticipant
                {
                    Question = "What is a correct syntax to output \"Hello World\" in C#?",

                    Rep1 = "console.Writeln(\"Hello World\");",
                    Rep2 = "print (\"Hello world\");",
                    Rep3 = "count << \"Hello World\";",
                    Rep4 = "System.out.println(\"Hello World\");",
                    QuestionType = "S",
                    QuestionQty = "3",
                    AgentFName = "Jean",
                    AgentLName = "Dupont",
                    PartFName = "Eric",
                    PartLName = "You",
                    Id = "4",
                    UserId = 456
                },

                new QuizParticipant
                {
                    Question = "What is this value ? \"Hello World\" in C#?",

                    Rep1 = "console.Writeln(\"Hello World\");",
                    Rep2 = "print (\"Hello world\");",
                    Rep3 = "count << \"Hello World\";",
                    Rep4 = "System.out.println(\"Hello World\");",
                    QuestionType = "S",
                    QuestionQty = "3",
                    AgentFName = "Jean",
                    AgentLName = "Dupont",
                    PartFName = "Eric",
                    PartLName = "You",
                    Id = "4",
                    UserId = 456
                },
                    new QuizParticipant
                {
                    Question = "How do you insert COMMENTS in C# code?",

                    Rep1 = "/* This is a comment",
                    Rep2 = "# This is a comment",
                    Rep3 = "// This is a comment",
                    Rep4 = "",
                    QuestionType = "S",
                    QuestionQty = "3",
                    AgentFName = "Jean",
                    AgentLName = "Dupont",
                    PartFName = "Eric",
                    PartLName = "You",
                    Id = "4",
                    UserId = 456
                }
            };
            //return (IHttpActionResult)Json(data);
            return this.Ok(data);
        }
    }
}