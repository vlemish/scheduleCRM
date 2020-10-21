using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Models
{
    class LessonTime
    {
        public static readonly LessonTime FirstLesson = new LessonTime("8:45");
        public static readonly LessonTime SecondLesson = new LessonTime("10:30");
        public static readonly LessonTime ThirdLesson = new LessonTime("12:30");
        public static readonly LessonTime FourthLesson = new LessonTime("14:15");

        public LessonTime(string value)
        {
            Value = value;
        }

        public LessonTime()
        {

        }

        public string Value { get; private set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
