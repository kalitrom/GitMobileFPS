using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUsed : Interactable
{
    [SerializeField] private int itemAmount;
    [SerializeField] private ItemType itemType;
    [SerializeField] private bool removeItemAfterUse;
    [SerializeField] private MessageItemNeedType messageItemNeedType;
    [SerializeField] private MessageHintType messageHintType;

    private Message message;
    private Inventory inventory;

    private void Start()
    {
        message = FindObjectOfType<Message>();
        inventory = FindObjectOfType<Inventory>();
    }

    public override void OnIntercation()
    {
        UseObject();
    }

    private void UseObject()
    {
        if ((itemType == 0) || (inventory.Items[(int)itemType] == itemAmount))
        {
            SendMessage("UseThisObject", SendMessageOptions.DontRequireReceiver);
            ShowHintMessage();
            RemoveItem();
        }
        else
        {
            ShowItemNeedMessage();
        }
    }

    private void ShowItemNeedMessage()
    {
        if (messageItemNeedType != 0)
        {
            message.ShowItemNeedMessage((int)messageItemNeedType);
        }
    }

    private void ShowHintMessage()
    {
        if (messageHintType != 0)
        {
            message.ShowHintMessage((int)messageHintType);
        }
    }

    private void RemoveItem()
    {
        if (removeItemAfterUse == true)
        {
            inventory.RemoveItem((int)itemType);
        }
    }
}
