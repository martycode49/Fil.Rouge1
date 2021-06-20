namespace Fil.Rouge.DataAccessLayer.AccessLayer
{
    using DataAccessLayer.Context;
    using DataAccessLayer.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Data.Entity;

    public class QuizParticipantAccessLayer
    {
        private readonly FilRougeContext context;
        private readonly DbSet<ParticipantData> participantdatas;

        public QuizParticipantAccessLayer()
        {
            this.context = new FilRougeContext();
            this.participantdatas = this.context.Set<ParticipantData>();
        }

        public List<ParticipantData> GetAll()
        {
            return this.participantdatas.ToList();
        }

        public ParticipantData Get(int id)
        {
            return this.participantdatas.AsQueryable().AsNoTracking()
                .FirstOrDefault(q => q.Id == id);
        }

        public async Task<bool> AddAsync(ParticipantData participantData)
        {
            this.participantdatas.Add(participantData);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> UpdateAsync(ParticipantData participantData)
        {
            var partdataToEdit = this.participantdatas.Include(q => q.Id).FirstOrDefault(q => q.Id == participantData.Id);

            if (partdataToEdit == null)
                return false;

            partdataToEdit.Participant = participantData.Participant;
            partdataToEdit.Quiz = participantData.Quiz;
            partdataToEdit.QuizCommentPart = participantData.QuizCommentPart;
            partdataToEdit.QuizFreeAnswer = participantData.QuizFreeAnswer;
            partdataToEdit.QuizId = participantData.QuizId;
            partdataToEdit.QuizParticipId = participantData.QuizId;
            partdataToEdit.QuizQend = participantData.QuizQend;
            partdataToEdit.QuizQstart = participantData.QuizQstart;
            partdataToEdit.QuizQuestionId = participantData.QuizQuestionId;
            partdataToEdit.QuizValidAnswer = participantData.QuizValidAnswer;
            partdataToEdit.QuizValidFreeAnswer = participantData.QuizValidFreeAnswer;

            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var quizToRemove = this.participantdatas.AsQueryable().FirstOrDefault(q => q.Id == id);
            this.participantdatas.Remove(quizToRemove);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }
    }
}
