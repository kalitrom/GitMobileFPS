using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryBooksHiddenElixir : MonoBehaviour
{
    [SerializeField] private bool moveBook;
    [SerializeField] private bool empty;
    [SerializeField] private Vector3 difference;

    float seconds;
    Vector3 begin;
    Vector3 end;

    private Collider _collider;

    void Start()
    {
        seconds = 1;

        begin = transform.position;
        end = begin + difference;
        _collider = GetComponent<Collider>();
    }

    void Update()
    {
        if (moveBook == true)
        {
            transform.position += difference * Time.deltaTime * seconds;
            transform.Rotate(0.2f, 0.2f, 0.3f);
        }
    }

    public void UseThisObject()
    {
        if (empty == false)
        {
            _collider.enabled = false;
            moveBook = true;
            RandomizeAndPlayBookSound("booksPre");
        }
    }

    public void StopMovingBooks()
    {
        if (moveBook == true)
        {
            moveBook = false;
            RandomizeAndPlayBookSound("booksDrop");
        }
    }

    private void RandomizeAndPlayBookSound(string soundType)
    {
        int random = Random.Range(0, 2);
        if (soundType == "booksPre")
        {
            if (random == 0)
            {
                UISound.Playsound(UISound.Sound.BookPre_01);
            }
            else
                UISound.Playsound(UISound.Sound.BookPre_02);
        }
        if (soundType == "booksDrop")
        {
            if (random == 0)
            {
                UISound.Playsound(UISound.Sound.Books_01);
            }
            else
                UISound.Playsound(UISound.Sound.Books_02);
        }
    }
}
