namespace LanTutV2.Data.Models
{
    public class QuestionData
    {
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectAnswer { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public string Difficulty { get; set; }
        public string Relation { get; set; }

        // Constructor
        public QuestionData(string question, string optionA, string optionB, string optionC, string optionD, string correctAnswer, string language, string category, string difficulty, string relation)
        {
            Question = question;
            OptionA = optionA;
            OptionB = optionB;
            OptionC = optionC;
            OptionD = optionD;
            CorrectAnswer = correctAnswer;
            Language = language;
            Category = category;
            Difficulty = difficulty;
            Relation = relation;
        }
        
        // Method to display the question and options
        public void DisplayQuestionWithOptions()
        {
            Console.WriteLine("Question: " + Question);
            Console.WriteLine("A) " + OptionA);
            Console.WriteLine("B) " + OptionB);
            Console.WriteLine("C) " + OptionC);
            Console.WriteLine("D) " + OptionD);
        }
    }
   
}