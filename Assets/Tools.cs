using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheValiantFox
{
  public class Tools
  {

    public static bool RaycastAllForFirstComponent<T>(Ray pRay, out RaycastHit pHit, out T pComponent, float pDistance = Mathf.Infinity, int pLayerMask=int.MaxValue) where T : Component
    {
      foreach (var aHit in Physics.RaycastAll(pRay, pDistance, pLayerMask))
      {
        var comp = aHit.transform.gameObject.GetComponent<T>();
        if (comp != null)
        {
          pComponent = comp;
          pHit = aHit;
          return true;
        }
      }

      pHit = new RaycastHit();
      pComponent = null;
      return false;
    }

    public static Canvas FindRootCanvas(RectTransform pTrans)
    {
      Canvas result = null;
      Canvas next = null;
      Transform cur = pTrans;

      while (cur.parent != null && (next = cur.parent.GetComponentInParent<Canvas>()) != null)
      {
        result = next;
        cur = next.transform;
      }

      return result;
    }

    public static Rect GetUiRect(RectTransform pTrans)
    {
      var canvas = FindRootCanvas(pTrans);
      Rect contRect = pTrans.rect;
      contRect.position = pTrans.position / canvas.scaleFactor;
      return contRect;
    }

    //public static bool FindNearestWithComponent<T>(Vector2 pPivot, CircleCollider2D pCircle, out T outComponent, int pLayerMask = int.MaxValue) where T : Component
    //{
    //  float curDistance = float.MaxValue;
    //  T curComponent = null;

    //  foreach (var aHit in Physics2D.OverlapCircleAll((Vector2)pCircle.transform.position + pCircle.offset, pCircle.radius, pLayerMask))
    //  {
    //    var comp = aHit.transform.gameObject.GetComponent<T>();
    //    if (comp == null) continue;

    //    float distance = Vector2.Distance()
    //    {
    //      pComponent = comp;
    //      pHit = aHit;
    //      return true;
    //    }
    //  }
    //}

    public static float GetClipLength(Animator pAnimator, string pClipName)
    {
      if (pAnimator == null) return 0;
      if (pAnimator.runtimeAnimatorController == null) return 0;

      foreach (var clip in pAnimator.runtimeAnimatorController.animationClips)
      {
        if (clip.name == pClipName)
          return clip.length;
      }

      return 0;
    }

    public static IEnumerator NextFrame(Action pAction)
    {
      yield return 0;
      pAction?.Invoke();
    }
  }
}
