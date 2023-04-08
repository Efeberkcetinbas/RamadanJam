using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class AutomaticDoor : DoorButtonControl
{
    [SerializeField] private int ID;

    [SerializeField] private GameObject leftDoor,rightDoor;

    [SerializeField] private float leftZ,leftOldZ,rightZ,rightOldZ,duration;

    internal override void OpenDoorButton(int id)
    {
        if(id==this.ID)
        {
            leftDoor.transform.DOLocalMoveZ(leftZ,duration);
            rightDoor.transform.DOLocalMoveZ(rightZ,duration);
        }
    }

    internal override void CloseDoorButton(int id)
    {
        if(id==this.ID)
        {
            leftDoor.transform.DOLocalMoveZ(leftOldZ,duration);
            rightDoor.transform.DOLocalMoveZ(rightOldZ,duration);
        }
    }
}
