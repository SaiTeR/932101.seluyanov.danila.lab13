using Lab13.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab13.Services
{
    public interface IDataStorageService
    {
        void AddModel(QuizModel model);
        List<QuizModel> GetModels();
        int GetQuestionsCount();
        int GetRightAnswersCount();
        void ClearModels();
    }


    public class DataStorageService : IDataStorageService
    {
        private List<QuizModel> _models;
        private int QuizCount;
        private int RightAnswersCount;

        public DataStorageService()
        {
            _models = new List<QuizModel>();
            QuizCount = 0;
            RightAnswersCount = 0;
        }

        public void AddModel(QuizModel model) 
        {
            QuizModel modelCopy = new QuizModel(model);
            

            _models.Add(modelCopy);
            QuizCount++;

            if(model.Answer == model.Result) 
            { 
                RightAnswersCount++; 
            }
        }

        public List<QuizModel> GetModels()
        {
            return _models;
        }

        public int GetQuestionsCount()
        {
            return QuizCount;
        }

        public int GetRightAnswersCount()
        {
            return RightAnswersCount;
        }

        public void ClearModels() 
        {
            _models.Clear();
            QuizCount = 0;
            RightAnswersCount = 0;
        }
    }
}
