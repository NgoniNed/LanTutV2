using LanTutV2.Data.Models;
using Microsoft.AspNetCore.Hosting;

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

        private IWebHostEnvironment _hostEnvironment;
        public LanTutSessionService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<Exercise> GetSessionExerciseAsync()
        {
            var sessionLEU = await GetSessionLEUAsync();

            var questions = await GetQuestionsByCriteriaAsync(null, null, null, sessionLEU.GetLanguageInformation().CurrentLanguage, 5);
            return new Exercise(questions);
        }

        public async Task<Exercise> GetSessionExerciseAsync(string _language)
        {
            var sessionLEU = await GetSessionLEUAsync();

            var questions = await GetQuestionsByCriteriaAsync(null, null, null, _language, 5);
            return new Exercise(questions);
        }

        public async Task<List<QuestionData>> GetQuestionsByCriteriaAsync(string? category, string? relation, string? difficulty, string? language, int batchSize)
        {
            QuestionDataHandler _QDH = new QuestionDataHandler();
            _QDH.ReadDataFromCSV(Path.Combine(_hostEnvironment.ContentRootPath, "Data//QuestionBank.csv"));
            var questions = _QDH.GetQuestionsByCriteria(category, relation, difficulty, language, batchSize);
            
            return questions;
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