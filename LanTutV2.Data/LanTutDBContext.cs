using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using LanTutorV2.Data.Models;

namespace LanTutorV2.Data
{
    public class LanTutDBContext : DbContext
    {
        public LanTutDBContext(DbContextOptions <LanTutDBContext> context) : base(context)
        {

        }

        public DbSet<ExerciseQuestion> ExerciseQuestions
        {
            get;
            set;
        }

        public DbSet<ExerciseDifficulty> ExerciseDifficultySet
        {
            get;
            set;
        }

        public DbSet<LanguageOptions> LanguageOptionsSet
        {
            get;
            set;
        }
    }

    public class LanTutorDbContextFoctory : IDesignTimeDbContextFactory<LanTutDBContext>
    {
        public LanTutDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LanTutDBContext>();
            
            optionsBuilder.UseSqlite("Data Source = test.db");
            return new LanTutDBContext(optionsBuilder.Options);
        }
    }
}