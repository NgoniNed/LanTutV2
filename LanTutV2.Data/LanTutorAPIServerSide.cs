using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using LanTutorV2.Data.Interfaces;
using LanTutorV2.Data.Models;

namespace LanTutorV2.Data
{
    public class LanTutorAPIServerSide : ILanTutorAPI
    {
        IDbContextFactory<LanTutDBContext> factory;

        public LanTutorAPIServerSide(IDbContextFactory<LanTutDBContext> factory)
        {
            this.factory = factory;
        }

        public async Task<ExerciseQuestion> GetExerciseQuestionAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return await context.ExerciseQuestions.Include(p=>p.Language).Include(p=>p.Difficulty).FirstOrDefaultAsync(p => p.ID == id);
        }
        public async Task<int> GetExerciseQuestionsCountAsync()
        {
            using var context = factory.CreateDbContext();
            return await context.ExerciseQuestions.CountAsync();
        }
        public async Task<List<ExerciseQuestion>> GetExerciseQuestionsAsync(int numberofQuestions, int startindex)
        {
            using var context = factory.CreateDbContext();
            return await context.ExerciseQuestions.Skip(startindex).Take(numberofQuestions).ToListAsync();
        }

        public async Task<List<ExerciseDifficulty>> GetExerciseDifficultiesAsync()
        {
            using var context = factory.CreateDbContext();
            return await context.ExerciseDifficultySet.ToListAsync();
        }

        public async Task<ExerciseDifficulty> GetExerciseDifficultyAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return await context.ExerciseDifficultySet.Include(p => p.exerciseQuestions).FirstOrDefaultAsync(c=>c.ID==id);
        }

        public async Task<LanguageOptions> GetLanguageOptionsAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return await context.LanguageOptionsSet.Include(p => p.exerciseQuestions).FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<List<LanguageOptions>> GetLanguageOptionsAsync()
        {
            using var context = factory.CreateDbContext();
            return await context.LanguageOptionsSet.ToListAsync();
        }

        private async Task DeleteItem(ILanTutorItem item)
        {
            using var context = factory.CreateDbContext();
            context.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteExerciseQuestionAsync(ExerciseQuestion item)
        {
            await DeleteItem(item);
        }

        public async Task DeleteExerciseDifficultyAsync(ExerciseDifficulty item)
        {
            await DeleteItem(item);
        }

        public async Task DeleteLanguageOptionsAsync(LanguageOptions item)
        {
            await DeleteItem(item);
        }

        public async Task<ExerciseQuestion> SaveExerciseQuestionAsync(ExerciseQuestion item)
        {
            return (await SaveItem(item)) as ExerciseQuestion;
        }

        public async Task<ExerciseDifficulty> SaveExerciseDifficultyAsync(ExerciseDifficulty item)
        {
            return (await SaveItem(item)) as ExerciseDifficulty;
        }

        public async Task<LanguageOptions> SaveLanguageOptionAsync(LanguageOptions item)
        {
            return (await SaveItem(item)) as LanguageOptions;
        }

        private async Task<ILanTutorItem> SaveItem(ILanTutorItem item)
        {
            using var context = factory.CreateDbContext();
            if (item.ID == 0)
            {
                context.Add(item);
            }
            else
            {
                if (item is ExerciseQuestion)
                {
                    var question = item as ExerciseQuestion;
                    var currentquestion = await context.ExerciseQuestions.Include(q => q.Difficulty).Include(q => q.Language).FirstOrDefaultAsync(q => q.ID == question.ID);
                    currentquestion.lExerciseQuestion = question.lExerciseQuestion;
                    currentquestion.Answer = question.Answer;

                    currentquestion.Language  = question.Language;
                    currentquestion.Difficulty = await context.ExerciseDifficultySet.FirstOrDefaultAsync(c => c.ID == question.Difficulty.ID);
                    await context.SaveChangesAsync();
                }
                else
                {
                    context.Entry(item).State = EntityState.Modified;
                }
            }
            await context.SaveChangesAsync();
            return item;
        }
    }
}