using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    private Transform target;
    private Camera camera;
    private Transform yTransform;

    public float smoothness;
    private float offset;

    private void Awake()
    {
        camera = GetComponent<Camera>();

        PlayerEvents.Instance().SpawnPlayer += SetTarget;
        PlayerEvents.Instance().TouchPlatform += SetHeight;
    }

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!target)
            return;

        float x, y, z;

        x = target.position.x;
        y = target.position.y;
        z = transform.position.z;

        if (yTransform)
        {
            y = yTransform.position.y + offset;
        }

        Vector2 lerp = Vector2.MoveTowards(transform.position, new Vector2(x, y), smoothness * Time.deltaTime);

        float finalX = x;
        float finalY = lerp.y;
        float finalZ = z;

        camera.transform.position = new Vector3(finalX, finalY, finalZ);
	}

    public void SetTarget(Transform t)
    {
        target = t;
    }

    public void SetHeight(Transform t, float o)
    {
        yTransform = t;
        offset = o;
    }
}
