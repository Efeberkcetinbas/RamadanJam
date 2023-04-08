using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;

    public CinemachineVirtualCamera cm;
    public Transform cmCamera;

    public GameData gameData;

    Vector3 cameraInitialPosition;

    [Header("Shake Control")]
    public float shakeMagnitude = 0.05f;
    public float shakeTime = 0.5f;

    [SerializeField] private GameObject topViewCamera;

    public GameObject instructionPanel;

    bool isTopView;
    bool isInstruction;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnPassThroughDoors,PassWall);
        EventManager.AddHandler(GameEvent.OnFireActive,OnFire);
        EventManager.AddHandler(GameEvent.OnFireDeactive,NotFire);
        EventManager.AddHandler(GameEvent.OnSpeedUp,OnSpeedUp);
        EventManager.AddHandler(GameEvent.OnSpeedNormal,OnSpeedNormal);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnPassThroughDoors,PassWall);
        EventManager.RemoveHandler(GameEvent.OnFireActive,OnFire);
        EventManager.RemoveHandler(GameEvent.OnFireDeactive,NotFire);
        EventManager.RemoveHandler(GameEvent.OnSpeedUp,OnSpeedUp);
        EventManager.RemoveHandler(GameEvent.OnSpeedNormal,OnSpeedNormal);
    }

    void PassWall()
    {
        ShakeIt();
    }

    void OnFire()
    {
        ShakeIt();
        ChangeFieldOfView(50,1);
    }

    void NotFire()
    {
        ChangeFieldOfView(40,1);
    }

    void OnSpeedUp()
    {
        ShakeIt();
        ChangeFieldOfView(40,1);
    }

    void OnSpeedNormal()
    {
        ChangeFieldOfView(50,1);
    }


    

    

    
    public void ChangeFieldOfView(float fieldOfView, float duration = 1)
    {
        DOTween.To(() => cm.m_Lens.FieldOfView, x => cm.m_Lens.FieldOfView = x, fieldOfView, duration);
    }
   
    public void ResetCamera()
    {
        cm.m_Priority = 1;
    }

    private void Update() 
    {

        if(Input.GetKeyDown(KeyCode.R))
        {
            DOTween.KillAll();
            SceneManager.LoadScene(0);
            Time.timeScale=1f;
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            isInstruction=!isInstruction;
        }
        if(isInstruction){
            instructionPanel.SetActive(true);
            gameData.timerIsRunning = false;
        }

        if(!isInstruction){
            instructionPanel.SetActive(false);
            gameData.timerIsRunning=true;
        }

        if(Input.GetMouseButtonDown(1)){
            isTopView=!isTopView;
        }

        if(isTopView){
            topViewCamera.SetActive(true);
        }
        else{
            topViewCamera.SetActive(false);
        }


        
    }


    #region CameraShaker

    private void ShakeIt()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);

    }

    private void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermediatePosition = mainCamera.transform.position;
        cameraIntermediatePosition.x += cameraShakingOffsetX;
        cameraIntermediatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermediatePosition;
    }

    private void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
    }
    #endregion    

}
