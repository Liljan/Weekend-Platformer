using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health = 1;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void TakeDamage(int d)
    {
        health -= d;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        // Temporary
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if(tag == "Player")
        {
            TakeDamage(10);
        }
        else if(tag == "PlayerBullet")
        {
            TakeDamage(1);
        }
    }
}
