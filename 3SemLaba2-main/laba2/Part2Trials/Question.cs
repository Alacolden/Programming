using System;
using System.Collections.Generic;
using System.Linq; 
namespace laba2.Part2Trials
{



public class Question
{
    string _text;
    string _answer;

    public string Text
    {
        get => _text;
        set => _text = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Answer
    {
        get => _answer;
        set => _answer = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Question(string text, string answer)
    {
        Text = text;
        Answer = answer;
    }

    public override string ToString()
    {
        return $"Вопрос: {_text}\n ответ: {_answer}";
    }
}
}