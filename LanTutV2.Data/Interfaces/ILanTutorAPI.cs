using System.Collections.Generic;
using System.Threading.Tasks;
using LanTutorV2.Data.Models;

namespace LanTutorV2.Data.Interfaces
{
    public interface ILanTutorAPI
    {
        Task<int> GetExerciseQuestionsCountAsync();
        Task<List<ExerciseQuestion>> GetExerciseQuestionsAsync(int numberofQuestions, int startindex);
        Task<List<ExerciseDifficulty>> GetExerciseDifficultiesAsync();
        Task<List<LanguageOptions>> GetLanguageOptionsAsync();

        Task<ExerciseQuestion> GetExerciseQuestionAsync(int id);
        Task<ExerciseDifficulty> GetExerciseDifficultyAsync(int id);
        Task<LanguageOptions> GetLanguageOptionsAsync(int id);

        Task<ExerciseQuestion> SaveExerciseQuestionAsync(ExerciseQuestion item);
        Task<ExerciseDifficulty> SaveExerciseDifficultyAsync(ExerciseDifficulty item);
        Task<LanguageOptions> SaveLanguageOptionAsync(LanguageOptions item);

        Task DeleteExerciseQuestionAsync(ExerciseQuestion item);
        Task DeleteExerciseDifficultyAsync(ExerciseDifficulty item);
        Task DeleteLanguageOptionsAsync(LanguageOptions item);

    }
}