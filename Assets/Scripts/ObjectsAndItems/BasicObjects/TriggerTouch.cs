using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTouch : MonoBehaviour
{
    [SerializeField] private MessageHintType messageHintType;
    [SerializeField] private ItemType itemType;
    [SerializeField] private int itemAmount;
    [SerializeField] private bool usedOnce;

    private Message message;
    private Inventory inventory;

    private void Start()
    {
        message = FindObjectOfType<Message>();
        inventory = FindObjectOfType<Inventory>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovementMobile>())
        {
            UseObjectAndShowHintMessage();
        }
    }

    private void UseObjectAndShowHintMessage()
    {
        if (messageHintType != 0)
        {
            if ((itemType == 0) || (itemType != 0) && (inventory.Items[(int)itemType] == itemAmount))
            {
                SendMessage("UseThisObject", SendMessageOptions.DontRequireReceiver);
                message.ShowHintMessage((int)messageHintType);
                UsedOnce();
            }
        }
    }

    private void UsedOnce()
    {
        if (usedOnce == true)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
