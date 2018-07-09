using System;
using System.Collections.Generic;


public class MaxHeap<T> : Heap<T> where T : IComparable<T>
{
    public MaxHeap() : base(func)
    {

    }
    public MaxHeap(List<T> a) : base(func, a)
    {
    }

    private static bool func(T a, T b)
    {
        return a.CompareTo(b) > 0;
    }
}
