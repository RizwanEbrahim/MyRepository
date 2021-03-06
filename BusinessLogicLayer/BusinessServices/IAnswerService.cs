﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;
namespace BusinessLogicLayer.BusinessServices
{
     public interface IAnswerService
    {
        IEnumerable<AnswerDto> GetAnswers(int questionNo);
        bool CreateAnswer(AnswerDto AnswerObject);
        bool CheckLogin(string Username, string Password);
    }
}
