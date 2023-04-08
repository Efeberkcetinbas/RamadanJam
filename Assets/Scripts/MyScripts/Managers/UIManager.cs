using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject StopTime,ContinueTime,FireActive,FireDeActive,SpeedUp,SpeedNormal,OnDoor,OfDoor,ShieldActive,ShieldDeactive;

    public TextMeshProUGUI starCounter;

    public GameData gameData;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnFireActive,FireActiveC);
        EventManager.AddHandler(GameEvent.OnFireDeactive,FireDeActiveC);
        EventManager.AddHandler(GameEvent.OnTimeStop,StopTimeC);
        EventManager.AddHandler(GameEvent.OnTimeContinue,ContinueTimeC);
        EventManager.AddHandler(GameEvent.OnSpeedUp,SpeedUpC);
        EventManager.AddHandler(GameEvent.OnSpeedNormal,SpeedNormalC);
        EventManager.AddHandler(GameEvent.OnPassThroughDoors,OnDoorC);
        EventManager.AddHandler(GameEvent.OnNotPasThroughDoors,OffDoorC);
        EventManager.AddHandler(GameEvent.OnInvulnerable,ShieldActiveC);
        EventManager.AddHandler(GameEvent.OnVulnerable,ShieldDeactiveC);
        EventManager.AddHandler(GameEvent.OnStarCollect,UpdateUI);
        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnFireActive,FireActiveC);
        EventManager.RemoveHandler(GameEvent.OnFireDeactive,FireDeActiveC);
        EventManager.RemoveHandler(GameEvent.OnTimeStop,StopTimeC);
        EventManager.RemoveHandler(GameEvent.OnTimeContinue,ContinueTimeC);
        EventManager.RemoveHandler(GameEvent.OnSpeedUp,SpeedUpC);
        EventManager.RemoveHandler(GameEvent.OnSpeedNormal,SpeedNormalC);
        EventManager.RemoveHandler(GameEvent.OnPassThroughDoors,OnDoorC);
        EventManager.RemoveHandler(GameEvent.OnNotPasThroughDoors,OffDoorC);
        EventManager.RemoveHandler(GameEvent.OnInvulnerable,ShieldActiveC);
        EventManager.RemoveHandler(GameEvent.OnVulnerable,ShieldDeactiveC);
        EventManager.RemoveHandler(GameEvent.OnStarCollect,UpdateUI);
    }

    void UpdateUI()
    {
        starCounter.SetText(gameData.StarNumber +  " / 55".ToString());
    }

    void StopTimeC()
    {
        StopTime.SetActive(true);
        StartCoroutine(ActivityLoss(StopTime));
    }   

    void ContinueTimeC()
    {
        ContinueTime.SetActive(true);
        StartCoroutine(ActivityLoss(ContinueTime));
    }

    void FireActiveC()
    {
        FireActive.SetActive(true);
        StartCoroutine(ActivityLoss(FireActive));
    }

    void FireDeActiveC()
    {
        FireDeActive.SetActive(true);
        StartCoroutine(ActivityLoss(FireDeActive));
    }

    void SpeedUpC()
    {
        SpeedUp.SetActive(true);
        StartCoroutine(ActivityLoss(SpeedUp));
    }

    void SpeedNormalC()
    {
        SpeedNormal.SetActive(true);
        StartCoroutine(ActivityLoss(SpeedNormal));
    }

    void OnDoorC()
    {
        OnDoor.SetActive(true);
        StartCoroutine(ActivityLoss(OnDoor));
    }

    void OffDoorC()
    {
        OfDoor.SetActive(true);
        StartCoroutine(ActivityLoss(OfDoor));
    }

    void ShieldActiveC()
    {
        ShieldActive.SetActive(true);
        StartCoroutine(ActivityLoss(ShieldActive));
    }

    void ShieldDeactiveC()
    {
        ShieldDeactive.SetActive(true);
        StartCoroutine(ActivityLoss(ShieldDeactive));
    }

    private IEnumerator ActivityLoss(GameObject gameObject)
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }



}
