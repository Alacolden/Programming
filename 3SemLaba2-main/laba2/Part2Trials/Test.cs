using System;
using System.Collections.Generic;
using System.Linq; 
namespace laba2.Part2Trials
{
    public class Test : Trial
    {
        public List<Question> Questions { get; set; }

        public Test(double result, DateTime date, TimeSpan duration, string discipline, List<Question> questions)
            : base(result, date, duration, discipline)
        {
            Questions = questions;
        }

        public void AddQuestion(Question q)
        {
            if (Questions.Any(x => x.Text == q.Text))
                throw new ArgumentException("Такой вопрос уже существует");
            Questions.Add(q);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Trial other)
                return false;

            return Discipline == other.Discipline &&
                   Result == other.Result && Date == other.Date &&
                   Duration == other.Duration;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Discipline, Result, Date, Duration);
        }
    }
}