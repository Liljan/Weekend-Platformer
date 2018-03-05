using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public uint damage;
    public uint speed;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnBecameInvisible()
    {
        PlayerEvents.Instance().InvokeDespawnShot(gameObject);
    }

    private void OnBecameVisible()
    {
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        rb2d.velocity = new Vector2(speed * Mathf.Cos(angle), speed * Mathf.Sin(angle));
    }
}
