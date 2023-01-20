using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    private bool doorForward;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void UseThisObject()
    {
        if (doorForward == true)
        {
            DoorForward();
        }
        else
            DoorBack();
        UISound.Playsound(UISound.Sound.DoorOpen_01);
    }

    public void DoorForward()
    {
        if (anim.GetBool("Door") == true)
        {
            anim.SetBool("Door", false);
            anim.SetBool("DoorBack", false);
        }
        else
        {
            anim.SetBool("Door", true);
            Invoke("ToggleAnimation", 0.5f);
        }
    }

    public void DoorBack()
    {
        if (anim.GetBool("DoorBack") == true)
        {
            anim.SetBool("DoorBack", false);
            anim.SetBool("Door", false);
        }
        else
        {
            anim.SetBool("DoorBack", true);
            Invoke("ToggleAnimation", 0.5f);
        }
    }

    private void ToggleAnimation()
    {
        if (doorForward == true)
        {
            anim.SetBool("DoorBack", true);
        }
        if (doorForward == false)
        {
            anim.SetBool("Door", true);
        }
    }

    public void DoorForwardBoolSwitch()
    {
        doorForward = !doorForward;
    }
}
