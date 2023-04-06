using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWall : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private GameManager gameManager;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnPassThroughDoors,OnPassThroughDoors);
        EventManager.AddHandler(GameEvent.OnNotPasThroughDoors,OnNotPasThroughDoors);
    }

    private void Start() 
    {
        gameManager=FindObjectOfType<GameManager>();
        meshRenderer=GetComponent<MeshRenderer>();
        
    }
    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnPassThroughDoors,OnPassThroughDoors);
        EventManager.RemoveHandler(GameEvent.OnNotPasThroughDoors,OnNotPasThroughDoors);
    }


    void OnPassThroughDoors()
    {
        meshRenderer.material=gameManager.SpecialMat;
    }

    void OnNotPasThroughDoors()
    {
        meshRenderer.material=gameManager.NormalMat;
    }
}
