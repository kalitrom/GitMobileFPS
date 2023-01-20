using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryTrap : MonoBehaviour
{
    [SerializeField] private MessageHintType messageHintType;
    [SerializeField] private GameObject spikedWall;
    [SerializeField] private AudioSource audioSourceSpikedWall;
    [SerializeField] private List<GameObject> ceilingPeaks;

    private Message message;

    private void Start()
    {
        message = FindObjectOfType<Message>();
        TrapVisibility(false);
    }

    public void TrapTurnOn()
    {
        StartCoroutine(_TrapTurnOn());
    }

    IEnumerator _TrapTurnOn()
    {
        yield return new WaitForSeconds(2f);
        TrapVisibility(true);
        yield return new WaitForSeconds(1f);
        message.ShowHintMessage((int)messageHintType);
        spikedWall.GetComponent<AnimationOneWay>().UseThisObject();
        audioSourceSpikedWall.Play();
        foreach (GameObject x in ceilingPeaks)
        {
            yield return new WaitForSeconds(0.26f);
            x.GetComponent<AnimationOneWay>().UseThisObject();
            x.GetComponent<AudioSource>().Play();
        }
        StopAllCoroutines();
    }

    private void TrapVisibility(bool toggle)
    {
        spikedWall.SetActive(toggle);
        foreach (GameObject x in ceilingPeaks)
        {
            x.SetActive(toggle);
        }
    }
}
