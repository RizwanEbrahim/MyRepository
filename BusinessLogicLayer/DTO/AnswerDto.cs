using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model;
namespace BusinessLogicLayer.DTO
{
   public class AnswerDto
    {
        public int Id { get; set; }
        public string Answerlist { get; set; }
        public DateTime AnswerDate { get; set; }
        public int QuestionId { get; set; }
        public int TimeDifference { get; set; }

    }
}
