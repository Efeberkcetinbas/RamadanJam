using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorButtonControl : MonoBehaviour
{
    private void OnEnable() 
    {
        EventManager.AddIdHandler(GameEvent.OnDoorOpen,OpenDoorButton);
        EventManager.AddIdHandler(GameEvent.OnDoorClose,CloseDoorButton);
    }

    private void OnDisable() 
    {
        EventManager.RemoveIdHandler(GameEvent.OnDoorOpen,OpenDoorButton);
        EventManager.RemoveIdHandler(GameEvent.OnDoorClose,CloseDoorButton);
    }

    internal virtual void OpenDoorButton(int id)
    {
        throw new System.NotImplementedException();
    }

    internal virtual void CloseDoorButton(int id)
    {
        throw new System.NotImplementedException();
    }
}
