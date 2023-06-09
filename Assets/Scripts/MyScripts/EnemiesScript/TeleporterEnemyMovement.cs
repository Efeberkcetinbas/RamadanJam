using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TeleporterEnemyMovement : MonoBehaviour, IEnemyMovement
{

    public List<Transform> Rooms=new List<Transform>();

    private int index;
    private int randomPos;
    
    private float timer;
    [SerializeField] private GameObject PortalEffect;

    [SerializeField] private int passedTimer;


    public GameData gameData;

    private void Start()
    {
        index=Rooms.Count;   
    }


    private void Update() 
    {
        if(!gameData.stopEnemies)
        {
            timer+=Time.deltaTime;
            if(timer>passedTimer)
            {
                CallCaroutine();
                timer=0;
            }
        }
    }



    private void CallCaroutine()
    {
        StartCoroutine(CallMove());
    }
    private IEnumerator CallMove()
    {
        RandomPos();
        //animator.SetBool("Travel",true);
        yield return new WaitForSeconds(1);
        //PlayParticleEffect();
        yield return new WaitForSeconds(2);
        transform.DOScale(new Vector3(0.1f,0.1f,0.1f),0.25f).OnComplete(()=>{
            Movement();
        });
    }
    public void Movement()
    {
        //Sadece sahnedeki groudlarin uzerinde olsun.
        transform.localPosition=Rooms[randomPos].transform.localPosition;
        //animator.SetBool("Travel",false);
        transform.DOScale(new Vector3(1,1,1),0.3f);
    }

    public void PlayParticleEffect()
    {
        Instantiate(PortalEffect,new Vector3(Rooms[randomPos].transform.localPosition.x,
        Rooms[randomPos].transform.localPosition.y+1,Rooms[randomPos].transform.localPosition.z),Rooms[randomPos].transform.localRotation);
    }

    

    private int RandomPos()
    {
        randomPos=Random.Range(0,index);
        return randomPos;
    }

    
}
