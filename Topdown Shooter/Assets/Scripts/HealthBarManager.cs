using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;

    void Start()
    {
        healthBar = GetComponent<Slider>();
        HPText = GetComponentInChildren<Text>();
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthBar.maxValue = maxHealth;
        HPText.text = healthBar.value + "/" + healthBar.maxValue;
    }

    public void SetCurrentHealth(int currentHealth)
    {
        healthBar.value = currentHealth;
        HPText.text = healthBar.value + "/" + healthBar.maxValue;
    }

    public void SubtractHealth(int damage)
    {
        healthBar.value -= damage;
        HPText.text = healthBar.value + "/" + healthBar.maxValue;
    }

}
