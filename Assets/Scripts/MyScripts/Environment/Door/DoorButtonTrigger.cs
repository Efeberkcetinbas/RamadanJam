using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorButtonTrigger : MonoBehaviour
{
    public int Id;


    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Player"))
            EventManager.BroadcastId(GameEvent.OnDoorOpen,Id);
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Player"))
            EventManager.BroadcastId(GameEvent.OnDoorClose,Id);
        
    }

    
}
