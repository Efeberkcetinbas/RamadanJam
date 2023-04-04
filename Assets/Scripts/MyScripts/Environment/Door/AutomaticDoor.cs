using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class AutomaticDoor : DoorButtonControl
{
    [SerializeField] private int ID;
    internal override void OpenDoorButton(int id)
    {
        if(id==this.ID)
        {
            Debug.Log("DOOR IS OPEN");
            transform.DOLocalMoveY(3,0.3f);
        }
    }

    internal override void CloseDoorButton(int id)
    {
        if(id==this.ID)
        {
            transform.DOLocalMoveY(0,0.3f);
            Debug.Log("DOOR IS CLOSED");
        }
    }
}
