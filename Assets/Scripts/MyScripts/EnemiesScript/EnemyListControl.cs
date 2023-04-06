using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListControl : MonoBehaviour
{
    public List<GameObject> Enemies=new List<GameObject>();

    private float lifeTime;
    public IEnumerator ActiveEnemy()
    {
        lifeTime+=0.5f;
        yield return new WaitForSeconds(3);
        for (int i = 0; i < Enemies.Count; i++)
        {   yield return new WaitForSeconds(lifeTime);
            Enemies[i].SetActive(true);
        }
    }
}
