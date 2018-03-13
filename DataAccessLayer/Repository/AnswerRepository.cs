
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model;

namespace DataAccessLayer.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        DatabaseContext db = new DatabaseContext();

        //Save the question asked within the forum
        public bool CreateAnswer(Answer AnswerObj)
        {
            try
            {
                AnswerObj.AnswerDate = DateTime.Now;
                db.Answers.Add(AnswerObj);
                var qList = db.Questions.Find(AnswerObj.QuestionId);
                qList.AnswerCount++;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }
        //GEt all the answers corresponding to a question
        public IEnumerable<Answer> GetAnswers(int questionNo)
        {
            return db.Answers.Where(q => q.QuestionId == questionNo).OrderByDescending(q => q.AnswerDate).ToList();
        }
    }
}
