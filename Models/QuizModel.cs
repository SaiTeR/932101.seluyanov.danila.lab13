namespace Lab13.Models
{
    public class QuizModel
    {
        public int A { get; set; }
        public int B { get; set; }

        public string Operation { get; set; }
        public double Result { get; set; }
        public double Answer { get; set; }

        public QuizModel() { }
        public QuizModel(QuizModel original)
        {
            A = original.A;
            B = original.B;
            Operation = original.Operation;
            Result = original.Result;
            Answer = original.Answer;
        }
    }




}
