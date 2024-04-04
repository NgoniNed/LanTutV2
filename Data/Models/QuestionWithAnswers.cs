namespace LanTutV2.Data.Models
{

    //question object will contain question, set of 4 answer options and the correct answer
    public struct QuestionWithAnswer
    {
        public QuestionWithAnswer(string question, string[] answerOptions, string cAnswer)
        {
            this.Question = question;
            this.CorrectAnswer = cAnswer;
            this.ArrayOfAnswerOptions = answerOptions;
        }
        //variable with the question
        public string Question;
        //array of answers
        public string[] ArrayOfAnswerOptions;
        //variable with correct response
        public string CorrectAnswer;
    }
}