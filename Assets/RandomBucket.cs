using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBucket<T>
{

  [Serializable]
  public struct Option
  {
    public int tickets;
    public T   option;
  }

  private int             totalTickets;
  private List<Option> options = new List<Option>();

  public void AddOption(T pOption, int pTickets)
  {
    AddOption(new Option { option = pOption, tickets = pTickets });
  }

  public void AddOption(Option pOption)
  {
    totalTickets += pOption.tickets;
    options.Add(pOption);
  }

  public T Draw()
  {
    if (options.Count == 0 || totalTickets == 0) return default;

    int ticket = UnityEngine.Random.Range(0, totalTickets);
    for(int i = 0; i < options.Count;i++)
    {
      var option = options[i];
      ticket -= option.tickets;
      if (ticket < 0)
      {
        totalTickets--;
        option.tickets--;
        return option.option;
      }
    }

    Debug.LogError("Something went wrong with ticket drawing. Check if `if (ticket < 0)` actually works.");
    return default;
  }

  public void Clear()
  {
    totalTickets = 0;
    options.Clear();
  }

}
