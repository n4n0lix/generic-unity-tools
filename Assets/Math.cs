using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GenericUnityTools
{
  class Math
  {

    public static double Map(double val, double oldMin, double oldMax, double newMin, double newMax)
    {
      double slope = (newMax - newMin) / (oldMax - oldMin);
      return newMin + slope * (val - oldMin);
    }

    public static float Map(float val, float oldMin, float oldMax, float newMin, float newMax)
    {
      float slope = (newMax - newMin) / (oldMax - oldMin);
      return newMin + slope * (val - oldMin);
    }

    public static bool IsSameSign(float x, float y)
    {
      return (x >= 0) ^ (y < 0);
    }

    public static float FastDecel(float x, float minX, float maxX)
    {
      return FallOff(Math.Map(x, minX, maxX, 0, 1));
    }

    // (x-1)^4
    public static float FallOff(float x)
    {
      // Clamp x to [0,1]
      if (x > 1) x = 1;
      else if (x < 0) x = 0;

      // (x-1)^4
      float xm1 = x - 1;          // x - 1
      float xm1_2 = xm1 * xm1;    // (x-1)²
      return xm1_2 * xm1_2;       // (x-1)^4
    }

    public static float Distance(GameObject a, GameObject b)
    {
      if (a == null || b == null) return float.NaN;

      Vector2 aPos = a.transform.position;
      Vector2 bPos = b.transform.position;

      return Vector2.Distance(aPos, bPos);
    }

    public static float NormalRandom(float mu, float sigma)
    {
      float rand1 = UnityEngine.Random.Range(0.0f, 1.0f);
      float rand2 = UnityEngine.Random.Range(0.0f, 1.0f);

      float n = Mathf.Sqrt(-2.0f * Mathf.Log(rand1)) * Mathf.Cos((2.0f * Mathf.PI) * rand2);

      return (mu + sigma * n);
    }

    public static float SineRandom()
    {
      const float _2PI = Mathf.PI * 2;
      var x = UnityEngine.Random.value * _2PI;
      return -0.5f*(Mathf.Cos(x)-1);
    }

    public static float SineRandomRange(float pMin, float pMax)
    {
      return Map(SineRandom(), 0, 1, pMin, pMax);
    }

    public static float SineRandom(float pAvg, float pVariance)
    {
      return Map(SineRandom(), 0, 1, pAvg - pVariance, pAvg + pVariance);
    }
  }
}
