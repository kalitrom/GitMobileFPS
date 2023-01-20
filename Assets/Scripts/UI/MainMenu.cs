using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int firstLevel;
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject uiMaintMenuLayer;

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
            uiMaintMenuLayer.SetActive(false);
        }
    }

    public void StartGame()
    {
        BlockButtons();
        SceneManager.LoadScene(firstLevel);
    }

    public void QuitGame()
    {
        BlockButtons();
        Application.Quit();
    }

    private void BlockButtons()
    {
        playButton.GetComponent<Button>().interactable = false;
        quitButton.GetComponent<Button>().interactable = false;
    }
}

            
