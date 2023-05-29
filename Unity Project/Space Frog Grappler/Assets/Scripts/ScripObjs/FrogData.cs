using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FrogData : ScriptableObject
{
   public float tongueSpeedOut;
   public float tongueSpeedIn;
   public float pullSpeed;
   public float clampSpeed;
   public float tongueMax;
   public float bouncy;

   public Sprite frogIdle;
   public Sprite frogStretch;
   public Sprite frogTank;
}
