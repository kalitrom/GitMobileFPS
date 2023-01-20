using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentilationRat : MonoBehaviour
{
    Animator anim;
    [SerializeField] private GameObject ratWithAnim;
    [SerializeField] private AudioSource ratAudio_01;

    private void Start()
    {
        anim = ratWithAnim.GetComponent<Animator>();
    }

    public void RatSaysHello()
    {
        anim.SetBool("isOn", true);
        ratAudio_01.Play();
    }

}
