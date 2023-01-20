using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private DamageScreen damageScreen;
    
    private void Start()
    {
        damageScreen = FindObjectOfType<DamageScreen>();
    }

    public override void TakeDamage(int ammount)
    {
        base.TakeDamage(ammount);
        damageScreen.ShowDamageSñreen();
        SetHealth();
        RandomizeAndPlayDamageSound();
    }

    public override void SetHealth()
    {
        base.SetHealth();
    }

    private void RandomizeAndPlayDamageSound()
    {
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            UISound.Playsound(UISound.Sound.PlayerDamage_01);
        }
        else
            UISound.Playsound(UISound.Sound.PlayerDamage_02);
    }
}
