using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProxyCollider : MonoBehaviour
{
  [Serializable]
  public class Trigger2DEvent : UnityEvent<Collider2D> { }

  [Serializable]
  public class Collision2DEvent : UnityEvent<Collision2D> { }

  public Trigger2DEvent triggerEnter2D;
  private void OnTriggerEnter2D(Collider2D pCollider)
  {
    if (triggerEnter2D != null)
      triggerEnter2D.Invoke(pCollider);
  }

  public Trigger2DEvent triggerStay2D;
  private void OnTriggerStay2D(Collider2D pCollider)
  {
    if (triggerStay2D != null)
      triggerStay2D.Invoke(pCollider);
  }

  public Trigger2DEvent triggerExit2D;
  private void OnTriggerExit2D(Collider2D pCollider)
  {
    if (triggerExit2D != null)
      triggerExit2D.Invoke(pCollider);
  }

  public Collision2DEvent collisionEnter2D;
  private void OnCollisionEnter2D(Collision2D pCollision)
  {
    if (collisionEnter2D != null)
      collisionEnter2D.Invoke(pCollision);
  }

  public Collision2DEvent collisionStay2D;
  private void OnCollisionStay2D(Collision2D pCollision)
  {
    if (collisionStay2D != null)
      collisionStay2D.Invoke(pCollision);
  }

  public Collision2DEvent collisionExit2D;
  private void OnCollisionExit2D(Collision2D pCollision)
  {
    if (collisionExit2D != null)
      collisionExit2D.Invoke(pCollision);
  }
}
