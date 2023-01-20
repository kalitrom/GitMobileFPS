using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private MessageItemPickupType messageItemPickupType;

    private Message message;
    private Inventory inventory;

    private void Start()
    {
        message = FindObjectOfType<Message>();
        inventory = FindObjectOfType<Inventory>();
    }

    public override void OnIntercation()
    {
        AddItemToInventory();
        ShowItemPickupMessage();
        Destroy(gameObject);
    }

    private void ShowItemPickupMessage()
    {
        message.ShowItemPickupMessage((int)messageItemPickupType);
    }

    private void AddItemToInventory()
    {
        inventory.AddItemToInventory((int)itemType);
    }
}
