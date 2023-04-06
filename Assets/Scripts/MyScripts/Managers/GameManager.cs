using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    private void Start() 
    {
        InvokeRepeating("CallDice",10,10);

        Reset();
    }

    private void CallDice()
    {
        EventManager.Broadcast(GameEvent.OnCallDice);
    }

    private void Reset()
    {
        gameData.stopEnemies=false;
    }
}
