using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public GameData gameData;


    void Start()
    {
        gameData.RemainingTime=600;
        gameData.timerIsRunning = true;
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
                Debug.Log("Time has run out!");
                gameData.RemainingTime = 0;
                gameData.timerIsRunning = false;
                Time.timeScale = 0f;
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
