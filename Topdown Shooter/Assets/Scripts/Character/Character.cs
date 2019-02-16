using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float damage;


    void Start ()
    {
        currentHealth = maxHealth;
    }

    public virtual float TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        return damage;
    }

    public float DoDamage()
    {
        return damage;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
