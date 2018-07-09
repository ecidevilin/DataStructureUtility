using System;
using System.Collections.Generic;


public class MaxHeap<T> where T : IComparable<T>
{
    private List<T> _A;
    public MaxHeap()
    {
        _A = new List<T>();
    }

    public MaxHeap(List<T> a)
    {
        BuildMaxHeap(a);
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

    public void MaxHeapify(int i)
    {
        int l = Left(i);
        int r = Right(i);
        int max = i;
        int size = _A.Count;
        if (l < size && _A[l].CompareTo(_A[i]) > 0)
        {
            max = l;
        }
        if (r < size && _A[r].CompareTo(_A[max]) > 0)
        {
            max = r;
        }
        if (max != i)
        {
            Swap(i, max);
            MaxHeapify(max);
        }
    }

    public void Swap(int i, int j)
    {
        T t = _A[i];
        _A[i] = _A[j];
        _A[j] = t;
    }

    public void BuildMaxHeap(List<T> a)
    {
        _A = a;
        for (int i = a.Count / 2; i >= 0; i--)
        {
            MaxHeapify(i);
        }
    }

    public T HeapMaximun()
    {
        return _A[0];
    }

    public int Size()
    {
        return _A.Count;
    }

    public T HeapExtractMax()
    {
        if (_A.Count == 0)
        {
            throw new Exception("Heap underflow");
        }
        T max = _A[0];
        int last = _A.Count - 1;
        _A[0] = _A[last];
        _A.RemoveAt(last);
        MaxHeapify(0);
        return max;
    }

    public void HeapIncreaseKey(int i, T key)
    {
        if (key.CompareTo(_A[i]) < 0)
        {
            throw new Exception("New key is smaller than current key");
        }
        _A[i] = key;
        int p = Parent(i);
        while (i > 0 && _A[p].CompareTo(_A[i]) < 0)
        {
            Swap(i, p);
            i = p;
            p = Parent(i);
        }
    }

    public void HeapInsert(T key)
    {
        _A.Add(key);
        HeapIncreaseKey(_A.Count - 1, key);
    }
}
