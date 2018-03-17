using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.BusinessServices;
using PresantaionLayer.Models;
using BusinessLogicLayer.DTO;
using System.Web.Script.Serialization;

namespace PresantaionLayer.Controllers
{
    public class QuestionController : Controller
    {

        private IQuestionService IQuestion;
        public QuestionController()
        {

        }
        //Dependency injection in controller
        public QuestionController(IQuestionService _IQuestion)
        {
            IQuestion = _IQuestion;
        }
        //Map the objects from QuestionDto  to QuestionView
        public IEnumerable<QuestionView> QMapToView(IEnumerable<QuestionDto> QServiceObj)
        {
            var QViewObject = QServiceObj.Select(q => new QuestionView
            {
                QuestionDate = q.QuestionDate,
                QuestionDescription = q.QuestionDescription,
                AnswerCount = q.AnswerCount,
                QuestionId = q.QuestionId,
                QuestionTitle = q.QuestionTitle,
                TimeDifference=q.TimeDifference


            }).ToList();
            return QViewObject;
        }
        //Map the objects from QuestionView to QuestionDto
        public QuestionDto QMapToDto(QuestionView QuestionObject)
        {
            return new QuestionDto
            {
                QuestionDate = QuestionObject.QuestionDate,
                QuestionDescription = QuestionObject.QuestionDescription,
                AnswerCount = QuestionObject.AnswerCount,
                QuestionId = QuestionObject.QuestionId,
                QuestionTitle = QuestionObject.QuestionTitle,

            };

        }
        //Display All Questions Asked In the forum
        public ActionResult AllQuestions()
        {
            var User = QMapToView(IQuestion.GetAllQuestions());
            ViewData["QCount"] = User.Count();
            return View(User);
        }
        //Save the question asked in the forum
        public ActionResult CreateQuestion([Bind(Include = "QuestionDescription,QuestionTitle")] QuestionView QuestionObject)
        {
            if (ModelState.IsValid)
            {
                if (IQuestion.CreateQuestion(QMapToDto(QuestionObject)))
                    return RedirectToAction("AllQuestions");
            }
            return View(QuestionObject);
        }

        //Display The create Question view
        public ActionResult AskView()
        {
            return View();
        }
       public JsonResult TimeDifference()
        {
            var questionList = QMapToView(IQuestion.GetAllQuestions());
             var result= questionList.Select(c => { c.TimeDifference = Convert.ToInt32(DateTime.Now.Subtract(c.QuestionDate).TotalSeconds); return c; }).ToList();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            //return jss.Deserialize<List<QuestionView>>(result.ToString());
    //       var finalresult= result.Select(c => c.TimeDifference).ToList();
            return Json(result);
        }
        [HttpGet]
        public ActionResult Search(string SearchText)
        {
            var questions = QMapToView(IQuestion.SearchQuestions(SearchText));
            return  View("AllQuestions", questions);
 
        }
    }
}
