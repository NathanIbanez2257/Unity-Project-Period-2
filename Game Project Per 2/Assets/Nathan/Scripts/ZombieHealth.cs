using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    [Header("Health Setttings")]
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;

    private void Start()
    {
        maxHealth = health;
    }



    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
