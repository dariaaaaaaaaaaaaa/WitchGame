using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public HealthBar healthBar; 
   


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

    }


    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
