using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public event Action<Transform> FireDelegate;

    public Transform shootPoint;
    private Animator animator;

    private void Awake()
    {
        shootPoint = transform.FindChild("ShootPoint");
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Shoot"))
        {
            animator.SetBool("Shooting", true);
            FireDelegate.Invoke(shootPoint);
        }
        else
        {
            animator.SetBool("Shooting", false);
        }

    }
}
