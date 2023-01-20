using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScreen : MonoBehaviour
{
    Animator anim;
    [SerializeField] private GameObject damageScreenEffect;

    private void Awake()
    {
        anim = damageScreenEffect.GetComponent<Animator>();
    }

    public void ShowDamageSñreen()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetBool("isOn", true);
        Invoke("HideDamageScreen", 0.5f);
    }

    //In AnimationEvent
    public void HideDamageScreen()
    {
        anim.SetBool("isOn", false);
    }
}
