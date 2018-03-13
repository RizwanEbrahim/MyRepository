using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.Model;
using BusinessLogicLayer.DTO;
namespace PresantaionLayer.Models
{
    public class AnswerView
    {
        public int AnswerNo { get; set; }
        public string Answerlist { get; set; }
        public DateTime AnswerDate { get; set; }
        public int QuestionId { get; set; }
        public int TimeDifference { get; set; }


    }
}