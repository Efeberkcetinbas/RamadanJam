using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public GameData gameData;

    private bool oneTime=false;
    void Start()
    {
        gameData.RemainingTime=900;
        
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnPlayerHurt,ScaleUpText);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnPlayerHurt,ScaleUpText);
    }

    void ScaleUpText()
    {
        timeText.transform.DOScale(new Vector3(1.5f,1.5f,1.5f),0.25f).OnComplete(()=>timeText.transform.DOScale(new Vector3(1,1,1),0.25f));
    }

    void Update()
    {
        if (gameData.timerIsRunning)
        {
            if (gameData.RemainingTime > 0)
            {
                gameData.RemainingTime -= Time.deltaTime;
                DisplayTime(gameData.RemainingTime);
                //O dan büyükse azaltıyor.
            }
            else
            {
                gameData.RemainingTime = 0;
                gameData.timerIsRunning = false;
                DisplayTime(gameData.RemainingTime);
                Time.timeScale = 0f;
                oneTime=true;
                if(oneTime)
                    EventManager.Broadcast(GameEvent.OnDeath);
                //bu durumda ise ana menuye dönücek.
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //60tan sonra dakikaya 1 ekliyor.

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //dakika saniye cinsinden gösteriyor.
    }
}
