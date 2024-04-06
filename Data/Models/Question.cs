namespace LanTutV2.Data.Models
{
    // Represents a question with options and answer checking functionality
    public class Question
    {
        public int QID { get; private set; }
        public string QuestionText { get; private set; }
        public string[] Options { get; private set; }
        private string CorrectAnswer { get; }

        private double TimeSpent = 0;
        private int Attempts = 0;
        private int FailedAttempts = 0;
        private int CorrectAttempts = 0;
        private bool IsCorrect = false;

        public Question(int qid, string questionText, string[] options, string correctAnswer, int attempts, int failedAttempts, int correctAttempts)
        {
            QID = qid;
            QuestionText = questionText;
            Options = options;
            CorrectAnswer = correctAnswer;
            Attempts = attempts;
            FailedAttempts = failedAttempts;
            CorrectAttempts = correctAttempts;
        }

        public void UpdateTimeSpent(double startTime, double endTime)
        {
            TimeSpent = Math.Abs(endTime - startTime);
        }

        public void CheckAnswer(string userResponse)
        {
            if (Options.Contains(userResponse))
            {
                IsCorrect = CorrectAnswer == userResponse;
            }
        }

        public int GetAttempts => Attempts;

        public int GetCorrectAttempts => CorrectAttempts;

        public int GetFailedAttempts => FailedAttempts;

        public static Question ConvertFromQuestionData(QuestionData questionData)
        {
            string[] options = { questionData.OptionA, questionData.OptionB, questionData.OptionC, questionData.OptionD };
            return new Question(0, questionData.Question, options, questionData.CorrectAnswer, 0, 0, 0);
        }
    }
}
