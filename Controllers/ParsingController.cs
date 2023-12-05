using Lab11.Models;
using Lab12.Models;
using Microsoft.AspNetCore.Mvc;





namespace Lab12.Controllers
{
    public class SeparateModel
    {
        public int A { get; set; }
        public int B { get; set; }
        public string Operation { get; set; }
    }


    public class ParsingController : Controller
    {
        private readonly ICalculationService _calculationService;

        private string operationConvert(string opr)
        {
            string temp;

            switch (opr)
            {
                case "Add":
                    temp = "+";
                    break;
                case "Subtract":
                    temp = "-";
                    break;
                case "Multiply":
                    temp = "*";
                    break;
                case "Divide":
                    temp = "/";
                    break;

                default:
                    throw new Exception("SOMETHING WENT WRONG!!");
            }

            return temp;
        }


        public ParsingController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }



        public IActionResult SingleAction()
        {
            CalcModel calcModel = new CalcModel
            {
                calcName = "Manual",
                controllerMethod = "ResultSingleAction"
            };

            return View("Form", calcModel);
        }

        public IActionResult ResultSingleAction()
        {
            var formData = HttpContext.Request.Form;

            try
            {
                int A = int.Parse(formData["A"].ToString());
                int B = int.Parse(formData["B"].ToString());
                string operation = formData["operation"];

                ViewBag.firstVal = A;
                ViewBag.secondVal = B;
                ViewBag.operation = operationConvert(operation);
                ViewBag.result = _calculationService.Calculate(A, B, operation);
            }
            catch 
            {
                throw new Exception("Данные введены неверно! Проверьте корректность ввода");
            }

            return View("Result");
        }



        public IActionResult SeparateActions()
        {
            CalcModel calcModel = new CalcModel
            {
                calcName = "ManualWithSeparateHandlers",
                controllerMethod = "ResultSeparateActions"
            };

            return View("Form", calcModel);
        }

        public IActionResult ResultSeparateActions()
        {
            var formData = HttpContext.Request.Form;
            return ResultSeparateActionsWithForm(formData);
        }

        public IActionResult ResultSeparateActionsWithForm(IFormCollection formData)
        {
            try
            {
                int A = int.Parse(formData["A"].ToString());
                int B = int.Parse(formData["B"].ToString());
                string operation = formData["operation"];

                ViewBag.firstVal = A;
                ViewBag.secondVal = B;
                ViewBag.operation = operationConvert(operation);
                ViewBag.result = _calculationService.Calculate(A, B, operation);
            }
            catch
            {
                throw new Exception("Данные введены неверно! Проверьте корректность ввода");
            }

            return View("Result");
        }



        public IActionResult ModelParameters()
        {
            CalcModel calcModel = new CalcModel
            {
                calcName = "ModelBindingInParameters",
                controllerMethod = "ResultModelParameters"
            };

            return View("Form", calcModel);
        }

        [HttpPost]
        public IActionResult ResultModelParameters(CalcModel model)
        {

            ViewBag.firstVal = model.A;
            ViewBag.secondVal = model.B;
            ViewBag.operation = operationConvert(model.operation);
            ViewBag.result = _calculationService.Calculate(model.A, model.B, model.operation);

            return View("Result");
        }



        public IActionResult ModelSeparate()
        {
            CalcModel calcModel = new CalcModel
            {
                calcName = "ModelBindingInSeparateModel",
                controllerMethod = "ResultModelSeparate"
            };

            return View("Form", calcModel);
        }

        public IActionResult ResultModelSeparate(SeparateModel model)
        {
            ViewBag.firstVal = model.A;
            ViewBag.secondVal = model.B;
            ViewBag.operation = operationConvert(model.Operation);
            ViewBag.result = _calculationService.Calculate(model.A, model.B, model.Operation);

            return View("Result");
        }

    }
}
