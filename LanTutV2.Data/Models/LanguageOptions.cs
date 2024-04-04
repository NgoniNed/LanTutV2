using System;
using System.Collections.Generic;
using LanTutorV2.Data;
using LanTutorV2.Data.Interfaces;


namespace LanTutorV2.Data.Models
{
    public class LanguageOptions  : ILanTutorItem
    {
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public ICollection<ExerciseQuestion> exerciseQuestions
        {
            get;
            set;
        }
    }
}