
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model;
namespace DataAccessLayer.Repository
{
   public interface IQuestionRepository
    {
        IEnumerable<Question> GetAllQuestions();
        bool CreateQuestion(Question QuestionObject);
    }
}
