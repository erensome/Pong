using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wall : Powerup
{
   private BallManager BM;
   private ZoneBehaviour PlayerZoneColl;
   private ZoneBehaviour EnemyZoneColl;

   private void Start()
   {
      BM = GameObject.Find("Ball").GetComponent<BallManager>();
      PlayerZoneColl = GameObject.Find("Player Dead Zone").GetComponent<ZoneBehaviour>();
      EnemyZoneColl = GameObject.Find("Enemy Dead Zone").GetComponent<ZoneBehaviour>();
   }

   public override void Play()
   {
      // Last hit boolean will be false by default(first time)
      bool lastHit = BM.GetLastHit();

      // True means Player paddle hit, Otherwise enemy paddle.
      if (lastHit)
      {
         PlayerZoneColl.ActivateWall();
      }
      else if (!lastHit)
      {
         EnemyZoneColl.ActivateWall();
      }
   }

   public override void DestroyThis()
   {
      Destroy(gameObject);
   }
}
