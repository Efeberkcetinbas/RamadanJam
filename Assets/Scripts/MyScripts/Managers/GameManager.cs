using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameData gameData;

    public Material SpecialMat,NormalMat;

    public GameObject GameOverPanel,SuccessPanel;
    private void Start() 
    {
        InvokeRepeating("CallDice",0,30);

        Reset();
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnDeath,GameOver);
        EventManager.AddHandler(GameEvent.OnSuccess,OpenSuccess);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnDeath,GameOver);
        EventManager.RemoveHandler(GameEvent.OnSuccess,OpenSuccess);
    }

    private void CallDice()
    {
        EventManager.Broadcast(GameEvent.OnCallDice);
    }

    private void Reset()
    {
        gameData.stopEnemies=false;
        GameOverPanel.SetActive(false);
        SuccessPanel.SetActive(false);
    }

    private void GameOver()
    {
        GameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void OpenSuccess()
    {
        SuccessPanel.SetActive(true);
    }
}
