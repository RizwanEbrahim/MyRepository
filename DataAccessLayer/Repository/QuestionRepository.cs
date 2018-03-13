using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model;
namespace DataAccessLayer.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        DatabaseContext db = new DatabaseContext();
        //Save the question asked in the portal 
        public bool CreateQuestion(Question QuestionObject)
        {
            try
            {
                QuestionObject.QuestionDate = DateTime.Now;
                db.Questions.Add(QuestionObject);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }
        //GEt all questions asked in the portal
        public IEnumerable<Question> GetAllQuestions()
        {
            return db.Questions.OrderBy(s => s.AnswerCount).OrderByDescending(s => s.QuestionDate).ToList();
        }
    }
}
