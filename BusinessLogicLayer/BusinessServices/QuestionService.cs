using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Repository;
using DataAccessLayer.Model;
namespace BusinessLogicLayer.BusinessServices
{
   public class QuestionService : IQuestionService
    { private IQuestionRepository _IQuest;
        QuestionDto DtoObject = new QuestionDto();
        public QuestionService()
        {

        }
        //Constructor dependency injection
        public QuestionService(IQuestionRepository IQuest)
        {
            _IQuest = IQuest;
        }
        //Map objects from QuestionDto to Question
        public Question QMApToModel(QuestionDto QuestionObject)
        {
            return new Question
            {
                AnswerCount = QuestionObject.AnswerCount,
                QuestionId = QuestionObject.QuestionId,
                IsAnswered = QuestionObject.IsAnswered,
                QuestionDescription = QuestionObject.QuestionDescription,
                QuestionTitle = QuestionObject.QuestionTitle
            };

        }
        //map objects from Question to QuestionDto
        public IEnumerable<QuestionDto> QMApToDto(IEnumerable<Question> QuestionObject)
        {
          return  QuestionObject.Select(q => new QuestionDto
             {
                 AnswerCount = q.AnswerCount,
                 QuestionId = q.QuestionId,
                 IsAnswered = q.IsAnswered,
                 QuestionDate = q.QuestionDate,
                 QuestionDescription = q.QuestionDescription,
                 QuestionTitle = q.QuestionTitle
             }).ToList();

        }
        //Get all the questions asked in the forum
        public IEnumerable<QuestionDto> GetAllQuestions()
        {
            return QMApToDto(_IQuest.GetAllQuestions());
        }
        //save the questions asked in the forum
        public bool CreateQuestion(QuestionDto QuestionObject )
        {
            return _IQuest.CreateQuestion(QMApToModel(QuestionObject));
        }
    }
}
