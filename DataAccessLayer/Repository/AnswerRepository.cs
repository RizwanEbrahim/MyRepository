
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model;

namespace DataAccessLayer.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        

        //Save the question asked within the forum
        public bool CreateAnswer(Answer AnswerObj)
        {
            try
            {
                using (var db = new DatabaseContext())
                {

                    AnswerObj.AnswerDate = DateTime.Now;
                    db.Answers.Add(AnswerObj);
                    var qList = db.Questions.Find(AnswerObj.QuestionId);
                    qList.AnswerCount++;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }
        //GEt all the answers corresponding to a question
        public IEnumerable<Answer> GetAnswers(int questionNo)
        {
            using (var db = new DatabaseContext())
            {
                return db.Answers.Where(q => q.QuestionId == questionNo).OrderByDescending(q => q.AnswerDate).ToList();
            }
        }
        public int UpdateVote(int id,int VoteCount)
        {
            using (var db = new DatabaseContext())
            {
                var ans=db.Answers.Find(id);
                if (VoteCount != 0)
                {
                    ans.NoOfVotes += VoteCount;
                }
                db.SaveChanges();
                return ans.NoOfVotes;


            }
        }
    }
}
