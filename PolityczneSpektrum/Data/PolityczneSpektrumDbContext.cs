using Microsoft.EntityFrameworkCore;
using PolityczneSpektrum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolityczneSpektrum.Data
{
    public class PolityczneSpektrumDbContext : DbContext
    {

        public PolityczneSpektrumDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionEditModel> QuestionwithAnswers { get; set; }
    }
}
