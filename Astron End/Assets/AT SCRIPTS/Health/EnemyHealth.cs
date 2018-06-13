using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float startingHealth = 50f;
    public float currentHealth;

    bool isDead = false;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            isDead = true;
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
