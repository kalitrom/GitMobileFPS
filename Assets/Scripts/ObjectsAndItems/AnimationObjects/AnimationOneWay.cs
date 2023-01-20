using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOneWay : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void UseThisObject()
    {
        anim.SetBool("isOn", true);
    }
}
