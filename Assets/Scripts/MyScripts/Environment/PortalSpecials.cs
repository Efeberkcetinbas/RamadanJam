using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class PortalSpecials : Obstacable
{
    public GameObject coinPrefab;

    [SerializeField] private GameObject particleEffect;
    public GameData gameData;
    internal override void DoAction(PlayerTrigger player)
    {
        gameData.StarNumber++;
        EventManager.Broadcast(GameEvent.OnStarCollect);
        if(gameData.StarNumber==55)
        {
            EventManager.Broadcast(GameEvent.OnOpenPortal);
        }

        StartCoinMove(gameObject);
        Instantiate(particleEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
        
        
    }

    private void StartCoinMove(GameObject a)
    {
        GameObject coin=Instantiate(coinPrefab,a.transform.position,coinPrefab.transform.rotation);
        coin.transform.DOLocalJump(coin.transform.localPosition,1,1,1,false);
        coin.transform.DOScale(Vector3.zero,1.5f);
        coin.transform.GetChild(0).GetComponent<TextMeshPro>().text="+1 ";
        coin.transform.GetChild(0).GetComponent<TextMeshPro>().DOFade(0,1.5f).OnComplete(()=>coin.transform.GetChild(0).gameObject.SetActive(false));
        Destroy(coin,2);
    }
}
