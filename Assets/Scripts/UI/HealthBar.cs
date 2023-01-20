using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    public void UpdateHealth(int health)
    {
        healthText.text = (health +"%").ToString();
    }
}
