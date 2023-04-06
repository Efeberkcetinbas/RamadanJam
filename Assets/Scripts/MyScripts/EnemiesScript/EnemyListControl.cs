using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListControl : MonoBehaviour
{
    public List<GameObject> Enemies=new List<GameObject>();
    public IEnumerator ActiveEnemy()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < Enemies.Count; i++)
        {
            Enemies[i].SetActive(true);
        }
    }
}
