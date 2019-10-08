using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolityczneSpektrum.Models
{
    public class QuestionEditModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Answer Answer { get; set; }
    }
}
