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
    //[SerializeField] private GameObject PortalEffect;

    [SerializeField] private int passedTimer;


    public GameData gameData;

    //private Animator animator;
    private void Start()
    {
        //animator=GetComponent<Animator>();
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
        PlayParticleEffect();
        yield return new WaitForSeconds(2);
        transform.DOScale(new Vector3(0.1f,0.1f,0.1f),0.25f).OnComplete(()=>{
            Movement();
        });
    }
    public void Movement()
    {
        //Sadece sahnedeki groudlarin uzerinde olsun.
        transform.position=Rooms[randomPos].transform.position;
        //animator.SetBool("Travel",false);
        transform.DOScale(new Vector3(1,1,1),0.3f);
    }

    public void PlayParticleEffect()
    {
        //Instantiate(PortalEffect,new Vector3(Rooms[randomPos].transform.position.x,
        //Rooms[randomPos].transform.position.y+1,Rooms[randomPos].transform.position.z),Rooms[randomPos].transform.rotation);
    }

    

    private int RandomPos()
    {
        //Bazen surekli ayni konum uzerinde donuyor. Random yerine index arttir.
        /*if(index<Rooms.Count-1)
        {
            index++;
        }
        else
        {
            index=0;
        }*/
        randomPos=Random.Range(0,index);
        //randomPos=index;
        Debug.Log(randomPos);
        return randomPos;
    }

    
}
