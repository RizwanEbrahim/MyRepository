using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.BusinessServices;
using BusinessLogicLayer.DTO;
using PresantaionLayer.Models;
using System.Web.UI;

namespace PresantaionLayer.Controllers
{
    public class AnswerController : Controller
    {
        private IAnswerService IAnswer;
        public AnswerController()
        {

        }
        //Dependency injection in controller
        public AnswerController(IAnswerService _IAnswer)
        {
            IAnswer = _IAnswer;
        }

        //Map the Objects From AnswerDto model to AnswerView model
        public IEnumerable<AnswerView> AMapToView(IEnumerable<AnswerDto> AServiceObj)
        {
            var AnswerObj = AServiceObj.Select(q => new AnswerView
            {
                Answerlist = q.Answerlist,
                TimeDifference = q.TimeDifference,
                AnswerDate = q.AnswerDate,
                AnswerNo= q.Id,
                QuestionId = q.QuestionId,
            }).ToList();
            return AnswerObj;
        }
        //map the objects from AnswerView to AnswerDto
        public AnswerDto AMapToDto(AnswerView AServiceObj)
        {
            return new AnswerDto
            {
                Answerlist = AServiceObj.Answerlist,
                QuestionId = AServiceObj.QuestionId,
             
            };

        }
    
        //Display all the answers corresponding to a selected question
        public ActionResult GetAnswers(int qNo, string qTitle, string qDesc)
        {
            TempData["Category"] = qNo;
            var answerList = AMapToView(IAnswer.GetAnswers(qNo));         
            ViewData["QuestionTitle"] = qTitle;
            ViewData["QuestionDesc"] = qDesc;
            return View(answerList);
        }

       //Save the answer entered for a specfic question
        public ActionResult CreateAnswer(string TxtAra)
        {
                int quNo = (int)TempData["Category"];

         
                AnswerView AnsObj = new AnswerView();
                AnsObj.Answerlist = TxtAra;
                AnsObj.QuestionId = quNo;
                IAnswer.CreateAnswer(AMapToDto(AnsObj));
                return RedirectToAction("AllQuestions", "Question");
           
        }



    }
}
