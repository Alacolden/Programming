using System;
using System.Collections.Generic;
using System.Linq; 
namespace laba2.Part2Trials
{

    public sealed class FinalExam : Exam
    {
        string _chairperson;
        string _thesisTopic;
        public List<string> CommissionMembers { get; set; }

        public string Chairperson
        {
            get => _chairperson;
            set => _chairperson = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string ThesisTopic
        {
            get => _thesisTopic;
            set => _thesisTopic = value ?? throw new ArgumentNullException(nameof(value));
        }

        public FinalExam(double result, DateTime date, TimeSpan duration, string discipline,
            List<Question> questions, string professor, string audience,
            string chairperson, string thesisTopic, List<string> commissionMembers)
            : base(result, date, duration, discipline, questions, professor, audience)
        {
            Chairperson = chairperson;
            ThesisTopic = thesisTopic;
            CommissionMembers = commissionMembers;
        }

        public override string ToString()
        {
            return base.ToString() + $", тема выпускной работы: {ThesisTopic}, " +
                   $"председатель комиссии: {Chairperson}";
        }
    }
}