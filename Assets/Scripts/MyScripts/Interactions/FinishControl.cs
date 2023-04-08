using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishControl : Obstacable
{
    internal override void DoAction(PlayerTrigger player)
    {
        EventManager.Broadcast(GameEvent.OnSuccess);
    }
}
