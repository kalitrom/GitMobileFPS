using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryEyeMonsterTrail : MonoBehaviour
{
    [SerializeField] private Animator eyeMonsterTrailAnimator;

    void Awake()
    {
        eyeMonsterTrailAnimator = GetComponent<Animator>();
        if(eyeMonsterTrailAnimator == null)
        {
            Debug.Log("Can't find eyeMonsterTrailAnimator");
        }
    }

    public void AttackAndReturn()
    {
        float returnTime = 4.5f;
        eyeMonsterTrailAnimator.SetBool("Attack", true);
        Invoke("Return", returnTime);
    }

    private void Return()
    {
        eyeMonsterTrailAnimator.SetBool("Attack", false);
    }

}
