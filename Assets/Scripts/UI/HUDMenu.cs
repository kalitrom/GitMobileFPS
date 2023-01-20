using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HUDMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> allHud;
    [SerializeField] private List<GameObject> playModeHud;

    [Header("In work")]

    [SerializeField] private Button useButton;
    [SerializeField] private Button viewButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button medicKitButton;
    [SerializeField] private Button customCameraClostButton;
    [SerializeField] private Button itemFoundCloseButton;
    [SerializeField] private GameObject ItemPickupMessage;
    [SerializeField] private GameObject UIFader;

    private CustomCameras customCameras;
    private PlayerInteractionController playerInteractionController;
    private PlayerMovementMobile playerMovementMobile;
    private Player player;
    private Message message;
    private DamageScreen damageScreen;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int startMenuSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (startMenuSceneIndex != 0)
        {
            FindScripts();
            PlayModeHUD();
        }
        if (startMenuSceneIndex == 0)
            HideAllHUD();
    }

    private void FindScripts()
    {
        customCameras = FindObjectOfType<CustomCameras>();
        playerInteractionController = FindObjectOfType<PlayerInteractionController>();
        playerMovementMobile = FindObjectOfType<PlayerMovementMobile>();
        player = FindObjectOfType<Player>();
        message = FindObjectOfType<Message>();
        damageScreen = FindObjectOfType<DamageScreen>();
    }

    private void PlayModeHUD()
    {
        HideAllHUD();
        ShowPlayModeHUD();
    }

    private void HideAllHUD()
    {
        for (int i = 0; i < allHud.Count; i++)
        {
            allHud[i].SetActive(false);
        }
    }

    private void ShowPlayModeHUD()
    {
        for (int i = 0; i < playModeHud.Count; i++)
        {
            playModeHud[i].SetActive(true);
        }
    }

    public void _DisableCustomCameraUi()
    {
        customCameraClostButton.gameObject.SetActive(false);
        PlayModeHUD();
        customCameras.DisableCustomCameraEnablePlayerCamera();
    }

    public void EnableCustomCameraUi()
    {
        HideAllHUD();
        customCameraClostButton.gameObject.SetActive(true);
    }

    public void ActionButtonToggle(string buttonType)
    {
        useButton.gameObject.SetActive(false);
        viewButton.gameObject.SetActive(false);
        if (buttonType == "use")
        {
            useButton.gameObject.SetActive(true);
        }
        if (buttonType == "view")
        {
            viewButton.gameObject.SetActive(true);
        }
        if (buttonType == "hide")
        {
            return;
        }
    }

    public void ActionButton()
    {
        playerInteractionController.Interact();
        StartCoroutine(ActionButtonsPause());
    }

    private IEnumerator ActionButtonsPause()
    {
        ActionButtonToggle(false);
        yield return new WaitForSeconds(1.5f);
        ActionButtonToggle(true);
    }

    private void ActionButtonToggle(bool toggle)
    {
        viewButton.interactable = toggle;
        useButton.interactable = toggle;
    }

    public void ShowItemPickupMessageWindow()
    {
        itemFoundCloseButton.gameObject.SetActive(true);
        UIFader.SetActive(true);
        playerMovementMobile.SwitchPlayerCanMove();
    }

    public void CloseItemPickupMessageWindow()
    {
        itemFoundCloseButton.gameObject.SetActive(false);
        UIFader.SetActive(false);
        message.ReloadItemPickup();
        playerMovementMobile.SwitchPlayerCanMove();
    }
}