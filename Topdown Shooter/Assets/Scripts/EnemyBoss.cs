using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public GameObject gameOver;

    void Start()
    {
        currentHealth = maxHealth;
        GameObject player;
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            aiDest.target = player.transform;
        }
        gameOver = player.GetComponent<Player>().gameOver;
    }

    public override void Die()
    {
        gameOver.SetActive(true);
        base.Die();
    }
}
