using Lab11.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab11.Controllers
{
    public class CalcController : Controller
    {
        private readonly ICalculationService _calculationService;

        public CalcController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public IActionResult ModelCalc()
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 11);
            int b = rnd.Next(0, 11);

            CalcModel model = new CalcModel
            {
                A = a,
                B = b,

                Sum = _calculationService.Add(a, b),
                Difference = _calculationService.Subtract(a, b),
                Product = _calculationService.Multiply(a, b),
                Quotient = _calculationService.Divide(a, b)
            };
            return View(model);
        }


        public IActionResult DataCalc()
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 11);
            int b = rnd.Next(0, 11);

            ViewData["A"] = a;
            ViewData["B"] = b;

            ViewData["Sum"] = _calculationService.Add(a, b);
            ViewData["Difference"] = _calculationService.Subtract(a, b);
            ViewData["Product"] = _calculationService.Multiply(a, b);
            ViewData["Quotient"] = _calculationService.Divide(a, b);

            return View();
        }


        public IActionResult BagCalc()
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 11);
            int b = rnd.Next(0, 11);

            ViewBag.A = a;
            ViewBag.B = b;

            ViewBag.Sum = _calculationService.Add(a, b);
            ViewBag.Difference = _calculationService.Subtract(a, b);
            ViewBag.Product = _calculationService.Multiply(a, b);
            ViewBag.Quotient = _calculationService.Divide(a, b);

            return View();
        }


        public IActionResult ServiceInjectionCalc()
        {
            var calcViewModel = _calculationService.createCalcModel();
            return View(calcViewModel);
        }
    }
}
