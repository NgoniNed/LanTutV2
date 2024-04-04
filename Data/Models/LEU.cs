namespace LanTutV2.Data.Models
{
    /*
    This class represents a language, Exercise and user information data structure
    */
    public class LEU
    {
        public LanguageStruct languageInfor;
        public UserStruct userInfor;
        public ExerciseStruct exerciseInfor;
        //default constructor
        public LEU()
        {
            languageInfor = new LanguageStruct();
            userInfor = new UserStruct();
            exerciseInfor = new ExerciseStruct();
        }

        public LEU(LanguageStruct llangStruct,UserStruct luserStruct,ExerciseStruct lexercStruct)
        {
            languageInfor = llangStruct;
            userInfor = luserStruct;
            exerciseInfor = lexercStruct;
        }
        
        public LEU(string currentLang, List<string> listOflangs,string userName,LanguageLevel langLevel,string timeSpent,ExerciseCategoryEnum exercCat,LanguageLevel exerciseDiff)
        {
            languageInfor = new LanguageStruct();
            SetLanguageInformation(currentLang,listOflangs);
            userInfor = new UserStruct();
            SetUserInformation(userName,langLevel,timeSpent);
            exerciseInfor = new ExerciseStruct();
            SetExerciseInformation(currentLang,exercCat,exerciseDiff);
        }
        

        public void SetLanguageInformation(string currentLang, List<string> listOflangs)
        {
            languageInfor.CurrentLanguage = currentLang;
            languageInfor.LanguageList = listOflangs;
        }
        
        public LanguageStruct GetLanguageInformation()
        {
            return languageInfor;
        }
        
        public void SetUserInformation(string userName,LanguageLevel langLevel,string timeSpent)
        {
            userInfor.UserName=userName;
            userInfor.Level=langLevel;
            userInfor.TimeSpent=timeSpent;
        }
        
        public UserStruct GetUserInformation()
        {
            return userInfor;
        }
        
        public void SetExerciseInformation(string langName,ExerciseCategoryEnum exercCat,LanguageLevel exerciseDiff)
        {
            exerciseInfor.LanguageName = langName;
            exerciseInfor.ExerciseCategory = exercCat;
            exerciseInfor.ExerciseDifficulty = exerciseDiff;
        }

        public ExerciseStruct GetExerciseInformation()
        {
            return exerciseInfor;
        }
    }
}