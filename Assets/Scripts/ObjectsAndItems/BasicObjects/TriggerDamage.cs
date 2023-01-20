using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    private Character player;
    [SerializeField] private int damageToPlayer;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            player.TakeDamage(damageToPlayer);
        }
    }

}
