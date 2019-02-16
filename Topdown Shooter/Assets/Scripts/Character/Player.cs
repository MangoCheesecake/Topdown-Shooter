using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Character
{
    HealthBarManager healthBar;
    public GameObject gameOver;

    #region Singleton
    public static Player instance;

	void Awake ()
	{
		instance = this;
	}

    #endregion

    void Start()
    {
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarManager>();
        SetHealth(0);
    }

    public override float TakeDamage(float damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        healthBar.SubtractHealth((int)damage);
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        return damage;
    }

    public void SetHealth(float additionalHealth)
    {
        healthBar.SetMaxHealth((int)maxHealth);
        healthBar.SetCurrentHealth((int)currentHealth);
    }


    public override void Die()
    {
        gameOver.SetActive(true);
        gameOver.transform.Find("GameOver Text").GetComponent<Text>().text = "You have died";
        base.Die();
	}
}
