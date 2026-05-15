using System;
using System.Collections.Generic;
using System.Linq; 
namespace laba2.Part2Trials

{

    public abstract class Trial
    {
        double _result;
        TimeSpan _duration;
        string _discipline;
        public DateTime Date { get; set; }

        public double Result
        {
            get => _result;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Результат прохождения испытания должен быть неотрицательным числом");
                _result = value;
            }
        }

        public TimeSpan Duration
        {
            get => _duration;
            set
            {
                if (value < TimeSpan.Zero)
                    throw new ArgumentException("Продолжительность не может быть отрицательной");
                _duration = value;
            }
        }

        public string Discipline
        {
            get => _discipline;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название дисциплины не может быть пустым");
                _discipline = value;
            }
        }

        public Trial(double result, DateTime date, TimeSpan duration, string discipline)
        {
            Result = result;
            Date = date;
            Duration = duration;
            Discipline = discipline;
        }

        public override string ToString()
        {
            return $"Дисциплина: {Discipline}, результат: {Result}, дата: {Date}, отведенное время: {Duration}";
        }
    }
}