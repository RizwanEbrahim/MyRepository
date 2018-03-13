using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionDescription { get; set; }
        public DateTime QuestionDate { get; set; }
        public int AnswerCount { get; set; }
        public bool IsAnswered { get; set; }

     
    }
}
