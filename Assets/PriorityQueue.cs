using System;
using System.Collections.Generic;
using UnityEngine;

namespace GenericUnityTools
{
  public enum PriorityOrder
  {
    LargestFirst,
    SmallestFirst
  }

  public class PriorityQueue<T>
  {

    private List<T> list = new List<T>();
    private IComparer<T> comparer;
    private PriorityOrder order;

    public PriorityQueue(PriorityOrder pOrder, IComparer<T> pComparer)
    {
      comparer = pComparer;
      order = pOrder;
    }

    public void Enqueue(T pVal)
    {
      list.Add(pVal);
      list.Sort(comparer);

      if (order == PriorityOrder.LargestFirst)
        list.Reverse();
    }

    public T Dequeue()
    {
      if (Count == 0)
        return default;

      var result = list[0];
      list.RemoveAt(0);
      return result;
    }

    public int Count { get { return list.Count; } }
    public bool Empty { get { return Count == 0; } }
  }

}
