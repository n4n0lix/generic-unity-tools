//using Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public static class Extensions
{

  #region GameObject
  public static bool HasComponent<T>(this GameObject a) where T : Component
  {
    return a.GetComponent<T>() != null;
  }

  public static bool HasComponent<T>(this MonoBehaviour a) where T : Component
  {
    return a.gameObject.HasComponent<T>();
  }

  public static T GetOrAddComponent<T>(this GameObject a) where T : Component
  {
    var component = a.GetComponent<T>();
    if (component == null)
      return a.AddComponent<T>();

    return component;
  }

  public static T GetOrAddComponent<T>(this MonoBehaviour a) where T : Component
  {
    return a.gameObject.GetOrAddComponent<T>();
  }

  public static void DoNextFrame(this MonoBehaviour a, Action pAction)
  {
    a.StartCoroutine(_DoNextFrame(pAction));
  }

  private static IEnumerator _DoNextFrame(Action pAction)
  {
    yield return 0;
    pAction?.Invoke();
  }
  #endregion

  #region Transform
  public static void DestroyAllChildren(this Transform t)
  {
    for (int i = 0; i < t.childCount; i++)
      MonoBehaviour.Destroy(t.GetChild(i).gameObject);
  }
  #endregion

  #region Queue
  public static void EnqueueAll<T>(this Queue<T> pSelf, IEnumerable<T> pRange)
  {
    foreach (T t in pRange)
      pSelf.Enqueue(t);
  }
  #endregion
}
