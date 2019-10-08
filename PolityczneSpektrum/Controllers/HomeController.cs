using Microsoft.AspNetCore.Mvc;
using PolityczneSpektrum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using PolityczneSpektrum.Services;
using PolityczneSpektrum.Views;
using PagedList.Core;
using ReflectionIT.Mvc.Paging;
using PolityczneSpektrum.Data;
using Microsoft.EntityFrameworkCore;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Drawing;

namespace PolityczneSpektrum.Controllers
{
    public class HomeController : Controller
    {

        private IQuestionsData _questions;
        private readonly PolityczneSpektrumDbContext _data;
        public static int pageNumber = 1;
        public static int QuestionNumber = 1;


        public HomeController( PolityczneSpektrumDbContext data, IQuestionsData questions)
        {
            _data = data;
            _questions = questions;
        }


        public async Task<IActionResult> Index()
        {
            await _data.Questions.ForEachAsync(a => a.Answer = Answer.None);
            await _data.SaveChangesAsync();

            return View();
        }


        
        public async Task<IActionResult> Result()
        {
            pageNumber = 1;
            QuestionNumber = 1;
            var test = await _data.Questions.ToListAsync();

            return View(test);
        }

        [HttpGet]
        public async Task<IActionResult> Questions(int page =1)
        {
            await _data.SaveChangesAsync();

            var query = _data.Questions.AsNoTracking().OrderBy(i => i.Id);

            var test = await PagingList.CreateAsync(query, 5, pageNumber);
            return View(test);
        }

        
        
        [HttpPost]
        [Produces("application/json")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Questions(IEnumerable<QuestionEditModel> request)
        {
            pageNumber++;

           
            foreach (var req in request)
            {
                var UpdatedQuestion = _questions.Get(QuestionNumber);
                UpdatedQuestion.Answer = req.Answer;
                QuestionNumber++;
            }

            await _data.SaveChangesAsync();

            if(pageNumber < 14)
            {
                return RedirectToAction($"Questions", "Home", pageNumber);
            }
            else
            {
                var test = request.FirstOrDefault();
                return RedirectToAction("Result", "Home", request);
            }


        }



    }
}
