using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptLocator : MonoBehaviour
{
    [Header("Menu Scripts")]
    [SerializeField] private HUDMenu hUDMenu;
    [SerializeField] private Message message;
    [SerializeField] private Inventory inventory;
    [SerializeField] private DamageScreen damageScreen;
    [SerializeField] private HealthBar healthBar;

    [Header("Scene Scripts")]
    [SerializeField] private PlayerMovementMobile playerMovementMobile;
    [SerializeField] private PlayerInteractionController playerInteractionController;
    [SerializeField] private CameraBobbing cameraBobbing;
    [SerializeField] private CustomCameras customCameras;

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
        FindMenuScripts();
        CheckMenuScripts();

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int menuScene = 0;
        if (sceneIndex != menuScene)
        {
            FindSceneScripts();
            CheckSceneScripts();
        }
    }

    private void FindMenuScripts()
    {
        hUDMenu = FindObjectOfType<HUDMenu>();
        message = FindObjectOfType<Message>();
        inventory = FindObjectOfType<Inventory>();
        damageScreen = FindObjectOfType<DamageScreen>();
        healthBar = FindObjectOfType<HealthBar>();
    }

    private void FindSceneScripts()
    {
        playerMovementMobile = FindObjectOfType<PlayerMovementMobile>();
        playerInteractionController = FindObjectOfType<PlayerInteractionController>();
        cameraBobbing = FindObjectOfType<CameraBobbing>();
        customCameras = FindObjectOfType<CustomCameras>();
    }

    private void CheckMenuScripts()
    {
        MonoBehaviour[] MenuScripts = { hUDMenu, message, inventory, damageScreen, healthBar };
        foreach (var menuScript in MenuScripts)
        {
            if (menuScript == null)
            {
                Debug.Log("Не могу найти один из скриптов меню в ScriptLocator");
            }
        }
    }

    private void CheckSceneScripts()
    {
        MonoBehaviour[] SceneScripts = { playerMovementMobile, playerInteractionController, cameraBobbing, customCameras };
        foreach (var sceneScript in SceneScripts)
        {
            if (sceneScript == null)
            {
                Debug.Log("Не могу найти один из скриптов на сцене в ScriptLocator");
            }
        }
    }

}
