using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundData : MonoBehaviour
{
    private static UISoundData _i;

    public static UISoundData i
    {
        get
        {
            if (_i == null)
            {
                Debug.Log("Instantiate SoundDate on Scene");
                _i = Instantiate(Resources.Load<UISoundData>("UISoundData"));
            }
            return _i;
        }
    }

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public UISound.Sound sound;
        public AudioClip audioClip;
    }
}

