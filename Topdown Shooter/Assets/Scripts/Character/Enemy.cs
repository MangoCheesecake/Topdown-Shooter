using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


    public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float damage;

    public float attackResetTimer = 1f;
    public bool canAttack = true;

    public AIDestinationSetter aiDest;

    public GameObject damageBurst;

    void Start()
    {
        currentHealth = maxHealth;
        GameObject player;
        player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            aiDest.target = player.transform;
        }
    }

    public float TakeDamage(float damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        return damage;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && canAttack)
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage);

            canAttack = false;

            // Damge Burst
            GameObject dmgBurst = Instantiate(damageBurst, other.transform.position, other.transform.rotation);
            var dmgBurstMain = dmgBurst.GetComponent<ParticleSystem>().main;
            dmgBurstMain.startColor = new Color(0.46f, 0f, 0f, 1f);

            Invoke("ResetAttackFlag", attackResetTimer);
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    void ResetAttackFlag()
    {
        canAttack = true;
    }
}
