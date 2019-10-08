//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using PolityczneSpektrum.Data;
//using PolityczneSpektrum.Models;

//namespace PolityczneSpektrum.Services
//{
//    public class SqlAnsweredQuestionsData : IAnsweredQuestionstData
//    {
//        private readonly PolityczneSpektrumDbContext _context;

//        public SqlAnsweredQuestionsData(PolityczneSpektrumDbContext context)
//        {
//            _context = context;
//        }

//        public QuestionEditModel Add(QuestionEditModel question)
//        {
//            _context.QuestionwithAnswers.Add(question);
//            _context.SaveChanges();

//            return question;
//        }

//        public IEnumerable<QuestionEditModel> GetAll()
//        {
//            return _context.QuestionwithAnswers.ToList();
//        }

//        public QuestionEditModel Update(QuestionEditModel question)
//        {
//            _context.Attach(question).State = EntityState.Modified;

//            _context.SaveChanges();

//            return question;
//        }
//    }
//}
