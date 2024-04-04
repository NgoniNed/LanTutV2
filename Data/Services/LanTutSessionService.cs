using LanTutV2.Data.Models;
namespace LanTutV2.Data.Services
{
    //service for the tutoring and profile session which retrieves
    //information from the database
    //service is preserved while the app is live
    // when app is terminated service should preserve all
    // session and store information within the database
    public class LanTutSessionService
    {
        public Task<LEU> GetSessionLEUAsync()
        {
            return Task.FromResult(new LEU("Russian",new List<string>(){"Arabic","Dutch","French","Russian"},"R232858E",LanguageLevel.Amateur,"900 min",ExerciseCategoryEnum.Culture,LanguageLevel.Intermediate));
        }
        public Task<Exercise> GetSessionExerciseAsync()
        {
            return Task.FromResult(new Exercise(GetQuestionBank()));
        }
        //method that requests a question bank object from the database
        private List<Question> GetQuestionBank()
        {
            List<Question> _QuestionBank = new List<Question>();
            _QuestionBank.Add(new Question(1,"How do you say  please  in Russian?",new string[] {"Пожалуйста","Спасибо","Да","Нет"},"Пожалуйста",0,0,0));
            _QuestionBank.Add(new Question(2,"What is the Russian word for  water ?",new string[] {"Чай","Молоко","Вода","Сок"},"Вода",0,0,0));
            _QuestionBank.Add(new Question(3,"Translate  table  into Russian.",new string[] {"Стол","Стул","Кровать","Книга"},"Стол",0,0,0));
            _QuestionBank.Add(new Question(4,"What does  спасибо  mean in English?",new string[] {"Goodbye","Hello","Thank you","Please"},"Thank you",0,0,0));
            _QuestionBank.Add(new Question(5,"How would you say  excuse me  in Russian?",new string[] {"Извините","Привет","Пожалуйста","Да"},"Извините",0,0,0));
            _QuestionBank.Add(new Question(6,"Translate  today  into Russian.",new string[] {"Завтра","Вчера","Сегодня","Зима"},"Сегодня",0,0,0));
            //request from db api exercisequestion
            return _QuestionBank;
        }
        public void GetSessionProfileAsync()
        {
            
        }
        public void StoreSessionLEUAsync()
        {

        }
        public void StoreSessionExerciseAsync()
        {
            
        }
        public void StoreSessionProfileAsync()
        {
            
        }
    }
}