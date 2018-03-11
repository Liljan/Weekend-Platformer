using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool isTriggered;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        isTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered)
            return;

        if(collision.gameObject.tag == "Player")
        {
            LevelEvents.Instance().InvokeSetCheckpoint(transform);
            isTriggered = true;
            animator.SetTrigger("Triggered");
        }
    }
}
