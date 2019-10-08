using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PolityczneSpektrum.Data;
using PolityczneSpektrum.Models;

namespace PolityczneSpektrum.Services
{
    public class SqlQuestionsData : IQuestionsData
    {
        private readonly PolityczneSpektrumDbContext _context;

        public SqlQuestionsData(PolityczneSpektrumDbContext context)
        {
            _context = context;
        }

        public Question Add(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();

            return question;
        }

        public Question Get(int id)
        {
            return _context.Questions.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _context.Questions.ToList();
        }

        public Question Update(Question question)
        {
            _context.Attach(question).State = EntityState.Modified;

            _context.SaveChanges();

            return question;
        }
    }
}
