using System;
using System.Collections.Generic;


public class MinHeap<T> where T : IComparable<T>
{
    private List<T> _A;
    public MinHeap()
    {
        _A = new List<T>();
    }

    public MinHeap(List<T> a)
    {
        BuildMinHeap(a);
    } 
    public static int Parent(int idx)
    {
        return (idx - 1) / 2;
    }

    public static int Left(int idx)
    {
        return 2 * idx + 1;
    }

    public static int Right(int idx)
    {
        return 2 * idx + 2;
    }

    public void MinHeapify(int i)
    {
        int l = Left(i);
        int r = Right(i);
        int min = i;
        int size = _A.Count;
        if (l < size && _A[l].CompareTo(_A[i]) < 0)
        {
            min = l;
        }
        if (r < size && _A[r].CompareTo(_A[min]) < 0)
        {
            min = r;
        }
        if (min != i)
        {
            Swap(i, min);
            MinHeapify(min);
        }
    }

    public void Swap(int i, int j)
    {
        T t = _A[i];
        _A[i] = _A[j];
        _A[j] = t;
    }

    public void BuildMinHeap(List<T> a)
    {
        _A = a;
        for (int i = a.Count / 2; i >= 0; i--)
        {
            MinHeapify(i);
        }
    }

    public T HeapMinimun()
    {
        return _A[0];
    }

    public int Size()
    {
        return _A.Count;
    }

    public T HeapExtractMin()
    {
        if (_A.Count == 0)
        {
            throw new Exception("Heap underflow");
        }
        T min = _A[0];
        int last = _A.Count - 1;
        _A[0] = _A[last];
        _A.RemoveAt(last);
        MinHeapify(0);
        return min;
    }

    public void HeapDecreaseKey(int i, T key)
    {
        if (key.CompareTo(_A[i]) > 0)
        {
            throw new Exception("New key is larger than current key");
        }
        _A[i] = key;
        int p = Parent(i);
        while (i > 0 && _A[p].CompareTo(_A[i]) > 0)
        {
            Swap(i, p);
            i = p;
            p = Parent(i);
        }
    }

    public void HeapInsert(T key)
    {
        _A.Add(key);
        HeapDecreaseKey(_A.Count - 1, key);
    }
}
