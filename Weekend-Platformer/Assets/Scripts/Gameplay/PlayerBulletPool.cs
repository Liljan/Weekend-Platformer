using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour {

    public string name;
    public GameObject Prefab;

    public int startSize = 10;
    private List<GameObject> instances;

    private void Awake()
    {
        FindObjectOfType<PlayerWeapon>().FireDelegate += SpawnBullet;
    }

    // Use this for initialization
    void Start () {

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
	void Update () {
		
	}

    private void SpawnBullet(Transform t)
    {
        for (int i = 0; i < instances.Capacity; i++)
        {
            GameObject instance = instances[i];
            if (!instance.activeSelf)
            {
                instance.SetActive(true);
                instance.transform.position = t.position;
                instance.transform.rotation = t.rotation;
                return;
            }
        }
    }
}
