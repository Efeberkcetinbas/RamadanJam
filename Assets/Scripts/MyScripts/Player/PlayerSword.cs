using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float nextFireTime=0f;

    public PlayerData playerData;

    private void Update() 
    {
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime>0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            animator.SetBool("hit1",false);
        }
        
        if(Time.time>nextFireTime)
        {
            if(Input.GetMouseButtonDown(0) && playerData.playerCanSwing)
            {
                OnClick();
            }
        }
        
    }

    void OnClick()
    {
        animator.SetBool("hit1",true);
    
    }
    
}
