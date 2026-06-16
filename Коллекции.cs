using System;
using System.Collections;
using System.Collections.Generic;

public class SmartStack<T> : IEnumerable<T>
{
    private T[] _items;
    private int _count;

    // Конструктор по умолчанию
    public SmartStack()
    {
        _items = new T[4];
        _count = 0;
    }

    public SmartStack(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity));

        _items = new T[capacity];
        _count = 0;
    }

    public SmartStack(IEnumerable<T> collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        int size = 0;

        foreach (var item in collection)
            size++;

        _items = new T[Math.Max(size, 4)];

        foreach (var item in collection)
        {
            _items[_count++] = item;
        }
    }

    public int Count => _count;

    public int Capacity => _items.Length;

    private void EnsureCapacity(int requiredCapacity)
    {
        if (requiredCapacity <= _items.Length)
            return;

        int newCapacity = _items.Length == 0 ? 4 : _items.Length;

        while (newCapacity < requiredCapacity)
            newCapacity *= 2;

        T[] newArray = new T[newCapacity];

        for (int i = 0; i < _count; i++)
            newArray[i] = _items[i];

        _items = newArray;
    }

    public void Push(T item)
    {
        EnsureCapacity(_count + 1);
        _items[_count++] = item;
    }

    public void PushRange(IEnumerable<T> collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        int collectionCount = 0;

        foreach (var item in collection)
            collectionCount++;

        T[] temp = new T[collectionCount];

        int index = 0;
        foreach (var item in collection)
            temp[index++] = item;

        EnsureCapacity(_count + collectionCount);

        for (int i = 0; i < temp.Length; i++)
            _items[_count++] = temp[i];
    }

    public T Pop()
    {
        if (_count == 0)
            throw new InvalidOperationException("Стек пуст.");

        T value = _items[--_count];
        _items[_count] = default(T);

        return value;
    }

    public T Peek()
    {
        if (_count == 0)
            throw new InvalidOperationException("Стек пуст.");

        return _items[_count - 1];
    }

    public bool Contains(T item)
    {
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;

        for (int i = 0; i < _count; i++)
        {
            if (comparer.Equals(_items[i], item))
                return true;
        }

        return false;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _items[_count - 1 - index];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = _count - 1; i >= 0; i--)
            yield return _items[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        SmartStack<int> stack = new SmartStack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine($"Вершина: {stack.Peek()}");
        Console.WriteLine($"Количество: {stack.Count}");
        Console.WriteLine($"Ёмкость: {stack.Capacity}");

        Console.WriteLine("\nСодержимое стека:");

        foreach (var item in stack)
            Console.WriteLine(item);

        Console.WriteLine($"\nУдалён элемент: {stack.Pop()}");

        Console.WriteLine("\nПосле удаления:");

        foreach (var item in stack)
            Console.WriteLine(item);
    }
}