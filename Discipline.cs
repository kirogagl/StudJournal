using System;

namespace StudJournal
{
    [Serializable]
    public class Discipline
    {
        private string name;
        private string teacher;
        private DayOfWeek dayWeek;
        private int lesson;
        public Discipline(string name, string teacher, DayOfWeek dayWeek, int lesson){
            this.name = name;
            this.teacher = teacher;
            this.dayWeek = dayWeek;
            this.lesson = lesson;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                this.teacher = value;
            }
        }
        public DayOfWeek DayWeek
        {
            get
            {
                return this.dayWeek;
            }
            set
            {
                this.dayWeek = value;
            }
        }
        public int Lesson
        {
            get
            {
                return this.lesson;
            }
            set
            {
                this.lesson = value;
            }
        }

        public override string ToString()
        {
            return name + " \n" + teacher;
        }
    }

}
