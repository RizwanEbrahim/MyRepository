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
       
        //Save the question asked in the portal 
        public bool CreateQuestion(Question QuestionObject)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    QuestionObject.QuestionDate = DateTime.Now;
                    db.Questions.Add(QuestionObject);
                    db.SaveChanges();
                }
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
            using (var db = new DatabaseContext())
            {
                return db.Questions.OrderBy(s => s.AnswerCount).OrderByDescending(s => s.QuestionDate).ToList();
            }
        }
        public IEnumerable<Question> GetSearchQuestions(string searchText)
        {
            using (var db = new DatabaseContext())
            {
                return db.Questions.Where(s=>s.QuestionTitle.Contains(searchText)||s.QuestionDescription.Contains(searchText)).OrderBy(s => s.AnswerCount).OrderByDescending(s => s.QuestionDate).ToList();
            }
        }
    }
}
