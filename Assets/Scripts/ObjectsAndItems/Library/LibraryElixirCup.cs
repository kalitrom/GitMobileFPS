using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryElixirCup : MonoBehaviour
{
    [SerializeField] private GameObject elixirCup;
    [SerializeField] private GameObject elixirMixed;
    [SerializeField] private GameObject emptyTubes;
    [SerializeField] private ParticleSystem particlesCup;

    [SerializeField] private bool isReadyToDrink;
    private LibraryTrap libraryTrap;
    private PlayerScale playerScale;

    private Animator otherAnimator;

    private void Start()
    {
        otherAnimator = elixirMixed.GetComponent<Animator>();
        ElixirAndTubesVisibility(false);
        libraryTrap = FindObjectOfType<LibraryTrap>();
        if (libraryTrap == null)
        {
            Debug.Log("Can't find libraryTrap");
        }
        playerScale = FindObjectOfType<PlayerScale>();
        if (playerScale == null)
        {
            Debug.Log("Can't find playerScale");
        }
        particlesCup.Stop();
    }

    public void UseThisObject()
    {
        if (isReadyToDrink == true)
        {
            DrinkTheElixir();
        }
        else
        {
            isReadyToDrink = true;
            FillTheCupWithElixir();
        }
    }

    private void FillTheCupWithElixir()
    {
        ElixirAndTubesVisibility(true);
        BowlUsabilityToggle();
        libraryTrap.TrapTurnOn();
        Invoke("BowlUsabilityToggle", 3.0f);
        particlesCup.Play();
        UISound.Playsound(UISound.Sound.FillTheCup_01);
    }

    private void DrinkTheElixir()
    {
        otherAnimator.SetBool("isDrinking", true);
        BowlUsabilityToggle();
        particlesCup.Stop();
        Invoke("_ReducePlayerSize", 3.0f);
        UISound.Playsound(UISound.Sound.Drink_01);
    }

    private void _ReducePlayerSize()
    {
        playerScale.ReducePlayerSize();
    }

    private void BowlUsabilityToggle()
    {
        elixirCup.GetComponent<BoxCollider>().enabled = !elixirCup.GetComponent<BoxCollider>().enabled;
    }

    private void ElixirAndTubesVisibility(bool toggle)
    {
        elixirMixed.SetActive(toggle);
        emptyTubes.SetActive(toggle);
    }
}
