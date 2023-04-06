using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrigger : MonoBehaviour
{

    public EnemyListControl enemyListControl;
    public GameObject DeadEffect;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Sword"))
        {
            Debug.Log("ENEMY IS DEAD");
            Instantiate(DeadEffect,transform.position,Quaternion.identity);
            //Particle
            enemyListControl.Enemies.Add(gameObject);
            enemyListControl.StartCoroutine(enemyListControl.ActiveEnemy());
            gameObject.SetActive(false);
        }
    }

    

}
