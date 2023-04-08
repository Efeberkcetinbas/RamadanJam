using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Game Data",menuName ="Data/Game Data",order =0)]
public class GameData : ScriptableObject
{
    public float RemainingTime;
    public bool timerIsRunning=false;
    public bool stopEnemies=false;
    public int startBuffTime,repeatBuffTime;
    public int StarNumber=0;
}
