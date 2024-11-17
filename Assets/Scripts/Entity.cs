using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public HealthBar healthBar;
    public float maxHealth;
    public float currentHealth;
    public float attack;
    public bool isDead;
    public Shoot shootComponent;


    public void DealDamage(float _damage)
    {
        currentHealth -= _damage;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentHealth <= 0f)
        {
            isDead = true;
            gameObject.SetActive(false);
        }

        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    public void Reset()
    {
        healthBar.Reset();
        isDead = false;
        currentHealth = maxHealth;
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        shootComponent = GetComponent<Shoot>();
    }
}