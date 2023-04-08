using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemyTrigger : Obstacable
{
    public PlayerData playerData;
    public GameData gameData;
    internal override void DoAction(PlayerTrigger player)
    {
        if(!playerData.isInvulnerable)
        {
            gameData.RemainingTime-=30;
            EventManager.Broadcast(GameEvent.OnPlayerHurt);
        }
    }
}
