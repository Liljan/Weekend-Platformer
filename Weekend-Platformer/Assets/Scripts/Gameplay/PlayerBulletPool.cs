using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour
{
    private static PlayerBulletPool instance;
    public string name;
    public GameObject Prefab;

    public int startSize = 10;
    private List<GameObject> instances;

    private void Awake()
    {
        instance = this;   
    }

    public static PlayerBulletPool Instance()
    {
        return instance;
    }

    // Use this for initialization
    void Start()
    {
        PlayerEvents.Instance().SpawnShot += SpawnBullet;
        PlayerEvents.Instance().DespawnShot += DespawnBullet;

        instances = new List<GameObject>();
        instances.Capacity = startSize;

        for (int i = 0; i < startSize; i++)
        {
            GameObject instance = Instantiate(Prefab);
            instance.SetActive(false);

            instances.Add(instance);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnBullet(Vector3 pos, Quaternion rot)
    {
        for (int i = 0; i < instances.Capacity; i++)
        {
            GameObject instance = instances[i];
            if (!instance.activeSelf)
            {
                instance.SetActive(true);
                instance.transform.position = pos;
                instance.transform.rotation = rot;
                return;
            }
        }
    }

    public void DespawnBullet(GameObject g)
    {
        for (int i = 0; i < instances.Capacity; i++)
        {
            GameObject instance = instances[i];
            if (instance == g)
            {
                instance.SetActive(false);
                return;
            }
        }
    }

}
