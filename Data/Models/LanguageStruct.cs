namespace LanTutV2.Data.Models
{
    public struct LanguageStruct
    {
        public List<string> LanguageList
        {
            get;
            set;
        }
        public string CurrentLanguage
        {
            get;
            set;
        }
    }

    public struct UserStruct
    {
        public string UserName
        {
            get;
            set;
        }

        public LanguageLevel Level
        {
            get;
            set;
        }

        public string TimeSpent
        {
            get;
            set;
        }
    }
    public struct ExerciseStruct
    {
        public string LanguageName
        {
            get;
            set;
        }

        public ExerciseCategoryEnum ExerciseCategory
        {
            get;
            set;
        }

        public LanguageLevel ExerciseDifficulty
        {
            get;
            set;
        }
    }
    public enum ExerciseCategoryEnum
    {
        Food,
        Social,
        Religion,
        Culture,
        Politics,
        Technology
    }
    public enum LanguageLevel
    {
        Amateur,
        Beginner,
        Intermediate,
        Advanced,
        Expert,
        Translator
    }
}