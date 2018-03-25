using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int health;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if(tag == "Enemy")
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(int d)
    {
        health--;
        health = Mathf.Max(0, health);
        PlayerEvents.Instance().InvokeUpdateHealth(health,maxHealth);

        if (health == 0)
            PlayerEvents.Instance().InvokeDeath();
    }
}
