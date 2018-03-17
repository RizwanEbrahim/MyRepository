using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
   public class Answer
    {
        public int Id { get; set; }
        public string Answerlist { get; set; }
        private DateTime answerDate;
     
        public int QuestionId { get; set; }
        public virtual Question QuestionObject { get; set; }
        public int NoOfVotes { get; set; }
        public DateTime AnswerDate
        {
            get
            {
                 return answerDate;  
            }

            set
            {
                answerDate =value;
            }
        }

       
        }
    }

