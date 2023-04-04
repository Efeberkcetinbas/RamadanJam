using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy Data",menuName ="Data/EnemyData",order =1)]
public class EnemyData : ScriptableObject
{
    public bool teleporterEnemyCanShoot=false;
    public float shootingInterval=0.25f;
}
