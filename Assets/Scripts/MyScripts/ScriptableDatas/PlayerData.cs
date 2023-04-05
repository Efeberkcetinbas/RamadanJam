using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Player Data",menuName ="Data/Player Data",order =2)]
public class PlayerData : ScriptableObject
{
    public bool isInvulnerable;
    public bool playerCanSwing;
}
