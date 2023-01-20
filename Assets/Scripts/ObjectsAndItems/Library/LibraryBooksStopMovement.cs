using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryBooksStopMovement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("through_player"))
        {
            other.gameObject.transform.parent.GetComponent<LibraryBooksHiddenElixir>().StopMovingBooks();
        }
    }
}
