using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject StopTime,ContinueTime,SwordActive,SwordDeActive,SpeedUp,SpeedNormal,OnDoor,OfDoor,ShieldActive,ShieldDeactive;


    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnSwordActive,SwordActiveC);
        EventManager.AddHandler(GameEvent.OnSwordDeactive,SwordDeActiveC);
        EventManager.AddHandler(GameEvent.OnTimeStop,StopTimeC);
        EventManager.AddHandler(GameEvent.OnTimeContinue,ContinueTimeC);
        EventManager.AddHandler(GameEvent.OnSpeedUp,SpeedUpC);
        EventManager.AddHandler(GameEvent.OnSpeedNormal,SpeedNormalC);
        EventManager.AddHandler(GameEvent.OnPassThroughDoors,OnDoorC);
        EventManager.AddHandler(GameEvent.OnNotPasThroughDoors,OffDoorC);
        EventManager.AddHandler(GameEvent.OnInvulnerable,ShieldActiveC);
        EventManager.AddHandler(GameEvent.OnVulnerable,ShieldDeactiveC);
        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnSwordActive,SwordActiveC);
        EventManager.RemoveHandler(GameEvent.OnSwordDeactive,SwordDeActiveC);
        EventManager.RemoveHandler(GameEvent.OnTimeStop,StopTimeC);
        EventManager.RemoveHandler(GameEvent.OnTimeContinue,ContinueTimeC);
        EventManager.RemoveHandler(GameEvent.OnSpeedUp,SpeedUpC);
        EventManager.RemoveHandler(GameEvent.OnSpeedNormal,SpeedNormalC);
        EventManager.RemoveHandler(GameEvent.OnPassThroughDoors,OnDoorC);
        EventManager.RemoveHandler(GameEvent.OnNotPasThroughDoors,OffDoorC);
        EventManager.RemoveHandler(GameEvent.OnInvulnerable,ShieldActiveC);
        EventManager.RemoveHandler(GameEvent.OnVulnerable,ShieldDeactiveC);
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

    void SwordActiveC()
    {
        SwordActive.SetActive(true);
        StartCoroutine(ActivityLoss(SwordActive));
    }

    void SwordDeActiveC()
    {
        SwordDeActive.SetActive(true);
        StartCoroutine(ActivityLoss(SwordDeActive));
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
