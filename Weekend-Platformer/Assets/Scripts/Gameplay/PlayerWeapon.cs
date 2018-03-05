using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
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

            Vector3 pos = shootPoint.position;
            Quaternion rot = shootPoint.rotation * Quaternion.Euler(0F, 0F, transform.localScale.x < 0F ? 180F : 0F);

            PlayerEvents.Instance().InvokeSpawnShot(pos, rot);
        }
        else
        {
            animator.SetBool("Shooting", false);
        }
    }
}
