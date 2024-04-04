using System;
using System.Collections.Generic;
using LanTutorV2.Data.Models;
using LanTutorV2.Data.Interfaces;

namespace LanTutorV2.Data.Models
{
    public class ExerciseQuestion : ILanTutorItem
    {
        public int ID
        {
            get;
            set;
        }

        public string lExerciseQuestion
        {
            get;
            set;
        }

        public string Answer
        {
            get;
            set;
        }

        public LanguageOptions Language
        {
            get;
            set;
        }

        public ExerciseDifficulty Difficulty
        {
            get;
            set;
        }
    }
}