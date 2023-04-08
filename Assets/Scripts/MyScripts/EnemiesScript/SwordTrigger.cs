using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrigger : MonoBehaviour
{

    public EnemyListControl enemyListControl;
    public GameObject DeadEffect;
    private bool inEnemyList=false;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Sword"))
        {
            Instantiate(DeadEffect,transform.position,Quaternion.identity);
            enemyListControl.deadSound.Play();
            //Particle
            if(!inEnemyList)
            {
                enemyListControl.Enemies.Add(gameObject);
                inEnemyList=true;
            }


            enemyListControl.StartCoroutine(enemyListControl.ActiveEnemy());
            gameObject.SetActive(false);
        }
    }

    

}
