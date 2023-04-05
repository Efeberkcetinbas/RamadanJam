using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemyTrigger : Obstacable
{
    public PlayerData playerData;
    internal override void DoAction(PlayerTrigger player)
    {
        if(!playerData.isInvulnerable)
        {
            Debug.Log("DAMAGE TO PLAYER");
        }
    }
}
