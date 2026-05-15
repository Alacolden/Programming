using System;
using System.Collections.Generic;
using System.Linq; 
namespace laba2.Part1MyList
{

    // Статический класс с методами расширения
    public static class ExtensionMethods
    {
        // Метод расширения для string: подсчет количества слов с заглавной буквы
        public static int CountCapitalizedWords(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?' },
                StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word) && char.IsUpper(word[0]))
                    count++;
            }
            return count;
        }

        // Метод расширения для MyList<T>: проверка на повторяющиеся элементы
        public static bool HasDuplicates<T>(this MyList<T> list)
        {
            if (list == null || list.Count == 0)
                return false;

            HashSet<T> seen = new HashSet<T>();
            foreach (T item in list)
            {
                if (!seen.Add(item))
                    return true;
            }
            return false;
        }
    }
}