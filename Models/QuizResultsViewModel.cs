using Microsoft.AspNetCore.Mvc;

namespace Lab13.Models
{
    public class QuizResultsViewModel
    {
        public List<QuizModel> Models { get; set; }
        public int QuestionCount { get; set; }
        public int RightAnswersCount { get; set; }
    }
}
