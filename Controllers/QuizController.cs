using Lab13.Models;
using Lab13.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lab13.Controllers
{
    public class QuizController : Controller
    {
        private readonly ICalculationService _calculationService;
        private readonly IDataStorageService _dataStorageService;
        
        
        
        public QuizController(ICalculationService calculationService, IDataStorageService dataStorageService)
        {
            _calculationService = calculationService;
            _dataStorageService = dataStorageService;
        }

        private QuizModel genQuiz(QuizModel m)
        {
            string[] operations = { "+", "-", "*", "/" };
            Random rnd = new Random();
            int rndA = rnd.Next(0, 11);
            int rndB = rnd.Next(0, 11);
            int rndOpr = rnd.Next(0, 4);


            m.A = rndA;
            m.B = rndB;
            m.Operation = (operations[rndOpr]);
            m.Result = _calculationService.Calculate(rndA, rndB, operations[rndOpr]);

            return m;
        }



        public IActionResult Quiz()
        {
            QuizModel model = new QuizModel();
            model = genQuiz(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult QuizNext(QuizModel model) 
        {
            _dataStorageService.AddModel(model);
            model = genQuiz(model);

            return View("Quiz", model);
        }

        [HttpPost]
        public IActionResult QuizResult(QuizModel model)
        {
            _dataStorageService.AddModel(model);

            var viewModel = new QuizResultsViewModel
            {
                Models = _dataStorageService.GetModels(),
                QuestionCount = _dataStorageService.GetQuestionsCount(),
                RightAnswersCount = _dataStorageService.GetRightAnswersCount()
            };

            return View(viewModel);

        }

        public IActionResult ClearModel()
        {
            _dataStorageService.ClearModels();

            var viewModel = new QuizResultsViewModel
            {
                Models = _dataStorageService.GetModels(),
                QuestionCount = _dataStorageService.GetQuestionsCount(),
                RightAnswersCount = _dataStorageService.GetRightAnswersCount()
            };


            return View("QuizResult", viewModel);
        }
        public IActionResult QuizResultFromIndex()
        {
            //if (_dataStorageService.GetModels().Count == 0)
            //{
            //    QuizModel model = new QuizModel();
            //    _dataStorageService.AddModel(model);
            //}

            var viewModel = new QuizResultsViewModel
            {
                Models = _dataStorageService.GetModels(),
                QuestionCount = _dataStorageService.GetQuestionsCount(),
                RightAnswersCount = _dataStorageService.GetRightAnswersCount()
            };

            return View("QuizResult", viewModel);

        }
    }
}
