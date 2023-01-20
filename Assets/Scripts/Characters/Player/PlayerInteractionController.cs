using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractionController : MonoBehaviour
{
    [Header("Interaction settings")]

    [SerializeField] private float maxDistance = 10;
    [SerializeField] private LayerMask interactableLayer;

    [Header("UI settings")]

    private Interactable currentInteractable;
    private HUDMenu hUDMenu;

    private void Start()
    {
        hUDMenu = FindObjectOfType<HUDMenu>();
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance))
        {
            if (hit.transform.gameObject.layer == 7)
            {
                currentInteractable = hit.collider.GetComponent<Interactable>();
            }
            else
                currentInteractable = null;
        }
        else currentInteractable = null;

        if (currentInteractable != null)
        {
            if (hit.collider.GetComponent<Viewable>() != null)
            {
                hUDMenu.ActionButtonToggle("view");
            }
            else
                hUDMenu.ActionButtonToggle("use");

        }
        if (currentInteractable == null)
        {
            hUDMenu.ActionButtonToggle("hide");
        }
    }

    public void Interact()
    {
        if (currentInteractable) currentInteractable.OnIntercation();
    }

}
