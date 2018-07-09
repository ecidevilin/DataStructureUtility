using System;
using System.Collections.Generic;


public class MinHeap<T> : Heap<T> where T : IComparable<T>
{
    public MinHeap() : base(func)
    {

    }
    public MinHeap(List<T> a) : base(func, a)
    {
    }

    private static bool func(T a, T b)
    {
        return a.CompareTo(b) < 0;
    }
}
