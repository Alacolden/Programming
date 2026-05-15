using System;
using System.Collections.Generic;
using laba2.Part1MyList;
using laba2.Part2Trials;
class Program
{
    static void Main(string[] args)
    {
       MyListTest();
       TrialsTest();
    }

    static void TrialsTest()
    {
        var questions = new List<Question>
        {
            new Question("Что такое класс?", "Описание структуры данных"),
            new Question("Что такое наследование?", "Механизм переиспользования кода")
        };

        // Создаём членов комиссии
        var commission = new List<string> { "Петров П.П.", "Иванова А.А.", "Сидоров С.С." };

        // Создаём разные типы испытаний
        Trial[] trials =
        {
            new Test(85, new DateTime(2025, 5, 20), TimeSpan.FromMinutes(60), "Информатика", questions),
            new Exam(92, new DateTime(2025, 6, 1), TimeSpan.FromHours(2), "Программирование", questions, "Иванов И.И.", "7-302"),
            new FinalExam(95, new DateTime(2025, 6, 15), TimeSpan.FromHours(3), "ООП", questions, "Петров С.С.", "5-101",
                "Кузнецов В.В.", "Система учёта испытаний", commission)
        };

        Console.WriteLine("=== Демонстрация полиморфизма ===\n");

        // Перебираем массив и вызываем методы
        foreach (var trial in trials)
        {
            Console.WriteLine(trial + "\n");   //Вызывает переопределённый ToString()
        }

        Console.WriteLine("=== Проверка Equals и GetHashCode ===\n");

        // Проверяем равенство двух объектов
        var t1 = new Exam(90, new DateTime(2025, 6, 1), TimeSpan.FromHours(2), "Программирование", questions, "Иванов И.И.", "7-302");
        var t2 = new Exam(90, new DateTime(2025, 6, 1), TimeSpan.FromHours(2), "Программирование", questions, "Иванов И.И.", "7-302");

        Console.WriteLine($"t1.Equals(t2) = {t1.Equals(t2)}");
        Console.WriteLine($"t1.GetHashCode() == t2.GetHashCode() = {t1.GetHashCode() == t2.GetHashCode()}");
    }

    static void MyListTest()
    {
        Console.WriteLine("=== ТЕСТИРОВАНИЕ КЛАССА MyList И МЕТОДОВ РАСШИРЕНИЯ ===\n");

        // Создание списков для тестирования
        MyList<int> list1 = new MyList<int>();
        list1.Add(1);
        list1.Add(2);
        list1.Add(3);

        MyList<int> list2 = new MyList<int>();
        list2.Add(4);
        list2.Add(5);

        Console.WriteLine($"list1: {list1}");
        Console.WriteLine($"list2: {list2}");

        // Тестирование перегруженных операций

        // 1. Операция + (item + list)
        Console.WriteLine("\n1. Тестирование операции + (item + list):");
        MyList<int> result1 = 0 + list1;
        Console.WriteLine($"0 + list1 = {result1}");

        // 2. Операция -- (удаление первого элемента)
        Console.WriteLine("\n2. Тестирование операции -- (--list):");
        MyList<int> result2 = --list1;
        Console.WriteLine($"--list1 = {result2}");
        Console.WriteLine($"Исходный list1 не изменился: {list1}");

        // 3. Операция != (проверка на неравенство)
        Console.WriteLine("\n3. Тестирование операции !=:");
        Console.WriteLine($"list1 != list2: {list1 != list2}");

        MyList<int> list3 = new MyList<int>();
        list3.Add(1);
        list3.Add(2);
        list3.Add(3);
        Console.WriteLine($"list1 != list3: {list1 != list3}");

        // 4. Операция * (объединение списков)
        Console.WriteLine("\n4. Тестирование операции * (объединение):");
        MyList<int> result3 = list1 * list2;
        Console.WriteLine($"list1 * list2 = {result3}");

        // Тестирование методов расширения

        Console.WriteLine("\n=== ТЕСТИРОВАНИЕ МЕТОДОВ РАСШИРЕНИЯ ===\n");

        // 1. Метод расширения для string
        Console.WriteLine("1. Метод расширения CountCapitalizedWords для string:");
        string testString = "Hello World! This is a Test String. programming in C#";
        Console.WriteLine($"Текст: \"{testString}\"");
        Console.WriteLine($"Количество слов с заглавной буквы: {testString.CountCapitalizedWords()}");

        // 2. Метод расширения для MyList<T>
        Console.WriteLine("\n2. Метод расширения HasDuplicates для MyList<T>:");

        MyList<int> uniqueList = new MyList<int>();
        uniqueList.Add(1);
        uniqueList.Add(2);
        uniqueList.Add(3);
        Console.WriteLine($"Список {uniqueList} имеет дубликаты: {uniqueList.HasDuplicates()}");

        MyList<int> duplicateList = new MyList<int>();
        duplicateList.Add(1);
        duplicateList.Add(2);
        duplicateList.Add(1);
        duplicateList.Add(3);
        Console.WriteLine($"Список {duplicateList} имеет дубликаты: {duplicateList.HasDuplicates()}");

        // Дополнительное тестирование со строками
        Console.WriteLine("\n3. Тестирование со строками:");
        MyList<string> stringList = new MyList<string>();
        stringList.Add("apple");
        stringList.Add("banana");
        stringList.Add("apple");
        Console.WriteLine($"Список {stringList} имеет дубликаты: {stringList.HasDuplicates()}");

        // Тестирование индексатора
        Console.WriteLine("\n=== ТЕСТИРОВАНИЕ ИНДЕКСАТОРА ===");
        Console.WriteLine($"list1[0] = {list1[0]}");
        Console.WriteLine($"list1[1] = {list1[1]}");

        // Тестирование перечисления
        Console.WriteLine("\n=== ТЕСТИРОВАНИЕ ПЕРЕЧИСЛЕНИЯ ===");
        Console.Write("Элементы list1: ");
        foreach (var item in list1)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();

        Console.WriteLine("\nТестирование завершено!");
    }
}