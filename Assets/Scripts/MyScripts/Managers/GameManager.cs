using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start() 
    {
        InvokeRepeating("CallDice",10,10);
    }

    private void CallDice()
    {
        EventManager.Broadcast(GameEvent.OnCallDice);
    }
}
