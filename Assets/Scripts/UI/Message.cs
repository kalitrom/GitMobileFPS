using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using TMPro;

public class Message : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;

    [SerializeField] private List<string> messageItemPickUpInfo;
    [SerializeField] private GameObject messageItemPickupImageContainer;
    [SerializeField] List<GameObject> messageItemPickupImage;

    [SerializeField] List<string> messageItemNeedInfo;
    [SerializeField] List<string> messageHintInfo;

    private HUDMenu hUDMenu;

    private void Awake()
    {
        ReloadItemPickup();
        hUDMenu = FindObjectOfType<HUDMenu>();
    }

    public void ReloadItemPickup()
    {
        CloseMessage();
        messageItemPickupImageContainer.SetActive(false);
        foreach (var y in messageItemPickupImage)
        {
            y.SetActive(false);
        }
    }

    public void CloseMessage()
    {
        messageText.gameObject.SetActive(false);
    }

    public void ShowItemPickupMessage(int messageTypeInt)
    {
        ReloadItemPickup();
        hUDMenu.ShowItemPickupMessageWindow();
        messageText.gameObject.SetActive(true);
        messageText.text = messageItemPickUpInfo[messageTypeInt];
        messageItemPickupImageContainer.SetActive(true);
        messageItemPickupImage[messageTypeInt].SetActive(true);
        UISound.Playsound(UISound.Sound.Collect_01);
    }

    public void ShowItemNeedMessage(int messageTypeInt)
    {
        CloseMessage();
        messageText.gameObject.SetActive(true);
        messageText.text = messageItemNeedInfo[messageTypeInt];
        Invoke("CloseMessage", 2.0f);
        UISound.Playsound(UISound.Sound.Collect_02);
    }

    public void ShowHintMessage(int messageTypeInt)
    {
        ReloadItemPickup();
        messageText.gameObject.SetActive(true);
        messageText.text = messageHintInfo[messageTypeInt];
        Invoke("CloseMessage", 2.0f);
        UISound.Playsound(UISound.Sound.Collect_02);
    }
}
