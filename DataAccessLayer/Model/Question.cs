using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Model
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionDescription { get; set; }
        private DateTime questionDate;
        [DefaultValue(0)]
        public int AnswerCount { get; set; }
        public bool IsAnswered { get; set; }
        public DateTime QuestionDate
        {
            get
            {
                return questionDate;
            }

            set
            {
                questionDate = value;
            }
        }


    }
}

