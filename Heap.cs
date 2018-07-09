using System;
using System.Collections.Generic;

public abstract class Heap<T> where T : IComparable<T>
{
    protected List<T> _A;

    public delegate bool Compare<T>(T a, T b);

    protected Compare<T> _compareFunc;

    public Heap(Compare<T> _func)
    {
        _compareFunc = _func;
        _A = new List<T>();
    }

    public Heap(Compare<T> _func, List<T> a)
    {
        _compareFunc = _func;
        Build(a);
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
    public void Swap(int i, int j)
    {
        T t = _A[i];
        _A[i] = _A[j];
        _A[j] = t;
    }

    public int Size()
    {
        return _A.Count;
    }

    public T Top()
    {
        return _A[0];
    }

    public virtual T ExtractTop()
    {
        if (_A.Count == 0)
        {
            throw new Exception("Heap underflow");
        }
        T top = _A[0];
        int last = _A.Count - 1;
        _A[0] = _A[last];
        _A.RemoveAt(last);
        Heapify(0);
        return top;
    }

    public virtual void Insert(T val)
    {

        _A.Add(val);
        ModifyValue(_A.Count - 1, val);
    }

    public virtual void Build(List<T> a)
    {
        _A = a;
        for (int i = a.Count / 2; i >= 0; i--)
        {
            Heapify(i);
        }
    }

    public virtual void Heapify(int i)
    {
        int l = Left(i);
        int r = Right(i);
        int m = i;
        int size = _A.Count;
        if (l < size && _compareFunc(_A[l], _A[i]))
        {
            m = l;
        }
        if (r < size && _compareFunc(_A[r], _A[m]))
        {
            m = r;
        }
        if (m != i)
        {
            Swap(i, m);
            Heapify(m);
        }
    }

    public virtual void ModifyValue(int i, T val)
    {
        if (_compareFunc(_A[i], val))
        {
            _A[i] = val;
            Heapify(i);
            return;
        }
        _A[i] = val;
        int p = Parent(i);
        while (i > 0 && _compareFunc(_A[i], _A[p]))
        {
            Swap(i, p);
            i = p;
            p = Parent(i);
        }
    }
}
