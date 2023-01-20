using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject PlayerStartPoint;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int startMenuSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (startMenuSceneIndex != 0)
        {
            InstantiatePlayerToStartPoint();
        }
    }

    private void InstantiatePlayerToStartPoint()
    {
        Player = Instantiate(Player);
        PlayerStartPoint = FindObjectOfType<PlayerInstantiatePoint>().gameObject;
        Player.transform.position = PlayerStartPoint.transform.position;
        Player.transform.rotation = PlayerStartPoint.transform.rotation;
    }

}
