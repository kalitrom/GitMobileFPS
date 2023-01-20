using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UISound
{
    public enum Sound
    {
        BookPre_01,
        BookPre_02,
        Books_01,
        Books_02,
        Collect_01,
        Collect_02,
        Fail,
        DoorClosed_01,
        DoorOpen_01,
        DrawerOpen_01,
        Drink_01,
        EyeMonsterAmbient_01,
        EyeMonsterAttack_01,
        EyeMonsterAttack_02,
        FillTheCup_01,
        OldComputer_01,
        Rat_01,
        SecretDoor_01,
        VentilationOpen_01,
        PlayerDamage_01,
        PlayerDamage_02
    }

    public static void Playsound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (UISoundData.SoundAudioClip soundAudioClip in UISoundData.i.soundAudioClipArray)
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
}
