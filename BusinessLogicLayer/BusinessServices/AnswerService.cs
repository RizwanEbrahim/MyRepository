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
    public class AnswerService : IAnswerService
    {
        private IAnswerRepository IAnswer;
        QuestionDto DtoObject = new QuestionDto();
        public AnswerService()
        {

        }
        //Constructor dependency injection
        public AnswerService(IAnswerRepository _IAnswer)
        {
            IAnswer = _IAnswer;
        }
        //Map object from answer to answerdto
        public IEnumerable<AnswerDto> AMapToDto(IEnumerable<Answer> AnswerObject)
        {
            return AnswerObject.Select(q => new AnswerDto
            {
                Answerlist = q.Answerlist,
                AnswerDate = q.AnswerDate,
                Id = q.Id,
                QuestionId = q.QuestionId,
            }).ToList();

        }
        //Map object from answerdto to answermodel
        public Answer AMapToModel(AnswerDto AServiceObj)
        {
            return new Answer
            {
                Answerlist = AServiceObj.Answerlist,
                QuestionId = AServiceObj.QuestionId,
            };

        }
        //Get all the answers listed for a corresponding course
        public IEnumerable<AnswerDto> GetAnswers(int questionNo)
        {
            return CalcTimeDiffer(AMapToDto(IAnswer.GetAnswers(questionNo)));
        }
        //Save the question asked in the forum
        public bool CreateAnswer(AnswerDto AnsObject)
        {
            return IAnswer.CreateAnswer(AMapToModel(AnsObject));
        }
        //Calculate the time difference of the answer from the current time
        public IEnumerable<AnswerDto> CalcTimeDiffer(IEnumerable<AnswerDto> answerList)
        {
            return answerList.Select(c => { c.TimeDifference = Convert.ToInt32(DateTime.Now.Subtract(c.AnswerDate).TotalMinutes); return c; }).ToList();

        }
    }
}
