using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Основной класс списка
public class MyList<T> : IEnumerable<T>
{
    private List<T> items;

    // Конструкторы
    public MyList()
    {
        items = new List<T>();
    }

    public MyList(IEnumerable<T> collection)
    {
        items = new List<T>(collection);
    }

    public MyList(int capacity)
    {
        items = new List<T>(capacity);
    }

    // Методы для работы со списком
    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public void RemoveAt(int index)
    {
        items.RemoveAt(index);
    }

    public void Clear()
    {
        items.Clear();
    }

    public bool Contains(T item)
    {
        return items.Contains(item);
    }

    public int Count => items.Count;

    // Индексатор
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= items.Count)
                throw new IndexOutOfRangeException();
            return items[index];
        }
        set
        {
            if (index < 0 || index >= items.Count)
                throw new IndexOutOfRangeException();
            items[index] = value;
        }
    }

    // Перегруженные операции

    
    public static MyList<T> operator +(T item, MyList<T> list)
    {
        MyList<T> result = new MyList<T>();
        result.items.Add(item);
        result.items.AddRange(list.items);
        return result;
    }

    public static MyList<T> operator --(MyList<T> list)
    {
        if (list.items.Count > 0)
        {
            MyList<T> result = new MyList<T>(list.items);
            result.items.RemoveAt(0);
            return result;
        }
        return new MyList<T>(list.items);
    }

    // != - проверка на неравенство
    public static bool operator !=(MyList<T> list1, MyList<T> list2)
    {
        return !(list1 == list2);
    }

    // == - проверка на равенство (необходим для !=)
    public static bool operator ==(MyList<T> list1, MyList<T> list2)
    {
        if (ReferenceEquals(list1, list2))
            return true;
        if (list1 is null || list2 is null)
            return false;

        return list1.items.SequenceEqual(list2.items);
    }

    // * - объединение двух списков
    public static MyList<T> operator *(MyList<T> list1, MyList<T> list2)
    {
        MyList<T> result = new MyList<T>(list1.items);
        result.items.AddRange(list2.items);
        return result;
    }

    // Переопределение Equals и GetHashCode для корректной работы операторов == и !=
    public override bool Equals(object obj)
    {
        if (obj is MyList<T> other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return items?.GetHashCode() ?? 0;
    }

    // Реализация интерфейса IEnumerable для поддержки foreach
    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Метод для вывода содержимого списка
    public override string ToString()
    {
        return $"[{string.Join(", ", items)}]";
    }
}