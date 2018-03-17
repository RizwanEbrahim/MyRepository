using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;
namespace BusinessLogicLayer.BusinessServices
{
    public interface IQuestionService
    {
       IEnumerable<QuestionDto> GetAllQuestions();
        bool CreateQuestion(QuestionDto QuestionObject);
        IEnumerable<QuestionDto> SearchQuestions(string searchText);
    }
}
