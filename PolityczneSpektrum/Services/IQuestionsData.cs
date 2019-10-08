using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolityczneSpektrum.Models;

namespace PolityczneSpektrum.Services
{
    public interface IQuestionsData
    {
        IEnumerable<Question> GetAll();
        Question Add(Question restaurant);
        Question Update(Question restaurant);
        Question Get(int id);
 
    }
}
