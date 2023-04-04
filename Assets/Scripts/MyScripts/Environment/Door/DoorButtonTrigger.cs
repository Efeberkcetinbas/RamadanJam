using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorButtonTrigger : Obstacable
{
    public int Id;

    public DoorButtonTrigger()
    {
        canDamageToPlayer=false;
    }

    internal override void DoAction(PlayerTrigger player)
    {
        EventManager.BroadcastId(GameEvent.OnDoorOpen,Id);
    }

    internal override void InteractionExit(PlayerTrigger player)
    {
        EventManager.BroadcastId(GameEvent.OnDoorClose,Id);
    }

    
}
