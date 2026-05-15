using System;
using System.Collections.Generic;
using System.Linq; 
namespace laba2.Part2Trials
{
    public class Exam : Test
    {
        string _professor;
        string _audience;

        public string Professor
        {
            get => _professor;
            set => _professor = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Audience
        {
            get => _audience;
            set
            {
                if (value.Length > 10)
                    throw new ArgumentException("Слишком длинное название аудитории");
                _audience = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public Exam(double result, DateTime date, TimeSpan duration, string discipline,
            List<Question> questions, string professor, string audience)
            : base(result, date, duration, discipline, questions)
        {
            Professor = professor;
            Audience = audience;
        }

        public override string ToString()
        {
            return base.ToString() + $", преподаватель: {Professor}, аудитория: {Audience}";
        }
    }
}