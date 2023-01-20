using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryEyeMonsterBoneCollider : MonoBehaviour
{
    private LibraryEyeMonster libraryEyeMonster;

    private void Start()
    {
        libraryEyeMonster = FindObjectOfType<LibraryEyeMonster>();
        if (libraryEyeMonster == null)
        {
            Debug.Log("Can't find libraryEyeMonster");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            libraryEyeMonster.PlayerDamage();
        }
    }
}
