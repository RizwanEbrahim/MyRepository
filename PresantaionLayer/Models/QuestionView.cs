using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PresantaionLayer.Models
{
    public class QuestionView
    {
        public int QuestionId { get; set; }
        [Required]
        public string QuestionTitle { get; set; }
        [Required]
        public string QuestionDescription { get; set; }
        public DateTime QuestionDate { get; set; }
        public int TimeDifference { get; set; }
        public int AnswerCount { get; set; }
        
    }
   

}