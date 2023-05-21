using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    public float changeAnimation;
    public float timeIdleBreak;


    public void SetMotionValue(float value)
    {
        GetComponent<Animator>().SetFloat("MoveSpeed", value);
        if (value == 0)
        {
            changeAnimation -= Time.deltaTime;
            if (changeAnimation < 0)
            {
                GetComponent<Animator>().SetTrigger("Break");
                changeAnimation = 10f;
            }

        }
    }
    public void SetDamageTrigger()
    {
        GetComponent<Animator>().SetTrigger("Damage");
    }
    public void SetJumpTrigger()
    {
        GetComponent<Animator>().SetTrigger("Jump");
    }

}
