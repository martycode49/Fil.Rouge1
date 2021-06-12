namespace Fil.Rouge.DataAccessLayer.AccessLayer
{
    using DataAccessLayer.Context;
    using DataAccessLayer.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Data.Entity;


    public class QuizAccessLayer
    {
        private readonly FilRougeContext context;
        private readonly DbSet<Quiz> quizs;

        public QuizAccessLayer()
        {
            this.context = new FilRougeContext();
            this.quizs = this.context.Set<Quiz>();
        }

        public List<Quiz> GetAll()
        {
            return this.quizs.ToList();
        }

        public Quiz Get(int id)
        {
            return this.quizs.AsQueryable().AsNoTracking()
                .FirstOrDefault(q => q.Id == id);
        }

        public async Task<bool> AddAsync(Quiz quiz)
        {
            this.quizs.Add(quiz);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> UpdateAsync(Quiz quiz)
        {
            var quizToEdit = this.quizs.Include(q => q.Id).FirstOrDefault(q => q.Id == quiz.Id);

            if (quizToEdit == null)
                return false;

            quizToEdit.Subject = quiz.Subject;
            quizToEdit.SubSubject = quiz.SubSubject;
            quizToEdit.Question = quiz.Question;
            quizToEdit.Question = quiz.Question;
            quizToEdit.QuestionType = quiz.QuestionType;
            quizToEdit.Rep1 = quiz.Rep1;
            quizToEdit.Rep2 = quiz.Rep2;
            quizToEdit.Rep3 = quiz.Rep3;
            quizToEdit.Rep4 = quiz.Rep4;
            quizToEdit.Level = quiz.Level;
            quizToEdit.Validquestion = quiz.Validquestion;
            quizToEdit.CommentFalse = quiz.CommentFalse;

            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var quizToRemove = this.quizs.AsQueryable().FirstOrDefault(q => q.Id == id);
            this.quizs.Remove(quizToRemove);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }
    }
}
