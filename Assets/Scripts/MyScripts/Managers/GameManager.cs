using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public PlayerData playerData;

    public Material SpecialMat,NormalMat;

    public GameObject GameOverPanel,SuccessPanel,Portal;
    private void Start() 
    {
        InvokeRepeating("CallDice",0,50);

        Reset();
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnDeath,GameOver);
        EventManager.AddHandler(GameEvent.OnSuccess,OpenSuccess);
        EventManager.AddHandler(GameEvent.OnOpenPortal,OpenPortal);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnDeath,GameOver);
        EventManager.RemoveHandler(GameEvent.OnSuccess,OpenSuccess);
        EventManager.RemoveHandler(GameEvent.OnOpenPortal,OpenPortal);
    }

    private void CallDice()
    {
        EventManager.Broadcast(GameEvent.OnCallDice);
    }

    private void Reset()
    {
        gameData.stopEnemies=false;
        playerData.isInvulnerable=false;
        GameOverPanel.SetActive(false);
        SuccessPanel.SetActive(false);
        Portal.SetActive(false);
        gameData.StarNumber=0;
    }

    private void GameOver()
    {
        GameOverPanel.SetActive(true);
    }


    private void OpenSuccess()
    {
        gameData.timerIsRunning=false;
        SuccessPanel.SetActive(true);
    }

    private void OpenPortal()
    {
        Portal.SetActive(true);
    }
}
