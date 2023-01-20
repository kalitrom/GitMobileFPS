using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;

    private HealthBar healthBar;

    private void Awake()
    {
        health = maxHealth;
        healthBar = FindObjectOfType<HealthBar>();
        if (healthBar == null)
        {
            Debug.Log("Can't find healthBar");
        }
    }

    public virtual void TakeDamage (int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

    }

    public virtual void SetHealth()
    {
        healthBar.UpdateHealth(health);
    }
}
