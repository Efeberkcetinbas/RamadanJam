using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterEnemyTrigger : Obstacable
{
    public EnemyData enemyData;

    public TeleporterEnemyTrigger()
    {
        //interval=enemyData.shootingInterval;
        canStay=true;
    }
    internal override void DoAction(PlayerTrigger player)
    {
        Shoot();
    }

    private void Shoot()
    {
        if(enemyData.teleporterEnemyCanShoot)
        {
            Debug.Log("SHOOT SHOOT SHOOT");
            //Area Attack
        }
    }

}
