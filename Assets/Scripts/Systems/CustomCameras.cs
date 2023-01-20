using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCameras : MonoBehaviour
{
    [SerializeField] private List<GameObject> customCameras;
    private GameObject PlayerCamera;
    private CharacterController characterController;
    private PlayerMovementMobile playerMovementMobile;
    private HUDMenu hUDMenu;

    void Start()
    {
        PlayerInteractionController _PlayerCamera = GameObject.FindObjectOfType<PlayerInteractionController>();
        PlayerCamera = _PlayerCamera.gameObject;
        HideAllCustomCameras();
        characterController = FindObjectOfType<CharacterController>();
        playerMovementMobile = FindObjectOfType<PlayerMovementMobile>();
        hUDMenu = FindObjectOfType<HUDMenu>();
    }

    public void HideAllCustomCameras()
    {
        foreach (GameObject obj in customCameras)
        {
            obj.SetActive(false);
        }
    }

    public void DisablePlayerCameraEnableCustomCamera(int camera_id)
    {
        playerMovementMobile.SwitchPlayerCanMove();
        PlayerCamera.SetActive(false);
        customCameras[camera_id].SetActive(true);
        hUDMenu.EnableCustomCameraUi();
    }

    public void DisableCustomCameraEnablePlayerCamera()
    {
        HideAllCustomCameras();
        PlayerCamera.SetActive(true);
        playerMovementMobile.SwitchPlayerCanMove();
    }
}
