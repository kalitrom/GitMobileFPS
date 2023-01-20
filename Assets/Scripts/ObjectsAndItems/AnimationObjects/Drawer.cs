using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void UseThisObject()
    {
        if (anim.GetBool("isOpen") == true)
        {
            anim.SetBool("isOpen", false);
        }
        else
        {
            anim.SetBool("isOpen", true);
        }
        UISound.Playsound(UISound.Sound.DrawerOpen_01);
    }
}
