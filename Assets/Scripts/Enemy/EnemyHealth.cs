using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealt;

    void Start()
    {
        currentHealt = maxHealth;    
    }

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;

        //animator.SetTrigger("Hurt");

        if(currentHealt <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Enemy died");

        //animator.SetBool("IsDead", true);

        Destroy(gameObject);
    }
}
