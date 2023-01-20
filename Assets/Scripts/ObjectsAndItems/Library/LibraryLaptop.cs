using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryLaptop : MonoBehaviour
{
    [SerializeField] private CustomCamerasType customCamerasType;
    [SerializeField] private GameObject screenOn;
    private CustomCameras customCameras;

    private void Start()
    {
        screenOn.SetActive(false);
        customCameras = FindObjectOfType<CustomCameras>();
    }

    public void UseThisObject()
    {
        StartCoroutine(_UseThisObject());
    }

    IEnumerator _UseThisObject()
    {
        UISound.Playsound(UISound.Sound.OldComputer_01);
        yield return new WaitForSeconds(0.2f);
        screenOn.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        customCameras.DisablePlayerCameraEnableCustomCamera((int)customCamerasType);
        StopAllCoroutines();
    }
}
