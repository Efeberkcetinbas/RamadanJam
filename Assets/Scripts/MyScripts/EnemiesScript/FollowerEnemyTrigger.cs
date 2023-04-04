using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemyTrigger : Obstacable
{
    internal override void DoAction(PlayerTrigger player)
    {
        Debug.Log("ATTACK PLAYER");
    }
}
